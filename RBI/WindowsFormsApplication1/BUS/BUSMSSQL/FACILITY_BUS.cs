using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class FACILITY_BUS
    {
        FACILITY_ConnectUtils DAL = new FACILITY_ConnectUtils();
        public void add(FACILITY obj)
        {
            DAL.add(obj.SiteID, obj.FacilityName, obj.ManagementFactor);
        }
        public void edit(FACILITY obj)
        {
            DAL.edit(obj.FacilityID, obj.SiteID, obj.FacilityName, (float)obj.ManagementFactor);
        }
        public void delete(FACILITY obj)
        {
            DAL.delete(obj.FacilityID);
        }
        public List<FACILITY> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
