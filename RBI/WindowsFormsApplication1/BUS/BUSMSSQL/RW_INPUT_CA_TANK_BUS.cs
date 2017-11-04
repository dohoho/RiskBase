using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.BUSMSSQL
{
    class RW_INPUT_CA_TANK_BUS
    {
        RW_INPUT_CA_TANK_ConnUtils DAL = new RW_INPUT_CA_TANK_ConnUtils();
        public void add(RW_INPUT_CA_TANK obj)
        {
            DAL.Add(obj.FLUID_HEIGHT, obj.SHELL_COURSE_HEIGHT, obj.TANK_DIAMETTER, obj.Prevention_Barrier, obj.Environ_Sensitivity, obj.P_lvdike, obj.P_onsite, obj.P_offsite, obj.Soil_Type, obj.TANK_FLUID, obj.API_FLUID, obj.SW);
        }
        public void edit(RW_INPUT_CA_TANK obj)
        {
            DAL.Edit(obj.ID, obj.FLUID_HEIGHT, obj.SHELL_COURSE_HEIGHT, obj.TANK_DIAMETTER, obj.Prevention_Barrier, obj.Environ_Sensitivity, obj.P_lvdike, obj.P_onsite, obj.P_offsite, obj.Soil_Type, obj.TANK_FLUID, obj.API_FLUID, obj.SW);
        }
        public void delete(RW_INPUT_CA_TANK obj)
        {
            DAL.Delete(obj.ID);
        }
        public RW_INPUT_CA_TANK getData(int ID)
        {
            return DAL.getData(ID);
        }
    }
}
