﻿using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AppLeanMaint.Views
{
	[Activity(Label = "@string/activity_orders", ParentActivity = typeof(MainActivity), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivityOrders : AppCompatActivity
	{
		#region Protected Properties
		protected TextView m_oactivity_orders_TextViewID_Order = null;
		protected EditText m_oactivity_orders_EditTextDescription = null;
		protected Spinner m_oactivity_orders_spinnerID_OrderType = null;
		protected EditText m_oactivity_orders_EditTextDatePlannedFor = null;
		protected EditText m_oactivity_orders_EditTextTimePlannedFor = null;
		protected EditText m_oactivity_orders_EditTextDateToCompleteBefore = null;
		protected EditText m_oactivity_orders_EditTextTimeToCompleteBefore = null;
		#endregion

		#region Override Methods
		///// <summary>
		///// Used to force the language in the app
		///// </summary>
		//protected override void AttachBaseContext(Context @base)
		//{
		//	Context oContext = @base;

		//	Models.Config oConfig = Database.Current.LoadConfig();
		//	if (oConfig != null && string.IsNullOrEmpty(oConfig.Language) == false)
		//	{
		//		oContext = LocalizedContextWrapper.Wrap(@base, oConfig.Language);
		//	}

		//	base.AttachBaseContext(oContext);
		//}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			this.GUI_Init();
		}

		protected override void OnResume()
		{
			GUI_BizToGui();

			base.OnResume();
		}

		protected override void OnStart()
		{
			base.OnStart();
		}

		protected override void OnStop()
		{
			base.OnStop();
		}

		[Obsolete("deprecated")]
		protected override Dialog OnCreateDialog(int id)
		{
			Dialog oRet = null;
			Button oButton = null;

			// switch (id)
			// {
			// 	case Resource.Id.RefillPage_ButtonDateReading:
			// 		oButton = this.FindViewById<Button>(Resource.Id.RefillPage_ButtonDateReading);
			// 		break;
			// }

			// oRet = Core.DatePickerDialogManager.Show(this, oButton);

			return (oRet);
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{

			return (base.OnCreateOptionsMenu(menu));
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{

			return base.OnOptionsItemSelected(item);
		}
		#endregion

		#region Protected Event Methods
		#endregion

		#region Protected GUI Methods
		protected void GUI_Init()
		{
			SetContentView(Resource.Layout.activity_orders);
			SupportActionBar.Title = Resources.GetString(Resource.String.activity_orders);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			// m_nCarID = Intent.GetIntExtra("nCarID", 0);

			m_oactivity_orders_TextViewID_Order = FindViewById<TextView>(Resource.Id.activity_orders_TextViewID_Order);
			m_oactivity_orders_EditTextDescription = FindViewById<EditText>(Resource.Id.activity_orders_EditTextDescription);
			m_oactivity_orders_spinnerID_OrderType = FindViewById<Spinner>(Resource.Id.activity_orders_spinnerID_OrderType);
			m_oactivity_orders_EditTextDatePlannedFor = FindViewById<EditText>(Resource.Id.activity_orders_EditTextDatePlannedFor);
			m_oactivity_orders_EditTextTimePlannedFor = FindViewById<EditText>(Resource.Id.activity_orders_EditTextTimePlannedFor);
			m_oactivity_orders_EditTextDateToCompleteBefore = FindViewById<EditText>(Resource.Id.activity_orders_EditTextDateToCompleteBefore);
			m_oactivity_orders_EditTextTimeToCompleteBefore = FindViewById<EditText>(Resource.Id.activity_orders_EditTextTimeToCompleteBefore);

			m_oactivity_orders_EditTextDescription.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextDatePlannedFor.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextTimePlannedFor.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextDateToCompleteBefore.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextTimeToCompleteBefore.SetSelectAllOnFocus(true);
		}

		public void GUI_BizToGui()
		{
			// m_oButtonDateReading.Text = m_oViewModel.DateReference.ToString("d");
			if (this.m_oactivity_orders_spinnerID_OrderType.Adapter == null)
			{
				ArrayAdapter oAdapter = new ArrayAdapter<string>(this, Resource.Layout.spinner_simple_item, Resources.GetStringArray(Resource.Array.activity_orders_ordertypes));
				this.m_oactivity_orders_spinnerID_OrderType.Adapter = oAdapter;
			}
			//m_oactivity_orders_spinnerID_OrderType.Post(delegate
			//{
			//	m_oactivity_orders_spinnerID_OrderType.SetSelection(MKA.App.SchedaCarburante.Models.Enums.Current.FuelTypes.IndexOf(m_oViewModel.FuelType));
			//});
		}

		public void GUI_GuiToBiz()
		{
			// m_oViewModel.DateReference = DateTime.Parse(m_oButtonDateReading.Text);
			// m_oViewModel.FuelType = MKA.App.SchedaCarburante.Models.Enums.Current.FuelTypes[m_oSpinnerFuelType.SelectedItemPosition];
		}

		protected string GUI_TextViewToDecimal(TextView oTextView)
		{
			String sRet = String.Empty;

			sRet = oTextView.Text.Replace(", ", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator);
			sRet = sRet.Replace(".", System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator);

			return (sRet);
		}
		#endregion
	}
}