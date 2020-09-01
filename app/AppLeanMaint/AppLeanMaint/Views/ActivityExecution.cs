using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AppLeanMaint.Views
{
	[Activity(Label = "@string/activity_execution", ParentActivity = typeof(MainActivity), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivityExecution : AppCompatActivity
	{
		#region Protected Properties
		protected TextView m_oactivity_execution_interventi_TextViewID_Plant = null;
		protected EditText m_oactivity_execution_interventi_EditTextDesc_Inter = null;
		protected EditText m_oactivity_execution_interventi_EditTextDateDT_Chiamata = null;
		protected EditText m_oactivity_execution_interventi_EditTextTimeDT_Chiamata = null;
		protected EditText m_oactivity_execution_interventi_EditTextTarif_Inter = null;
		protected EditText m_oactivity_execution_interventi_EditTextTipo_Risorsa = null;
		protected EditText m_oactivity_execution_interventi_EditTextDesc_Risorsa = null;
		protected EditText m_oactivity_execution_interventi_EditTextCDC_Risorsa = null;
		protected EditText m_oactivity_execution_interventi_EditTextTipo_Plant = null;
		protected EditText m_oactivity_execution_interventi_EditTextDT_Conf_Int = null;
		protected EditText m_oactivity_execution_interventi_EditTextDT_Eff_Int = null;
		protected EditText m_oactivity_execution_interventi_EditTextDT_Ultimo_Guasto = null;
		protected EditText m_oactivity_execution_interventi_EditTextDT_Ultima_Riparazione = null;
		protected EditText m_oactivity_execution_interventi_EditTextEsito_maint = null;
		protected EditText m_oactivity_execution_interventi_EditTextStato = null;
		protected TextView m_oactivity_execution_interventi_TextViewID_Inter = null;
		protected EditText m_oactivity_execution_interventi_EditTextID_Persona = null;
		protected EditText m_oactivity_execution_interventi_EditTextORE_Inter = null;
		protected EditText m_oactivity_execution_interventi_EditTextCosto_Inter = null;
		protected EditText m_oactivity_execution_interventi_EditTextProbabil = null;
		protected EditText m_oactivity_execution_interventi_EditTextGravity = null;
		protected EditText m_oactivity_execution_interventi_EditTextRilevabil = null;

		protected string m_sID_Plant = string.Empty;
		protected string m_sID_Inter = string.Empty;
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
			SetContentView(Resource.Layout.activity_execution);
			SupportActionBar.Title = Resources.GetString(Resource.String.activity_execution);
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			m_sID_Plant = Intent.GetStringExtra("ID_Plant");
			m_sID_Inter = Intent.GetStringExtra("ID_Inter");
			m_oactivity_execution_interventi_TextViewID_Plant = FindViewById<TextView>(Resource.Id.activity_execution_TextViewID_Plant);
			m_oactivity_execution_interventi_EditTextDesc_Inter = FindViewById<EditText>(Resource.Id.activity_execution_EditTextDesc_Inter);
			m_oactivity_execution_interventi_EditTextDateDT_Chiamata = FindViewById<EditText>(Resource.Id.activity_execution_EditTextDateDT_Chiamata);
			m_oactivity_execution_interventi_EditTextTimeDT_Chiamata = FindViewById<EditText>(Resource.Id.activity_execution_EditTextTimeDT_Chiamata);
			m_oactivity_execution_interventi_EditTextTarif_Inter = FindViewById<EditText>(Resource.Id.activity_execution_EditTextTarif_Inter);
			m_oactivity_execution_interventi_EditTextTipo_Risorsa = FindViewById<EditText>(Resource.Id.activity_execution_EditTextTipo_Risorsa);
			m_oactivity_execution_interventi_EditTextDesc_Risorsa = FindViewById<EditText>(Resource.Id.activity_execution_EditTextDesc_Risorsa);
			m_oactivity_execution_interventi_EditTextCDC_Risorsa = FindViewById<EditText>(Resource.Id.activity_execution_EditTextCDC_Risorsa);
			m_oactivity_execution_interventi_EditTextTipo_Plant = FindViewById<EditText>(Resource.Id.activity_execution_EditTextTipo_Plant);
			m_oactivity_execution_interventi_EditTextDT_Conf_Int = FindViewById<EditText>(Resource.Id.activity_execution_EditTextDT_Conf_Int);
			m_oactivity_execution_interventi_EditTextDT_Eff_Int = FindViewById<EditText>(Resource.Id.activity_execution_EditTextDT_Eff_Int);
			m_oactivity_execution_interventi_EditTextDT_Ultimo_Guasto = FindViewById<EditText>(Resource.Id.activity_execution_EditTextDT_Ultimo_Guasto);
			m_oactivity_execution_interventi_EditTextDT_Ultima_Riparazione = FindViewById<EditText>(Resource.Id.activity_execution_EditTextDT_Ultima_Riparazione);
			m_oactivity_execution_interventi_EditTextEsito_maint = FindViewById<EditText>(Resource.Id.activity_execution_EditTextEsito_maint);
			m_oactivity_execution_interventi_EditTextStato = FindViewById<EditText>(Resource.Id.activity_execution_EditTextStato);
			m_oactivity_execution_interventi_TextViewID_Inter = FindViewById<TextView>(Resource.Id.activity_execution_TextViewID_Inter);
			m_oactivity_execution_interventi_EditTextID_Persona = FindViewById<EditText>(Resource.Id.activity_execution_EditTextID_Persona);
			m_oactivity_execution_interventi_EditTextORE_Inter = FindViewById<EditText>(Resource.Id.activity_execution_EditTextORE_Inter);
			m_oactivity_execution_interventi_EditTextCosto_Inter = FindViewById<EditText>(Resource.Id.activity_execution_EditTextCosto_Inter);
			m_oactivity_execution_interventi_EditTextProbabil = FindViewById<EditText>(Resource.Id.activity_execution_EditTextProbabil);
			m_oactivity_execution_interventi_EditTextGravity = FindViewById<EditText>(Resource.Id.activity_execution_EditTextGravity);
			m_oactivity_execution_interventi_EditTextRilevabil = FindViewById<EditText>(Resource.Id.activity_execution_EditTextRilevabil);

			m_oactivity_execution_interventi_EditTextDesc_Inter.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextDateDT_Chiamata.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextTimeDT_Chiamata.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextTarif_Inter.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextTipo_Risorsa.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextDesc_Risorsa.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextCDC_Risorsa.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextTipo_Plant.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextDT_Conf_Int.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextDT_Eff_Int.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextDT_Ultimo_Guasto.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextDT_Ultima_Riparazione.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextEsito_maint.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextStato.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextID_Persona.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextORE_Inter.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextCosto_Inter.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextProbabil.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextGravity.SetSelectAllOnFocus(true);
			m_oactivity_execution_interventi_EditTextRilevabil.SetSelectAllOnFocus(true);
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
