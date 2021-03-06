using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public GeographicCenter Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  27/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_GeographicCenter = {ID_GeographicCenter}")]
	public partial class GeographicCenter
	{
		public GeographicCenter()
		{
		}

		public GeographicCenter(Int32 nID_GeographicCenter)
		{
			m_nID_GeographicCenter = nID_GeographicCenter;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_GeographicCenter
		{
		  get { return (m_nID_GeographicCenter); }
		  set { m_nID_GeographicCenter = value; }
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
		public Int32 ID_GeographicCenterType
		{
		  get { return (m_nID_GeographicCenterType); }
		  set { m_nID_GeographicCenterType = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Double Latitude
		{
		  get { return (m_nLatitude); }
		  set { m_nLatitude = value; m_bLatitude_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Latitude_HasValue
		{
		  get { return (m_bLatitude_HasValue); }
		  set { m_bLatitude_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Double Longitude
		{
		  get { return (m_nLongitude); }
		  set { m_nLongitude = value; m_bLongitude_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Longitude_HasValue
		{
		  get { return (m_bLongitude_HasValue); }
		  set { m_bLongitude_HasValue = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Parent
		{
		  get { return (m_nID_Parent); }
		  set { m_nID_Parent = value; m_bID_Parent_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool ID_Parent_HasValue
		{
		  get { return (m_bID_Parent_HasValue); }
		  set { m_bID_Parent_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_GeographicCenter;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		protected Int32 m_nID_GeographicCenterType;
		protected Double m_nLatitude;
		protected bool m_bLatitude_HasValue;
		protected Double m_nLongitude;
		protected bool m_bLongitude_HasValue;
		protected Int32 m_nID_ObjStatus;
		protected Int32 m_nID_Parent;
		protected bool m_bID_Parent_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_GeographicCenter)
		{
			m_nID_GeographicCenter = nID_GeographicCenter;
		}
		#endregion
	}
}
