using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI
{
    class TEST_COMPONENT
    {
        public int componentID { set; get; }
        public int equipmentID { set; get; }
        public String componentName { set; get; }
        public TEST_COMPONENT(int id, int parentID, String name)
        {
            componentID = id;
            equipmentID = parentID;
            componentName = name;
        }
    }
}
