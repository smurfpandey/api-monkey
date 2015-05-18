using APIMonkey.Model;
using Arango.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIMonkey.Code
{
    public class DataManager
    {
        private static string DATABASE = "apimonkey";

        public DataManager()
        {
            if (!ASettings.HasConnection(DATABASE))
            {
                // adds new connection data to database manager
                ASettings.AddConnection(
                    DATABASE,
                    "127.0.0.1",
                    8529,
                    false,
                    "apimonkey",
                    "webapp",
                    "qweasdzxc"
                );
            }
        }

        /// <summary>
        /// Get the banana by it's ID
        /// </summary>
        /// <param name="bananaId">The unique ID of the banana</param>
        /// <returns>Banana object</returns>
        public Banana GetMyBanana(string bananaId)
        {
            Banana objBanana = null;

            // initialize new database context
            var db = new ADatabase(DATABASE);

            // retrieve specified document
            string docHandle = Banana.COLLECTION_NAME + "/" + bananaId;
            var getResult = db.Document.Get(docHandle);

            if (getResult.Success)
            {
                //We got a values
                var resultVal = getResult.Value;
                string strValue = JsonConvert.SerializeObject(resultVal);
                objBanana = JsonConvert.DeserializeObject<Banana>(strValue);
            }
            else
            {
                //Log this error
                Logger.TraceDBError(getResult.Error);
            }

            return objBanana;
        }

        public string PlantBanana(Banana objBanana)
        {
            string firstError = string.Empty;

            // initialize new database context
            var db = new ADatabase(DATABASE);

            var createDocumentResult = db.Document
                .WaitForSync(true)
                .Create(Banana.COLLECTION_NAME, JsonConvert.SerializeObject(objBanana));

            if (createDocumentResult.Success)
            {
                var id = createDocumentResult.Value.String("_id");                
                var key = createDocumentResult.Value.String("_key");
                var revision = createDocumentResult.Value.String("_rev");
            }
            else
            {
                firstError = createDocumentResult.Error.Message;

                //Log this error
                Logger.TraceDBError(createDocumentResult.Error);
            }

            return firstError;
        }
    }
}