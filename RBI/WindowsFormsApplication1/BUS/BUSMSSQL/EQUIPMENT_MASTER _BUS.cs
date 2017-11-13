using System;
using System.Collections.Generic;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class EQUIPMENT_MASTER_BUS
    {
        EQUIPMENT_MASTER_ConnectUtils DAL = new EQUIPMENT_MASTER_ConnectUtils();
        public void add(EQUIPMENT_MASTER obj)
        {
            DAL.add( obj.EquipmentNumber, obj.EquipmentTypeID, obj.EquipmentName, obj.CommissionDate, obj.DesignCodeID, obj.SiteID, obj.FacilityID, obj.ManufacturerID, obj.PFDNo, obj.ProcessDescription, obj.EquipmentDesc, obj.IsArchived, obj.Archived, obj.ArchivedBy);
        }
        public void edit(EQUIPMENT_MASTER obj)
        {
            DAL.edit(obj.EquipmentID, obj.EquipmentNumber, obj.EquipmentTypeID, obj.EquipmentName, obj.CommissionDate, obj.DesignCodeID, obj.SiteID, obj.FacilityID, obj.ManufacturerID, obj.PFDNo, obj.ProcessDescription, obj.EquipmentDesc, obj.IsArchived, obj.Archived, obj.ArchivedBy);
        }
        public void delete(EQUIPMENT_MASTER obj)
        {
            DAL.delete(obj.EquipmentID);
        }
        public List<EQUIPMENT_MASTER> getDataSource()
        {
            return DAL.getDataSource();
        }
        public int getSiteID(int eqID)
        {
            return DAL.getSiteID(eqID);
        }
        public int getEquipmentTypeID(int eqID)
        {
            return DAL.getEquipmentTypeID(eqID);
        }
    }
}
