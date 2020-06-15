using APN.Models;
using System;
using System.Collections.Generic;

namespace APN.Model
{
    /// <summary>
    /// Note classifications
    /// </summary>
    [Serializable]
    public enum NoteClassification
    {
        Question = 0,
        Information = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        Emergency = 5,
        Other = 6
    }

    /// <summary>
    /// Notes class to be stored and sent by the application
    /// </summary>
    [Serializable]
    public class Note : IDisposable
    {
        #region Properties

        public uint? NoteId { get; set; }
        public uint CategoryId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public BasicGeoposition NoteCoordinates { get; set; }
        public DateTime NoteDatetime { get; set; }
        public string APP_GUID { get; set; }
        public NoteClassification NoteClassification { get; set; }

        public ICollection<Image> Imagecollection { get; set; }
        public ICollection<Video> Videocollection { get; set; }
        public ICollection<Photo> Photocollection { get; set; }
        public ICollection<Audio> Audiocollection { get; set; }

        public uint CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public uint? ModifiedBy { get; set; }
		public DateTime? ModifiedAt { get; set; }
		
		private bool _disposed = false;
		
        #endregion

        #region Constructor

        public Note() { }
        
        public Note(uint? noteId, uint categoryId, string noteTitle, string noteContent, BasicGeoposition noteCoordinates, DateTime noteDatetime, string APP_GUID, NoteClassification noteClassification, ICollection<Image> imageCollection, ICollection<Video> videoCollection, ICollection<Photo> photocollection, ICollection<Audio> audiocollection, uint createdBy, DateTime createdAt, uint? modifiedBy, DateTime? modifiedAt)
        {
            NoteId = noteId;
            CategoryId = categoryId;
            NoteTitle = noteTitle;
            NoteContent = noteContent;
            NoteCoordinates = noteCoordinates;
            NoteDatetime = noteDatetime;
            this.APP_GUID = APP_GUID;
            NoteClassification = noteClassification;
            Imagecollection = imageCollection;
            Videocollection = videoCollection;
            Photocollection = photocollection;
            Audiocollection = audiocollection;
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
