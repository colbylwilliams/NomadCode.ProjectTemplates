namespace ${SolutionName}
{
	public static partial class Settings
	{
		#region Visible Settings

		public static string VersionNumber
		{
			get { return StringForKey (SettingsKeys.VersionNumber); }
#if __ANDROID__
            set { SetSetting (SettingsKeys.VersionNumber, value); }
#endif
		}

		public static string BuildNumber
		{
			get { return StringForKey (SettingsKeys.BuildNumber); }
#if __ANDROID__
            set { SetSetting (SettingsKeys.BuildNumber, value); }
#endif
		}

		public static string GitHash => StringForKey (SettingsKeys.GitCommitHash);

		public static string UserReferenceKey
		{
			get { return StringForKey (SettingsKeys.UserReferenceKey); }
			set { SetSetting (SettingsKeys.UserReferenceKey, value ?? "anonymous"); }
		}

		#endregion


		#region Hidden Settings


		#endregion


		#region Debug Setting
#if DEBUG


#endif
		#endregion

	}
}
