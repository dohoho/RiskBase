using RBI.DAL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS
{
    class BusRiskDemo
    {
        RiskSummary risk = new RiskSummary();
        RiskSummaryConnUtils1 riskUtils = new RiskSummaryConnUtils1();
        public bool checkExist(RiskSummary risk)
        {
            return riskUtils.checkExist(risk.ComName, risk.ItemNo);
        }
        public void add(RiskSummary risk)
        {
            if (!checkExist(risk))
            {
                riskUtils.add(
                        risk.ItemNo,
                        risk.EqDesc,
                        risk.EqType,
                        risk.ComName,
                        risk.RepresentFluid,
                        risk.FluidPhase,
                        risk.CotcatFlammable,
                        risk.CurrentRisk,
                        risk.CotcatPeople,
                        risk.CotcatAsset,
                        risk.CotcatEnv,
                        risk.CotcatReputation,
                        risk.CotcatCombinled,
                        risk.ComponentMaterialGrade,
                        risk.InitThinningCategory,
                        risk.InitEnvCracking,
                        risk.InitOtherCategory,
                        risk.InitCategory,
                        risk.ExtThinningCategory,
                        risk.ExtEnvCracking,
                        risk.ExtOtherCategory,
                        risk.ExtCategory,
                        risk.POFCategory,
                        risk.CurrentRiskCal,
                        risk.FutureRisk);
            }
            else
            {

            }
            
        }
        public List<RiskSummary> loads()
        {
            return riskUtils.loads();
        }
    }
}
