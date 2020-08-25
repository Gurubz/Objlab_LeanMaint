using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public Material Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID = {ID}")]
	public class Material
	{
		public Material()
		{
		}

		public Material(Int32 nID)
		{
			m_nID = nID;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID
		{
		  get { return (m_nID); }
		  set { m_nID = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Description
		{
		  get { return (m_sDescription); }
		  set { m_sDescription = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Plant
		{
		  get { return (m_nID_Plant); }
		  set { m_nID_Plant = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Coded
		{
		  get { return (m_nCoded); }
		  set { m_nCoded = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Supplier
		{
		  get { return (m_nID_Supplier); }
		  set { m_nID_Supplier = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DateTime UsedFrom
		{
		  get { return (m_oUsedFrom); }
		  set { m_oUsedFrom = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_CostCenter
		{
		  get { return (m_nID_CostCenter); }
		  set { m_nID_CostCenter = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Decimal Cost
		{
		  get { return (m_nCost); }
		  set { m_nCost = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_Plant;
		protected Int32 m_nCoded;
		protected Int32 m_nID_Supplier;
		protected DateTime m_oUsedFrom = DateTime.MinValue;
		protected Int32 m_nID_CostCenter;
		protected Decimal m_nCost;
		protected Int32 m_nID_ObjStatus;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID)
		{
			m_nID = nID;
		}
		#endregion
	}
}
