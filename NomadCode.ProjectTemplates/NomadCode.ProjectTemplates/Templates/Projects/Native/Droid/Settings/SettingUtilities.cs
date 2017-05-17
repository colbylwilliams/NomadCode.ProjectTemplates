using System;

using Android.App;
using Android.Preferences;

namespace ${SolutionName}
{
    public static partial class Settings
    {

        const string zero = "0";

        #region Utilities


        public static void RegisterDefaultSettings () { }


        public static void SetSetting (string key, string value)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context))
            using (var sharedPreferencesEditor = sharedPreferences.Edit ())
            {
                sharedPreferencesEditor.PutString (key, value);
                sharedPreferencesEditor.Commit ();
            }
        }


        public static void SetSetting (string key, bool value)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context))
            using (var sharedPreferencesEditor = sharedPreferences.Edit ())
            {
                sharedPreferencesEditor.PutBoolean (key, value);
                sharedPreferencesEditor.Commit ();
            }
        }


        public static void SetSetting (string key, int value, bool asString = true)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context))
            using (var sharedPreferencesEditor = sharedPreferences.Edit ())
            {
                if (asString)
                {
                    sharedPreferencesEditor.PutString (key, value.ToString ());
                }
                else
                {
                    sharedPreferencesEditor.PutInt (key, value);
                }
                sharedPreferencesEditor.Commit ();
            }
        }


        public static void SetSetting (string key, DateTime value)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context))
            using (var sharedPreferencesEditor = sharedPreferences.Edit ())
            {
                sharedPreferencesEditor.PutString (key, value.ToString ());
                sharedPreferencesEditor.Commit ();
            }
        }



        public static int Int32ForKey (string key, bool fromString = true)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context))
            {
                if (fromString)
                {
                    return int.Parse (sharedPreferences.GetString (key, zero));
                }
                return Convert.ToInt32 (sharedPreferences.GetInt (key, 0));
            }
        }


        public static bool BoolForKey (string key)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context))
                return sharedPreferences.GetBoolean (key, false);
        }


        public static string StringForKey (string key)
        {
            using (var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences (Application.Context))
                return sharedPreferences.GetString (key, string.Empty);
        }


        public static DateTime DateTimeForKey (string key)
        {
            return DateTime.TryParse (StringForKey (key), out DateTime outDateTime) ? outDateTime : DateTime.MinValue;
        }


        #endregion
    }
}