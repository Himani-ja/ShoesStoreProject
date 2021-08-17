using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.IEnumerable;

namespace ShoesData
{
    public class FileRepo
    {
        static List<shoes> cats = null;
        static string path = @".\shoes.xml";
        public List<shoes> Init()
        {
            cats = new List<shoes>(){
                    new shoes(){Id,Category},
                    
                };
            return cats;
        }
    }
}
