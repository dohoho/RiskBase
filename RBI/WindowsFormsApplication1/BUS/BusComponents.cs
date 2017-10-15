using RBI.DAL;
using RBI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS
{
    class BusComponents
    {
        Component com = new Component();
        ComponentsConnUtils comUtils = new ComponentsConnUtils();
        public void add( Component com)
        {
            comUtils.add(com.Name, com.Description, com.MOC, com.LinerMOC, com.HeightLength, com.Diameter, com.NorminalThickness, com.CA, com.DesignPressure, com.DesignTemp, com.NoEquidment, com.ComponentType);
        }
        public void edit(Component com, String olderComName, String olderNoEq)
        {
            comUtils.edit(com.Name, com.Description, com.MOC, com.LinerMOC, com.HeightLength, com.Diameter, com.NorminalThickness, com.CA, com.DesignPressure, com.DesignTemp, com.NoEquidment, com.ComponentType, olderComName, olderNoEq);
        }
        public void delete(Component com)
        {
            comUtils.delete(com.Name, com.NoEquidment);
        }
        public List<Component> loads()
        {
            return comUtils.loads();
        }
        public bool checkExist(Component com)
        {
            return comUtils.checkExist(com.Name, com.NoEquidment);
        }
        public double getCA(String name, String noEq)
        {
            return comUtils.getCA(name, noEq);
        }
        public Component getcom (String name, String noEq)
        {
            return comUtils.getcom(name, noEq);
        }
    }
}
