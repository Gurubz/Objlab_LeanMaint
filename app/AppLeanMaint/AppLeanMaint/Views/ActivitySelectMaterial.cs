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
	[Activity(Label = "@string/activity_select_material", ParentActivity = typeof(ActivityOrders), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivitySelectMaterial : AppCompatActivity
	{
		#region Protected Properties
		protected AutoCompleteTextView m_oAutoCompleteTextViewMaterial = null;
		protected LinearLayout m_oLinearLayoutMaterial = null;
		protected TextView m_oTextViewID_Material = null;
		protected TextView m_oTextViewDescription = null;
		protected PlanningWS.Material[] m_aMaterials = null;
		protected PlanningWS.Material m_oMaterial = null;
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
				if (this.m_oMaterial != null)
				{
					Intent oIntent = new Intent(this, typeof(ActivityOrders));
					oIntent.PutExtra("ID", m_oMaterial.ID_Material);
					oIntent.PutExtra("Name", m_oMaterial.Name);
					this.SetResult(Result.Ok, oIntent);
				}				
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
			SetContentView(Resource.Layout.activity_select_material);
			SupportActionBar.Title = Resources.GetString(Resource.String.activity_select_material);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			Helpers.WS.Instance.UpdateLocalMaterialsForOrder();

			// m_nCarID = Intent.GetIntExtra("nCarID", 0);

			m_oAutoCompleteTextViewMaterial = FindViewById<AutoCompleteTextView>(Resource.Id.activity_select_material_AutoCompleteTextViewMaterial);

			m_aMaterials = Helpers.Database.Current.SearchMaterials(string.Empty);
			string[] aMaterials = (from o in m_aMaterials select $"{o.Name}").ToArray();
			ArrayAdapter<string> oAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, aMaterials);
			m_oAutoCompleteTextViewMaterial.Adapter = oAdapter;
			m_oAutoCompleteTextViewMaterial.TextChanged += (sender, e) =>
			{
				m_oMaterial = (from o in m_aMaterials where o.Name == m_oAutoCompleteTextViewMaterial.Text select o).SingleOrDefault();
				this.GUI_BizToGui();
			};

			m_oLinearLayoutMaterial = FindViewById<LinearLayout>(Resource.Id.activity_select_material_LinearLayoutMaterial);
			m_oTextViewID_Material = FindViewById<TextView>(Resource.Id.activity_select_material_TextViewID_Material);
			m_oTextViewDescription = FindViewById<TextView>(Resource.Id.activity_select_material_TextViewDescription);
		}

		public void GUI_BizToGui()
		{
			if (m_oMaterial != null)
			{
				m_oTextViewID_Material.Text = $"{m_oMaterial.ID_Material}";
				m_oTextViewDescription.Text = $"{m_oMaterial.Description}";
				m_oLinearLayoutMaterial.Visibility = ViewStates.Visible;
			}
			else
			{
				m_oLinearLayoutMaterial.Visibility = ViewStates.Gone;
			}
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
