using System;
using Android.App;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;

namespace AppLeanMaint.Helpers
{
	public static class UI
	{
		public static void ShowPersistentMessage(Activity oActivity, int resId, Action<View> clickHandler)
		{
			ShowPersistentMessage(oActivity, resId, Snackbar.LengthIndefinite, clickHandler);
		}

		public static void ShowPersistentMessage(Activity oActivity, int resId, int duration, Action<View> clickHandler)
		{
			View oRoot = oActivity.FindViewById(Android.Resource.Id.Content);

			Snackbar.Make(oRoot, resId, duration).SetAction("OK", clickHandler).Show();
		}

		public static void ShowProgressMessage(Activity oActivity, int resId)
		{
			Toast.MakeText(oActivity, resId, ToastLength.Long).Show();
		}
	}
}