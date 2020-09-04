using System;
using Android.App;
using Android.Support.Design.Widget;
using Android.Views;

namespace AppLeanMaint.Helpers
{
	public static class UI
	{
		public static void ShowSnackbar(Activity oActivity, int resId, Action<View> clickHandler)
		{
			ShowSnackbar(oActivity, resId, Snackbar.LengthIndefinite, clickHandler);
		}

		public static void ShowSnackbar(Activity oActivity, int resId, int duration, Action<View> clickHandler)
		{
			View oRoot = oActivity.FindViewById(Android.Resource.Id.Content);

			Snackbar.Make(oRoot, resId, duration).SetAction("OK", clickHandler).Show();
		}
	}
}