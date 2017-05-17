﻿using System;
using System.IO;

using Foundation;

using static Foundation.NSUserDefaults;

namespace ${SolutionName}
{

	public static partial class Settings
	{


		#region Utilities


		const string _settingsDir = "Settings";
		const string _bundleName = "bundle";
		const string _rootPlist = "Root.plist";
		const string _key = "Key";
		const string _defaultValue = "DefaultValue";
		const string _preferenceSpecifiers = "PreferenceSpecifiers";


		public static void RegisterDefaultSettings ()
		{
			var path = Path.Combine (NSBundle.MainBundle.PathForResource (_settingsDir, _bundleName), _rootPlist);

			using (NSString keyString = new NSString (_key), defaultString = new NSString (_defaultValue), preferenceSpecifiers = new NSString (_preferenceSpecifiers))
			using (var settings = NSDictionary.FromFile (path))
			using (var preferences = (NSArray)settings.ValueForKey (preferenceSpecifiers))
			using (var registrationDictionary = new NSMutableDictionary ())
			{
				for (nuint i = 0; i < preferences.Count; i++)
					using (var prefSpecification = preferences.GetItem<NSDictionary> (i))
					using (var key = (NSString)prefSpecification.ValueForKey (keyString))
						if (key != null)
							using (var def = prefSpecification.ValueForKey (defaultString))
								if (def != null)
									registrationDictionary.SetValueForKey (def, key);

				StandardUserDefaults.RegisterDefaults (registrationDictionary);

				Synchronize ();
			}
		}


		public static void Synchronize () => StandardUserDefaults.Synchronize ();

		public static void SetSetting (string key, string value) => StandardUserDefaults.SetString (value, key);

		public static void SetSetting (string key, bool value) => StandardUserDefaults.SetBool (value, key);

		public static void SetSetting (string key, int value) => StandardUserDefaults.SetInt (value, key);

		public static void SetSetting (string key, DateTime value) => SetSetting (key, value.ToString ());

		public static int Int32ForKey (string key) => Convert.ToInt32 (StandardUserDefaults.IntForKey (key));

		public static bool BoolForKey (string key) => StandardUserDefaults.BoolForKey (key);

		public static string StringForKey (string key) => StandardUserDefaults.StringForKey (key);

		public static DateTime DateTimeForKey (string key)
		{
			DateTime outDateTime;

			return DateTime.TryParse (StandardUserDefaults.StringForKey (key), out outDateTime) ? outDateTime : DateTime.MinValue;
		}

		#endregion
	}
}