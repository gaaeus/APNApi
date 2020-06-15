using System;

namespace APN.UserManagement
{
	[Serializable]
	public class Profile : IDisposable
	{
		public uint? ProfileId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public uint CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public uint? ModifiedBy { get; set; }
		public DateTime? ModifiedAt { get; set; }
		
		private bool _disposed = false;
		
		public Profile() {}
		
		public Profile(uint? profileId, string name, string description, uint createdBy, DateTime createdAt, uint? modifiedBy, DateTime? modifiedAt)
		{
			ProfileId = profileId;
			Name = name;
			Description = description;
			CreatedBy = createdBy;
			CreatedAt = createdAt;
			ModifiedBy = modifiedBy;
			ModifiedAt = modifiedAt;
		}
		
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