using APIMonkey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIMonkey.Code
{
    public class BananaManager
    {
        public async Task<Banana> GetMyBanana(string bananaId)
        {
            Banana objBanana = await DataManager.GetMyBanana(bananaId);

            return objBanana;
        }

        public async Task<Banana> PlantABanana(dynamic objBananaFlesh)
        {
            Banana objBanana = new Banana();
            objBanana.Id = Guid.NewGuid();
            objBanana.flesh = objBananaFlesh;

            string firstError = await DataManager.PlantBanana(objBanana);

            if (!string.IsNullOrEmpty(firstError))
            {
                //Log database insert error
                return null;
            }

            return objBanana;
        }
    }
}