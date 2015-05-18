using Newtonsoft.Json.Linq;
using RethinkDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APIMonkey.Model
{
    [DataContract]
    public class Banana
    {
        public static IDatabaseQuery Db = Query.Db("apimonkey");
        public static ITableQuery<Banana> Table = Db.Table<Banana>("banana");

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        public dynamic flesh { get; set; }
    }
}