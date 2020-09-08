using System;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace AppLeanMaint.Views
{
	public class ViewHolderOrder : RecyclerView.ViewHolder
	{
		public ViewHolderOrder(View oItemView, Action<int> oClickListener) : base(oItemView)
		{
			this.ID_Order = oItemView.FindViewById<TextView>(Resource.Id.cardview_order_id_order);
			this.Asset = oItemView.FindViewById<TextView>(Resource.Id.cardview_order_asset);
			this.Operator = oItemView.FindViewById<TextView>(Resource.Id.cardview_order_operator);
			this.Description = oItemView.FindViewById<TextView>(Resource.Id.cardview_order_description);

			oItemView.Click += (sender, e) => oClickListener(this.Position);
		}

		public void Update(PlanningWS.Order oOrder)
		{
			this.ID_Order.Text = oOrder.ID_Order.ToString();
			int? nID_Asset = oOrder.Assets.FirstOrDefault()?.ID_Asset;
			PlanningWS.Asset oAsset = Helpers.Database.Current.GetAsset(nID_Asset.Value);
			if (oAsset != null) this.Asset.Text = oAsset.Description;
			int? nID_Operator = oOrder.Operators.FirstOrDefault()?.ID_Operator;
			PlanningWS.Operator oOperator = Helpers.Database.Current.GetOperator(nID_Operator.Value);
			if (oOperator != null) this.Operator.Text = oOperator.Description;
			this.Description.Text = oOrder.Description;
		}

		public TextView ID_Order { get; private set; }
		public TextView Asset { get; private set; }
		public TextView Description { get; private set; }
		public TextView Operator { get; private set; }
	}
}

