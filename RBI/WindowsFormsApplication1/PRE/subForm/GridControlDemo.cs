﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RBI.Object;
using RBI.BUS;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace RBI.PRE.subForm
{
    public partial class GridControlDemo : UserControl
    {
        public GridControlDemo()
        {
            InitializeComponent();
            Format_Grid();
            loadData();
        }
        private void Format_Grid()
        {
            gridView1.Columns.Clear();
            string[] field = {"PLANT",
                                "Unit",
                                "EquipNum",
                                "EquipDescrip",
                                "EquipType",
                                "SubComponent",
                                "SubComponentDescrip",
                                "MOC",
                                "LMOC",
                                "HeightLength",
                                "Diameter",
                                "NominalThick",
                                "CA",
                                "DesignPressure",
                                "DesignTemp",
                                "OPPressInlet",
                                "OPTempInlet",
                                "OPPressOutlet",
                                "OPTempOutlet",
                                "TestPress",
                                "MDMT",
                                "InService",
                                "ServiceDate",
                                "LastIsnpDate",
                                "LDTBXH",
                                "Insulated",
                                "PWHT",
                                "InsulationType",
                                "OperatingState",
                                "InventoryLiquid",
                                "InventoryVapor",
                                "InventoryTotal",
                                "ConfidentInstream",
                                "VaporDensityLessAir",
                                "CorrosionInhibitor",
                                "PrequentFeedChange",
                                "MajorChemicals",
                                "Contaminant",
                                "OnlineMonitor",
                                "CathodicProtection",
                                "CorrosionMonitor",
                                "OHCalibUpDate",
                                "DistFromFacility",
                                "EquipCount",
                                "HAZOPRate",
                                "PersonDensity",
                                "MitigationEquip",
                                "EnvRate",
                                "InsTechUsed",
                                "EquidModification_Repair",
                                "InspFinding",
                                "VaporDensity",
                                "LiquidDensity",
                                "Vapor",
                                "Liquid",
                                "HMBPFDNum",
                                "PIDNum",
                                "Service",
                                "HMBStream",
                                "CrackPresent",
                                "Fms",
                                "ProtectedBarrier",
                                "ComponentType",
                                "LastCrackingInspDate",
                                "InternalLiner",
                                "CatalogThin",
                                "NoInsp",
                                "CheckThin",
                                "Cladding",
                                "Fom",
                                "Fip",
                                "Fdl",
                                "Fwd",
                                "Fam",
                                "Fsm",
                                "CorrosionRateMetal",
                                "CorrosionRateCladding",
                                "MinimumThick",
                                "ThickBaseMetal",
                                "LinningType",
                                "Flc",
                                "YearInservice",
                                "LevelCaustic",
                                "CatalogCaustic",
                                "LevelAmine",
                                "CatalogAmine",
                                "CatalogSulfide",
                                "pH",
                                "Sulfide_ppm",
                                "NoPWHT",
                                "HIC_H2S_Catalog",
                                "H2S_ppm",
                                "CacbonateCatalog",
                                "Cacbonate_ppm",
                                "CatalogPTA",
                                "Materials",
                                "HeatTreatment",
                                "CatalogCLSCC",
                                "TempPH",
                                "Clo_ppm",
                                "Catalog_HF",
                                "HFpresent",
                                "BrinellHardness",
                                "Catalog_HIC_HF",
                                "SulfurPercent",
                                "Catalog_External",
                                "ExternalDriver",
                                "CoatQuality",
                                "CatalogCUI",
                                "DriverCUI",
                                "CorrosionRateCUI",
                                "Complexity",
                                "Insulation",
                                "AllowConfig",
                                "EnterSoil",
                                "InsulationTypeCUI",
                                "CatalogExtCLSCC",
                                "DriverExtCLSCC",
                                "PipingComplexity",
                                "InsulationCondition",
                                "HTHA_Catalog",
                                "AgeHTHA",
                                "TempHTHA",
                                "PH2",
                                "TempMinBrittle",
                                "TempUpsetBrittle",
                                "NBP",
                                "TempImpact",
                                "MaterialCurve",
                                "LowTemp",
                                "SCE",
                                "ReferenceTemp",
                                "TempMin885",
                                "BrittleCheck",
                                "TempShut",
                                "PercentSigma",
                                "NoFailure",
                                "SeverityVibration",
                                "NoWeek",
                                "CyclicType",
                                "CorrectAction",
                                "ToTalPiping",
                                "TypeOfPiping",
                                "PipeCondition",
                                "BranchDiametter",
                                "Fluid",
                                "MaterialsCA",
                                "FluidPhase",
                                "FluidType",
                                "ReleaseFluid",
                                 "DetectionType",
                                "IsolationType",
                                "StoredPressure",
                                "AtmosphericPressure",
                                "StoredTemp",
                                "AtmosphericTemp",
                                "Reynol",
                                "MitigationSystem",
                                "ToxicMaterialsLV1",
                                "ToxicPercent",
                                "ReleaseDuration",
                                "NonToxic_NonFlammable",
                                "OutageMultiplier",
                                "ProductionCost",
                                "InjuryCost",
                                "EnvCost",
                                "EquipmentCost",
                                "PoolFireType",
                                "MassFractionLiquid",
                                "FractionFuild",
                                "BubblePointTemp",
                                "DewPointVapor",
                                "TimeSteady",
                                "SpecificHeat",
                                "MassFrammableVapor",
                                "MassFract",
                                "VolumeLiquid",
                                "BubblePointPress",
                                "WindSpeed",
                                "AreaType",
                                "GroundTemp",
                                "AmbientCondition",
                                "Humidity",
                                "MoleFract",
                                "ToxicComponent",
                                "Criteria",
                                "GradeLevelCloud",
                                "RepresentFluid",
                                "MoleFlash",
                                "MaximumFillHeight",
                                "ReleaseHoleSize",
                                "ShellCourse",
                                "CHT",
                                "EnvironSensitivity",
                                "P_dike",
                                "P_onsite",
                                "P_offsite",
                                "Tank_type",
                                "SoilHydraulic",
                                "Distance",
                                "Fc",
                                "OverPress",
                                "MAWP",
                                "Fenv",
                                "CheckPass",
                                "CatalogRelief",
                                "FluidSeverityPoF",
                                "WelbullPoF",
                                "FluidSeverityLeak",
                                "WelbullLeak",
                                "TotalDemand",
                                "Fs",
                                "IsLeak",
                                "LevelLeak",
                                "RateCapacity",
                                "TimeIsolate",
                                "FluidCost",
                                "PRDinletSize",
                                "PRDType",
                                "Fr",
                                "NoDay",
                                "IgnoreLeak",
                                "RateReduct",
                                "MainCost"
                               };
            string[] caption = { "PLANT",
                                "Unit",
                                "EquipNum",
                                "Equip Description",
                                "Type",
                                "Sub Component",
                                "SubComp Description",
                                "MOC",
                                "Liner MOC",
                                "Height Length(m)",
                                "Diameter(m)",
                                "Nominal Thickness(mm)",
                                "CA(mm)",
                                "Design Pressure(barg)",
                                "Design Temp(C)",
                                "Opering Press(barg) Inlet",
                                "Opering Temp(C) Inlet",
                                "Opering Press(barg) Outlet",
                                "Opering Temp(C) Outlet",
                                "Test Press(barg)",
                                "MDMT,C",
                                "In Service?",
                                "Service Date (mm/dd/yyyy)",
                                "Last Insp Date (mm/dd/yyyy)",
                                "LDTBXH Covered?",
                                "Insulated?",
                                "PWHT?",
                                "Insulation Type",
                                "Operating State (Vapor/Liquid/Slurry)",
                                "Inventory Liquid(lbs)",
                                "Inventory Vapor(lbs)",
                                "Inventory Total(lbs)",
                                "Confident InStream Analysis?",
                                "Vapor Density < Air?",
                                "Corrosion Inhibitor?",
                                "Prequent Feed Change?",
                                "Major Chemicals (with %weight)",
                                "Contaminant",
                                "Online Monitor?",
                                "Cathodic Protection?",
                                "Corrosion Monitor?",
                                "OHCalib UptoDate?",
                                "Dist From Facility",
                                "Equip Count",
                                "HAZOP Rating",
                                "Person Density(people/km2)",
                                "Mitigation Equip",
                                "Env Rating",
                                "InspTech Used",
                                "Equid Modification/Repair",
                                "Insp Findings",
                                "Vapor Density(kg/m3)",
                                "Liquid Density(kg/m3)",
                                "Vapor(kg)",
                                "Liquid(kg)",
                                "HMBPFDNum",
                                "PIDNum",
                                "Service",
                                "HMBStream",
                                "Crack Present?",
                                "Management Systems Factor, Fms",
                                "Protected Barrier?",
                                "Component Type",
                                "Last Cracking InspDate(mm/dd/yyyy)",
                                "Internal Liner?",
                                "Catalog Thinning",
                                "NoInsp",
                                "Check Thinning?",
                                "Cladding?",
                                "On-Line Monitoring Adjustment Factor,Fom",
                                "Injection Point,Fip",
                                "Dead Legs,Fdl",
                                "Welded Contruction,Fwd",
                                "Maintenance Accordance, Fam",
                                "Settlement, Fsm",
                                "Corrosion Rate for Base Metal (mmpy)",
                                "Corrosion rate for Cladding (mmpy)",
                                "Minimum Required Wall Thickness, mm",
                                "Thickness of comp base metal (mm)",
                                "Lining Type",
                                "Lining Condition Adjusment, Flc",
                                "Year in Service",
                                "Level Caustic",
                                "Inspection Effective Catalog caustic",
                                "Level Amine",
                                "Inspection Effective Catalog Amine",
                                "Inspection Effective Catalog Sulfide",
                                "pH",
                                "Sulfide Concentration(ppm)",
                                "Max Brinnell Hardness",
                                "Inspection Effective Catalog HIC/H2S",
                                "H2S Concentration(ppm)",
                                "Inspection Effective Catalog Cacbon",
                                "Cacbon Concentration(ppm)",
                                "Inspection Effective Catalog PTA",
                                "Materials",
                                "Function of Heat Treatment",
                                "Inspection Effective Catalog CLSCC",
                                "Temperature of pH, C",
                                "Clo Concentration(ppm)",
                                "Inspection Effective Catalog HF",
                                "HF present?",
                                "Brinell Hardness of Weldments",
                                "Inspection Effective Catalog HIC/HF",
                                "Sulfur Concentration, %S",
                                "Inspection Effective Catalog Extenal Corrosion",
                                "Driver Extend",
                                "Coat Quality",
                                "Inspection Effective Catalog CUI",
                                "Driver CUI",
                                "Corrosion Rate for CUI, mmpy",
                                "Complexity",
                                "Insulation",
                                "Allow Config?",
                                "Enter Soil?",
                                "Insulation Type",
                                "Inspection Effective Catalog External CLSCC",
                                "Driver External CLSCC",
                                "Piping Complexity",
                                "Insulation Condition",
                                "Inspection Effective Catalog HTHA",
                                "In-Service Time HTHA (hours/day)",
                                "Temperature HTHA ,C",
                                "Hydrogen Partial Pressure (MPa)",
                                "TempMin for Brittle Facture, C",
                                "Temp Upset for Brittle Facture, C",
                                "Normal Boiling Point, NBP ,C",
                                "Temp Impact, C",
                                "Material Curve",
                                "Low Temperature?",
                                "SCE",
                                "Reference Temperature, C",
                                "Temp Min for 885, C",
                                "Brittle Check?",
                                "Temp Shutdown",
                                "Percent Sigma",
                                "NoPre Fatigue Failures",
                                "Severity of Vibration",
                                "No.Weeks",
                                "Cyclic Type",
                                "Corrective Actions Take",
                                "Total Pipe Fitting",
                                "Type of Joint in This Piping",
                                "Condition of Pipe",
                                "Branch Diameter, NPS",
                                "Fluid",
                                "Materials CA",
                                "Fluid Phase",
                                "Fluid Type",
                                "Release Phase",
                                "Detection Type",
                                "Isolation Type",
                                "Stored Pressure, Mpa",
                                "Atmospheric Pressure,Mpa",
                                "Stored Temperature, C",
                                "Atmospheric Temperature, C",
                                "Reynol Constant",
                                "Mitigation System",
                                "Toxic Materials Level 1",
                                "Toxic Percent",
                                "Release Duration, Minutes",
                                "Non Toxic, Non Flamable Fluids",
                                "Outage Multiplier",
                                "Production Cost, $/day",
                                "Injury Cost, $/dead",
                                "Environment Cost, $",
                                "Equipment Cost, $/m2",
                                "Pool Fire Type",
                                "Mass Fraction Liquid",
                                "Fraction of Fluid Flashed",
                                "Bubble Point Temperature, C",
                                "Dew Point Temperature, C",
                                "Time for Steady Release, seconds",
                                "Specific Heat, J/kg-K",
                                "Mass of Flammable Material in Vapor Cloud, Kg",
                                "Mass Fraction of Release Rate, Kg",
                                "Volume of Liquid, (m3)",
                                "Bubble-Point Pressure, (kPa)",
                                "Wind Speed, (m/s)",
                                "Area Surface Type",
                                "Ground Temperature, C",
                                "Ambient Condition",
                                "Humidity, %",
                                "Mole Fraction of Release Rate",
                                "Toxic Component",
                                "Criteria",
                                "Grade Level Cloud",
                                "Represent Fluid",
                                "Moles Flash From Liquid to Vapor",
                                "Maximum Fill Height, m",
                                "Release Hole Size",
                                "i_th Shell Course",
                                "CHT",
                                "Environment Sensitivity",
                                "Percentage of Fluid Leaving the Dike, %",
                                "Percent on-site, %",
                                "Percent off-site, %",
                                "Tank Type",
                                "Soil Hydraulic Conductivity, m/day",
                                "Distance to the Groundwater Underneath the Tank, m",
                                "Adjustment Factor for Conventional Valves",
                                "Overpressure, kPa",
                                "Maximum Allowable Working Pressure, kPa",
                                "Adjustment Factor for Environmental Factors",
                                "Check is Pass?",
                                "Catalog Relief Device",
                                "Fluid Severity PoF",
                                "Welbull PoF",
                                "Fluid Severity Leakage",
                                "Weibull Leakage",
                                "Total Demand Rate, demands/year",
                                "Adjustment Factor for the Presence of Soft Seats",
                                "IsLeakage?",
                                "Level Leakage",
                                "Rated Capacity of a PRD, kg/hr",
                                "Time To Isolate, mins",
                                "The Fluid Costs, $/kg",
                                "PRD Inlet Size, cm",
                                "PRDs Type",
                                "Recovery Factor",
                                "number of days required to shut a unit down, days",
                                "Ignore Leakage?",
                                "Rate Reduction",
                                "Maintenance Cost, $"
                                };
            for(int i = 0; i< field.Length; i++)
            {
                DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
                col.FieldName = field[i];
                col.Caption = caption[i];
                gridView1.Columns.Add(col);
                gridView1.Columns[i].Visible = true;
            }
            gridView1.BestFitColumns();
            //data format
            int[] j = { 0,1,2,3,4,5,6,7,8,27,28,36,37,55,56,57,58,62,65,67,70,71,72,73,74,79,80,82,83,84,85,86,90,92,94,95,96,97,
                        100,103,105,106,107,108,109,111,112,115,116,117,118,119,120,135,136,137,139,140,142,143,145,146,147,148,149,
                        157,158,160,161,167,179,181,184,185,187,190,193,197,200,203,205,206,207,208,209,211,213,218,219};
            for(int k = 0; k<j.Length; k++)
            {
                gridView1.Columns[j[k]].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            }
        }
        private void loadData()
        {
            BusFullPlant bus = new BusFullPlant();
            List<FullPlantObject> list = bus.load();
            gridControl1.DataSource = list;
        }

        private void gridView1_RowCellDefaultAlignment(object sender, RowCellAlignmentEventArgs e)
        {
            GridView Xgv = sender as GridView;
            DataRow dtRow = Xgv.GetDataRow(e.RowHandle);
            e.HorzAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
    }
}
