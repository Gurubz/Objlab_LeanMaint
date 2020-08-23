using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public Region Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  23/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Region = {ID_Region}")]
	public class Region
	{
		public Region()
		{
		}

		public Region(Int32 nID_Region)
		{
			m_nID_Region = nID_Region;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Region
		{
		  get { return (m_nID_Region); }
		  set { m_nID_Region = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Country
		{
		  get { return (m_nID_Country); }
		  set { m_nID_Country = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Region;
		protected String m_sName = String.Empty;
		protected Int32 m_nID_Country;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Region)
		{
			m_nID_Region = nID_Region;
		}
		#endregion
	}
}
