using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase;
using PhoneXamarinAndroid.Model;
using Firebase.Firestore;

namespace PhoneXamarinAndroid.Helpers
{
    public class DataHelper
    {
        public static FirebaseFirestore GetDatabsase()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            app = null;

            if (app == null)
            {
                var option = new FirebaseOptions.Builder()
                    .SetProjectId("phonexamarinforms")
                    .SetApplicationId("phonexamarinforms")
                    .SetApiKey("AIzaSyDRdUy_dlmFzDeM1mbJ6ORFWSP2OWQfeGU")
                    .SetDatabaseUrl("https://phonexamarinforms.firebaseio.com")
                    .SetStorageBucket("phonexamarinforms.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, option, "phone_db");
                //var settings = new FirebaseFirestoreSettings.Builder().SetTimestampsInSnapshotsEnabled(true).Build();
                var firestore = FirebaseFirestore.GetInstance(app);

                //firestore.FirestoreSettings = settings;

                return firestore;

            }

            return FirebaseFirestore.GetInstance(app);

        }

        public static List<Phone> SeedData()
        {
            return new List<Phone>
            {
                new Phone { Id = 1, CompanyName = "Apple", Name = "IPhone XR", Price = "300", MemoryCapacity = "64", Color = "Black", PublishYear = DateTime.Now, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new Phone { Id = 2, CompanyName = "Apple", Name = "IPhone XS", Price = "300", MemoryCapacity = "64", Color = "Red", PublishYear = DateTime.Now, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now}            
            };
        }
    }
}