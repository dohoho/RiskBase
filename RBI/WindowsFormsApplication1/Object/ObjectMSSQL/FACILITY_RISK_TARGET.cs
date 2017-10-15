using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object.ObjectMSSQL
{
    public class FACILITY_RISK_TARGET
    {
        public int FacilityID { set; get; }
        public double RiskTarget_A { set; get; }
        public double RiskTarget_B { set; get; }
        public double RiskTarget_C { set; get; }
        public double RiskTarget_D { set; get; }
        public double RiskTarget_E { set; get; }
        public double RiskTarget_CA { set; get; }
        public double RiskTarget_FC { set; get; }
    }
}
