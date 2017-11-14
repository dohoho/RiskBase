using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.PRE.subForm.InputDataForm;
using RBI.PRE.subForm.OutputDataForm;
namespace RBI.Object
{
    class ucTabNormal
    {
        public int ID { set; get; }
        public UCAssessmentInfo ucAss { set; get; }
        public UCEquipmentProperties ucEq { set; get; }
        public UCComponentProperties ucComp { set; get; }
        public UCOperatingCondition ucOpera { set; get; }
        public UCCoatLiningIsulationCladding ucCoat { set; get; }
        public UCMaterial ucMaterial { set; get; }
        public UCStream ucStream { set; get; }
        public UCCA ucCA { set; get; }
        public UCRiskFactor ucRiskFactor { set; get; }
        public UCEquipmentPropertiesTank ucEquipmentTank {set;get;}
        public UCComponentPropertiesTank ucComponentTank {set; get;}
        public UCMaterialTank ucMaterialTank {set; get;}
        public UCStreamTank ucStreamTank {set; get;}
        public ucTabNormal(int id, UCAssessmentInfo u1, UCEquipmentProperties u2, UCComponentProperties u3, UCOperatingCondition u4, 
            UCCoatLiningIsulationCladding u5, UCMaterial u6, UCStream u7, UCCA u8, UCRiskFactor u9)
        {
            ID = id;
            ucAss = u1;
            ucEq = u2;
            ucComp = u3;
            ucOpera = u4;
            ucCoat = u5;
            ucMaterial = u6;
            ucStream = u7;
            ucCA = u8;
            ucRiskFactor = u9;
        }
        public ucTabNormal(int ID, UCAssessmentInfo u1, UCEquipmentPropertiesTank u2, UCComponentPropertiesTank u3, UCMaterialTank u4, UCStreamTank u5)
        {
            this.ID = ID;
            ucAss = u1;
            ucEquipmentTank = u2;
            ucComponentTank = u3;
            ucMaterialTank = u4;
            ucStreamTank = u5;
        }
    }
}
