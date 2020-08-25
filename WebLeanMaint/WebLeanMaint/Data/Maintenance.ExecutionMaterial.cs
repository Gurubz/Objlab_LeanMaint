using System;
using System.Diagnostics;

namespace Data.Maintenance
{
	/// <summary>
	/// Public ExecutionMaterial Class
	/// </summary>
	/// <remarks>
	/// 	[SQLClassGenerator]  25/08/2020  Created
	/// </remarks>
	[DebuggerDisplay("ID_Execution = {ID_Execution}, ID_Material = {ID_Material}")]
	public class ExecutionMaterial
	{
		public ExecutionMaterial()
		{
		}

		public ExecutionMaterial(Int32 nID_Execution, Int32 nID_Material)
		{
			m_nID_Execution = nID_Execution;
			m_nID_Material = nID_Material;
		}

		#region Public Properties
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Execution
		{
		  get { return (m_nID_Execution); }
		  set { m_nID_Execution = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 ID_Material
		{
		  get { return (m_nID_Material); }
		  set { m_nID_Material = value; }
		}
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Int32 Quantity
		{
		  get { return (m_nQuantity); }
		  set { m_nQuantity = value; }
		}
		#endregion

		#region Protected Properties
		protected Int32 m_nID_Execution;
		protected Int32 m_nID_Material;
		protected Int32 m_nQuantity;
		#endregion

		#region Friends Methods
		internal void SetKeys(Int32 nID_Execution, Int32 nID_Material)
		{
			m_nID_Execution = nID_Execution;
			m_nID_Material = nID_Material;
		}
		#endregion
	}
}
