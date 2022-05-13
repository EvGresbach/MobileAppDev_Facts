using System;
using System.Collections.Generic; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DogFactsSamples.Data; 
using DogFactsSamples.Models; 

namespace DogFactsSamples
{
    public partial class App : Application
    {
        static DogFactsSamplesDatabase database; 
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        public static DogFactsSamplesDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DogFactsSamplesDatabase(); 
                    prefillDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        static void prefillDatabase()
        {
            database.ClearAllAsync();
            List<MyFact> items = new List<MyFact>(); 
                items.Add(new MyFact() { TheFact = "I like to read, crochet, and work with animals", ShortFact = "My Hobbies", TheImage = "camille.jpg" });
                items.Add(new MyFact() { TheFact = "My favorite language is JavaScript", ShortFact = "Favorite Language", TheImage = "javascript.png"});
                items.Add(new MyFact() { TheFact = "I work at the library on campus", ShortFact = "Work", TheImage = "library.png"});
                items.Add(new MyFact() { TheFact = "My favorite book is 'A Thousand Splendid Suns'", ShortFact = "Favorite Book", TheImage = "a_thousand_splendid_sungs.jpg"});
                items.Add(new MyFact() { TheFact = "I will be starting an internship at Lanex LLC this upcoming June", ShortFact = "Internship", TheImage = "lanex.png" });
                database.InsertList(items); 
        }
    }
}
