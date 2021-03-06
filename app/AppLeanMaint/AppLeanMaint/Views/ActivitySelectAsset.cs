﻿using System;
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
	[Activity(Label = "@string/activity_select_asset", ParentActivity = typeof(ActivityOrders), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivitySelectAsset : AppCompatActivity
	{
		#region Protected Properties
		protected AutoCompleteTextView m_oAutoCompleteTextViewAsset = null;
		protected LinearLayout m_oLinearLayoutAsset = null;
		protected TextView m_oTextViewID_Asset = null;
		protected TextView m_oTextViewName = null;
		protected TextView m_oTextViewDescription = null;
		protected TextView m_oTextViewID_AssetType = null;
		protected TextView m_oTextViewID_OrganizationCenter = null;
		protected TextView m_oTextViewID_CostCenter = null;
		protected TextView m_oTextViewID_GeographicCenter = null;
		protected TextView m_oTextViewID_Parent = null;
		protected PlanningWS.Asset[] m_aAssets = null;
		protected PlanningWS.Asset m_oAsset = null;
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
				if (this.m_oAsset != null)
				{
					Intent oIntent = new Intent(this, typeof(ActivityOrders));
					oIntent.PutExtra("ID", m_oAsset.ID_Asset);
					oIntent.PutExtra("Name", m_oAsset.Name);
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
			SetContentView(Resource.Layout.activity_select_asset);
			SupportActionBar.Title = Resources.GetString(Resource.String.activity_select_asset);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			Helpers.WS.Instance.UpdateLocalAssetsForOrder();

			// m_nCarID = Intent.GetIntExtra("nCarID", 0);

			m_oAutoCompleteTextViewAsset = FindViewById<AutoCompleteTextView>(Resource.Id.activity_select_asset_AutoCompleteTextViewAsset);

			m_aAssets = Helpers.Database.Current.SearchAssets(string.Empty);
			string[] aAssets = (from o in m_aAssets select $"{o.Name}").ToArray();
			ArrayAdapter<string> oAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, aAssets);
			m_oAutoCompleteTextViewAsset.Adapter = oAdapter;
			m_oAutoCompleteTextViewAsset.TextChanged += (sender, e) =>
			{
				m_oAsset = (from o in m_aAssets where o.Name == m_oAutoCompleteTextViewAsset.Text select o).SingleOrDefault();
				this.GUI_BizToGui();
			};

			m_oLinearLayoutAsset = FindViewById<LinearLayout>(Resource.Id.activity_select_asset_LinearLayoutAsset);
			m_oTextViewID_Asset = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewID_Asset);
			m_oTextViewName = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewName);
			m_oTextViewDescription = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewDescription);
			m_oTextViewID_AssetType = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewID_AssetType);
			m_oTextViewID_OrganizationCenter = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewID_OrganizationCenter);
			m_oTextViewID_CostCenter = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewID_CostCenter);
			m_oTextViewID_GeographicCenter = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewID_GeographicCenter);
			m_oTextViewID_Parent = FindViewById<TextView>(Resource.Id.activity_select_asset_TextViewID_Parent);
		}

		public void GUI_BizToGui()
		{
			if (m_oAsset != null)
			{
				m_oTextViewID_Asset.Text = $"{m_oAsset.ID_Asset}";
				m_oTextViewName.Text = $"{m_oAsset.Name}";
				m_oTextViewDescription.Text = $"{m_oAsset.Description}";
				m_oTextViewID_AssetType.Text = $"{m_oAsset.ID_AssetType}";
				m_oTextViewID_OrganizationCenter.Text = $"{m_oAsset.ID_OrganizationCenter}";
				m_oTextViewID_CostCenter.Text = $"{m_oAsset.ID_CostCenter}";
				m_oTextViewID_GeographicCenter.Text = $"{m_oAsset.ID_GeographicCenter}";
				m_oTextViewID_Parent.Text = $"{m_oAsset.ID_Parent}";
				m_oLinearLayoutAsset.Visibility = ViewStates.Visible;
			}
			else
			{
				m_oLinearLayoutAsset.Visibility = ViewStates.Gone;
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
