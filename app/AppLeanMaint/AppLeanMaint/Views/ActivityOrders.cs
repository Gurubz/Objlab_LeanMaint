using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using System.Linq;

namespace AppLeanMaint.Views
{
	[Activity(Label = "@string/activity_orders", ParentActivity = typeof(MainActivity), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivityOrders : AppCompatActivity
	{
		#region Protected Properties
		protected PlanningWS.Order m_oOrder = null;
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
			this.MenuInflater.Inflate(Resource.Menu.confirm, menu);

			return (base.OnCreateOptionsMenu(menu));
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			if (item.ItemId == Resource.Id.ConfirmMenu_ButtonConfirm)
			{
				this.GUI_GuiToBiz();

				//this.m_oViewModel.Save();
				Helpers.WS.Instance.CreateOrder(this.m_oOrder);

				this.Finish();
			}

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
			GUI_AddDatePicker(m_oactivity_orders_EditTextDatePlannedFor);
			m_oactivity_orders_EditTextTimePlannedFor = FindViewById<EditText>(Resource.Id.activity_orders_EditTextTimePlannedFor);
			GUI_AddTimePicker(m_oactivity_orders_EditTextTimePlannedFor);
			m_oactivity_orders_EditTextDateToCompleteBefore = FindViewById<EditText>(Resource.Id.activity_orders_EditTextDateToCompleteBefore);
			GUI_AddDatePicker(m_oactivity_orders_EditTextDateToCompleteBefore);
			m_oactivity_orders_EditTextTimeToCompleteBefore = FindViewById<EditText>(Resource.Id.activity_orders_EditTextTimeToCompleteBefore);
			GUI_AddTimePicker(m_oactivity_orders_EditTextTimeToCompleteBefore);
			m_oactivity_orders_EditTextDescription.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextDatePlannedFor.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextTimePlannedFor.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextDateToCompleteBefore.SetSelectAllOnFocus(true);
			m_oactivity_orders_EditTextTimeToCompleteBefore.SetSelectAllOnFocus(true);

			
		}

		public void GUI_BizToGui()
		{
			if (this.m_oactivity_orders_spinnerID_OrderType.Adapter == null)
			{
				ArrayAdapter oAdapter = new ArrayAdapter<string>(this, Resource.Layout.spinner_simple_item, (from o in Helpers.Database.Current.GetOrderTypes() select o.Name).ToArray());
				this.m_oactivity_orders_spinnerID_OrderType.Adapter = oAdapter;
			}

			if (m_oOrder != null)
			{
				m_oactivity_orders_TextViewID_Order.Text = m_oOrder.ID_Order.ToString();
				m_oactivity_orders_EditTextDescription.Text = m_oOrder.Description;
				m_oactivity_orders_spinnerID_OrderType.Post(delegate
				{
					m_oactivity_orders_spinnerID_OrderType.SetSelection(m_oOrder.ID_OrderType - 1);
				});
				m_oactivity_orders_EditTextDatePlannedFor.Text = m_oOrder.PlannedFor.ToShortDateString();
				m_oactivity_orders_EditTextTimePlannedFor.Text = m_oOrder.PlannedFor.ToShortTimeString();
				m_oactivity_orders_EditTextDateToCompleteBefore.Text = m_oOrder.ToCompleteBefore.ToShortDateString();
				m_oactivity_orders_EditTextTimeToCompleteBefore.Text = m_oOrder.ToCompleteBefore.ToShortTimeString();
			}
		}

		public void GUI_GuiToBiz()
		{
			if(m_oOrder==null) m_oOrder = new PlanningWS.Order();

			m_oOrder.ID_Order = int.Parse(m_oactivity_orders_TextViewID_Order.Text);
			m_oOrder.Description = m_oactivity_orders_EditTextDescription.Text;
			m_oOrder.ID_OrderType = m_oactivity_orders_spinnerID_OrderType.SelectedItemPosition + 1;
			m_oOrder.PlannedFor = DateTime.Parse(m_oactivity_orders_EditTextDatePlannedFor.Text + " " + m_oactivity_orders_EditTextTimePlannedFor.Text);
			m_oOrder.ToCompleteBefore = DateTime.Parse(m_oactivity_orders_EditTextDateToCompleteBefore.Text + " " + m_oactivity_orders_EditTextTimeToCompleteBefore.Text);

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
		#endregion
	}
}
