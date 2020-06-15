using APN.DBContexts;
using APN.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APN.Model
{
    /// <summary>
    /// Class to store audio data attacheable to a note
    /// </summary>
    [Serializable]
    public class Audio : IDisposable
    {
        #region Properties

        public uint? AudioId { get; set; }
        public uint NoteId { get; set; }
        [MaxLength(12)]
        public string AudioNo { get; set; }
		public string AudioName  { get; set; }
		public string AudioDescription  { get; set; }
        [MaxLength(1024)]
        public string AudioPath { get; set; }
        public BasicGeoposition AudioCoordinates { get; set; }
        public DateTime AudioDatetime { get; set; }

		public uint CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public uint? ModifiedBy { get; set; }
		public DateTime? ModifiedAt { get; set; }
		
		private bool _disposed = false;

        #endregion

        #region Constructor

        public Audio() { }

        public Audio(uint? audioId, uint noteId, string audioNo, string audioName, string audioDescription, string audioPath, BasicGeoposition audioCoordinates, DateTime audioDatetime, uint createdBy, DateTime createdAt, uint? modifiedBy, DateTime? modifiedAt)
        {
            AudioId = audioId;
            NoteId = noteId;
			AudioNo = audioNo;
			AudioName = audioName;
			AudioDescription = audioDescription;
			AudioPath = audioPath;
            AudioCoordinates = audioCoordinates;
            AudioDatetime = audioDatetime;
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
