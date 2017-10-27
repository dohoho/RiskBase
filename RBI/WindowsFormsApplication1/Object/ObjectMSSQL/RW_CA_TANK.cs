using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class RW_CA_TANK
    {
        public float FLUID_HEIGHT { set; get; }
        public float SHELL_COURSE_HEIGHT { set; get; }
        public float TANK_DIAMETER { set; get; }
        public int PREVENTION_BARRIER { set; get; }//Release Prevention Barrier
        public String EnvironSensitivity { set; get; }
        public float P_lvdike { set; get; }
        public float P_onsite { set; get; }
        public float P_offsite { set; get; }
        public String Soil_type { set; get; }
        public String TANK_FLUID { set; get; }
        public float Swg { set; get; }
    }
}
