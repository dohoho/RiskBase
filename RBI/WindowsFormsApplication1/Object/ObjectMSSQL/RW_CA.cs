using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_CA
    {
        public string Fluid { set; get; }
        public float EquipmentCost { set; get; }
        public float InjureCost { set; get; }
        public float EnvironmentCost { set; get; }
        public float ToxicPercent { set; get; }
        public string ReleaseDuration { set; get; }
        public float PersonDensity { set; get; }
        //cac dau vao chung cho ca Tank
        public string FluidPhase { set; get; }
        public float MaterialCost { set; get; }
        public float ProductionCost { set; get; }
        public string DetectionType { set; get; }
        public string IsulationType { set; get; }
        public float MassInvert { set; get; }
        public float MassComponent { set; get; }
        public string MittigationSystem { set; get; }
        public float StoredPressure { set; get; }
        public float AtmosphericPressure { set; get; } 
        public float StoredTemp { set; get; }
        public float AtmosphereTemperature { set; get; }
    }
}
