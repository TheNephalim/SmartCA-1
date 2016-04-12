using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Model.Projects
{
    public class Allowance
    {
        private decimal amount;
        private string title;
        
        public Allowance(string title, decimal amount)
        {
            this.title = title;
            this.amount = amount;
        }

        public string Title
        {
            get { return title; }
        }

        public decimal Amount
        {
            get { return amount; }
        }

    }
}
