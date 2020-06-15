using System;

namespace PolEX.Model
{
    /// <summary>
    /// Main settings for the application
    /// </summary>
    [Serializable]
    public class AppSettings
    {
        #region Properties

  //      [Column("MAX_VIDEO_KB")]
  //      public UInt64 MAX_VIDEO_KB { get; set; }

		//[Column("MAX_AUDIO_KB")]
  //      public UInt64 MAX_AUDIO_KB { get; set; }
		
		//[Column("MAX_PHOTO_KB")]
  //      public UInt64 MAX_PHOTO_KB { get; set; }
		
		//[Column("MAX_PHOTO_DIMENSIONS")]
  //      public tuple<int,int> MAX_PHOTO_DIMENSIONS { get; set; }
		
		//[Column("MAX_IMAGE_KB")]
  //      public UInt64 MAX_IMAGE_KB { get; set; }
		
  //      [Column("USE_COORDINATES")]
  //      public Boolean USE_COORDINATES { get; set; }

  //      [Column("SEND_ANONYMOUS")]
  //      public Boolean SEND_ANONYMOUS { get; set; }

  //      [Column("SERVER_URL")]
  //      public String SERVER_URL { get; set; }

  //      [Column("SERVER_PORT")]
  //      public String SERVER_PORT { get; set; }

  //      [Column("SERVER_CONNECTION_TIMEOUT")]
  //      public UInt32 SERVER_CONNECTION_TIMEOUT { get; set; }

  //      [Column("USE_SSL")]
        public Boolean USE_SSL { get; set; }

        #endregion

        #region Constructor

        public AppSettings() { }

        #endregion
    }
}
