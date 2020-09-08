using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.Widget;

namespace AppLeanMaint.Views
{
	[Activity(Label = "@string/activity_orders_list", ParentActivity = typeof(MainActivity), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivityOrdersList : AppCompatActivity
	{
		#region Protected Properties
		protected Android.Support.V7.Widget.RecyclerView m_oactivity_orders_list = null;
		protected RecyclerView.LayoutManager m_oRecyclerViewLayoutManager = null;
		protected AdapterOrders m_oCounterAdapter = null;
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
			SetContentView(Resource.Layout.activity_orders_list);
			SupportActionBar.Title = Resources.GetString(Resource.String.activity_orders_list);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			// m_nCarID = Intent.GetIntExtra("nCarID", 0);

			m_oactivity_orders_list = FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.activity_orders_list);
			m_oactivity_orders_list.HasFixedSize = true;
			m_oRecyclerViewLayoutManager = new LinearLayoutManager(this);
			m_oactivity_orders_list.SetLayoutManager(m_oRecyclerViewLayoutManager);
			m_oCounterAdapter = new AdapterOrders(Helpers.WS.Instance.GetOrders());
			m_oactivity_orders_list.SetAdapter(m_oCounterAdapter);
			// m_oCounterAdapter.ItemClick += M_oCounterAdapter_ItemClick;
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
		#endregion
	}
}
