using System;
using System.Security.Permissions;

namespace APN.Models
{
    public class BasicGeoposition
    {
        /// <summary>
        /// GeoPosition parent type
        /// </summary>
        [Serializable]
        public enum CoordinatesParentType
        {
            Note = 0,
            Photo = 1,
            Video = 2,
            Image = 3,
            Audio = 4
        }

        /// <summary>
        /// Identifier for the object owning the coordinates
        /// </summary>
        public uint ParentId { get; set; }

        public CoordinatesParentType ParentType { get; set; }

        /// <summary>
        /// The latitude of the geographic position.
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// The longitude of the geographic position.
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// The altitude of the geographic position.
        /// </summary>
        public double? Altitude { get; set; }

        /// <summary>
        /// The optional description for the location
        /// </summary>
        public string Description { get; set; }

        public BasicGeoposition() {}

        public BasicGeoposition(uint parentId, CoordinatesParentType parentType, double latitude, double longitude, double altitude, string description = "")
        {
            ParentId = parentId;
            ParentType = parentType;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            Description = description;
        }
    }
}
