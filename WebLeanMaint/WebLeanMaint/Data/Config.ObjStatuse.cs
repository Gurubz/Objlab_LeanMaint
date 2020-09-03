using System;
using System.Diagnostics;

namespace Data.Config
{
	/// <summary>
	/// Public ObjStatuse Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_ObjStatus = {ID_ObjStatus}")]
	public class ObjStatuse
	{
		public ObjStatuse()
		{
		}

		public ObjStatuse(Int32 nID_ObjStatus)
		{
			m_nID_ObjStatus = nID_ObjStatus;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_ObjStatus
		{
		  get { return (m_nID_ObjStatus); }
		  set { m_nID_ObjStatus = value; }
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
		protected Int32 m_nID_ObjStatus;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_ObjStatus)
		{
			m_nID_ObjStatus = nID_ObjStatus;
		}
		#endregion
	}
}
