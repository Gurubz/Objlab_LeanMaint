using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public __MigrationHistory Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("MigrationId = {MigrationId}, ContextKey = {ContextKey}")]
	public class __MigrationHistory
	{
		public __MigrationHistory()
		{
		}

		public __MigrationHistory(String sMigrationId, String sContextKey)
		{
			m_sMigrationId = sMigrationId;
			m_sContextKey = sContextKey;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String MigrationId
		{
		  get { return (m_sMigrationId); }
		  set { m_sMigrationId = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ContextKey
		{
		  get { return (m_sContextKey); }
		  set { m_sContextKey = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Byte[] Model
		{
		  get { return (m_aModel); }
		  set { m_aModel = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String ProductVersion
		{
		  get { return (m_sProductVersion); }
		  set { m_sProductVersion = value; }
		}
		#endregion

		#region Protected Properties
		protected String m_sMigrationId = String.Empty;
		protected String m_sContextKey = String.Empty;
		protected Byte[] m_aModel;
		protected String m_sProductVersion = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(String sMigrationId, String sContextKey)
		{
			m_sMigrationId = sMigrationId;
			m_sContextKey = sContextKey;
		}
		#endregion
	}
}
