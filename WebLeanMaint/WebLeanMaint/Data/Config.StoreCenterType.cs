using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public StoreCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  24/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_StoreCenterType = {ID_StoreCenterType}")]
	public partial class StoreCenterType
	{
		public StoreCenterType()
		{
		}

		public StoreCenterType(Int32 nID_StoreCenterType)
		{
			m_nID_StoreCenterType = nID_StoreCenterType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_StoreCenterType
		{
		  get { return (m_nID_StoreCenterType); }
		  set { m_nID_StoreCenterType = value; }
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
		#endregion

		#region Protected Properties
		protected Int32 m_nID_StoreCenterType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_StoreCenterType)
		{
			m_nID_StoreCenterType = nID_StoreCenterType;
		}
		#endregion
	}
}
