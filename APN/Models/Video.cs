using APN.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APN.Model
{
    /// <summary>
    /// Class to store video data attacheable to a note
    /// </summary>
    [Serializable]
    public class Video : IDisposable
    {
        #region Properties

        public uint? VideoId { get; set; }
        public uint NoteId { get; set; }
        [MaxLength(12)]
        public string VideoNo { get; set; }
		public string VideoName  { get; set; }
		public string VideoDescription  { get; set; }
        [MaxLength(1024)]
        public string VideoPath { get; set; }
        public BasicGeoposition VideoCoordinates { get; set; }
		public DateTime VideoDatetime { get; set; }

		public uint CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public uint? ModifiedBy { get; set; }
		public DateTime? ModifiedAt { get; set; }
		
		private bool _disposed = false;

        #endregion

        #region Constructor

        public Video() { }

        public Video(uint? videoId, uint noteId, string videoNo, string videoName, string videoDescription, string videoPath, BasicGeoposition videoCoordinates, DateTime videoDatetime, uint createdBy, DateTime createdAt, uint? modifiedBy, DateTime? modifiedAt)
        {
            VideoId = videoId;
            NoteId = noteId;
			VideoNo = videoNo;
			VideoName = videoName;
			VideoDescription = videoDescription;
			VideoPath = videoPath;
            VideoCoordinates = videoCoordinates;
            VideoDatetime = videoDatetime;
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
