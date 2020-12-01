using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using PhoneXamarinAndroid.Model;
using System;
using System.Collections.Generic;

namespace PhoneXamarinAndroid.Adapter
{
    class PhoneAdapter : RecyclerView.Adapter
    {
        public event EventHandler<PhoneAdapterClickEventArgs> ItemClick;
        public event EventHandler<PhoneAdapterClickEventArgs> ItemLongClick;
        List<Phone> items;
        Phone phone;
        Context context;

        public PhoneAdapter(List<Phone> data, Context context)
        {
            items = data;
            this.context = context;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.phone_row, parent, false);
            //var id = Resource.Layout.__YOUR_ITEM_HERE;
            //itemView = LayoutInflater.From(parent.Context).
            //       Inflate(id, parent, false);

            var vh = new PhoneAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            phone = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as PhoneAdapterViewHolder;
            //holder.TextView.Text = items[position];

            holder.nameText.Text = phone.Name;
            holder.memoryCapacityText.Text = phone.MemoryCapacity + "GB";
            holder.colorText.Text = phone.Color + " Color";
            holder.priceText.Text = phone.Price + " USD";

            holder.ItemView.Click += onItemClick;
        }

        public override int ItemCount => items != null ? items.Count : 0;

        void OnClick(PhoneAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);

        void onItemClick(object sender, EventArgs args)
        {
            var intent = new Intent(context, typeof(PhoneDetailsActivity));

            intent.PutExtra("phone_details", phone.Id);
            context.StartActivity(intent);

        }

        void OnLongClick(PhoneAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class PhoneAdapterViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }

        public TextView nameText { get; set; }

        public TextView memoryCapacityText { get; set; }

        public TextView colorText { get; set; }

        public TextView priceText { get; set; }


        public PhoneAdapterViewHolder(View itemView, Action<PhoneAdapterClickEventArgs> clickListener,
                            Action<PhoneAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            //TextView = v;

            nameText = (TextView)itemView.FindViewById(Resource.Id.nameText);
            memoryCapacityText = (TextView)itemView.FindViewById(Resource.Id.memoryCapacityText);
            colorText = (TextView)itemView.FindViewById(Resource.Id.colorText);
            priceText = (TextView)itemView.FindViewById(Resource.Id.priceText);


            itemView.Click += (sender, e) => clickListener(new PhoneAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new PhoneAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class PhoneAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}