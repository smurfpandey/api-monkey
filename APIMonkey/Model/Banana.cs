using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;

namespace APIMonkey.Model
{

    public class Banana
    {
        public static string COLLECTION_NAME = "banana";

        public Guid _key { get; set; }

        public dynamic flesh { get; set; }
    }
}