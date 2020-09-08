using System;
using Android.Content;
using System.Collections.Generic;
using Android.Widget;
using Android.App;
using Android.Views;
using Android.Support.V7.Widget;
using Android.Graphics;

namespace AppLeanMaint.Views
{
	/// <summary>
	/// Public class to manage the FuelCards array for the ListView
	/// </summary>
	public class AdapterOrders : RecyclerView.Adapter
	{
		public AdapterOrders(PlanningWS.Order[] aItems)
			: base()
		{
			this.Items = aItems;
		}

		public event EventHandler<int> ItemClick;

		public PlanningWS.Order[] Items { get; set; }

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			// Inflate the CardView for the Car:
			View oItemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cardview_order, parent, false);

			// Create a ViewHolder to hold view references inside the CardView:
			ViewHolderOrder oHolder = new ViewHolderOrder(oItemView, OnItemClick);

			return (oHolder);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			ViewHolderOrder oHolder = holder as ViewHolderOrder;

			// Load the photo image resource from the photo album
			PlanningWS.Order oEntry = Items[position];

			oHolder.Update(oEntry);
		}

		public override int ItemCount
		{
			get
			{
				int nRet = 0;

				if (Items != null)
					nRet = Items.Length;

				return (nRet);
			}
		}

		void OnItemClick(int position)
		{
			if (ItemClick != null) ItemClick(this, position);
		}
	}
}

