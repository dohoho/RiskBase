using RBI.DAL.MSSQL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object.ObjectMSSQL;
namespace RBI.BUS.BUSMSSQL
{
    class RW_FULL_FCOF_BUS
    {
        RW_FULL_FCOF_ConnectUtils DAL = new RW_FULL_FCOF_ConnectUtils();
        public void add(RW_FULL_FCOF obj)
        {
            DAL.add(obj.ID, obj.FCoFValue, obj.FCoFCategory, obj.AIL, obj.envcost, obj.equipcost, obj.prodcost, obj.popdens, obj.injcost, obj.FCoFMatrixValue);
        }
        public void edit(RW_FULL_FCOF obj)
        {
            DAL.edit(obj.ID, obj.FCoFValue, obj.FCoFCategory, obj.AIL, obj.envcost, obj.equipcost, obj.prodcost, obj.popdens, obj.injcost, obj.FCoFMatrixValue);
        
        }
        public void delete(RW_FULL_FCOF obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_FULL_FCOF> getDataSource()
        {
            return DAL.getDataSource();
        }

    }
}
