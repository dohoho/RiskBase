using RBI.DAL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS
{
    class BusInspectionPlant
    {
        InspectionPlant insp = new InspectionPlant();
        InspectionPlantConnUtils inspUtils = new InspectionPlantConnUtils();
        public void add( InspectionPlant insp)
        {
            inspUtils.add(insp.ItemNo,
                        insp.DamageMechanism,
                        insp.Method,
                        insp.Coverage,
                        insp.Availability,
                        insp.LastInspectionDate,
                        insp.InspectionInterval,
                        insp.DueDate,
                        insp.System);
        }
        public void edit( InspectionPlant insp, String olderDamageMechanism,String olderMethod,String olderItemNo)
        {
            inspUtils.edit(insp.ItemNo,
                        insp.DamageMechanism,
                        insp.Method,
                        insp.Coverage,
                        insp.Availability,
                        insp.LastInspectionDate,
                        insp.InspectionInterval,
                        insp.DueDate,
                        insp.System,
                        olderDamageMechanism,
                        olderMethod,
                        olderItemNo);
        }
        public void delete(InspectionPlant insp)
        {
            inspUtils.delete(insp.DamageMechanism, insp.Method, insp.ItemNo);
        }
        public List<InspectionPlant> loads()
        {
            return inspUtils.loads();
        }
    }
}
