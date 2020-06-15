using APN.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APN.Model
{
    /// <summary>
    /// Class to store photo data attacheable to a note
    /// </summary>
    [Serializable]
    public class Photo : IDisposable
    {
        #region Properties

        public uint? PhotoId { get; set; }
        public uint NoteId { get; set; }
        [MaxLength(12)]
        public string PhotoNo { get; set; }
		public string PhotoName  { get; set; }
		public string PhotoDescription  { get; set; }
        [MaxLength(1024)]
        public string PhotoPath { get; set; }
        public BasicGeoposition PhotoCoordinates { get; set; }
		public DateTime PhotoDatetime { get; set; }

		public uint CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public uint? ModifiedBy { get; set; }
		public DateTime? ModifiedAt { get; set; }
		
		private bool _disposed = false;

        #endregion

        #region Constructor

        public Photo() { }

        public Photo(uint? photoId, uint noteId, string photoNo, string photoName, string photoDescription, string photoPath, BasicGeoposition photoCoordinates, DateTime photoDatetime, uint createdBy, DateTime createdAt, uint? modifiedBy, DateTime? modifiedAt)
        {
            PhotoId = photoId;
            NoteId = noteId;
			PhotoNo = photoNo;
			PhotoName = photoName;
			PhotoDescription = photoDescription;
			PhotoPath = photoPath;
            PhotoCoordinates = photoCoordinates;
            PhotoDatetime = photoDatetime;
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
