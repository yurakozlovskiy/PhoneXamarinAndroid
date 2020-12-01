using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PhoneXamarinAndroid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneXamarinAndroid
{
    [Activity(Label = "PhoneDetailsActivity")]
    public class PhoneDetailsActivity : Activity
    {
        TextView nameDetailView;
        TextView companyNameDetailView;
        TextView priceDetailView;
        TextView colorDetailView;
        TextView publishYearDetailView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            //var phone = Intent.Extras.Get("phone_details");
            var phoneId = Intent.Extras.GetInt("phone_details");

            var phone = DataHelper.SeedData().Where(x => x.Id == phoneId).FirstOrDefault();

            SetContentView(Resource.Layout.phone_details_activity);

            nameDetailView = (TextView)FindViewById(Resource.Id.nameDetail);
            companyNameDetailView = (TextView)FindViewById(Resource.Id.companyNameDetail);
            colorDetailView = (TextView)FindViewById(Resource.Id.colorDetail);
            priceDetailView = (TextView)FindViewById(Resource.Id.priceDetail);
            publishYearDetailView = (TextView)FindViewById(Resource.Id.publishYearDetail);

            nameDetailView.Text = phone?.Name;
            companyNameDetailView.Text = phone?.CompanyName;
            colorDetailView.Text = phone?.Color;
            priceDetailView.Text = phone?.Price + "USD";
            publishYearDetailView.Text = phone?.PublishYear.Value.Date.ToString();

        }
    }
}