using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public GeographicCenterType Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_GeographicCenterType = {ID_GeographicCenterType}")]
	public class GeographicCenterType
	{
		public GeographicCenterType()
		{
		}

		public GeographicCenterType(Int32 nID_GeographicCenterType)
		{
			m_nID_GeographicCenterType = nID_GeographicCenterType;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_GeographicCenterType
		{
		  get { return (m_nID_GeographicCenterType); }
		  set { m_nID_GeographicCenterType = value; }
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
		protected Int32 m_nID_GeographicCenterType;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_GeographicCenterType)
		{
			m_nID_GeographicCenterType = nID_GeographicCenterType;
		}
		#endregion
	}
}
