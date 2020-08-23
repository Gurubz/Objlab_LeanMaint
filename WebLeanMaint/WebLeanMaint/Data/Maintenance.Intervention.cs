using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Intervention Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Intervention = {ID_Intervention}")]
	public class Intervention
	{
		public Intervention()
		{
		}

		public Intervention(Int32 nID_Intervention)
		{
			m_nID_Intervention = nID_Intervention;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Intervention
		{
		  get { return (m_nID_Intervention); }
		  set { m_nID_Intervention = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Description
		{
		  get { return (m_sDescription); }
		  set { m_sDescription = value; m_bDescription_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Description_HasValue
		{
		  get { return (m_bDescription_HasValue); }
		  set { m_bDescription_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Operator
		{
		  get { return (m_nID_Operator); }
		  set { m_nID_Operator = value; m_bID_Operator_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Operator_HasValue
		{
		  get { return (m_bID_Operator_HasValue); }
		  set { m_bID_Operator_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Plant
		{
		  get { return (m_nID_Plant); }
		  set { m_nID_Plant = value; m_bID_Plant_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Plant_HasValue
		{
		  get { return (m_bID_Plant_HasValue); }
		  set { m_bID_Plant_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime RequestedAt
		{
		  get { return (m_oRequestedAt); }
		  set { m_oRequestedAt = value; m_bRequestedAt_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool RequestedAt_HasValue
		{
		  get { return (m_bRequestedAt_HasValue); }
		  set { m_bRequestedAt_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Tarif_Inter
		{
		  get { return (m_nTarif_Inter); }
		  set { m_nTarif_Inter = value; m_bTarif_Inter_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Tarif_Inter_HasValue
		{
		  get { return (m_bTarif_Inter_HasValue); }
		  set { m_bTarif_Inter_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Tipo_Risorsa
		{
		  get { return (m_sTipo_Risorsa); }
		  set { m_sTipo_Risorsa = value; m_bTipo_Risorsa_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Tipo_Risorsa_HasValue
		{
		  get { return (m_bTipo_Risorsa_HasValue); }
		  set { m_bTipo_Risorsa_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Desc_Risorsa
		{
		  get { return (m_sDesc_Risorsa); }
		  set { m_sDesc_Risorsa = value; m_bDesc_Risorsa_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Desc_Risorsa_HasValue
		{
		  get { return (m_bDesc_Risorsa_HasValue); }
		  set { m_bDesc_Risorsa_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String CDC_Risorsa
		{
		  get { return (m_sCDC_Risorsa); }
		  set { m_sCDC_Risorsa = value; m_bCDC_Risorsa_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool CDC_Risorsa_HasValue
		{
		  get { return (m_bCDC_Risorsa_HasValue); }
		  set { m_bCDC_Risorsa_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Tipo_Plant
		{
		  get { return (m_sTipo_Plant); }
		  set { m_sTipo_Plant = value; m_bTipo_Plant_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Tipo_Plant_HasValue
		{
		  get { return (m_bTipo_Plant_HasValue); }
		  set { m_bTipo_Plant_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 DT_Conf_Int
		{
		  get { return (m_nDT_Conf_Int); }
		  set { m_nDT_Conf_Int = value; m_bDT_Conf_Int_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool DT_Conf_Int_HasValue
		{
		  get { return (m_bDT_Conf_Int_HasValue); }
		  set { m_bDT_Conf_Int_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 DT_Eff_Int
		{
		  get { return (m_nDT_Eff_Int); }
		  set { m_nDT_Eff_Int = value; m_bDT_Eff_Int_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool DT_Eff_Int_HasValue
		{
		  get { return (m_bDT_Eff_Int_HasValue); }
		  set { m_bDT_Eff_Int_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 DT_Ultimo_Guasto
		{
		  get { return (m_nDT_Ultimo_Guasto); }
		  set { m_nDT_Ultimo_Guasto = value; m_bDT_Ultimo_Guasto_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool DT_Ultimo_Guasto_HasValue
		{
		  get { return (m_bDT_Ultimo_Guasto_HasValue); }
		  set { m_bDT_Ultimo_Guasto_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 DT_Ultima_Riparazione
		{
		  get { return (m_nDT_Ultima_Riparazione); }
		  set { m_nDT_Ultima_Riparazione = value; m_bDT_Ultima_Riparazione_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool DT_Ultima_Riparazione_HasValue
		{
		  get { return (m_bDT_Ultima_Riparazione_HasValue); }
		  set { m_bDT_Ultima_Riparazione_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Outcome
		{
		  get { return (m_nID_Outcome); }
		  set { m_nID_Outcome = value; m_bID_Outcome_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Outcome_HasValue
		{
		  get { return (m_bID_Outcome_HasValue); }
		  set { m_bID_Outcome_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; m_bID_ObjStatus_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_ObjStatus_HasValue
		{
		  get { return (m_bID_ObjStatus_HasValue); }
		  set { m_bID_ObjStatus_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Hours
		{
		  get { return (m_nHours); }
		  set { m_nHours = value; m_bHours_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Hours_HasValue
		{
		  get { return (m_bHours_HasValue); }
		  set { m_bHours_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 TotalCost
		{
		  get { return (m_nTotalCost); }
		  set { m_nTotalCost = value; m_bTotalCost_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool TotalCost_HasValue
		{
		  get { return (m_bTotalCost_HasValue); }
		  set { m_bTotalCost_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Probability
		{
		  get { return (m_nProbability); }
		  set { m_nProbability = value; m_bProbability_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Probability_HasValue
		{
		  get { return (m_bProbability_HasValue); }
		  set { m_bProbability_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Gravity
		{
		  get { return (m_nGravity); }
		  set { m_nGravity = value; m_bGravity_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Gravity_HasValue
		{
		  get { return (m_bGravity_HasValue); }
		  set { m_bGravity_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Rilevability
		{
		  get { return (m_nRilevability); }
		  set { m_nRilevability = value; m_bRilevability_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Rilevability_HasValue
		{
		  get { return (m_bRilevability_HasValue); }
		  set { m_bRilevability_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Intervention;
		protected String m_sDescription = String.Empty;
		protected bool m_bDescription_HasValue;
		protected Int32 m_nID_Operator;
		protected bool m_bID_Operator_HasValue;
		protected Int32 m_nID_Plant;
		protected bool m_bID_Plant_HasValue;
		protected DateTime m_oRequestedAt = DateTime.MinValue;
		protected bool m_bRequestedAt_HasValue;
		protected Int32 m_nTarif_Inter;
		protected bool m_bTarif_Inter_HasValue;
		protected String m_sTipo_Risorsa = String.Empty;
		protected bool m_bTipo_Risorsa_HasValue;
		protected String m_sDesc_Risorsa = String.Empty;
		protected bool m_bDesc_Risorsa_HasValue;
		protected String m_sCDC_Risorsa = String.Empty;
		protected bool m_bCDC_Risorsa_HasValue;
		protected String m_sTipo_Plant = String.Empty;
		protected bool m_bTipo_Plant_HasValue;
		protected Int32 m_nDT_Conf_Int;
		protected bool m_bDT_Conf_Int_HasValue;
		protected Int32 m_nDT_Eff_Int;
		protected bool m_bDT_Eff_Int_HasValue;
		protected Int32 m_nDT_Ultimo_Guasto;
		protected bool m_bDT_Ultimo_Guasto_HasValue;
		protected Int32 m_nDT_Ultima_Riparazione;
		protected bool m_bDT_Ultima_Riparazione_HasValue;
		protected Int32 m_nID_Outcome;
		protected bool m_bID_Outcome_HasValue;
		protected Int32 m_nID_ObjStatus;
		protected bool m_bID_ObjStatus_HasValue;
		protected Int32 m_nHours;
		protected bool m_bHours_HasValue;
		protected Int32 m_nTotalCost;
		protected bool m_bTotalCost_HasValue;
		protected Int32 m_nProbability;
		protected bool m_bProbability_HasValue;
		protected Int32 m_nGravity;
		protected bool m_bGravity_HasValue;
		protected Int32 m_nRilevability;
		protected bool m_bRilevability_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Intervention)
		{
			m_nID_Intervention = nID_Intervention;
		}
		#endregion
	}
}
