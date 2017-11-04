using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI
{
    class TEST_EQUIPMENT
    {
        public int equipmentID { set; get; }
        public int facilityID { set; get; }
        public String equipmentName { set; get; }
        public TEST_EQUIPMENT(int id, int parentID, String name)
        {
            equipmentID = id;
            facilityID = parentID;
            equipmentName = name;
        }
    }
}
