using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using AppLeanMaint;

namespace AppLeanMaint.Views
{
	[Activity(Label = "@string/activity_select_asset_ex", ParentActivity = typeof(MainActivity), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivitySelectAssetEx : AppCompatActivity
	{
		#region Protected Properties
		protected LinearLayout m_oLinearLayoutQr = null;
		protected SurfaceView m_oSurfaceViewQr = null;
		protected LinearLayout m_oLinearLayoutText = null;
		protected SurfaceView m_oSurfaceViewText = null;
		protected ImageButton m_oImageButtonQr = null;
		protected ImageButton m_oImageButtonText = null;
		protected ImageButton m_oImageButtonVoice = null;
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
			SetContentView(Resource.Layout.activity_select_asset_ex);
			SupportActionBar.Title = Resources.GetString(Resource.String.activity_select_asset_ex);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			// m_nCarID = Intent.GetIntExtra("nCarID", 0);

			m_oLinearLayoutQr = FindViewById<LinearLayout>(Resource.Id.activity_select_asset_ex_LinearLayoutQr);
			m_oSurfaceViewQr = FindViewById<SurfaceView>(Resource.Id.activity_select_asset_ex_SurfaceViewQr);
			m_oLinearLayoutText = FindViewById<LinearLayout>(Resource.Id.activity_select_asset_ex_LinearLayoutText);
			m_oSurfaceViewText = FindViewById<SurfaceView>(Resource.Id.activity_select_asset_ex_SurfaceViewText);
			m_oImageButtonQr = FindViewById<ImageButton>(Resource.Id.activity_select_asset_ex_ImageButtonQr);
			m_oImageButtonText = FindViewById<ImageButton>(Resource.Id.activity_select_asset_ex_ImageButtonText);
			m_oImageButtonVoice = FindViewById<ImageButton>(Resource.Id.activity_select_asset_ex_ImageButtonVoice);
		}

		public void GUI_BizToGui()
		{
			// m_oButtonDateReading.Text = m_oViewModel.DateReference.ToString("d");
			// if (m_oSpinnerFuelType.Adapter == null)
			// {
			// 	Adapters.FuelTypesAdapter oAdapter = new Views.Adapters.FuelTypesAdapter(this);
			// 	m_oSpinnerFuelType.Adapter = oAdapter;
			// }
			// m_oSpinnerFuelType.Post(delegate
			// {
			// 	m_oSpinnerFuelType.SetSelection(MKA.App.SchedaCarburante.Models.Enums.Current.FuelTypes.IndexOf(m_oViewModel.FuelType));
			// });
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

		protected void GUI_AddDatePicker(EditText oEditText)
		{
			oEditText.Focusable = false;
			oEditText.Click += delegate
			{
				DateTime oCurrent = DateTime.Now;
				if (string.IsNullOrEmpty(oEditText.Text) == false)
				{
					DateTime.TryParse(oEditText.Text, out oCurrent);
				}

				var dialog = new DatePickerDialog(this, (sender, e) =>
				{
					oEditText.Text = e.Date.ToShortDateString();
				}, oCurrent.Year, oCurrent.Month, oCurrent.Day);
				dialog.Show();
			};
		}

		protected void GUI_AddTimePicker(EditText oEditText)
		{
			oEditText.Focusable = false;
			oEditText.Click += delegate
			{
				int nHour = DateTime.Now.Hour;
				int nMin = DateTime.Now.Minute;
				if (string.IsNullOrEmpty(oEditText.Text) == false)
				{
					string[] aHourMin = oEditText.Text.Split(":".ToCharArray());
					int.TryParse(aHourMin[0], out nHour);
					int.TryParse(aHourMin[1], out nMin);
				}

				var dialog = new TimePickerDialog(this, (sender, e) =>
				{
					oEditText.Text = new DateTime(1970, 1, 1, e.HourOfDay, e.Minute, 0).ToShortTimeString();
				}, nHour, nMin, true);
				dialog.Show();
			};
		}

		protected void GUI_AddActivityResult<T>(EditText oEditText, EditText oEditTextParent1 = null)
		{
			oEditText.Focusable = false;
			oEditText.Click += delegate
			{
				int nID = 0;
				string sName = string.Empty;

				if (oEditTextParent1 != null)
				{
					nID = (int)oEditTextParent1.Tag;
					sName = oEditTextParent1.Text;
				}
				Intent oIntent = new Intent(this, typeof(T));
				oIntent.PutExtra("ID", nID);
				oIntent.PutExtra("Name", sName);
				StartActivityForResult(oIntent, oEditText.Id & 0xFFFF);
			};
		}
		#endregion
	}
}
