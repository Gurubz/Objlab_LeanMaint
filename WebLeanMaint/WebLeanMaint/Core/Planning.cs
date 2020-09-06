using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using WebLeanMaint.WS;

namespace WebLeanMaint.Core
{
	public static class Planning
	{
		public static Data.Planning.OrderAsset[] GetAssetsInOrder(int ID_Order)
		{
			Data.Planning.OrderAssets aOrderAssets = new Data.Planning.OrderAssets();
			aOrderAssets.Load("ID_Order=" + EntitiesManagerBase.UTI_ValueToSql(ID_Order));

			return (aOrderAssets.ToArray());
		}

		public static Data.Maintenance.Asset[] GetAssetsForOrder(int ID_Order)
		{
			Data.Maintenance.Assets aAssets = new Data.Maintenance.Assets();

			Data.Planning.Order oOrder = Data.Planning.Orders.LoadOne(ID_Order);
			if (oOrder != null)
			{
				aAssets.Load("ID_ObjStatus=" + EntitiesManagerBase.UTI_ValueToSql((int)Data.Config.ObjStatuseEnum.Active), "Name");
			}
			else
			{
				aAssets.Load("ID_ObjStatus=" + EntitiesManagerBase.UTI_ValueToSql((int)Data.Config.ObjStatuseEnum.Active), "Name");
			}

			return (aAssets.ToArray());
		}

		public static Data.Maintenance.Material[] GetMaterialsForOrder(int ID_Order)
		{
			SortedList<int, Data.Maintenance.Material> aRet = new SortedList<int, Data.Maintenance.Material>();

			foreach (Data.Planning.OrderAsset oOrderAsset in GetAssetsInOrder(ID_Order))
			{
				foreach (Data.Maintenance.Material oMaterial in GetMaterialsForAsset(oOrderAsset.ID_Asset))
				{
					if (aRet.ContainsKey(oMaterial.ID_Material) == false)
					{
						aRet.Add(oMaterial.ID_Material, oMaterial);
					}
				}
			}

			return (aRet.Values.ToArray());
		}

		public static Data.Maintenance.Material[] GetMaterialsForAsset(int ID_Asset)
		{
			SortedList<int, Data.Maintenance.Material> aRet = new SortedList<int, Data.Maintenance.Material>();

			Data.Maintenance.MaterialAssets aMaterialAssets = new Data.Maintenance.MaterialAssets();
			aMaterialAssets.Load("ID_Asset=" + EntitiesManagerBase.UTI_ValueToSql(ID_Asset));
			foreach (Data.Maintenance.MaterialAsset oMaterialAsset in aMaterialAssets)
			{
				if (aRet.ContainsKey(oMaterialAsset.ID_Material) == false)
				{
					Data.Maintenance.Material oMaterial = Data.Maintenance.Materials.LoadOne(oMaterialAsset.ID_Material);

					aRet.Add(oMaterial.ID_Material, oMaterial);
				}
			}

			return (aRet.Values.ToArray());
		}
	}
}