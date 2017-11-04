using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI
{
    class TEST_SITE
    {
        public int SiteID { set; get; }
        public int ParentID { set; get; }
        public String SiteName { set; get; }
        public TEST_SITE(int id, String name)
        {
            SiteID = id;
            ParentID = -1;
            SiteName = name;
        }
    }
}
