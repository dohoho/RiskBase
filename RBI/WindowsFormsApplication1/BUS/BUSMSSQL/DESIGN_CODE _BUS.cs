using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class DESIGN_CODE_BUS
    {
        DESIGN_CODE_ConnectUtils DAL = new DESIGN_CODE_ConnectUtils();
        public void add(DESIGN_CODE obj)
        {
            DAL.add(obj.DesignCode, obj.DesignCodeApp);
        }
        public void edit(DESIGN_CODE obj)
        {
            DAL.edit(obj.DesignCodeID, obj.DesignCode, obj.DesignCodeApp);
        }
        public void delete(DESIGN_CODE obj)
        {
            DAL.delete(obj.DesignCodeID);
        }
        public List<DESIGN_CODE> getDataSource()
        {
            return DAL.getDataSource();
        }
    }
}
