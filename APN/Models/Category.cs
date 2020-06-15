using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace APN.Model
{
    /// <summary>
    /// Categories to be used by the system. These are the standard divisors of information to be used to process information
    /// </summary>
    [Serializable]
    public class Category : IDisposable
    {
        #region Properties

		public uint? CategoryId { get; set; }
		public string CategoryIdentifier { get; set; }
		public string CategoryName { get; set; }
		public string CategoryDescription { get; set; }
		public uint? ParentCategoryId { get; set; }
		public ICollection<Category> SubCategories { get; set; }

		public uint CreatedBy { get; set; }
		public DateTime CreatedAt { get; set; }
		public uint? ModifiedBy { get; set; }
		public DateTime? ModifiedAt { get; set; }
		
		private bool _disposed = false;
		
        #endregion

        #region Constructor

        public Category() { }

        public Category(uint? categoryId, string categoryIdentifier, string categoryName, string categoryDescription, uint? parentCategoryId, ICollection<Category> subCategories, uint createdBy, DateTime createdAt, uint? modifiedBy, DateTime? modifiedAt)
        {
            CategoryId = categoryId;
            CategoryIdentifier = categoryIdentifier;
            CategoryName = categoryName;
            CategoryDescription = categoryDescription;
            ParentCategoryId = parentCategoryId;
            SubCategories = subCategories;
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
