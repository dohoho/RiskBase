using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class SITES_BUS
    {
        SITES_ConnectUtils DAL = new SITES_ConnectUtils();
        public void add(SITES obj)
        {
            DAL.add(obj.SiteName);
        }
        public void edit(SITES obj)
        {
            DAL.edit(obj.SiteID, obj.SiteName);
        }
        public void delete(SITES obj)
        {
            DAL.delete(obj.SiteID);
        }
        public List<SITES> getData()
        {
            return DAL.getDataSource();
        }
    }
}
