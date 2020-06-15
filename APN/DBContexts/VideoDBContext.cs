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
    /// Database context class for the Video Class
    /// </summary>
    public class VideoDBContext : BaseDBContext
    {
        public VideoDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Video Records from the database
        /// </summary>
        public async Task<List<Video>> GetVideos(uint noteId)
        {
            var list = new List<Video>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM video WHERE NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["VideoId"]),
                                                               BasicGeoposition.CoordinatesParentType.Video,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("VideoCoordinateDescription")));

                        list.Add(new Video()
                        {
                            VideoId = Convert.ToUInt32(reader["VideoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            VideoNo = reader["VideoNo"].ToString(),
                            VideoName = reader["VideoName"].ToString(),
                            VideoDescription = reader["VideoDescription"].ToString(),
                            VideoPath = reader["VideoPath"].ToString(),
                            VideoCoordinates = coordinates,
                            VideoDatetime = Convert.ToDateTime(reader["VideoDatetime"]),
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
        /// Retrieves a single Video Record from the database
        /// </summary>
        public async Task<Video> GetVideo(uint videoId, uint noteId)
        {
            Video videoRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Video WHERE VideoId = @videoId AND NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);
                cmd.Parameters.AddWithValue("@videoId", videoId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["VideoId"]),
                                                               BasicGeoposition.CoordinatesParentType.Video,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("VideoCoordinateDescription")));

                        videoRecord = new Video()
                        {
                            VideoId = Convert.ToUInt32(reader["VideoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            VideoNo = reader["VideoNo"].ToString(),
                            VideoName = reader["VideoName"].ToString(),
                            VideoDescription = reader["VideoDescription"].ToString(),
                            VideoPath = reader["VideoPath"].ToString(),
                            VideoCoordinates = coordinates,
                            VideoDatetime = Convert.ToDateTime(reader["VideoDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return videoRecord;
        }
    }
}
