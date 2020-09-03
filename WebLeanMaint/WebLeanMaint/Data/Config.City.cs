using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public City Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_City = {ID_City}")]
	public class City
	{
		public City()
		{
		}

		public City(Int32 nID_City)
		{
			m_nID_City = nID_City;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_City
		{
		  get { return (m_nID_City); }
		  set { m_nID_City = value; }
		}
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
		#endregion

		#region Protected Properties
		protected Int32 m_nID_City;
		protected Int32 m_nID_Region;
		protected String m_sName = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_City)
		{
			m_nID_City = nID_City;
		}
		#endregion
	}
}
