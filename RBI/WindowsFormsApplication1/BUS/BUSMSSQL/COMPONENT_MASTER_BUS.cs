using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class COMPONENT_MASTER_BUS
    {
        COMPONENT_MASTER_ConnectUtils DAL = new COMPONENT_MASTER_ConnectUtils();

        public void add(COMPONENT_MASTER obj)
        {
            DAL.add(obj.ComponentNumber, obj.EquipmentID, obj.ComponentTypeID, obj.ComponentName
                   , obj.ComponentDesc, obj.IsEquipment, obj.IsEquipmentLinked, obj.APIComponentTypeID);
        }
        public void edit(COMPONENT_MASTER obj)
        {
            DAL.edit(obj.ComponentID,obj.ComponentNumber, obj.EquipmentID, obj.ComponentTypeID, obj.ComponentName
                   , obj.ComponentDesc, obj.IsEquipment, obj.IsEquipmentLinked, obj.APIComponentTypeID);
        }
        public void delete(COMPONENT_MASTER obj)
        {
            DAL.delete(obj.ComponentID);
        }
        public List<COMPONENT_MASTER> getDataSource()
        {
            return DAL.getDataSource();
        }
        
    }
}
