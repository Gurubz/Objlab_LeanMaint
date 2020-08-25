using System;
using System.Diagnostics;

namespace Data.Hierarchy
{
	/// <summary>
	/// Public GeographicCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("")]
	public class GeographicCenter
	{
		public GeographicCenter()
		{
		}

		public GeographicCenter(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild)
		{
			m_nID_GeographicCenter = nID_GeographicCenter;
			m_nLevel = nLevel;
			m_nID_GeographicCenterChild = nID_GeographicCenterChild;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_GeographicCenter
		{
		  get { return (m_nID_GeographicCenter); }
		  set { m_nID_GeographicCenter = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Level
		{
		  get { return (m_nLevel); }
		  set { m_nLevel = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_GeographicCenterChild
		{
		  get { return (m_nID_GeographicCenterChild); }
		  set { m_nID_GeographicCenterChild = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_GeographicCenter;
		protected Int32 m_nLevel;
		protected Int32 m_nID_GeographicCenterChild;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_GeographicCenter, Int32 nLevel, Int32 nID_GeographicCenterChild)
		{
			m_nID_GeographicCenter = nID_GeographicCenter;
			m_nLevel = nLevel;
			m_nID_GeographicCenterChild = nID_GeographicCenterChild;
		}
		#endregion
	}
}
