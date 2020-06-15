using APN.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace APN.Model
{
    /// <summary>
    /// Class to store image data attacheable to a note
    /// </summary>
    [Serializable]
    public class Image : IDisposable
    {
        #region Properties

        public uint? ImageId { get; set; }
        public uint NoteId { get; set; }
        [MaxLength(12)]
        public string ImageNo { get; set; }
		public string ImageName  { get; set; }
		public string ImageDescription  { get; set; }
        [MaxLength(1024)]
        public string ImagePath { get; set; }
        public BasicGeoposition ImageCoordinates { get; set; }
        public DateTime ImageDatetime { get; set; }

		public uint CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public uint? ModifiedBy { get; set; }
		public DateTime? ModifiedAt { get; set; }
		
		private bool _disposed = false;

        #endregion

        #region Constructor

        public Image() { }

        public Image(uint? imageId, uint noteId, string imageNo, string imageName, string imageDescription, string imagePath, BasicGeoposition imageCoordinates, DateTime imageDatetime, uint createdBy, DateTime createdAt, uint? modifiedBy, DateTime? modifiedAt)
        {
            ImageId = imageId;
            NoteId = noteId;
			ImageNo = imageNo;
			ImageName = imageName;
			ImageDescription = imageDescription;
			ImagePath = imagePath;
            ImageCoordinates = imageCoordinates;
            ImageDatetime = imageDatetime;
			CreatedBy = createdBy;
			CreatedAt = createdAt;
			ModifiedBy = modifiedBy;
			ModifiedAt = modifiedAt;
        }

        #endregion
		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing) 
				{
					// free managed resources
				}
				// free native resources if there are any.
			}
			// Indicate that the instance has been disposed.
			_disposed = true;
		}
    }
}
