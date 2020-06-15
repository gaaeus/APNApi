using APN.Model;
using APN.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APN.DBContexts
{
    /// <summary>
    /// Database context class for the Audio Class
    /// </summary>
    public class AudioDBContext : BaseDBContext
    {
        public AudioDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Audio Records from the database
        /// </summary>
        public async Task<List<Audio>> GetAudios(uint noteId)
        {
            var list = new List<Audio>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM audio WHERE NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["AudioId"]),
                                                               BasicGeoposition.CoordinatesParentType.Audio,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("AudioCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("AudioCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("AudioCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("AudioCoordinateDescription")));

                        list.Add(new Audio()
                        {
                            AudioId = Convert.ToUInt32(reader["AudioId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            AudioNo = reader["AudioNo"].ToString(),
                            AudioName = reader["AudioName"].ToString(),
                            AudioDescription = reader["AudioDescription"].ToString(),
                            AudioPath = reader["AudioPath"].ToString(),
                            AudioCoordinates = coordinates,
                            AudioDatetime = Convert.ToDateTime(reader["AudioDatetime"]),
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
        /// Retrieves a single Audio Record from the database
        /// </summary>
        public async Task<Audio> GetAudio(uint audioId, uint noteId)
        {
            Audio audioRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Audio WHERE AudioId = @audioId AND NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);
                cmd.Parameters.AddWithValue("@audioId", audioId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["AudioId"]),
                                                               BasicGeoposition.CoordinatesParentType.Audio,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("AudioCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("AudioCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("AudioCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("AudioCoordinateDescription")));

                        audioRecord = new Audio()
                        {
                            AudioId = Convert.ToUInt32(reader["AudioId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            AudioNo = reader["AudioNo"].ToString(),
                            AudioName = reader["AudioName"].ToString(),
                            AudioDescription = reader["AudioDescription"].ToString(),
                            AudioPath = reader["AudioPath"].ToString(),
                            AudioCoordinates = coordinates,
                            AudioDatetime = Convert.ToDateTime(reader["AudioDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return audioRecord;
        }
    }
}
