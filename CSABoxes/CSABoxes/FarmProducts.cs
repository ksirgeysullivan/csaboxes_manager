using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSABoxes
{
    public class FarmProducts
    {
        public static List<string> Options()
        {
            var returnVal = new List<string>();

            returnVal.Add("APPLES (bag)");
            returnVal.Add("BROCCOLI (head)");
            returnVal.Add("CARROTS (bunch)");
            returnVal.Add("DAIKON RADISHES (bunch");
            returnVal.Add("EGGPLANT");
            returnVal.Add("FENNEL (bulb)");

            return returnVal;
        }
    }
}
