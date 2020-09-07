using System;
using System.Diagnostics;
using Android.App;
using Android.Content;

namespace AppLeanMaint.Helpers
{
	public static class Exceptions
	{
		public static void LogUnhandledException(Exception exception)
		{
			try
			{
				const string errorFileName = "Fatal.log";
				var libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // iOS: Environment.SpecialFolder.Resources
				var errorFilePath = System.IO.Path.Combine(libraryPath, errorFileName);
				var errorMessage = String.Format("Time: {0}\r\nError: Unhandled Exception\r\n{1}",
				DateTime.Now, exception.ToString());
				System.IO.File.WriteAllText(errorFilePath, errorMessage);

				// Log to Android Device Logging.
				Android.Util.Log.Error("Crash Report", errorMessage);
			}
			catch
			{
				// just suppress any error logging exceptions
			}
		}

		/// <summary>
		// If there is an unhandled exception, the exception information is diplayed 
		// on screen the next time the app is started (only in debug configuration)
		/// </summary>
		public static bool DisplayCrashReport(Context oContext)
		{
			bool bRet = false;
			const string errorFilename = "Fatal.log";
			var libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			var errorFilePath = System.IO.Path.Combine(libraryPath, errorFilename);

			if (System.IO.File.Exists(errorFilePath))
			{
				bRet = true;
				var errorText = System.IO.File.ReadAllText(errorFilePath);
				new AlertDialog.Builder(oContext)
						.SetPositiveButton("Clear", (sender, args) =>
						{
							System.IO.File.Delete(errorFilePath);
						})
						.SetNegativeButton("Close", (sender, args) =>
						{
							// User pressed Close.
						})
						.SetMessage(errorText)
						.SetTitle("Crash Report")
						.Show();
			}

			return (bRet);
		}
	}
}