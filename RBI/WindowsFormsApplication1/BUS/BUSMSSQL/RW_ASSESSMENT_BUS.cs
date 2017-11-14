using System;
using RBI.DAL.MSSQL;
using RBI.Object.ObjectMSSQL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.Object;

namespace RBI.BUS.BUSMSSQL
{
    class RW_ASSESSMENT_BUS
    {
        RW_ASSESSMENT_ConnectUtils DAL = new RW_ASSESSMENT_ConnectUtils();
        public void add(RW_ASSESSMENT obj)
        {
            DAL.add(obj.EquipmentID, obj.ComponentID, obj.AssessmentDate, obj.AssessmentMethod, obj.RiskAnalysisPeriod, obj.IsEquipmentLinked, obj.RecordType, obj.ProposalNo, obj.RevisionNo, obj.IsRecommend, obj.ProposalOrRevision, obj.AdoptedBy, obj.AdoptedDate, obj.RecommendedBy, obj.RecommendedDate, obj.ProposalName);
        }
        public void edit(RW_ASSESSMENT obj)
        {
            DAL.edit(obj.ID, obj.EquipmentID, obj.ComponentID, obj.AssessmentDate, obj.AssessmentMethod, obj.RiskAnalysisPeriod, obj.IsEquipmentLinked, obj.RecordType, obj.ProposalNo, obj.RevisionNo, obj.IsRecommend, obj.ProposalOrRevision, obj.AdoptedBy, obj.AdoptedDate, obj.RecommendedBy, obj.RecommendedDate, obj.ProposalName);
        }
        public void delete(RW_ASSESSMENT obj)
        {
            DAL.delete(obj.ID);
        }
        public List<RW_ASSESSMENT> getDataSource()
        {
            return DAL.getDataSource();
        }
        public int getEquipmentID(int ID)
        {
            return DAL.getEquipmentID(ID);
        }
        public DateTime getAssessmentDate(int ID)
        {
            return DAL.getAssessmentDate(ID);
        }
        public Boolean checkExistAssessment(int ID)
        {
            return DAL.checkExistAssessment(ID);
        }
        public int[] getEquipmentID_ComponentID(int ID)
        {
            return DAL.getEquipmentID_ComponentID(ID);
        }
    }
}
