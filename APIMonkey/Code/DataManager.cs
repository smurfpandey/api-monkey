using APIMonkey.Model;
using RethinkDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIMonkey.Code
{
    public class DataManager
    {
        private static IConnectionFactory connectionFactory =
            RethinkDb.Newtonsoft.Configuration.ConfigurationAssembler.CreateConnectionFactory("apimonkey");


        /// <summary>
        /// Get the banana by it's ID
        /// </summary>
        /// <param name="bananaId">The unique ID of the banana</param>
        /// <returns>Banana object</returns>
        public static async Task<Banana> GetMyBanana(string bananaId)
        {
            Banana objBanana = null;
            using (IConnection conn = connectionFactory.Get())
            {
                objBanana = await conn.RunAsync(Banana.Table.Get(bananaId));
            }

            return objBanana;
        }

        public static async Task<string> PlantBanana(Banana objBanana)
        {
            string firstError = string.Empty;            
            using (IConnection conn = connectionFactory.Get())
            {
                var response = await conn.RunAsync(Banana.Table.Insert(objBanana));

                if (response.Errors > 0)
                {
                    firstError = response.FirstError;
                    return firstError;
                }                
            }

            return firstError;
        }
    }
}