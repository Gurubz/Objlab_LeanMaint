using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using AppLeanMaint;
using Android.Gms.Vision.Barcodes;
using Android.Gms.Vision.Texts;
using Android.Gms.Vision;
using static Android.Gms.Vision.Detector;
using Android.Runtime;
using Android.Graphics;
using Android.Util;
using Android.Speech;
using Android.Content.PM;
using Android.Support.V4.App;
using Android;

namespace AppLeanMaint.Views
{
	[Activity(Label = "@string/activity_select_asset_ex", ParentActivity = typeof(MainActivity), ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
	public class ActivitySelectAssetEx : AppCompatActivity, ISurfaceHolderCallback, IProcessor
	{
		#region Protected Properties
		protected LinearLayout m_oLinearLayoutQr = null;
		protected SurfaceView m_oSurfaceViewQr = null;
		protected LinearLayout m_oLinearLayoutText = null;
		protected SurfaceView m_oSurfaceViewText = null;
		protected ImageButton m_oImageButtonQr = null;
		protected ImageButton m_oImageButtonText = null;
		protected ImageButton m_oImageButtonVoice = null;

		BarcodeDetector m_oBarcodeDetector;
		TextRecognizer m_oTextRecognizer;

		CameraSource cameraSource;

		bool m_bIsText = false;
		bool m_bIsSpeech = false;

		const int VOICE_REQUEST_CODE = 10;
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

		protected override void OnActivityResult(int requestCode, Android.App.Result resultVal, Intent data)
		{
			if (this.m_bIsSpeech == true && requestCode == VOICE_REQUEST_CODE)
			{
				if (resultVal == Android.App.Result.Ok)
				{
					var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
					if (matches.Count > 0)
					{
						string sSerial = matches[0].ToString();
						this.GUI_Process(sSerial);
					}
				}
			}

			base.OnActivityResult(requestCode, resultVal, data);
		}

		const int REQUEST_CAMERA_PERMISSIONID = 1001;
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			switch (requestCode)
			{
				case REQUEST_CAMERA_PERMISSIONID:
					{
						if (grantResults[0] == Permission.Granted)
						{
							if (ActivityCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
							{
								//Request Permission  
								ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Camera }, REQUEST_CAMERA_PERMISSIONID);
								return;
							}

							this.GUI_CameraStart();
						}
					}
					break;
			}
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
		public void ReceiveDetections(Detections detections)
		{
			SparseArray items = detections.DetectedItems;
			if (items.Size() != 0)
			{
				m_oSurfaceViewQr.Post(() =>
				{
					cameraSource.Stop();

					Vibrator vibrator = (Vibrator)GetSystemService(Context.VibratorService);
					vibrator.Vibrate(VibrationEffect.CreateOneShot(200, VibrationEffect.DefaultAmplitude));

					string sSerial = string.Empty;
					if (this.m_bIsText == false)
					{
						// Read barcode data
						Barcode oBarcode = items.ValueAt(0) as Barcode;
						if (oBarcode != null)
						{
							sSerial = oBarcode.DisplayValue;
							this.GUI_Process(sSerial);
						}
					}
					else
					{
						// Read text data
						for (int i = 0; i < items.Size(); i++)
						{
							TextBlock oTextBlock = items.ValueAt(i) as TextBlock;
							if (oTextBlock != null)
							{
								sSerial += oTextBlock.Value;
							}
						}
						this.GUI_Process(sSerial);
					}
				});
			}
		}

		public void Release()
		{
			
		}

		public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
		{
			
		}

		public void SurfaceCreated(ISurfaceHolder holder)
		{
			if (ActivityCompat.CheckSelfPermission(ApplicationContext, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
			{
				//Request Permision  
				ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.Camera }, REQUEST_CAMERA_PERMISSIONID);
				return;
			}
			this.GUI_CameraStart();			
		}

		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			cameraSource.Stop();
		}
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
			m_oImageButtonQr.Click += (sender, e) =>
			{
				this.m_bIsText = false;
				this.m_bIsSpeech = false;
				m_oBarcodeDetector = new BarcodeDetector.Builder(this)
					.SetBarcodeFormats(BarcodeFormat.QrCode)
					.Build();
				cameraSource = new CameraSource.Builder(this, m_oBarcodeDetector)
					.SetFacing(CameraFacing.Back)
					.SetRequestedPreviewSize(640, 480)
					.SetRequestedFps(2.0f)
					.SetAutoFocusEnabled(true)
					.Build();
				m_oSurfaceViewQr.Holder.AddCallback(this);
				m_oBarcodeDetector.SetProcessor(this);
				m_oLinearLayoutQr.Visibility = ViewStates.Visible;
				m_oLinearLayoutText.Visibility = ViewStates.Gone;
			};
			m_oImageButtonText = FindViewById<ImageButton>(Resource.Id.activity_select_asset_ex_ImageButtonText);
			m_oImageButtonText.Click += (sender, e) =>
			{
				this.m_bIsText = true;
				this.m_bIsSpeech = false;
				m_oTextRecognizer = new TextRecognizer.Builder(this).Build();
				cameraSource = new CameraSource.Builder(this, m_oTextRecognizer)
					.SetFacing(CameraFacing.Back)
					.SetRequestedPreviewSize(640, 480)
					.SetRequestedFps(2.0f)
					.SetAutoFocusEnabled(true)
					.Build();
				m_oSurfaceViewText.Holder.AddCallback(this);
				m_oTextRecognizer.SetProcessor(this);
				m_oLinearLayoutQr.Visibility = ViewStates.Gone;
				m_oLinearLayoutText.Visibility = ViewStates.Visible;
			};
			m_oImageButtonVoice = FindViewById<ImageButton>(Resource.Id.activity_select_asset_ex_ImageButtonVoice);
			m_oImageButtonVoice.Click += (sender, e) =>
			{
				this.m_bIsText = false;
				this.m_bIsSpeech = true;
				m_oLinearLayoutQr.Visibility = ViewStates.Gone;
				m_oLinearLayoutText.Visibility = ViewStates.Gone;
				var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);
				voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
				voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, Resources.GetString(Resource.String.activity_select_asset_ex_speak));
				voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
				voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
				voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
				voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);
				StartActivityForResult(voiceIntent, VOICE_REQUEST_CODE);
			};
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

		private void GUI_CameraStart()
		{
			try
			{
				if (m_bIsText == false) cameraSource.Start(m_oSurfaceViewQr.Holder);
				else cameraSource.Start(m_oSurfaceViewText.Holder);
			}
			catch (InvalidOperationException)
			{
			}			
		}

		protected void GUI_Process(string sSerial)
		{
			if (Helpers.WS.Instance.IsSerialValid(sSerial) == false)
			{
				Helpers.UI.ShowPersistentMessage(this, Resource.String.activity_select_asset_ex_serialnovalid, (x) =>
				{
					if (this.m_bIsSpeech == false) cameraSource.Start();
				});
			}
			else
			{
				Helpers.UI.ShowProgressMessage(this, Resource.String.app_please_wait);

				// Process the serial
				var aOrders = Helpers.WS.Instance.GetExecutableOrdersByAssetBarcode(sSerial);
			}
		}
		#endregion
	}
}
