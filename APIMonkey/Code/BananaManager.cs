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
        public Banana GetMyBanana(string bananaId)
        {
            Banana objBanana = new DataManager().GetMyBanana(bananaId);

            return objBanana;
        }

        public Banana PlantABanana(dynamic objBananaFlesh)
        {
            Banana objBanana = new Banana();
            objBanana._key = Guid.NewGuid();
            objBanana.flesh = objBananaFlesh;

            string firstError = new DataManager().PlantBanana(objBanana);

            if (!string.IsNullOrEmpty(firstError))
            {
                //Log database insert error
                return null;
            }

            return objBanana;
        }
    }
}