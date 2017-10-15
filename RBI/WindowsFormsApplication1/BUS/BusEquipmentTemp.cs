using RBI.DAL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS
{
    class BusEquipmentTemp
    {
        EquipmentTemp eqTem = new EquipmentTemp();
        EquipmentTempConnUtils eqTemUtils = new EquipmentTempConnUtils();
        
        public void add(EquipmentTemp eqTem)
        {
            int max = eqTemUtils.loads().Count;
            eqTem.Count = max + 1;
            eqTemUtils.add(eqTem.ItemNo,
                           eqTem.ComName,
                           eqTem.Plant,
                           eqTem.OperingPressInlet,
                           eqTem.OperTempInlet,
                           eqTem.OperingPressOutlet,
                           eqTem.OperTempOutlet,
                           eqTem.TestPress,
                           eqTem.MDMT,
                           eqTem.InService,
                           eqTem.ServiceDate,
                           eqTem.LastInternalInspectionDate,
                           eqTem.LDTBXHCovered,
                           eqTem.Insulated,
                           eqTem.PWHT,
                           eqTem.InsulatedType,
                           eqTem.OperatingState,
                           eqTem.InventoryLiquip,
                           eqTem.InventoryVapor,
                           eqTem.InventoryTotal,
                           eqTem.ConfidentInStreamAnalysis,
                           eqTem.VaporDensityAir,
                           eqTem.CorrosionInhibitor,
                           eqTem.FrequentFeedChanged,
                           eqTem.MajorChemicals,
                           eqTem.Contaminants,
                           eqTem.OnLineMonitoring,
                           eqTem.CathodicProtection,
                           eqTem.CorrosionMonitoring,
                           eqTem.OHCalibUptodate,
                           eqTem.DistFromFacility,
                           eqTem.EquipCount,
                           eqTem.HAZOPRating,
                           eqTem.PersonalDensity,
                           eqTem.MitigationEquip,
                           eqTem.EnvRating,
                           eqTem.InspTechUsed,
                           eqTem.EquipModification,
                           eqTem.InspectionFinding,
                           eqTem.VaporDensity,
                           eqTem.LiquipDensity,
                           eqTem.Vapor,
                           eqTem.Liquip,
                           eqTem.HMBPFDNum,
                           eqTem.PIDNum,
                           eqTem.Service,
                           eqTem.HMBStream,
                           eqTem.Count);
        }
        public void edit(int count)
        {
            eqTemUtils.edit(eqTem.ItemNo,
                           eqTem.ComName,
                           eqTem.Plant,
                           eqTem.OperingPressInlet,
                           eqTem.OperTempInlet,
                           eqTem.OperingPressOutlet,
                           eqTem.OperTempOutlet,
                           eqTem.TestPress,
                           eqTem.MDMT,
                           eqTem.InService,
                           eqTem.ServiceDate,
                           eqTem.LastInternalInspectionDate,
                           eqTem.LDTBXHCovered,
                           eqTem.Insulated,
                           eqTem.PWHT,
                           eqTem.InsulatedType,
                           eqTem.OperatingState,
                           eqTem.InventoryLiquip,
                           eqTem.InventoryVapor,
                           eqTem.InventoryTotal,
                           eqTem.ConfidentInStreamAnalysis,
                           eqTem.VaporDensityAir,
                           eqTem.CorrosionInhibitor,
                           eqTem.FrequentFeedChanged,
                           eqTem.MajorChemicals,
                           eqTem.Contaminants,
                           eqTem.OnLineMonitoring,
                           eqTem.CathodicProtection,
                           eqTem.CorrosionMonitoring,
                           eqTem.OHCalibUptodate,
                           eqTem.DistFromFacility,
                           eqTem.EquipCount,
                           eqTem.HAZOPRating,
                           eqTem.PersonalDensity,
                           eqTem.MitigationEquip,
                           eqTem.EnvRating,
                           eqTem.InspTechUsed,
                           eqTem.EquipModification,
                           eqTem.InspectionFinding,
                           eqTem.VaporDensity,
                           eqTem.LiquipDensity,
                           eqTem.Vapor,
                           eqTem.Liquip,
                           eqTem.HMBPFDNum,
                           eqTem.PIDNum,
                           eqTem.Service,
                           eqTem.HMBStream,
                           eqTem.Count);
        }
        public void delete(int count)
        {
            eqTemUtils.delete(count);
        }
        public List<EquipmentTemp> loads()
        {
            return eqTemUtils.loads();
        }
        public bool checkExist(int count)
        {
            return eqTemUtils.checkExist(count);
        }
        public double getMass(String itemNo, String comName)
        {
            return eqTemUtils.getMass(itemNo, comName);
        }
        public bool checkExist(String plant, String itemNo, String comName)
        {
            return eqTemUtils.checkExist(plant, itemNo, comName);
        }
    }
}
