using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Firebase.Firestore;
using PhoneXamarinAndroid.Adapter;
using PhoneXamarinAndroid.Helpers;
using PhoneXamarinAndroid.Model;

namespace PhoneXamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnSuccessListener
    {
        RecyclerView recyclerView;
        ImageView searchButton;
        EditText searchText;
        List<Phone> phones;

        PhoneAdapter adapter;

        FirebaseFirestore db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            recyclerView = (RecyclerView)FindViewById(Resource.Id.myRecyclerView);

            searchButton = (ImageView)FindViewById(Resource.Id.searchButton);
            searchText = (EditText)FindViewById(Resource.Id.searchText);

            phones = DataHelper.SeedData();

            

            db = DataHelper.GetDatabsase();

            var a = db.Collection("phones").Document("AIppzUUfprOLuMXga7PC").Get().AddOnSuccessListener(this);

            SetupRecycleView();

            //FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.addNewPhone);
            //fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void SetupRecycleView()
        {
            recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
            adapter = new PhoneAdapter(phones, this);
            recyclerView.SetAdapter(adapter);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            var snapshot = (DocumentSnapshot)result;

            var a = snapshot.Get("name").ToString();
            
        }
    }
}
