using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModusInc.Model
{
    public class BudgetModel
    {
        public double TotalInflow { get; set; }
        public double TotalOutflow { get; set; }
        public double WorkingBalance { get; set; }

        public BudgetModel()
        {

        }
    }
}
