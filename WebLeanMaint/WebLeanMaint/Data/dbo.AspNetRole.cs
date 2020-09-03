using System;
using System.Diagnostics;

namespace Data.dbo
{
	/// <summary>
	/// Public AspNetRole Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  03/09/2020  Created
	/// </remarks>
	[DebuggerDisplay("Id = {Id}")]
	public class AspNetRole
	{
		public AspNetRole()
		{
		}

		public AspNetRole(String sId)
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
		  set { m_sName = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public String Discriminator
		{
		  get { return (m_sDiscriminator); }
		  set { m_sDiscriminator = value; }
		}
		#endregion

		#region Protected Properties
		protected String m_sId = String.Empty;
		protected String m_sName = String.Empty;
		protected String m_sDiscriminator = String.Empty;
		#endregion

		#region Friends Methods
		internal void SetKeys(String sId)
		{
			m_sId = sId;
		}
		#endregion
	}
}
