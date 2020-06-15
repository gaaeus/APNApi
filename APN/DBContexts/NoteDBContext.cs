using APN.Model;
using APN.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APN.DBContexts
{
    /// <summary>
    /// Database context class for the Note Class
    /// </summary>
    public class NoteDBContext : BaseDBContext
    {
        public NoteDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Note Records from the database
        /// </summary>
        public async Task<List<Note>> GetNotes()
        {
            var list = new List<Note>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM note", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["NoteId"]),
                                                               BasicGeoposition.CoordinatesParentType.Note,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateAlt")));

                        list.Add(new Note()
                        {
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            CategoryId = Convert.ToUInt32(reader["CategoryId"]),
                            NoteClassification = (NoteClassification)Convert.ToUInt32(reader["NoteClassification"]),
                            NoteTitle = reader["NoteTitle"].ToString(),
                            APP_GUID = reader["APP_GUID"].ToString(),
                            NoteContent = reader["NoteContent"].ToString(),
                            NoteCoordinates = coordinates,
                            NoteDatetime = ConversionHelpers.SafeGetDateTime(reader, reader.GetOrdinal("NoteDatetime")),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = ConversionHelpers.SafeGetDateTime(reader, reader.GetOrdinal("ModifiedAt")),
                            ModifiedBy = ConversionHelpers.SafeGetInt(reader, reader.GetOrdinal("ModifiedBy")),
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Retrieves a single Note Record from the database
        /// </summary>
        /// <param name="id">Note identifier</param>
        public async Task<Note> GetNote(int noteId)
        {
            Note noteRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM note WHERE NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["NoteId"]),
                                                               BasicGeoposition.CoordinatesParentType.Note,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateAlt")));

                        noteRecord = new Note()
                        {
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            CategoryId = Convert.ToUInt32(reader["CategoryId"]),
                            NoteClassification = (NoteClassification)Convert.ToUInt32(reader["NoteClassification"]),
                            NoteTitle = reader["NoteTitle"].ToString(),
                            APP_GUID = reader["APP_GUID"].ToString(),
                            NoteContent = reader["NoteContent"].ToString(),
                            NoteCoordinates = coordinates,
                            NoteDatetime = ConversionHelpers.SafeGetDateTime(reader, reader.GetOrdinal("NoteDatetime")),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = ConversionHelpers.SafeGetDateTime(reader, reader.GetOrdinal("ModifiedAt")),
                            ModifiedBy = ConversionHelpers.SafeGetInt(reader, reader.GetOrdinal("ModifiedBy")),
                        };
                    }
                }
            }
            return noteRecord;
        }

        /// <summary>
        /// Creates a note in the database
        /// </summary>
        /// <param name="newNote"></param>
        /// <returns></returns>
        public async Task<int> CreateNote(Note newNote)
        {
            int newId = -1;

            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    var strSQL = @"INSERT INTO note (
                                                    CategoryId,
                                                    NoteClassification,
                                                    NoteTitle,
                                                    APP_GUID,
                                                    NoteContent,
                                                    NoteCoordinateLat,
                                                    NoteCoordinateLng,
                                                    NoteCoordinateAlt,
                                                    NoteCoordinateDescription,
                                                    NoteDatetime,
                                                    CreatedBy,
                                                    CreatedAt,
                                                    ModifiedBy,
                                                    ModifiedAt
                                                )
                                                VALUES (
                                                    @CategoryId,
                                                    @NoteClassification,
                                                    @NoteTitle,
                                                    @APP_GUID,
                                                    @NoteContent,
                                                    @NoteCoordinateLat,
                                                    @NoteCoordinateLng,
                                                    @NoteCoordinateAlt,
                                                    @NoteCoordinateDescription,
                                                    @NoteDatetime,
                                                    @CreatedBy,
                                                    NOW(),
                                                    @ModifiedBy,
                                                    NOW()
                                                );
                                                SELECT LAST_INSERT_ID();";

                    var cmd = new MySqlCommand(strSQL, conn);

                    cmd.Parameters.AddWithValue("@CategoryId", newNote.CategoryId);
                    cmd.Parameters.AddWithValue("@NoteClassification", newNote.NoteClassification);
                    cmd.Parameters.AddWithValue("@NoteTitle", newNote.NoteTitle);
                    cmd.Parameters.AddWithValue("@APP_GUID", newNote.APP_GUID);
                    cmd.Parameters.AddWithValue("@NoteContent", newNote.NoteContent);
                    cmd.Parameters.AddWithValue("@NoteCoordinateLat", newNote.NoteCoordinates.Latitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateLng", newNote.NoteCoordinates.Longitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateAlt", newNote.NoteCoordinates.Altitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateDescription", newNote.NoteCoordinates.Description);
                    cmd.Parameters.AddWithValue("@NoteDatetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CreatedBy", 100);
                    cmd.Parameters.AddWithValue("@ModifiedBy", 100);

                    cmd.Prepare();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            newId = Convert.ToInt32(reader["LAST_INSERT_ID()"]);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
            return newId;
        }

        public async Task UpdateNote(Note note)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    var strSQL = @"UPDATE note SET
                                    CategoryId = @CategoryId,
                                    NoteClassification = @NoteClassification,
                                    NoteTitle = @NoteTitle,
                                    APP_GUID = @APP_GUID,,
                                    NoteContent = @NoteContent,
                                    NoteCoordinateLat = @NoteCoordinateLat,
                                    NoteCoordinateLng = @NoteCoordinateLng,
                                    NoteCoordinateAlt = @NoteCoordinateAlt,
                                    NoteCoordinateDescription = @NoteCoordinateDescription,
                                    NoteDatetime = @NoteDatetime,
                                    ModifiedBy = @ModifiedBy,
                                    ModifiedAt = NOW()
                                   WHERE NoteId = @NoteId); ";

                    var cmd = new MySqlCommand(strSQL, conn);

                    cmd.Parameters.AddWithValue("@CategoryId", note.CategoryId);
                    cmd.Parameters.AddWithValue("@NoteClassification", note.NoteClassification);
                    cmd.Parameters.AddWithValue("@NoteTitle", note.NoteTitle);
                    cmd.Parameters.AddWithValue("@APP_GUID", note.APP_GUID);
                    cmd.Parameters.AddWithValue("@NoteContent", note.NoteContent);
                    cmd.Parameters.AddWithValue("@NoteCoordinateLat", note.NoteCoordinates.Latitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateLng", note.NoteCoordinates.Longitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateAlt", note.NoteCoordinates.Altitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateDescription", note.NoteCoordinates.Description);
                    cmd.Parameters.AddWithValue("@NoteDatetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ModifiedBy", 100);
                    cmd.Parameters.AddWithValue("@NoteId", note.NoteId);

                    cmd.Prepare();

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
