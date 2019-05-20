using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModusInc.Model
{
    [XmlRoot("data_x0024_")]
    public class InputDataModel
    {
        public string Name{ get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }          
    }
}
