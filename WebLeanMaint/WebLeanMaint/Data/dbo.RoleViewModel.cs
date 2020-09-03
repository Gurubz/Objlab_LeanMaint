using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public RoleViewModel Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("Id = {Id}")]
	public class RoleViewModel
	{
		public RoleViewModel()
		{
		}

		public RoleViewModel(String sId)
		{
			m_sId = sId;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Id
		{
		  get { return (m_sId); }
		  set { m_sId = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Name
		{
		  get { return (m_sName); }
		  set { m_sName = value; m_bName_HasValue = true; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool Name_HasValue
		{
		  get { return (m_bName_HasValue); }
		  set { m_bName_HasValue = value; }
		}
		#endregion

		#region Protected Properties
		protected String m_sId = String.Empty;
		protected String m_sName = String.Empty;
		protected bool m_bName_HasValue;
		#endregion

		#region Friends Methods
		internal void SetKeys(String sId)
		{
			m_sId = sId;
		}
		#endregion
	}
}
