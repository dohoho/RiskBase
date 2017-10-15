using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.DAL;
namespace RBI.BUS.BUSExcel
{
    class FullplantObjectExcel
    {
        FullPlantObject plant;
        ExcelConnect exConn = new ExcelConnect();
        public OleDbConnection getConnect(String path)
        {
            return exConn.connectionExcel(path);
        }
        public List<FullPlantObject> getListPlant(String path)
        {
            List<FullPlantObject> list = new List<FullPlantObject>();
            OleDbConnection conn = getConnect(path);
            try
            {
                conn.Open();
                String cmd = "select * from [Data$]";
                OleDbCommand command = new OleDbCommand(cmd, conn);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader[2].ToString().Equals(""))
                    {
                        plant = new FullPlantObject();
                        //
                        plant.PLANT = reader[0].ToString();
                        //
                        plant.Unit = reader[1].ToString();
                        //
                        plant.EquipNum = reader[2].ToString();
                        //
                        plant.EquipDescrip = reader[3].ToString();
                        //
                        plant.EquipType = reader[4].ToString();
                        //
                        plant.SubComponent = reader[5].ToString();
                        //
                        plant.SubComponentDescrip = reader[6].ToString();
                        //
                        plant.MOC = reader[7].ToString();
                        //
                        plant.LMOC = reader[8].ToString();
                        //
                        try
                        {
                            plant.HeightLength = reader.GetDouble(9);
                        }
                        catch
                        {
                            plant.HeightLength = 0;
                        }
                        //
                        try
                        {
                            plant.Diameter = reader.GetDouble(10);
                        }
                        catch
                        {
                            plant.Diameter = 0;
                        }
                        //
                        try
                        {
                            plant.NominalThick = reader.GetDouble(11);
                        }
                        catch
                        {
                            plant.NominalThick = 0;
                        }
                        //
                        try
                        {
                            plant.CA = reader.GetDouble(12);
                        }
                        catch
                        {
                            plant.CA = 0;
                        }
                        //
                        try
                        {
                            plant.DesignPressure = reader.GetDouble(13);
                        }
                        catch
                        {
                            plant.DesignPressure = 0;
                        }
                        //
                        try
                        {
                            plant.DesignTemp = reader.GetDouble(14);
                        }
                        catch
                        {
                            plant.DesignTemp = 0;
                        }
                        //
                        try
                        {
                            plant.OPPressInlet = reader.GetDouble(15);
                        }
                        catch
                        {
                            plant.OPPressInlet = 0;
                        }
                        //
                        try
                        {
                            plant.OPTempInlet = reader.GetDouble(16);
                        }
                        catch
                        {
                            plant.OPTempInlet = 0;
                        }
                        //
                        try
                        {
                            plant.OPPressOutlet = reader.GetDouble(17);
                        }
                        catch
                        {
                            plant.OPPressOutlet = 0;
                        }
                        //
                        try
                        {
                            plant.OPTempOutlet = reader.GetDouble(18);
                        }
                        catch
                        {
                            plant.OPTempOutlet = 0;
                        }
                        //
                        try
                        {
                            plant.TestPress = reader.GetDouble(19);
                        }
                        catch
                        {
                            plant.TestPress = 0;
                        }
                        //
                        try
                        {
                            plant.MDMT = reader.GetDouble(20);
                        }
                        catch
                        {
                            plant.MDMT = 0;
                        }
                        //
                        if (reader[21].ToString() == "-1")
                            plant.InService = true;
                        else
                            plant.InService = false;
                        //
                        plant.ServiceDate = reader[22].ToString();
                        //
                        plant.LastIsnpDate = reader[23].ToString();
                        //
                        if (reader[24].ToString() == "-1")
                            plant.LDTBXH = true;
                        else
                            plant.LDTBXH = false;
                        //
                        if (reader[25].ToString() == "-1")
                            plant.Insulated = true;
                        else
                            plant.Insulated = false;
                        //
                        if (reader[26].ToString() == "-1")
                            plant.PWHT = true;
                        else
                            plant.PWHT = false;
                        //
                        plant.InsulationType = reader[27].ToString();
                        //
                        plant.OperatingState = reader[28].ToString();
                        //
                        try
                        {
                            plant.InventoryLiquid = reader.GetDouble(29);
                        }
                        catch
                        {
                            plant.InventoryLiquid = 0;
                        }
                        //
                        try
                        {
                            plant.InventoryVapor = reader.GetDouble(30);
                        }
                        catch
                        {
                            plant.InventoryVapor = 0;
                        }
                        //
                        try
                        {
                            plant.InventoryTotal = reader.GetDouble(31);
                        }
                        catch
                        {
                            plant.InventoryTotal = 0;
                        }
                        //
                        if (reader[32].ToString() == "-1")
                            plant.ConfidentInstream = true;
                        else
                            plant.ConfidentInstream = false;
                        //
                        if (reader[33].ToString() == "-1")
                            plant.VaporDensityLessAir = true;
                        else
                            plant.VaporDensityLessAir = false;
                        //
                        if (reader[34].ToString() == "-1")
                            plant.CorrosionInhibitor = true;
                        else
                            plant.CorrosionInhibitor = false;
                        //
                        if (reader[35].ToString() == "-1")
                            plant.PrequentFeedChange = true;
                        else
                            plant.PrequentFeedChange = false;
                        //
                        try
                        {
                            plant.MajorChemicals = reader.GetDouble(36);
                        }
                        catch
                        {
                            plant.MajorChemicals = 0;
                        }
                        //
                        plant.Contaminant = reader[37].ToString();
                        //
                        if (reader[38].ToString() == "-1")
                            plant.OnlineMonitor = true;
                        else
                            plant.OnlineMonitor = false;
                        //
                        if (reader[39].ToString() == "-1")
                            plant.CathodicProtection = true;
                        else
                            plant.CathodicProtection = false;
                        //
                        if (reader[40].ToString() == "-1")
                            plant.CorrosionMonitor = true;
                        else
                            plant.CorrosionMonitor = false;
                        //
                        if (reader[41].ToString() == "-1")
                            plant.OHCalibUpDate = true;
                        else
                            plant.OHCalibUpDate = false;
                        // Dist Facility
                        try
                        {
                            plant.DistFromFacility = reader.GetDouble(42);
                        }
                        catch
                        {
                            plant.DistFromFacility = 52;
                        }

                        //
                        try
                        {
                            plant.EquipCount = reader.GetDouble(43);
                        }
                        catch
                        {
                            plant.EquipCount = 30;
                        }
                        //
                        try
                        {
                            plant.HAZOPRate = reader.GetDouble(44);
                        }
                        catch
                        {
                            plant.HAZOPRate = 4;
                        }
                        // person density
                        try
                        {
                            plant.PersonDensity = reader.GetDouble(45);
                        }
                        catch
                        {
                            plant.PersonDensity = 52;
                        }
                        //
                        try
                        {
                            plant.MitigationEquip = reader.GetDouble(46);
                        }
                        catch
                        {
                            plant.MitigationEquip = 2;
                        }
                        //
                        try
                        {
                            plant.EnvRate = reader.GetDouble(47);
                        }
                        catch
                        {
                            plant.EnvRate = 3;
                        }
                        //
                        plant.InsTechUsed = reader[48].ToString();
                        //
                        plant.EquidModification_Repair = reader[49].ToString();
                        //
                        plant.InspFinding = reader[50].ToString();
                        //
                        try
                        {
                            plant.VaporDensity = reader.GetDouble(51);
                        }
                        catch
                        {
                            plant.VaporDensity = 0;
                        }
                        //
                        try
                        {
                            plant.LiquidDensity = reader.GetDouble(52);
                        }
                        catch
                        {
                            plant.LiquidDensity = 0;
                        }
                        //
                        try
                        {
                            plant.Vapor = reader.GetDouble(53);
                        }
                        catch
                        {
                            plant.Vapor = 0;
                        }
                        //
                        try
                        {
                            plant.Liquid = reader.GetDouble(54);
                        }
                        catch
                        {
                            plant.Liquid = 0;
                        }
                        //
                        plant.HMBPFDNum = reader[55].ToString();
                        //
                        plant.PIDNum = reader[56].ToString();
                        //
                        plant.Service = reader[57].ToString();
                        //
                        plant.HMBStream = reader[58].ToString();
                        //
                        if (reader[59].ToString() == "-1")
                            plant.CrackPresent = true;
                        else
                            plant.CrackPresent = false;
                        //
                        if (reader[61].ToString() == "-1")
                            plant.ProtectedBarrier = true;
                        else
                            plant.ProtectedBarrier = false;
                        //
                        plant.ComponentType = reader[62].ToString();
                        //
                        plant.LastCrackingInspDate = reader[63].ToString();
                        //
                        if (reader[64].ToString() == "-1")
                            plant.InternalLiner = true;
                        else
                            plant.InternalLiner = false;
                        //
                        plant.CatalogThin = reader[65].ToString();
                        //
                        try
                        {
                            plant.NoInsp = reader.GetInt32(66);
                        }
                        catch
                        {
                            plant.NoInsp = 1;
                        }
                        //
                        plant.CheckThin = reader[67].ToString();
                        //
                        if (reader[68].ToString() == "-1")
                            plant.Cladding = true;
                        else
                            plant.Cladding = false;
                        //
                        try
                        {
                            plant.Fom = reader.GetInt32(69);
                        }
                        catch
                        {
                            plant.Fom = 1;
                        }
                        //
                        if (reader[70].ToString() == "Necessary")
                            plant.Fip = 3;
                        else
                            plant.Fip = 1;
                        //
                        if (reader[71].ToString() == "Necessary")
                            plant.Fdl = 3;
                        else
                            plant.Fdl = 1;
                        //
                        if (reader[72].ToString() == "Otherwise")
                            plant.Fwd = 10;
                        else
                            plant.Fwd = 1;
                        //
                        if (reader[73].ToString() == "Otherwise")
                            plant.Fam = 5;
                        else
                            plant.Fam = 1;
                        //
                        if (reader[74].ToString() == "Exceeds")
                            plant.Fsm = 2;
                        else if (reader[73].ToString() == "Meets")
                            plant.Fsm = 1;
                        else if (reader[73].ToString() == "Settlement never evaluated")
                            plant.Fsm = 1.5;
                        else
                            plant.Fsm = 1;
                        //
                        try
                        {
                            plant.CorrosionRateMetal = reader.GetDouble(75);
                        }
                        catch
                        {
                            plant.CorrosionRateMetal = 0;
                        }
                        //
                        try
                        {
                            plant.CorrosionRateCladding = reader.GetDouble(76);
                        }
                        catch
                        {
                            plant.CorrosionRateCladding = 0;
                        }
                        //
                        try
                        {
                            plant.MinimumThick = reader.GetDouble(77);
                        }
                        catch
                        {
                            plant.MinimumThick = 0;
                        }
                        //
                        try
                        {
                            plant.ThickBaseMetal = reader.GetDouble(78);
                        }
                        catch
                        {
                            plant.ThickBaseMetal = 0;
                        }
                        //
                        plant.LinningType = reader[79].ToString();
                        //
                        if (reader[80].ToString() == "Poor")
                            plant.Flc = 10;
                        else if (reader[80].ToString() == "Average")
                            plant.Flc = 2;
                        else
                            plant.Flc = 1;
                        //
                        try
                        {
                            plant.YearInservice = reader.GetInt32(81);
                        }
                        catch
                        {
                            plant.YearInservice = 0;
                        }
                        //
                        plant.LevelCaustic = reader[82].ToString();
                        //
                        plant.CatalogCaustic = reader[83].ToString();
                        //
                        plant.LevelAmine = reader[84].ToString();
                        //
                        plant.CatalogAmine = reader[85].ToString();
                        //
                        plant.CatalogSulfide = reader[86].ToString();
                        //
                        try
                        {
                            plant.pH = reader.GetDouble(87);
                        }
                        catch
                        {
                            plant.pH = 0;
                        }
                        //
                        try
                        {
                            plant.Sulfide_ppm = reader.GetDouble(88);
                        }
                        catch
                        {
                            plant.Sulfide_ppm = 0;
                        }
                        //
                        try
                        {
                            plant.NoPWHT = reader.GetDouble(89);
                        }
                        catch
                        {
                            plant.NoPWHT = 0;
                        }
                        //
                        plant.HIC_H2S_Catalog = reader[90].ToString();
                        //
                        try
                        {
                            plant.H2S_ppm = reader.GetDouble(91);
                        }
                        catch
                        {
                            plant.H2S_ppm = 0;
                        }
                        //
                        plant.CacbonateCatalog = reader[92].ToString();
                        //
                        try
                        {
                            plant.Cacbonate_ppm = reader.GetDouble(93);
                        }
                        catch
                        {
                            plant.Cacbonate_ppm = 0;
                        }
                        //
                        plant.CatalogPTA = reader[94].ToString();
                        //
                        plant.Materials = reader[95].ToString();
                        //
                        plant.HeatTreatment = reader[96].ToString();
                        //
                        plant.CatalogCLSCC = reader[97].ToString();
                        //
                        try
                        {
                            plant.TempPH = reader.GetDouble(98);
                        }
                        catch
                        {
                            plant.TempPH = 0;
                        }
                        //
                        try
                        {
                            plant.Clo_ppm = reader.GetDouble(99);
                        }
                        catch
                        {
                            plant.Clo_ppm = 0;
                        }
                        //
                        plant.Catalog_HF = reader[100].ToString();
                        //
                        if (reader[101].ToString() == "-1")
                            plant.HFpresent = true;
                        else
                            plant.HFpresent = false;
                        //
                        try
                        {
                            plant.BrinellHardness = reader.GetDouble(102);
                        }
                        catch
                        {
                            plant.BrinellHardness = 0;
                        }
                        //
                        plant.Catalog_HIC_HF = reader[103].ToString();
                        //
                        try
                        {
                            plant.SulfurPercent = reader.GetDouble(104);
                        }
                        catch
                        {
                            plant.SulfurPercent = 0;
                        }
                        //
                        plant.Catalog_External = reader[105].ToString();
                        //
                        plant.ExternalDriver = reader[106].ToString();
                        //
                        plant.CoatQuality = reader[107].ToString();
                        //
                        plant.CatalogCUI = reader[108].ToString();
                        //
                        plant.DriverCUI = reader[109].ToString();
                        //
                        try
                        {
                            plant.CorrosionRateCUI = reader.GetDouble(110);
                        }
                        catch
                        {
                            plant.CorrosionRateCUI = 0;
                        }
                        //
                        plant.Complexity = reader[111].ToString();
                        //
                        plant.Insulation = reader[112].ToString();
                        //
                        if (reader[113].ToString() == "-1")
                            plant.AllowConfig = true;
                        else
                            plant.AllowConfig = false;
                        //
                        if (reader[114].ToString() == "-1")
                            plant.EnterSoil = true;
                        else
                            plant.EnterSoil = false;
                        //
                        plant.InsulationTypeCUI = reader[115].ToString();
                        //
                        plant.CatalogExtCLSCC = reader[116].ToString();
                        //
                        plant.DriverExtCLSCC = reader[117].ToString();
                        //
                        plant.PipingComplexity = reader[118].ToString();
                        //
                        plant.InsulationCondition = reader[119].ToString();
                        //
                        plant.HTHA_Catalog = reader[120].ToString();
                        //
                        try
                        {
                            plant.AgeHTHA = reader.GetInt32(121);
                        }
                        catch
                        {
                            plant.AgeHTHA = 0;
                        }
                        //
                        try
                        {
                            plant.TempHTHA = reader.GetDouble(122);
                        }
                        catch
                        {
                            plant.TempHTHA = 0;
                        }
                        //
                        try
                        {
                            plant.PH2 = reader.GetDouble(123);
                        }
                        catch
                        {
                            plant.PH2 = 0;
                        }
                        //
                        try
                        {
                            plant.TempMinBrittle = reader.GetDouble(124);
                        }
                        catch
                        {
                            plant.TempMinBrittle = 0;
                        }
                        //
                        try
                        {
                            plant.TempUpsetBrittle = reader.GetDouble(125);
                        }
                        catch
                        {
                            plant.TempUpsetBrittle = 0;
                        }
                        //
                        try
                        {
                            plant.NBP = reader.GetDouble(126);
                        }
                        catch
                        {
                            plant.NBP = 0;
                        }
                        //
                        try
                        {
                            plant.TempImpact = reader.GetDouble(127);
                        }
                        catch
                        {
                            plant.TempImpact = 0;
                        }
                        //
                        plant.MaterialCurve = reader[128].ToString();
                        //
                        if (reader[129].ToString() == "-1")
                            plant.LowTemp = true;
                        else
                            plant.LowTemp = false;
                        //
                        try
                        {
                            plant.SCE = reader.GetDouble(130);
                        }
                        catch
                        {
                            plant.SCE = 0;
                        }
                        //
                        try
                        {
                            plant.ReferenceTemp = reader.GetDouble(131);
                        }
                        catch
                        {
                            plant.ReferenceTemp = 0;
                        }
                        //
                        try
                        {
                            plant.TempMin885 = reader.GetDouble(132);
                        }
                        catch
                        {
                            plant.TempMin885 = 0;
                        }
                        //
                        if (reader[133].ToString() == "-1")
                            plant.BrittleCheck = true;
                        else
                            plant.BrittleCheck = false;
                        //
                        try
                        {
                            plant.TempShut = reader.GetDouble(134);
                        }
                        catch
                        {
                            plant.TempShut = 0;
                        }
                        //
                        try
                        {
                            plant.PercentSigma = reader.GetDouble(135);
                        }
                        catch
                        {
                            plant.PercentSigma = 0;
                        }
                        //
                        plant.NoFailure = reader[136].ToString();
                        //
                        plant.SeverityVibration = reader[137].ToString();
                        //
                        try
                        {
                            plant.NoWeek = reader.GetInt32(138);
                        }
                        catch
                        {
                            plant.NoWeek = 0;
                        }
                        //
                        plant.CyclicType = reader[139].ToString();
                        //
                        plant.CorrectAction = reader[140].ToString();
                        //
                        try
                        {
                            plant.ToTalPiping = reader.GetDouble(141);
                        }
                        catch
                        {
                            plant.ToTalPiping = 0;
                        }
                        //
                        plant.TypeOfPiping = reader[142].ToString();
                        //
                        plant.PipeCondition = reader[143].ToString();
                        //
                        try
                        {
                            plant.BranchDiametter = reader.GetDouble(144);
                        }
                        catch
                        {
                            plant.BranchDiametter = 0;
                        }
                        //
                        plant.Fluid = reader[145].ToString();
                        //
                        plant.MaterialsCA = reader[146].ToString();
                        //
                        plant.FluidPhase = reader[147].ToString();
                        //
                        plant.FluidType = reader[148].ToString();
                        //
                        plant.ReleaseFluid = reader[149].ToString();
                        //
                        try
                        {
                            plant.StoredPressure = reader.GetDouble(152);
                        }
                        catch
                        {
                            plant.StoredPressure = 0;
                        }
                        //
                        try
                        {
                            plant.AtmosphericPressure = reader.GetDouble(153);
                        }
                        catch
                        {
                            plant.AtmosphericPressure = 0;
                        }
                        //
                        try
                        {
                            plant.StoredTemp = reader.GetDouble(154);
                        }
                        catch
                        {
                            plant.StoredTemp = 0;
                        }
                        //
                        try
                        {
                            plant.AtmosphericTemp = reader.GetDouble(155);
                        }
                        catch
                        {
                            plant.AtmosphericTemp = 0;
                        }
                        //
                        try
                        {
                            plant.Reynol = reader.GetDouble(156);
                        }
                        catch
                        {
                            plant.Reynol = 10000;
                        }
                        //
                        if (reader[157].ToString() == "Foam spray system")
                            plant.MitigationSystem = 4;
                        else if (reader[157].ToString() == "Fire water monitors only")
                            plant.MitigationSystem = 3;
                        else if (reader[157].ToString() == "Fire water deluge system and monitors")
                            plant.MitigationSystem = 2;
                        else
                            plant.MitigationSystem = 1;
                        //
                        plant.ToxicMaterialsLV1 = reader[158].ToString();
                        //
                        try
                        {
                            plant.ToxicPercent = reader.GetDouble(159);
                        }
                        catch
                        {
                            plant.ToxicPercent = 0;
                        }
                        //
                        plant.ReleaseDuration = reader[160].ToString();
                        //
                        plant.NonToxic_NonFlammable = reader[161].ToString();
                        //
                        try
                        {
                            plant.OutageMultiplier = reader.GetDouble(162);
                        }
                        catch
                        {
                            plant.OutageMultiplier = 1;
                        }
                        //
                        try
                        {
                            plant.ProductionCost = reader.GetDouble(163);
                        }
                        catch
                        {
                            plant.ProductionCost = 0;
                        }
                        //
                        try
                        {
                            plant.InjuryCost = reader.GetDouble(164);
                        }
                        catch
                        {
                            plant.InjuryCost = 0;
                        }
                        //
                        try
                        {
                            plant.EnvCost = reader.GetDouble(165);
                        }
                        catch
                        {
                            plant.EnvCost = 0;
                        }
                        //
                        try
                        {
                            plant.EquipmentCost = reader.GetDouble(166);
                        }
                        catch
                        {
                            plant.EquipmentCost = 0;
                        }
                        //
                        plant.PoolFireType = reader[167].ToString();
                        //
                        try
                        {
                            plant.MassFractionLiquid = reader.GetDouble(168);
                        }
                        catch
                        {
                            plant.MassFractionLiquid = 0;
                        }
                        //
                        try
                        {
                            plant.FractionFuild = reader.GetDouble(169);
                        }
                        catch
                        {
                            plant.FractionFuild = 0;
                        }
                        //
                        try
                        {
                            plant.BubblePointTemp = reader.GetDouble(170);
                        }
                        catch
                        {
                            plant.BubblePointTemp = 0;
                        }
                        //
                        try
                        {
                            plant.DewPointVapor = reader.GetDouble(171);
                        }
                        catch
                        {
                            plant.DewPointVapor = 0;
                        }
                        //
                        try
                        {
                            plant.TimeSteady = reader.GetDouble(172);
                        }
                        catch
                        {
                            plant.TimeSteady = 0;
                        }
                        //
                        try
                        {
                            plant.SpecificHeat = reader.GetDouble(173);
                        }
                        catch
                        {
                            plant.SpecificHeat = 0;
                        }
                        //
                        try
                        {
                            plant.MassFrammableVapor = reader.GetDouble(174);
                        }
                        catch
                        {
                            plant.MassFrammableVapor = 0;
                        }
                        //
                        try
                        {
                            plant.MassFract = reader.GetDouble(175);
                        }
                        catch
                        {
                            plant.MassFract = 0;
                        }
                        //
                        try
                        {
                            plant.VolumeLiquid = reader.GetDouble(176);
                        }
                        catch
                        {
                            plant.VolumeLiquid = 0;
                        }
                        //
                        try
                        {
                            plant.BubblePointPress = reader.GetDouble(177);
                        }
                        catch
                        {
                            plant.BubblePointPress = 0;
                        }
                        //
                        try
                        {
                            plant.WindSpeed = reader.GetDouble(178);
                        }
                        catch
                        {
                            plant.WindSpeed = 0;
                        }
                        //
                        plant.AreaType = reader[179].ToString();
                        //
                        try
                        {
                            plant.GroundTemp = reader.GetDouble(180);
                        }
                        catch
                        {
                            plant.GroundTemp = 0;
                        }
                        //
                        plant.AmbientCondition = reader[181].ToString();
                        //
                        try
                        {
                            plant.Humidity = reader.GetDouble(182);
                        }
                        catch
                        {
                            plant.Humidity = 0;
                        }
                        //
                        try
                        {
                            plant.MoleFract = reader.GetDouble(183);
                        }
                        catch
                        {
                            plant.MoleFract = 0;
                        }
                        //
                        plant.ToxicComponent = reader[184].ToString();
                        //
                        plant.Criteria = reader[185].ToString();
                        //
                        try
                        {
                            plant.GradeLevelCloud = reader.GetDouble(186);
                        }
                        catch
                        {
                            plant.GradeLevelCloud = 0;
                        }
                        //
                        plant.RepresentFluid = reader[187].ToString();
                        //
                        try
                        {
                            plant.MoleFlash = reader.GetDouble(188);
                        }
                        catch
                        {
                            plant.MoleFlash = 0;
                        }
                        //
                        try
                        {
                            plant.MaximumFillHeight = reader.GetDouble(189);
                        }
                        catch
                        {
                            plant.MaximumFillHeight = 0;
                        }
                        //
                        plant.ReleaseHoleSize = reader[190].ToString();
                        //
                        try
                        {
                            plant.ShellCourse = reader.GetInt32(191);
                        }
                        catch
                        {
                            plant.ShellCourse = 0;
                        }
                        //
                        try
                        {
                            plant.CHT = reader.GetDouble(192);
                        }
                        catch
                        {
                            plant.CHT = 0;
                        }
                        //
                        plant.EnvironSensitivity = reader[193].ToString();
                        //
                        try
                        {
                            plant.P_dike = reader.GetDouble(194);
                        }
                        catch
                        {
                            plant.P_dike = 0;
                        }
                        //
                        try
                        {
                            plant.P_onsite = reader.GetDouble(195);
                        }
                        catch
                        {
                            plant.P_onsite = 0;
                        }
                        //
                        try
                        {
                            plant.P_offsite = reader.GetDouble(196);
                        }
                        catch
                        {
                            plant.P_offsite = 0;
                        }
                        //
                        plant.Tank_type = reader[197].ToString();
                        //
                        try
                        {
                            plant.SoilHydraulic = reader.GetDouble(198);
                        }
                        catch
                        {
                            plant.SoilHydraulic = 0;
                        }
                        //
                        try
                        {
                            plant.Distance = reader.GetDouble(199);
                        }
                        catch
                        {
                            plant.Distance = 0;
                        }
                        //
                        if (reader[200].ToString() == "Closed System or Flare")
                            plant.Fc = 0.75;
                        else
                            plant.Fc = 1;
                        //
                        try
                        {
                            plant.OverPress = reader.GetDouble(201);
                        }
                        catch
                        {
                            plant.OverPress = 0;
                        }
                        //
                        try
                        {
                            plant.MAWP = reader.GetDouble(202);
                        }
                        catch
                        {
                            plant.MAWP = 0;
                        }
                        //
                        if (reader[203].ToString() == "Operating Temperature 200<T<500F")
                            plant.Fenv = 1;
                        else if (reader[203].ToString() == "Operating Temperature > 500F")
                            plant.Fenv = 2;
                        else if (reader[203].ToString() == "Operating Ratio >90% for spring-loaded PRVs or >95% for pilot-operated PRVs")
                            plant.Fenv = 3;
                        else if (reader[203].ToString() == "Installed Piping Vibration")
                            plant.Fenv = 4;
                        else if (reader[203].ToString() == "Pulsating or Cyclical service, such as Downstream of Positive Displacement Rotating Equipment")
                            plant.Fenv = 5;
                        else if (reader[203].ToString() == "History of Excessive Actuation in Service (greater than 5 times per year)")
                            plant.Fenv = 6;
                        else
                            plant.Fenv = 7;
                        //
                        if (reader[204].ToString() == "-1")
                            plant.CheckPass = true;
                        else
                            plant.CheckPass = false;
                        //
                        plant.CatalogRelief = reader[205].ToString();
                        //
                        plant.FluidSeverityPoF = reader[206].ToString();
                        //
                        plant.WelbullPoF = reader[207].ToString();
                        //
                        plant.FluidSeverityLeak = reader[208].ToString();
                        //
                        plant.WelbullLeak = reader[209].ToString();
                        //
                        try
                        {
                            plant.TotalDemand = reader.GetDouble(210);
                        }
                        catch
                        {
                            plant.TotalDemand = 0;
                        }
                        //
                        if (reader[211].ToString() == "Soft Seated Design")
                            plant.Fs = 1.25;
                        else
                            plant.Fs = 1;
                        //
                        if (reader[212].ToString() == "-1")
                            plant.IsLeak = true;
                        else
                            plant.IsLeak = false;
                        //
                        plant.LevelLeak = reader[213].ToString();
                        //
                        try
                        {
                            plant.RateCapacity = reader.GetDouble(214);
                        }
                        catch
                        {
                            plant.RateCapacity = 0;
                        }
                        //
                        try
                        {
                            plant.TimeIsolate = reader.GetDouble(215);
                        }
                        catch
                        {
                            plant.TimeIsolate = 0;
                        }
                        //
                        try
                        {
                            plant.FluidCost = reader.GetDouble(216);
                        }
                        catch
                        {
                            plant.FluidCost = 0;
                        }
                        //
                        try
                        {
                            plant.PRDinletSize = reader.GetDouble(217);
                        }
                        catch
                        {
                            plant.PRDinletSize = 0;
                        }
                        //
                        plant.PRDType = reader[218].ToString();
                        //
                        if (reader[219].ToString() == "PRD discharges to flare and a flare recovery system is installed")
                            plant.Fr = 0.5;
                        else if (reader[219].ToString() == "PRD discharges to a closed system")
                            plant.Fr = 0;
                        else
                            plant.Fr = 1;
                        //
                        try
                        {
                            plant.NoDay = reader.GetDouble(220);
                        }
                        catch
                        {
                            plant.NoDay = 0;
                        }
                        //
                        if (reader[221].ToString() == "-1")
                            plant.IgnoreLeak = true;
                        else
                            plant.IgnoreLeak = false;
                        //
                        try
                        {
                            plant.RateReduct = reader.GetDouble(222);
                        }
                        catch
                        {
                            plant.RateReduct = 0;
                        }
                        //
                        try
                        {
                            plant.MainCost = reader.GetDouble(223);
                        }
                        catch
                        {
                            plant.MainCost = 0;
                        }
                        //
                        try
                        {
                            plant.Fms = reader.GetDouble(60);
                        }
                        catch
                        {
                            plant.Fms = 1;
                        }
                        //
                        plant.DetectionType = reader[150].ToString();
                        //
                        plant.IsolationType = reader[151].ToString();

                        list.Add(plant);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Check Version Excel File Or Fomat\n", "Error rbi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
    }
}
