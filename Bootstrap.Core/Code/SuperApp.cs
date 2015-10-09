using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.Code
{
    public class SuperApp
    {
        static SuperApp _instance = null;
        public static SuperApp Instance
        {
            get
            {

                if (_instance == null)
                {
                    _instance = new SuperApp();
                }
                return _instance;
            }
        }
    }
}
