using System;
using Android.App;
using Android.Content;
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

		public static void ShowYesNo(Activity oActivity, String sTitle, String sMessage, EventHandler<DialogClickEventArgs> oYesHandler, EventHandler<DialogClickEventArgs> oNoHandler)
		{
			Android.Support.V7.App.AlertDialog.Builder oBuilder = new Android.Support.V7.App.AlertDialog.Builder(oActivity);
			oBuilder.SetTitle(sTitle);
			oBuilder.SetMessage(sMessage);
			oBuilder.SetIcon(Android.Resource.Drawable.IcDialogInfo);
			if (oYesHandler != null) oBuilder.SetPositiveButton(Android.Resource.String.Yes, oYesHandler);
			else oBuilder.SetPositiveButton(Android.Resource.String.Yes, (o, args) => { });
			if (oNoHandler != null) oBuilder.SetNegativeButton(Android.Resource.String.No, oNoHandler);
			else oBuilder.SetNegativeButton(Android.Resource.String.No, (o, args) => { });

			oBuilder.Show();
		}
	}
}