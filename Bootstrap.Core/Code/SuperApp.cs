using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap.Core.Code
{
    public class SuperApp
    {
        static SuperApp _instance = null;
        public static SuperApp Instance => _instance ?? (_instance = new SuperApp());
    }
}
