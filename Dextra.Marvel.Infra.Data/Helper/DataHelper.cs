using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dextra.Marvel.Infra.Data.Helper
{
    public static class DataHelper
    {
        public static List<int> GetIdList(string numberStr)
        {
            var idList = new List<int>();

            if (!string.IsNullOrEmpty(numberStr))
            {
                string[] splitted = numberStr.Split(',');
                for (int i = 0; i < splitted.Length; i++)
                {
                    int idOut;
                    if (int.TryParse(splitted[i], out idOut))
                        idList.Add(idOut);
                }
            }
            
            return idList;
        }
    }
}
