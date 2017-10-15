using RBI.DAL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS
{
    class BusRiskSummary
    {
        RiskSummary risk = new RiskSummary();
        RiskSummaryConnUtils riskUtils = new RiskSummaryConnUtils();
        public bool checkExist(RiskSummary risk)
        {
            return riskUtils.checkExist(risk.ComName, risk.ItemNo);
        }
        public void add(RiskSummary risk)
        {
            riskUtils.add(risk.ComName,
                        risk.ItemNo,
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
        public void edit(RiskSummary risk)
        {
            riskUtils.edit(risk.ComName,
                        risk.ItemNo,
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
                        risk.FutureRisk
                     );
        }
        public void delete(String comName, String itemNo)
        {
            riskUtils.delete(comName,itemNo);
        }
        public List<RiskSummary> loads()
        {
            return riskUtils.loads();
        }
    }
}
