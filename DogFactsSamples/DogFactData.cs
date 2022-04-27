using System;
using System.Collections.Generic;

namespace DogFactsSamples
{
    public class MyFactData
    {
        public MyFactData()
        {
        }
        public static IEnumerable<MyFactData> All { private set; get; }
        public string TheFact { get; set; }
        public string ShortFact { get; set; }
        public string TheImage { get; set; }
        static MyFactData()
        {
            List<MyFactData> all = new List<MyFactData>();
            all.Add(new MyFactData() { TheFact = "I like to read, crochet, and work with animals", ShortFact = "My Hobbies", TheImage = "camille.jpg" });
            all.Add(new MyFactData() { TheFact = "My favorite language is JavaScript", ShortFact = "Favorite Language", TheImage = "javascript.png"});
            all.Add(new MyFactData() { TheFact = "I work at the library on campus", ShortFact = "Work", TheImage = "library.png"});
            all.Add(new MyFactData() { TheFact = "My favorite book is 'A Thousand Splendid Suns'", ShortFact = "Favorite Book", TheImage = "a_thousand_splendid_sungs.jpg"});
            all.Add(new MyFactData() { TheFact = "I will be starting an internship at Lanex LLC this upcoming June", ShortFact = "Internship", TheImage = "lanex.png" });
            All = all;

        }
    }
}