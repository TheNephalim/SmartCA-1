using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataContracts
{
    public abstract class ContractBase
    {
        private object key;
        
        public object Key
        {
            get { return key; }
            set { key = value; }
        }
    }
}
