using System;
using System.Diagnostics;

namespace Data.Hierarchy
{
	/// <summary>
	/// Public Asset Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("")]
	public class Asset
	{
		public Asset()
		{
		}

		public Asset(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild)
		{
			m_nID_Asset = nID_Asset;
			m_nLevel = nLevel;
			m_nID_AssetChild = nID_AssetChild;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Asset
		{
		  get { return (m_nID_Asset); }
		  set { m_nID_Asset = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Level
		{
		  get { return (m_nLevel); }
		  set { m_nLevel = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_AssetChild
		{
		  get { return (m_nID_AssetChild); }
		  set { m_nID_AssetChild = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Asset;
		protected Int32 m_nLevel;
		protected Int32 m_nID_AssetChild;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Asset, Int32 nLevel, Int32 nID_AssetChild)
		{
			m_nID_Asset = nID_Asset;
			m_nLevel = nLevel;
			m_nID_AssetChild = nID_AssetChild;
		}
		#endregion
	}
}
