using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI
{
    class TEST_FACILITY
    {
        public int FacilityID { set; get; }
        public int SiteID { set; get; }
        public String FacilityName { set; get; }
        public TEST_FACILITY(int id, int parentID, String name)
        {
            FacilityID = id;
            SiteID = parentID;
            FacilityName = name;
        }
    }
}
