using MySql.Data.MySqlClient;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBI.DAL
{
    class FullPlantConnUtils
    {
        FullPlantObject fullPlant = null;
        public void Add(String PLANT,
         String Unit,
         String EquipNum,
         String EquipDescrip,
         String EquipType,
         String SubComponent,
         String SubComponentDescrip,
         String MOC,
         String LMOC,
         double HeightLength,
         double Diameter,
         double NominalThick,
         double CA,
         double DesignPressure,
         double DesignTemp,
         double OPPressInlet,
         double OPTempInlet,
         double OPPressOutlet,
         double OPTempOutlet,
         double TestPress,
         double MDMT,
         Boolean InService,
         String ServiceDate,
         String LastIsnpDate,
         Boolean LDTBXH,
         Boolean Insulated,
         Boolean PWHT,
         String InsulationType,
         String OperatingState,
         double InventoryLiquid,
         double InventoryVapor,
         double InventoryTotal,
         Boolean ConfidentInstream,
         Boolean VaporDensityLessAir,
         Boolean CorrosionInhibitor,
         Boolean PrequentFeedChange,
         double MajorChemicals,
         String Contaminant,
         Boolean OnlineMonitor,
         Boolean CathodicProtection,
         Boolean CorrosionMonitor,
         Boolean OHCalibUpDate,
         double DistFromFacility,
         double EquipCount,
         double HAZOPRate,
         double PersonDensity,
         double MitigationEquip,
         double EnvRate,
         String InsTechUsed,
         String EquidModification_Repair,
         String InspFinding,
         double VaporDensity,
         double LiquidDensity,
         double Vapor,
         double Liquid,
         String HMBPFDNum,
         String PIDNum,
         String Service,
         String HMBStream,
         Boolean CrackPresent,
         Boolean ProtectedBarrier,
         String ComponentType,
         String LastCrackingInspDate,
         Boolean InternalLiner,
         String CatalogThin,
         int NoInsp,
         String CheckThin,
         Boolean Cladding,
         int Fom,
         int Fip,
         int Fdl,
         int Fwd,
         int Fam,
         double Fsm,
         double CorrosionRateMetal,
         double CorrosionRateCladding,
         double MinimumThick,
         double ThickBaseMetal,
         String LinningType,
         int Flc,
         int YearInservice,
         String LevelCaustic,
         String CatalogCaustic,
         String LevelAmine,
         String CatalogAmine,
         String CatalogSulfide,
         double pH,
         double Sulfide_ppm,
         double NoPWHT,
         String HIC_H2S_Catalog,
         double H2S_ppm,
         String CacbonateCatalog,
         double Cacbonate_ppm,
         String CatalogPTA,
         String Materials,
         String HeatTreatment,
         String CatalogCLSCC,
         double TempPH,
         double Clo_ppm,
         String Catalog_HF,
         Boolean HFpresent,
         double BrinellHardness,
         String Catalog_HIC_HF,
         double SulfurPercent,
         String Catalog_External,
         String ExternalDriver,
         String CoatQuality,
         String CatalogCUI,
         String DriverCUI,
         double CorrosionRateCUI,
         String Complexity,
         String Insulation,
         Boolean AllowConfig,
         Boolean EnterSoil,
         String InsulationTypeCUI,
         String CatalogExtCLSCC,
         String DriverExtCLSCC,
         String PipingComplexity,
         String InsulationCondition,
         String HTHA_Catalog,
         int AgeHTHA,
         double TempHTHA,
         double PH2,
         double TempMinBrittle,
         double TempUpsetBrittle,
         double NBP,
         double TempImpact,
         String MaterialCurve,
         Boolean LowTemp,
         double SCE,
         double ReferenceTemp,
         double TempMin885,
         Boolean BrittleCheck,
         double TempShut,
         double PercentSigma,
         String NoFailure,
         String SeverityVibration,
         double NoWeek,
         String CyclicType,
         String CorrectAction,
         double ToTalPiping,
         String TypeOfPiping,
         String PipeCondition,
         double BranchDiametter,
         String Fluid,
         String MaterialsCA,
         String FluidPhase,
         String FluidType,
         String ReleaseFluid,
         double StoredPressure,
         double AtmosphericPressure,
         double StoredTemp,
         double AtmosphericTemp,
         double Reynol,
         int MitigationSystem,
         String ToxicMaterialsLV1,
         double ToxicPercent,
         String ReleaseDuration,
         String NonToxic_NonFlammable,
         double OutageMultiplier,
         double ProductionCost,
         double InjuryCost,
         double EnvCost,
         double EquipmentCost,
         String PoolFireType,
         double MassFractionLiquid,
         double FractionFuild,
         double BubblePointTemp,
         double DewPointVapor,
         double TimeSteady,
         double SpecificHeat,
         double MassFrammableVapor,
         double MassFract,
         double VolumeLiquid,
         double BubblePointPress,
         double WindSpeed,
         String AreaType,
         double GroundTemp,
         String AmbientCondition,
         double Humidity,
         double MoleFract,
         String ToxicComponent,
         String Criteria,
         double GradeLevelCloud,
         String RepresentFluid,
         double MoleFlash,
         double MaximumFillHeight,
         String ReleaseHoleSize,
         int ShellCourse,
         double CHT,
         String EnvironSensitivity,
         double P_dike,
         double P_onsite,
         double P_offsite,
         String Tank_type,
         double SoilHydraulic,
         double Distance,
         double Fc,
         double OverPress,
         double MAWP,
         int Fenv,
         Boolean CheckPass,
         String CatalogRelief,
         String FluidSeverityPoF,
         String WelbullPoF,
         String FluidSeverityLeak,
         String WelbullLeak,
         double TotalDemand,
         double Fs,
         Boolean IsLeak,
         String LevelLeak,
         double RateCapacity,
         double TimeIsolate,
         double FluidCost,
         double PRDinletSize,
         String PRDType,
         double Fr,
         double NoDay,
         Boolean IgnoreLeak,
         double RateReduct,
         double MainCost,
         double Fms,
         String DetectionType,
         String IsolationType)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "INSERT INTO `tbl_full_plant` "+
                            "VALUES(" +
                            "'" + PLANT + "'," +
                            "'" + Unit + "'," +
                            "'" + EquipNum + "'," +
                            "'" + EquipDescrip + "'," +
                            "'" + EquipType + "'," +
                            "'" + SubComponent + "'," +
                            "'" + SubComponentDescrip + "'," +
                            "'" + MOC + "'," +
                            "'" + LMOC + "'," +
                            "'" + HeightLength + "'," +
                            "'" + Diameter + "'," +
                            "'" + NominalThick + "'," +
                            "'" + CA + "'," +
                            "'" + DesignPressure + "'," +
                            "'" + DesignTemp + "'," +
                            "'" + OPPressInlet + "'," +
                            "'" + OPTempInlet + "'," +
                            "'" + OPPressOutlet + "'," +
                            "'" + OPTempOutlet + "'," +
                            "'" + TestPress + "'," +
                            "'" + MDMT + "'," +
                            "'" + InService + "'," +
                            "'" + ServiceDate + "'," +
                            "'" + LastIsnpDate + "'," +
                            "'" + LDTBXH + "'," +
                            "'" + Insulated + "'," +
                            "'" + PWHT + "'," +
                            "'" + InsulationType + "'," +
                            "'" + OperatingState + "'," +
                            "'" + InventoryLiquid + "'," +
                            "'" + InventoryVapor + "'," +
                            "'" + InventoryTotal + "'," +
                            "'" + ConfidentInstream + "'," +
                            "'" + VaporDensityLessAir + "'," +
                            "'" + CorrosionInhibitor + "'," +
                            "'" + PrequentFeedChange + "'," +
                            "'" + MajorChemicals + "'," +
                            "'" + Contaminant + "'," +
                            "'" + OnlineMonitor + "'," +
                            "'" + CathodicProtection + "'," +
                            "'" + CorrosionMonitor + "'," +
                            "'" + OHCalibUpDate + "'," +
                            "'" + DistFromFacility + "'," +
                            "'" + EquipCount + "'," +
                            "'" + HAZOPRate + "'," +
                            "'" + PersonDensity + "'," +
                            "'" + MitigationEquip + "'," +
                            "'" + EnvRate + "'," +
                            "'" + InsTechUsed + "'," +
                            "'" + EquidModification_Repair + "'," +
                            "'" + InspFinding + "'," +
                            "'" + VaporDensity + "'," +
                            "'" + LiquidDensity + "'," +
                            "'" + Vapor + "'," +
                            "'" + Liquid + "'," +
                            "'" + HMBPFDNum + "'," +
                            "'" + PIDNum + "'," +
                            "'" + Service + "'," +
                            "'" + HMBStream + "'," +
                            "'" + CrackPresent + "'," +
                            "'" + ProtectedBarrier + "'," +
                            "'" + ComponentType + "'," +
                            "'" + LastCrackingInspDate + "'," +
                            "'" + InternalLiner + "'," +
                            "'" + CatalogThin + "'," +
                            "'" + NoInsp + "'," +
                            "'" + CheckThin + "'," +
                            "'" + Cladding + "'," +
                            "'" + Fom + "'," +
                            "'" + Fip + "'," +
                            "'" + Fdl + "'," +
                            "'" + Fwd + "'," +
                            "'" + Fam + "'," +
                            "'" + Fsm + "'," +
                            "'" + CorrosionRateMetal + "'," +
                            "'" + CorrosionRateCladding + "'," +
                            "'" + MinimumThick + "'," +
                            "'" + ThickBaseMetal + "'," +
                            "'" + LinningType + "'," +
                            "'" + Flc + "'," +
                            "'" + YearInservice + "'," +
                            "'" + LevelCaustic + "'," +
                            "'" + CatalogCaustic + "'," +
                            "'" + LevelAmine + "'," +
                            "'" + CatalogAmine + "'," +
                            "'" + CatalogSulfide + "'," +
                            "'" + pH + "'," +
                            "'" + Sulfide_ppm + "'," +
                            "'" + NoPWHT + "'," +
                            "'" + HIC_H2S_Catalog + "'," +
                            "'" + H2S_ppm + "'," +
                            "'" + CacbonateCatalog + "'," +
                            "'" + Cacbonate_ppm + "'," +
                            "'" + CatalogPTA + "'," +
                            "'" + Materials + "'," +
                            "'" + HeatTreatment + "'," +
                            "'" + CatalogCLSCC + "'," +
                            "'" + TempPH + "'," +
                            "'" + Clo_ppm + "'," +
                            "'" + Catalog_HF + "'," +
                            "'" + HFpresent + "'," +
                            "'" + BrinellHardness + "'," +
                            "'" + Catalog_HIC_HF + "'," +
                            "'" + SulfurPercent + "'," +
                            "'" + Catalog_External + "'," +
                            "'" + ExternalDriver + "'," +
                            "'" + CoatQuality + "'," +
                            "'" + CatalogCUI + "'," +
                            "'" + DriverCUI + "'," +
                            "'" + CorrosionRateCUI + "'," +
                            "'" + Complexity + "'," +
                            "'" + Insulation + "'," +
                            "'" + AllowConfig + "'," +
                            "'" + EnterSoil + "'," +
                            "'" + InsulationTypeCUI + "'," +
                            "'" + CatalogExtCLSCC + "'," +
                            "'" + DriverExtCLSCC + "'," +
                            "'" + PipingComplexity + "'," +
                            "'" + InsulationCondition + "'," +
                            "'" + HTHA_Catalog + "'," +
                            "'" + AgeHTHA + "'," +
                            "'" + TempHTHA + "'," +
                            "'" + PH2 + "'," +
                            "'" + TempMinBrittle + "'," +
                            "'" + TempUpsetBrittle + "'," +
                            "'" + NBP + "'," +
                            "'" + TempImpact + "'," +
                            "'" + MaterialCurve + "'," +
                            "'" + LowTemp + "'," +
                            "'" + SCE + "'," +
                            "'" + ReferenceTemp + "'," +
                            "'" + TempMin885 + "'," +
                            "'" + BrittleCheck + "'," +
                            "'" + TempShut + "'," +
                            "'" + PercentSigma + "'," +
                            "'" + NoFailure + "'," +
                            "'" + SeverityVibration + "'," +
                            "'" + NoWeek + "'," +
                            "'" + CyclicType + "'," +
                            "'" + CorrectAction + "'," +
                            "'" + ToTalPiping + "'," +
                            "'" + TypeOfPiping + "'," +
                            "'" + PipeCondition + "'," +
                            "'" + BranchDiametter + "'," +
                            "'" + Fluid + "'," +
                            "'" + MaterialsCA + "'," +
                            "'" + FluidPhase + "'," +
                            "'" + FluidType + "'," +
                            "'" + ReleaseFluid + "'," +
                            "'" + StoredPressure + "'," +
                            "'" + AtmosphericPressure + "'," +
                            "'" + StoredTemp + "'," +
                            "'" + AtmosphericTemp + "'," +
                            "'" + Reynol + "'," +
                            "'" + MitigationSystem + "'," +
                            "'" + ToxicMaterialsLV1 + "'," +
                            "'" + ToxicPercent + "'," +
                            "'" + ReleaseDuration + "'," +
                            "'" + NonToxic_NonFlammable + "'," +
                            "'" + OutageMultiplier + "'," +
                            "'" + ProductionCost + "'," +
                            "'" + InjuryCost + "'," +
                            "'" + EnvCost + "'," +
                            "'" + EquipmentCost + "'," +
                            "'" + PoolFireType + "'," +
                            "'" + MassFractionLiquid + "'," +
                            "'" + FractionFuild + "'," +
                            "'" + BubblePointTemp + "'," +
                            "'" + DewPointVapor + "'," +
                            "'" + TimeSteady + "'," +
                            "'" + SpecificHeat + "'," +
                            "'" + MassFrammableVapor + "'," +
                            "'" + MassFract + "'," +
                            "'" + VolumeLiquid + "'," +
                            "'" + BubblePointPress + "'," +
                            "'" + WindSpeed + "'," +
                            "'" + AreaType + "'," +
                            "'" + GroundTemp + "'," +
                            "'" + AmbientCondition + "'," +
                            "'" + Humidity + "'," +
                            "'" + MoleFract + "'," +
                            "'" + ToxicComponent + "'," +
                            "'" + Criteria + "'," +
                            "'" + GradeLevelCloud + "'," +
                            "'" + RepresentFluid + "'," +
                            "'" + MoleFlash + "'," +
                            "'" + MaximumFillHeight + "'," +
                            "'" + ReleaseHoleSize + "'," +
                            "'" + ShellCourse + "'," +
                            "'" + CHT + "'," +
                            "'" + EnvironSensitivity + "'," +
                            "'" + P_dike + "'," +
                            "'" + P_onsite + "'," +
                            "'" + P_offsite + "'," +
                            "'" + Tank_type + "'," +
                            "'" + SoilHydraulic + "'," +
                            "'" + Distance + "'," +
                            "'" + Fc + "'," +
                            "'" + OverPress + "'," +
                            "'" + MAWP + "'," +
                            "'" + Fenv + "'," +
                            "'" + CheckPass + "'," +
                            "'" + CatalogRelief + "'," +
                            "'" + FluidSeverityPoF + "'," +
                            "'" + WelbullPoF + "'," +
                            "'" + FluidSeverityLeak + "'," +
                            "'" + WelbullLeak + "'," +
                            "'" + TotalDemand + "'," +
                            "'" + Fs + "'," +
                            "'" + IsLeak + "'," +
                            "'" + LevelLeak + "'," +
                            "'" + RateCapacity + "'," +
                            "'" + TimeIsolate + "'," +
                            "'" + FluidCost + "'," +
                            "'" + PRDinletSize + "'," +
                            "'" + PRDType + "'," +
                            "'" + Fr + "'," +
                            "'" + NoDay + "'," +
                            "'" + IgnoreLeak + "'," +
                            "'" + RateReduct + "'," +
                            "'" + MainCost + "'," +
                            "'" + Fms + "'," +
                            "'" + DetectionType + "'," +
                            "'" + IsolationType + "')";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Add data failed" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void edit(String PLANT,
         String Unit,
         String EquipNum,
         String EquipDescrip,
         String EquipType,
         String SubComponent,
         String SubComponentDescrip,
         String MOC,
         String LMOC,
         double HeightLength,
         double Diameter,
         double NominalThick,
         double CA,
         double DesignPressure,
         double DesignTemp,
         double OPPressInlet,
         double OPTempInlet,
         double OPPressOutlet,
         double OPTempOutlet,
         double TestPress,
         double MDMT,
         Boolean InService,
         String ServiceDate,
         String LastIsnpDate,
         Boolean LDTBXH,
         Boolean Insulated,
         Boolean PWHT,
         String InsulationType,
         String OperatingState,
         double InventoryLiquid,
         double InventoryVapor,
         double InventoryTotal,
         Boolean ConfidentInstream,
         Boolean VaporDensityLessAir,
         Boolean CorrosionInhibitor,
         Boolean PrequentFeedChange,
         double MajorChemicals,
         String Contaminant,
         Boolean OnlineMonitor,
         Boolean CathodicProtection,
         Boolean CorrosionMonitor,
         Boolean OHCalibUpDate,
         double DistFromFacility,
         double EquipCount,
         double HAZOPRate,
         double PersonDensity,
         double MitigationEquip,
         double EnvRate,
         String InsTechUsed,
         String EquidModification_Repair,
         String InspFinding,
         double VaporDensity,
         double LiquidDensity,
         double Vapor,
         double Liquid,
         String HMBPFDNum,
         String PIDNum,
         String Service,
         String HMBStream,
         Boolean CrackPresent,
         Boolean ProtectedBarrier,
         String ComponentType,
         String LastCrackingInspDate,
         Boolean InternalLiner,
         String CatalogThin,
         int NoInsp,
         String CheckThin,
         Boolean Cladding,
         int Fom,
         int Fip,
         int Fdl,
         int Fwd,
         int Fam,
         double Fsm,
         double CorrosionRateMetal,
         double CorrosionRateCladding,
         double MinimumThick,
         double ThickBaseMetal,
         String LinningType,
         int Flc,
         int YearInservice,
         String LevelCaustic,
         String CatalogCaustic,
         String LevelAmine,
         String CatalogAmine,
         String CatalogSulfide,
         double pH,
         double Sulfide_ppm,
         double NoPWHT,
         String HIC_H2S_Catalog,
         double H2S_ppm,
         String CacbonateCatalog,
         double Cacbonate_ppm,
         String CatalogPTA,
         String Materials,
         String HeatTreatment,
         String CatalogCLSCC,
         double TempPH,
         double Clo_ppm,
         String Catalog_HF,
         Boolean HFpresent,
         double BrinellHardness,
         String Catalog_HIC_HF,
         double SulfurPercent,
         String Catalog_External,
         String ExternalDriver,
         String CoatQuality,
         String CatalogCUI,
         String DriverCUI,
         double CorrosionRateCUI,
         String Complexity,
         String Insulation,
         Boolean AllowConfig,
         Boolean EnterSoil,
         String InsulationTypeCUI,
         String CatalogExtCLSCC,
         String DriverExtCLSCC,
         String PipingComplexity,
         String InsulationCondition,
         String HTHA_Catalog,
         int AgeHTHA,
         double TempHTHA,
         double PH2,
         double TempMinBrittle,
         double TempUpsetBrittle,
         double NBP,
         double TempImpact,
         String MaterialCurve,
         Boolean LowTemp,
         double SCE,
         double ReferenceTemp,
         double TempMin885,
         Boolean BrittleCheck,
         double TempShut,
         double PercentSigma,
         String NoFailure,
         String SeverityVibration,
         double NoWeek,
         String CyclicType,
         String CorrectAction,
         double ToTalPiping,
         String TypeOfPiping,
         String PipeCondition,
         double BranchDiametter,
         String Fluid,
         String MaterialsCA,
         String FluidPhase,
         String FluidType,
         String ReleaseFluid,
         double StoredPressure,
         double AtmosphericPressure,
         double StoredTemp,
         double AtmosphericTemp,
         double Reynol,
         int MitigationSystem,
         String ToxicMaterialsLV1,
         double ToxicPercent,
         String ReleaseDuration,
         String NonToxic_NonFlammable,
         double OutageMultiplier,
         double ProductionCost,
         double InjuryCost,
         double EnvCost,
         double EquipmentCost,
         String PoolFireType,
         double MassFractionLiquid,
         double FractionFuild,
         double BubblePointTemp,
         double DewPointVapor,
         double TimeSteady,
         double SpecificHeat,
         double MassFrammableVapor,
         double MassFract,
         double VolumeLiquid,
         double BubblePointPress,
         double WindSpeed,
         String AreaType,
         double GroundTemp,
         String AmbientCondition,
         double Humidity,
         double MoleFract,
         String ToxicComponent,
         String Criteria,
         double GradeLevelCloud,
         String RepresentFluid,
         double MoleFlash,
         double MaximumFillHeight,
         String ReleaseHoleSize,
         int ShellCourse,
         double CHT,
         String EnvironSensitivity,
         double P_dike,
         double P_onsite,
         double P_offsite,
         String Tank_type,
         double SoilHydraulic,
         double Distance,
         double Fc,
         double OverPress,
         double MAWP,
         int Fenv,
         Boolean CheckPass,
         String CatalogRelief,
         String FluidSeverityPoF,
         String WelbullPoF,
         String FluidSeverityLeak,
         String WelbullLeak,
         double TotalDemand,
         double Fs,
         Boolean IsLeak,
         String LevelLeak,
         double RateCapacity,
         double TimeIsolate,
         double FluidCost,
         double PRDinletSize,
         String PRDType,
         double Fr,
         double NoDay,
         Boolean IgnoreLeak,
         double RateReduct,
         double MainCost,
         double Fms,
         String DetectionType,
         String IsolationType,
         String PLANT_NEW,
         String EquipNum_New,
         String SubComponent_New)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "UPDATE `tbl_full_plant`"+
                        "SET" +
                        "`PLANT` = '" + PLANT + "'," +
                        "`Unit` = '" + Unit + "'," +
                        "`EquipNum` = '" + EquipNum + "'," +
                        "`EquipDescrip` = '" + EquipDescrip + "'," +
                        "`EquipType` = '" + EquipType + "'," +
                        "`SubComponent` = '" + SubComponent + "'," +
                        "`SubComponentDescrip` = '" + SubComponentDescrip + "'," +
                        "`MOC` = '" + MOC + "'," +
                        "`LMOC` = '" + LMOC + "'," +
                        "`HeightLength` = '" + HeightLength + "'," +
                        "`Diameter` = '" + Diameter + "'," +
                        "`NominalThick` = '" + NominalThick + "'," +
                        "`CA` = '" + CA + "'," +
                        "`DesignPressure` = '" + DesignPressure + "'," +
                        "`DesignTemp` = '" + DesignTemp + "'," +
                        "`OPPressInlet` = '" + OPPressInlet + "'," +
                        "`OPTempInlet` = '" + OPTempInlet + "'," +
                        "`OPPressOutlet` = '" + OPPressOutlet + "'," +
                        "`OPTempOutlet` = '" + OPTempOutlet + "'," +
                        "`TestPress` = '" + TestPress + "'," +
                        "`MDMT` = '" + MDMT + "'," +
                        "`InService` = '" + InService + "'," +
                        "`ServiceDate` = '" + ServiceDate + "'," +
                        "`LastIsnpDate` = '" + LastIsnpDate + "'," +
                        "`LDTBXH` = '" + LDTBXH + "'," +
                        "`Insulated` = '" + Insulated + "'," +
                        "`PWHT` = '" + PWHT + "'," +
                        "`InsulationType` = '" + InsulationType + "'," +
                        "`OperatingState` = '" + OperatingState + "'," +
                        "`InventoryLiquid` = '" + InventoryLiquid + "'," +
                        "`InventoryVapor` = '" + InventoryVapor + "'," +
                        "`InventoryTotal` = '" + InventoryTotal + "'," +
                        "`ConfidentInstream` = '" + ConfidentInstream + "'," +
                        "`VaporDensityLessAir` = '" + VaporDensityLessAir + "'," +
                        "`CorrosionInhibitor` = '" + CorrosionInhibitor + "'," +
                        "`PrequentFeedChange` = '" + PrequentFeedChange + "'," +
                        "`MajorChemicals` = '" + MajorChemicals + "'," +
                        "`Contaminant` = '" + Contaminant + "'," +
                        "`OnlineMonitor` = '" + OnlineMonitor + "'," +
                        "`CathodicProtection` = '" + CathodicProtection + "'," +
                        "`CorrosionMonitor` = '" + CorrosionMonitor + "'," +
                        "`OHCalibUpDate` = '" + OHCalibUpDate + "'," +
                        "`DistFromFacility` = '" + DistFromFacility + "'," +
                        "`EquipCount` = '" + EquipCount + "'," +
                        "`HAZOPRate` = '" + HAZOPRate + "'," +
                        "`PersonDensity` = '" + PersonDensity + "'," +
                        "`MitigationEquip` = '" + MitigationEquip + "'," +
                        "`EnvRate` = '" + EnvRate + "'," +
                        "`InsTechUsed` = '" + InsTechUsed + "'," +
                        "`EquidModification_Repair` = '" + EquidModification_Repair + "'," +
                        "`InspFinding` = '" + InspFinding + "'," +
                        "`VaporDensity` = '" + VaporDensity + "'," +
                        "`LiquidDensity` = '" + LiquidDensity + "'," +
                        "`Vapor` = '" + Vapor + "'," +
                        "`Liquid` = '" + Liquid + "'," +
                        "`HMBPFDNum` = '" + HMBPFDNum + "'," +
                        "`PIDNum` = '" + PIDNum + "'," +
                        "`Service` = '" + Service + "'," +
                        "`HMBStream` = '" + HMBStream + "'," +
                        "`CrackPresent` = '" + CrackPresent + "'," +
                        "`ProtectedBarrier` = '" + ProtectedBarrier + "'," +
                        "`ComponentType` = '" + ComponentType + "'," +
                        "`LastCrackingInspDate` = '" + LastCrackingInspDate + "'," +
                        "`InternalLiner` = '" + InternalLiner + "'," +
                        "`CatalogThin` = '" + CatalogThin + "'," +
                        "`NoInsp` = '" + NoInsp + "'," +
                        "`CheckThin` = '" + CheckThin + "'," +
                        "`Cladding` = '" + Cladding + "'," +
                        "`Fom` = '" + Fom + "'," +
                        "`Fip` = '" + Fip + "'," +
                        "`Fdl` = '" + Fdl + "'," +
                        "`Fwd` = '" + Fwd + "'," +
                        "`Fam` = '" + Fam + "'," +
                        "`Fsm` = '" + Fsm + "'," +
                        "`CorrosionRateMetal` = '" + CorrosionRateMetal + "'," +
                        "`CorrosionRateCladding` = '" + CorrosionRateCladding + "'," +
                        "`MinimumThick` = '" + MinimumThick + "'," +
                        "`ThickBaseMetal` = '" + ThickBaseMetal + "'," +
                        "`LinningType` = '" + LinningType + "'," +
                        "`Flc` = '" + Flc + "'," +
                        "`YearInservice` = '" + YearInservice + "'," +
                        "`LevelCaustic` = '" + LevelCaustic + "'," +
                        "`CatalogCaustic` = '" + CatalogCaustic + "'," +
                        "`LevelAmine` = '" + LevelAmine + "'," +
                        "`CatalogAmine` = '" + CatalogAmine + "'," +
                        "`CatalogSulfide` = '" + CatalogSulfide + "'," +
                        "`pH` = '" + pH + "'," +
                        "`Sulfide_ppm` = '" + Sulfide_ppm + "'," +
                        "`NoPWHT` = '" + NoPWHT + "'," +
                        "`HIC_H2S_Catalog` = '" + HIC_H2S_Catalog + "'," +
                        "`H2S_ppm` = '" + H2S_ppm + "'," +
                        "`CacbonateCatalog` = '" + CacbonateCatalog + "'," +
                        "`Cacbonate_ppm` = '" + Cacbonate_ppm + "'," +
                        "`CatalogPTA` = '" + CatalogPTA + "'," +
                        "`Materials` = '" + Materials + "'," +
                        "`HeatTreatment` = '" + HeatTreatment + "'," +
                        "`CatalogCLSCC` = '" + CatalogCLSCC + "'," +
                        "`TempPH` = '" + TempPH + "'," +
                        "`Clo_ppm` = '" + Clo_ppm + "'," +
                        "`Catalog_HF` = '" + Catalog_HF + "'," +
                        "`HFpresent` = '" + HFpresent + "'," +
                        "`BrinellHardness` = '" + BrinellHardness + "'," +
                        "`Catalog_HIC/HF` = '" + Catalog_HIC_HF + "'," +
                        "`SulfurPercent` = '" + SulfurPercent + "'," +
                        "`Catalog_External` = '" + Catalog_External + "'," +
                        "`ExternalDriver` = '" + ExternalDriver + "'," +
                        "`CoatQuality` = '" + CoatQuality + "'," +
                        "`CatalogCUI` = '" + CatalogCUI + "'," +
                        "`DriverCUI` = '" + DriverCUI + "'," +
                        "`CorrosionRateCUI` = '" + CorrosionRateCUI + "'," +
                        "`Complexity` = '" + Complexity + "'," +
                        "`Insulation` = '" + Insulation + "'," +
                        "`AllowConfig` = '" + AllowConfig + "'," +
                        "`EnterSoil` = '" + EnterSoil + "'," +
                        "`InsulationTypeCUI` = '" + InsulationTypeCUI + "'," +
                        "`CatalogExtCLSCC` = '" + CatalogExtCLSCC + "'," +
                        "`DriverExtCLSCC` = '" + DriverExtCLSCC + "'," +
                        "`PipingComplexity` = '" + PipingComplexity + "'," +
                        "`InsulationCondition` = '" + InsulationCondition + "'," +
                        "`HTHA_Catalog` = '" + HTHA_Catalog + "'," +
                        "`AgeHTHA` = '" + AgeHTHA + "'," +
                        "`TempHTHA` = '" + TempHTHA + "'," +
                        "`PH2` = '" + PH2 + "'," +
                        "`TempMinBrittle` = '" + TempMinBrittle + "'," +
                        "`TempUpsetBrittle` = '" + TempUpsetBrittle + "'," +
                        "`NBP` = '" + NBP + "'," +
                        "`TempImpact` = '" + TempImpact + "'," +
                        "`MaterialCurve` = '" + MaterialCurve + "'," +
                        "`LowTemp` = '" + LowTemp + "'," +
                        "`SCE` = '" + SCE + "'," +
                        "`ReferenceTemp` = '" + ReferenceTemp + "'," +
                        "`TempMin885` = '" + TempMin885 + "'," +
                        "`BrittleCheck` = '" + BrittleCheck + "'," +
                        "`TempShut` = '" + TempShut + "'," +
                        "`PercentSigma` = '" + PercentSigma + "'," +
                        "`NoFailure` = '" + NoFailure + "'," +
                        "`SeverityVibration` = '" + SeverityVibration + "'," +
                        "`NoWeek` = '" + NoWeek + "'," +
                        "`CyclicType` = '" + CyclicType + "'," +
                        "`CorrectAction` = '" + CorrectAction + "'," +
                        "`ToTalPiping` = '" + ToTalPiping + "'," +
                        "`TypeOfPiping` = '" + TypeOfPiping + "'," +
                        "`PipeCondition` = '" + PipeCondition + "'," +
                        "`BranchDiametter` = '" + BranchDiametter + "'," +
                        "`Fluid` = '" + Fluid + "'," +
                        "`MaterialsCA` = '" + MaterialsCA + "'," +
                        "`FluidPhase` = '" + FluidPhase + "'," +
                        "`FluidType` = '" + FluidType + "'," +
                        "`ReleaseFluid` = '" + ReleaseFluid + "'," +
                        "`StoredPressure` = '" + StoredPressure + "'," +
                        "`AtmosphericPressure` = '" + AtmosphericPressure + "'," +
                        "`StoredTemp` = '" + StoredTemp + "'," +
                        "`AtmosphericTemp` = '" + AtmosphericTemp + "'," +
                        "`Reynol` = '" + Reynol + "'," +
                        "`MitigationSystem` = '" + MitigationSystem + "'," +
                        "`ToxicMaterialsLV1` = '" + ToxicMaterialsLV1 + "'," +
                        "`ToxicPercent` = '" + ToxicPercent + "'," +
                        "`ReleaseDuration` = '" + ReleaseDuration + "'," +
                        "`NonToxic,NonFlammable` = '" + NonToxic_NonFlammable + "'," +
                          "`OutageMultiplier` = '" + OutageMultiplier + "'," +
                          "`ProductionCost` = '" + ProductionCost + "'," +
                          "`InjuryCost` = '" + InjuryCost + "'," +
                          "`EnvCost` = '" + EnvCost + "'," +
                          "`EquipmentCost` = '" + EquipmentCost + "'," +
                          "`PoolFireType` = '" + PoolFireType + "'," +
                          "`MassFractionLiquid` = '" + MassFractionLiquid + "'," +
                          "`FractionFuild` = '" + FractionFuild + "'," +
                          "`BubblePointTemp` = '" + BubblePointTemp + "'," +
                          "`DewPointVapor` = '" + DewPointVapor + "'," +
                          "`TimeSteady` = '" + TimeSteady + "'," +
                          "`SpecificHeat` = '" + SpecificHeat + "'," +
                          "`MassFrammableVapor` = '" + MassFrammableVapor + "'," +
                          "`MassFract` = '" + MassFract + "'," +
                          "`VolumeLiquid` = '" + VolumeLiquid + "'," +
                          "`BubblePointPress` = '" + BubblePointPress + "'," +
                          "`WindSpeed` = '" + WindSpeed + "'," +
                          "`AreaType` = '" + AreaType + "'," +
                          "`GroundTemp` = '" + GroundTemp + "'," +
                          "`AmbientCondition` = '" + AmbientCondition + "'," +
                          "`Humidity` = '" + Humidity + "'," +
                          "`MoleFract` = '" + MoleFract + "'," +
                          "`ToxicComponent` = '" + ToxicComponent + "'," +
                          "`Criteria` = '" + Criteria + "'," +
                          "`GradeLevelCloud` = '" + GradeLevelCloud + "'," +
                          "`RepresentFluid` = '" + RepresentFluid + "'," +
                          "`MoleFlash` = '" + MoleFlash + "'," +
                          "`MaximumFillHeight` = '" + MaximumFillHeight + "'," +
                          "`ReleaseHoleSize` = '" + ReleaseHoleSize + "'," +
                          "`ShellCourse` = '" + ShellCourse + "'," +
                          "`CHT` = '" + CHT + "'," +
                          "`EnvironSensitivity` = '" + EnvironSensitivity + "'," +
                          "`P_dike` = '" + P_dike + "'," +
                          "`P_onsite` = '" + P_onsite + "'," +
                          "`P_offsite` = '" + P_offsite + "'," +
                          "`Tank_type` = '" + Tank_type + "'," +
                          "`SoilHydraulic` = '" + SoilHydraulic + "'," +
                          "`Distance` = '" + Distance + "'," +
                          "`Fc` = '" + Fc + "'," +
                          "`OverPress` = '" + OverPress + "'," +
                          "`MAWP` = '" + MAWP + "'," +
                          "`Fenv` = '" + Fenv + "'," +
                          "`CheckPass` = '" + CheckPass + "'," +
                          "`CatalogRelief` = '" + CatalogRelief + "'," +
                          "`FluidSeverityPoF` = '" + FluidSeverityPoF + "'," +
                          "`WelbullPoF` = '" + WelbullPoF + "'," +
                          "`FluidSeverityLeak` = '" + FluidSeverityLeak + "'," +
                          "`WelbullLeak` = '" + WelbullLeak + "'," +
                          "`TotalDemand` = '" + TotalDemand + "'," +
                          "`Fs` = '" + Fs + "'," +
                          "`IsLeak` = '" + IsLeak + "'," +
                          "`LevelLeak` = '" + LevelLeak + "'," +
                          "`RateCapacity` = '" + RateCapacity + "'," +
                          "`TimeIsolate` = '" + TimeIsolate + "'," +
                          "`FluidCost` = '" + FluidCost + "'," +
                          "`PRDinletSize` = '" + PRDinletSize + "'," +
                          "`PRDType` = '" + PRDType + "'," +
                          "`Fr` = '" + Fr + "'," +
                          "`NoDay` = '" + NoDay + "'," +
                          "`IgnoreLeak` = '" + IgnoreLeak + "'," +
                          "`RateReduct` = '" + RateReduct + "'," +
                          "`MainCost` = '" + MainCost + "'," +
                          "`Fms` = '" + Fms + "'," +
                          "`DetectionType` = '" + DetectionType + "'," +
                          "`IsolationType` = '" + IsolationType +"'WHERE `PLANT` = '" + PLANT_NEW + "' AND `EquipNum` = '" + EquipNum_New + "' AND `SubComponent` = '" + SubComponent_New + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                //MessageBox.Show("Edit data failed" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public void delete(String PLANT,
         String EquipNum,
         String SubComponent)
        {
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "DELETE FROM `tbl_full_plant` WHERE `PLANT` = '" + PLANT + "' AND `EquipNum` = '" + EquipNum + "' AND `SubComponent` = '" + SubComponent + "'";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show("Delete data failed" + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public List<FullPlantObject> getList()
        {
            List<FullPlantObject> list = new List<FullPlantObject>();
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_full_plant;";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            fullPlant = new FullPlantObject();
                            fullPlant.PLANT = reader.GetString(0);
                            fullPlant.Unit = reader.GetString(1);
                            fullPlant.EquipNum = reader.GetString(2);
                            fullPlant.EquipDescrip = reader.GetString(3);
                            fullPlant.EquipType = reader.GetString(4);
                            fullPlant.SubComponent = reader.GetString(5);
                            fullPlant.SubComponentDescrip = reader.GetString(6);
                            fullPlant.MOC = reader.GetString(7);
                            fullPlant.LMOC = reader.GetString(8);
                            fullPlant.HeightLength = reader.GetDouble(9);
                            fullPlant.Diameter = reader.GetDouble(10);
                            fullPlant.NominalThick = reader.GetDouble(11);
                            fullPlant.CA = reader.GetDouble(12);
                            fullPlant.DesignPressure = reader.GetDouble(13);
                            fullPlant.DesignTemp = reader.GetDouble(14);
                            fullPlant.OPPressInlet = reader.GetDouble(15);
                            fullPlant.OPTempInlet = reader.GetDouble(16);
                            fullPlant.OPPressOutlet = reader.GetDouble(17);
                            fullPlant.OPTempOutlet = reader.GetDouble(18);
                            fullPlant.TestPress = reader.GetDouble(19);
                            fullPlant.MDMT = reader.GetDouble(20);
                            fullPlant.InService = reader.GetBoolean(21);
                            fullPlant.ServiceDate = reader.GetString(22);
                            fullPlant.LastIsnpDate = reader.GetString(23);
                            fullPlant.LDTBXH = reader.GetBoolean(24);
                            fullPlant.Insulated = reader.GetBoolean(25);
                            fullPlant.PWHT = reader.GetBoolean(26);
                            fullPlant.InsulationType = reader.GetString(27);
                            fullPlant.OperatingState = reader.GetString(28);
                            fullPlant.InventoryLiquid = reader.GetDouble(29);
                            fullPlant.InventoryVapor = reader.GetDouble(30);
                            fullPlant.InventoryTotal = reader.GetDouble(31);
                            fullPlant.ConfidentInstream = reader.GetBoolean(32);
                            fullPlant.VaporDensityLessAir = reader.GetBoolean(33);
                            fullPlant.CorrosionInhibitor = reader.GetBoolean(34);
                            fullPlant.PrequentFeedChange = reader.GetBoolean(35);
                            fullPlant.MajorChemicals = reader.GetDouble(36);
                            fullPlant.Contaminant = reader.GetString(37);
                            fullPlant.OnlineMonitor = reader.GetBoolean(38);
                            fullPlant.CathodicProtection = reader.GetBoolean(39);
                            fullPlant.CorrosionMonitor = reader.GetBoolean(40);
                            fullPlant.OHCalibUpDate = reader.GetBoolean(41);
                            fullPlant.DistFromFacility = reader.GetDouble(42);
                            fullPlant.EquipCount = reader.GetDouble(43);
                            fullPlant.HAZOPRate = reader.GetDouble(44);
                            fullPlant.PersonDensity = reader.GetDouble(45);
                            fullPlant.MitigationEquip = reader.GetDouble(46);
                            fullPlant.EnvRate = reader.GetDouble(47);
                            fullPlant.InsTechUsed = reader.GetString(48);
                            fullPlant.EquidModification_Repair = reader.GetString(49);
                            fullPlant.InspFinding = reader.GetString(50);
                            fullPlant.VaporDensity = reader.GetDouble(51);
                            fullPlant.LiquidDensity = reader.GetDouble(52);
                            fullPlant.Vapor = reader.GetDouble(53);
                            fullPlant.Liquid = reader.GetDouble(54);
                            fullPlant.HMBPFDNum = reader.GetString(55);
                            fullPlant.PIDNum = reader.GetString(56);
                            fullPlant.Service = reader.GetString(57);
                            fullPlant.HMBStream = reader.GetString(58);
                            fullPlant.CrackPresent = reader.GetBoolean(59);
                            fullPlant.ProtectedBarrier = reader.GetBoolean(60);
                            fullPlant.ComponentType = reader.GetString(61);
                            fullPlant.LastCrackingInspDate = reader.GetString(62);
                            fullPlant.InternalLiner = reader.GetBoolean(63);
                            fullPlant.CatalogThin = reader.GetString(64);
                            fullPlant.NoInsp = reader.GetInt32(65);
                            fullPlant.CheckThin = reader.GetString(66);
                            fullPlant.Cladding = reader.GetBoolean(67);
                            fullPlant.Fom = reader.GetInt32(68);
                            fullPlant.Fip = reader.GetInt32(69);
                            fullPlant.Fdl = reader.GetInt32(70);
                            fullPlant.Fwd = reader.GetInt32(71);
                            fullPlant.Fam = reader.GetInt32(72);
                            fullPlant.Fsm = reader.GetDouble(73);
                            fullPlant.CorrosionRateMetal = reader.GetDouble(74);
                            fullPlant.CorrosionRateCladding = reader.GetDouble(75);
                            fullPlant.MinimumThick = reader.GetDouble(76);
                            fullPlant.ThickBaseMetal = reader.GetDouble(77);
                            fullPlant.LinningType = reader.GetString(78);
                            fullPlant.Flc = reader.GetInt32(79);
                            fullPlant.YearInservice = reader.GetInt32(80);
                            fullPlant.LevelCaustic = reader.GetString(81);
                            fullPlant.CatalogCaustic = reader.GetString(82);
                            fullPlant.LevelAmine = reader.GetString(83);
                            fullPlant.CatalogAmine = reader.GetString(84);
                            fullPlant.CatalogSulfide = reader.GetString(85);
                            fullPlant.pH = reader.GetDouble(86);
                            fullPlant.Sulfide_ppm = reader.GetDouble(87);
                            fullPlant.NoPWHT = reader.GetDouble(88);
                            fullPlant.HIC_H2S_Catalog = reader.GetString(89);
                            fullPlant.H2S_ppm = reader.GetDouble(90);
                            fullPlant.CacbonateCatalog = reader.GetString(91);
                            fullPlant.Cacbonate_ppm = reader.GetDouble(92);
                            fullPlant.CatalogPTA = reader.GetString(93);
                            fullPlant.Materials = reader.GetString(94);
                            fullPlant.HeatTreatment = reader.GetString(95);
                            fullPlant.CatalogCLSCC = reader.GetString(96);
                            fullPlant.TempPH = reader.GetDouble(97);
                            fullPlant.Clo_ppm = reader.GetDouble(98);
                            fullPlant.Catalog_HF = reader.GetString(99);
                            fullPlant.HFpresent = reader.GetBoolean(100);
                            fullPlant.BrinellHardness = reader.GetDouble(101);
                            fullPlant.Catalog_HIC_HF = reader.GetString(102);
                            fullPlant.SulfurPercent = reader.GetDouble(103);
                            fullPlant.Catalog_External = reader.GetString(104);
                            fullPlant.ExternalDriver = reader.GetString(105);
                            fullPlant.CoatQuality = reader.GetString(106);
                            fullPlant.CatalogCUI = reader.GetString(107);
                            fullPlant.DriverCUI = reader.GetString(108);
                            fullPlant.CorrosionRateCUI = reader.GetDouble(109);
                            fullPlant.Complexity = reader.GetString(110);
                            fullPlant.Insulation = reader.GetString(111);
                            fullPlant.AllowConfig = reader.GetBoolean(112);
                            fullPlant.EnterSoil = reader.GetBoolean(113);
                            fullPlant.InsulationTypeCUI = reader.GetString(114);
                            fullPlant.CatalogExtCLSCC = reader.GetString(115);
                            fullPlant.DriverExtCLSCC = reader.GetString(116);
                            fullPlant.PipingComplexity = reader.GetString(117);
                            fullPlant.InsulationCondition = reader.GetString(118);
                            fullPlant.HTHA_Catalog = reader.GetString(119);
                            fullPlant.AgeHTHA = reader.GetInt32(120);
                            fullPlant.TempHTHA = reader.GetDouble(121);
                            fullPlant.PH2 = reader.GetDouble(122);
                            fullPlant.TempMinBrittle = reader.GetDouble(123);
                            fullPlant.TempUpsetBrittle = reader.GetDouble(124);
                            fullPlant.NBP = reader.GetDouble(125);
                            fullPlant.TempImpact = reader.GetDouble(126);
                            fullPlant.MaterialCurve = reader.GetString(127);
                            fullPlant.LowTemp = reader.GetBoolean(128);
                            fullPlant.SCE = reader.GetDouble(129);
                            fullPlant.ReferenceTemp = reader.GetDouble(130);
                            fullPlant.TempMin885 = reader.GetDouble(131);
                            fullPlant.BrittleCheck = reader.GetBoolean(132);
                            fullPlant.TempShut = reader.GetDouble(133);
                            fullPlant.PercentSigma = reader.GetDouble(134);
                            fullPlant.NoFailure = reader.GetString(135);
                            fullPlant.SeverityVibration = reader.GetString(136);
                            fullPlant.NoWeek = reader.GetDouble(137);
                            fullPlant.CyclicType = reader.GetString(138);
                            fullPlant.CorrectAction = reader.GetString(139);
                            fullPlant.ToTalPiping = reader.GetDouble(140);
                            fullPlant.TypeOfPiping = reader.GetString(141);
                            fullPlant.PipeCondition = reader.GetString(142);
                            fullPlant.BranchDiametter = reader.GetDouble(143);
                            fullPlant.Fluid = reader.GetString(144);
                            fullPlant.MaterialsCA = reader.GetString(145);
                            fullPlant.FluidPhase = reader.GetString(146);
                            fullPlant.FluidType = reader.GetString(147);
                            fullPlant.ReleaseFluid = reader.GetString(148);
                            fullPlant.StoredPressure = reader.GetDouble(149);
                            fullPlant.AtmosphericPressure = reader.GetDouble(150);
                            fullPlant.StoredTemp = reader.GetDouble(151);
                            fullPlant.AtmosphericTemp = reader.GetDouble(152);
                            fullPlant.Reynol = reader.GetDouble(153);
                            fullPlant.MitigationSystem = reader.GetInt32(154);
                            fullPlant.ToxicMaterialsLV1 = reader.GetString(155);
                            fullPlant.ToxicPercent = reader.GetDouble(156);
                            fullPlant.ReleaseDuration = reader.GetString(157);
                            fullPlant.NonToxic_NonFlammable = reader.GetString(158);
                            fullPlant.OutageMultiplier = reader.GetDouble(159);
                            fullPlant.ProductionCost = reader.GetDouble(160);
                            fullPlant.InjuryCost = reader.GetDouble(161);
                            fullPlant.EnvCost = reader.GetDouble(162);
                            fullPlant.EquipmentCost = reader.GetDouble(163);
                            fullPlant.PoolFireType = reader.GetString(164);
                            fullPlant.MassFractionLiquid = reader.GetDouble(165);
                            fullPlant.FractionFuild = reader.GetDouble(166);
                            fullPlant.BubblePointTemp = reader.GetDouble(167);
                            fullPlant.DewPointVapor = reader.GetDouble(168);
                            fullPlant.TimeSteady = reader.GetDouble(169);
                            fullPlant.SpecificHeat = reader.GetDouble(170);
                            fullPlant.MassFrammableVapor = reader.GetDouble(171);
                            fullPlant.MassFract = reader.GetDouble(172);
                            fullPlant.VolumeLiquid = reader.GetDouble(173);
                            fullPlant.BubblePointPress = reader.GetDouble(174);
                            fullPlant.WindSpeed = reader.GetDouble(175);
                            fullPlant.AreaType = reader.GetString(176);
                            fullPlant.GroundTemp = reader.GetDouble(177);
                            fullPlant.AmbientCondition = reader.GetString(178);
                            fullPlant.Humidity = reader.GetDouble(179);
                            fullPlant.MoleFract = reader.GetDouble(180);
                            fullPlant.ToxicComponent = reader.GetString(181);
                            fullPlant.Criteria = reader.GetString(182);
                            fullPlant.GradeLevelCloud = reader.GetDouble(183);
                            fullPlant.RepresentFluid = reader.GetString(184);
                            fullPlant.MoleFlash = reader.GetDouble(185);
                            fullPlant.MaximumFillHeight = reader.GetDouble(186);
                            fullPlant.ReleaseHoleSize = reader.GetString(187);
                            fullPlant.ShellCourse = reader.GetInt32(188);
                            fullPlant.CHT = reader.GetDouble(189);
                            fullPlant.EnvironSensitivity = reader.GetString(190);
                            fullPlant.P_dike = reader.GetDouble(191);
                            fullPlant.P_onsite = reader.GetDouble(192);
                            fullPlant.P_offsite = reader.GetDouble(193);
                            fullPlant.Tank_type = reader.GetString(194);
                            fullPlant.SoilHydraulic = reader.GetDouble(195);
                            fullPlant.Distance = reader.GetDouble(196);
                            fullPlant.Fc = reader.GetDouble(197);
                            fullPlant.OverPress = reader.GetDouble(198);
                            fullPlant.MAWP = reader.GetDouble(199);
                            fullPlant.Fenv = reader.GetInt32(200);
                            fullPlant.CheckPass = reader.GetBoolean(201);
                            fullPlant.CatalogRelief = reader.GetString(202);
                            fullPlant.FluidSeverityPoF = reader.GetString(203);
                            fullPlant.WelbullPoF = reader.GetString(204);
                            fullPlant.FluidSeverityLeak = reader.GetString(205);
                            fullPlant.WelbullLeak = reader.GetString(206);
                            fullPlant.TotalDemand = reader.GetDouble(207);
                            fullPlant.Fs = reader.GetDouble(208);
                            fullPlant.IsLeak = reader.GetBoolean(209);
                            fullPlant.LevelLeak = reader.GetString(210);
                            fullPlant.RateCapacity = reader.GetDouble(211);
                            fullPlant.TimeIsolate = reader.GetDouble(212);
                            fullPlant.FluidCost = reader.GetDouble(213);
                            fullPlant.PRDinletSize = reader.GetDouble(214);
                            fullPlant.PRDType = reader.GetString(215);
                            fullPlant.Fr = reader.GetDouble(216);
                            fullPlant.NoDay = reader.GetDouble(217);
                            fullPlant.IgnoreLeak = reader.GetBoolean(218);
                            fullPlant.RateReduct = reader.GetDouble(219);
                            fullPlant.MainCost = reader.GetDouble(220);
                            fullPlant.Fms = reader.GetDouble(221);
                            fullPlant.DetectionType = reader.GetString(222);
                            fullPlant.IsolationType = reader.GetString(223);
                            list.Add(fullPlant);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Load data Failure!" + e.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }
        public Boolean checkExist(String PLANT,
         String EquipNum,
         String SubComponent)
        {
            bool check = false;
            MySqlConnection conn = DBUtils.getDBConnection();
            conn.Open();
            String sql = "SELECT * FROM tbl_full_plant WHERE `PLANT` = '" + PLANT + "' AND `EquipNum` = '" + EquipNum + "' AND `SubComponent` = '" + SubComponent + "' ";
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = sql;
                cmd.Connection = conn;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                        check = true;
                }
            }
            catch
            {
                MessageBox.Show("SQLCmd Error!");
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return check;
        }
    }
}
