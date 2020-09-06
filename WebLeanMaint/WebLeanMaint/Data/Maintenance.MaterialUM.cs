using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public MaterialUM Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  06/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_MaterialUM = {ID_MaterialUM}")]
	public class MaterialUM
	{
		public MaterialUM()
		{
		}

		public MaterialUM(Int32 nID_MaterialUM)
		{
			m_nID_MaterialUM = nID_MaterialUM;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_MaterialUM
		{
		  get { return (m_nID_MaterialUM); }
		  set { m_nID_MaterialUM = value; }
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
		protected Int32 m_nID_MaterialUM;
		protected String m_sName = String.Empty;
		protected String m_sDescription = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_MaterialUM)
		{
			m_nID_MaterialUM = nID_MaterialUM;
		}
		#endregion
	}
}
