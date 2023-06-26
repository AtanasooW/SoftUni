using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucks.Utilities
{
    public class Restrictions
    {
        //Client

        //Client -> Name
        public const int ClientMinCharName = 3;
        public const int ClientMaxCharName = 40;
        //Client -> Nationality
        public const int ClientMinCharNationality = 2;
        public const int ClientMaxCharNationality = 40;

        //Despatcher
        public const int DespatcherMinCharName = 2;
        public const int DespatcherMaxCharName = 40;
    }
}
