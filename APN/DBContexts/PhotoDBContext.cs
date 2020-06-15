using APN.Model;
using APN.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace APN.DBContexts
{
    /// <summary>
    /// Database context class for the Photo Class
    /// </summary>
    public class PhotoDBContext : BaseDBContext
    {
        public PhotoDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Photo Records from the database
        /// </summary>
        public async Task<List<Photo>> GetPhotos(uint noteId)
        {
            var list = new List<Photo>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM photo WHERE NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["PhotoId"]),
                                                               BasicGeoposition.CoordinatesParentType.Photo,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("PhotoCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("PhotoCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("PhotoCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("PhotoCoordinateDescription")));

                        list.Add(new Photo()
                        {
                            PhotoId = Convert.ToUInt32(reader["PhotoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            PhotoNo = reader["PhotoNo"].ToString(),
                            PhotoName = reader["PhotoName"].ToString(),
                            PhotoDescription = reader["PhotoDescription"].ToString(),
                            PhotoPath = reader["PhotoPath"].ToString(),
                            PhotoCoordinates = coordinates,
                            PhotoDatetime = Convert.ToDateTime(reader["PhotoDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Retrieves a single Photo Record from the database
        /// </summary>
        public async Task<Photo> GetPhoto(uint videoId, uint noteId)
        {
            Photo photoRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Photo WHERE PhotoId = @photoId AND NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@photoId", videoId);
                cmd.Parameters.AddWithValue("@noteId", noteId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {                    
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["PhotoId"]),
                                                               BasicGeoposition.CoordinatesParentType.Photo,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("PhotoCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("PhotoCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("PhotoCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("PhotoCoordinateDescription")));

                        photoRecord = new Photo()
                        {
                            PhotoId = Convert.ToUInt32(reader["PhotoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            PhotoNo = reader["PhotoNo"].ToString(),
                            PhotoName = reader["PhotoName"].ToString(),
                            PhotoDescription = reader["PhotoDescription"].ToString(),
                            PhotoPath = reader["PhotoPath"].ToString(),
                            PhotoCoordinates = coordinates,
                            PhotoDatetime = Convert.ToDateTime(reader["PhotoDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return photoRecord;
        }
    }
}
