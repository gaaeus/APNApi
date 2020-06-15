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
    /// Database context class for the Image Class
    /// </summary>
    public class ImageDBContext : BaseDBContext
    {
        public ImageDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Image Records from the database
        /// </summary>
        public async Task<List<Image>> GetImages(uint noteId)
        {
            var list = new List<Image>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM image WHERE NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["ImageId"]),
                                                               BasicGeoposition.CoordinatesParentType.Image,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("ImageCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("ImageCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("ImageCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("ImageCoordinateDescription")));

                        list.Add(new Image()
                        {
                            ImageId = Convert.ToUInt32(reader["ImageId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            ImageNo = reader["ImageNo"].ToString(),
                            ImageName = reader["ImageName"].ToString(),
                            ImageDescription = reader["ImageDescription"].ToString(),
                            ImagePath = reader["ImagePath"].ToString(),
                            ImageCoordinates = coordinates,
                            ImageDatetime = Convert.ToDateTime(reader["ImageDatetime"]),
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
        /// Retrieves a single Image Record from the database
        /// </summary>
        public async Task<Image> GetImage(uint imageId, uint noteId)
        {
            Image imageRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Image WHERE ImageId = @imageId AND NoteId = @noteId", conn);
                cmd.Parameters.AddWithValue("@noteId", noteId);
                cmd.Parameters.AddWithValue("@imageId", imageId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToUInt32(reader["ImageId"]),
                                                               BasicGeoposition.CoordinatesParentType.Image,
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("ImageCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("ImageCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("ImageCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("ImageCoordinateDescription")));

                        imageRecord = new Image()
                        {
                            ImageId = Convert.ToUInt32(reader["ImageId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            ImageNo = reader["ImageNo"].ToString(),
                            ImageName = reader["ImageName"].ToString(),
                            ImageDescription = reader["ImageDescription"].ToString(),
                            ImagePath = reader["ImagePath"].ToString(),
                            ImageCoordinates = coordinates,
                            ImageDatetime = Convert.ToDateTime(reader["ImageDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return imageRecord;
        }
    }
}
