using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Core
{
	public static class Maintenance
	{
		public static Data.Maintenance.Execution CreateExecutionFromOrder(int nID_Order)
		{
			Data.Maintenance.Execution oRet = null;
			Data.Planning.Order oOrder = Data.Planning.Orders.LoadOne(nID_Order);
			if (oOrder != null)
			{
				Data.Maintenance.Executions aExecutions = new Data.Maintenance.Executions();
				aExecutions.Load("ID_Order=" + EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_Order));
				if (aExecutions.Count == 1)
				{
					oRet = aExecutions[0];
				}
				else
				{
					oRet = new Data.Maintenance.Execution();
					oRet.ID_ExecutionType = (int)Data.Maintenance.ExecutionTypeEnum.Planned;
					oRet.ID_Order = oOrder.ID_Order;
					oRet.ID_Priority = (int)Data.Maintenance.ExecutionPriorityEnum.Routine;
					oRet.StartedAt = DateTime.Now;
					Data.Maintenance.Executions.InsertOne(oRet);

					Data.Planning.OrderAssets aOrderAssets = new Data.Planning.OrderAssets();
					Data.Planning.OrderAssetMaterials aOrderAssetMaterials = new Data.Planning.OrderAssetMaterials();
					Data.Planning.OrderOperators aOrderOperators = new Data.Planning.OrderOperators();

					aOrderAssets.Load("ID_Order=" + EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_Order));
					foreach (Data.Planning.OrderAsset oOrderAsset in aOrderAssets)
					{
						Data.Maintenance.ExecutionAsset oExecutionAsset = new Data.Maintenance.ExecutionAsset();
						oExecutionAsset.ID_Execution = oRet.ID_Execution;
						oExecutionAsset.ID_Asset = oOrderAsset.ID_Asset;
						oExecutionAsset.Stopped = oOrderAsset.StopRequired;
						Data.Maintenance.ExecutionAssets.InsertOne(oExecutionAsset);

						aOrderAssetMaterials.Load("ID_OrderAsset=" + EntitiesManagerBase.UTI_ValueToSql(oOrderAsset.ID_OrderAsset));
						foreach (Data.Planning.OrderAssetMaterial oOrderAssetMaterial in aOrderAssetMaterials)
						{
							Data.Maintenance.ExecutionAssetMaterial oExecutionAssetMaterial = new Data.Maintenance.ExecutionAssetMaterial();
							oExecutionAssetMaterial.ID_ExecutionAsset = oExecutionAsset.ID_ExecutionAsset;
							oExecutionAssetMaterial.ID_Material = oOrderAssetMaterial.ID_Material;
							oExecutionAssetMaterial.Quantity = oOrderAssetMaterial.Quantity;
							Data.Maintenance.ExecutionAssetMaterials.InsertOne(oExecutionAssetMaterial);
						}
					}

					aOrderOperators.Load("ID_Order=" + EntitiesManagerBase.UTI_ValueToSql(oOrder.ID_Order));
					foreach (Data.Planning.OrderOperator oOrderOperator in aOrderOperators)
					{
						Data.Maintenance.ExecutionOperator oExecutionOperator = new Data.Maintenance.ExecutionOperator();
						oExecutionOperator.ID_Execution = oRet.ID_Execution;
						oExecutionOperator.ID_Operator = oOrderOperator.ID_Operator;
						Data.Maintenance.ExecutionOperators.InsertOne(oExecutionOperator);
					}
				}
			}

			return (oRet);
		}
	}
}