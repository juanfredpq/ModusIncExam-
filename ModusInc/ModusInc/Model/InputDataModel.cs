using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModusInc.Model
{
    [XmlRoot("InputData")]
    public class InputDataModel
    {       
        public string Category { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        BudgetModel composeBudget { get; set; }
        public InputDataModel() { }
    }
}
