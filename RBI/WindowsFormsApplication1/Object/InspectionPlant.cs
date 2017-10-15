using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.Object
{
    class InspectionPlant
    {
        String itemNo;
        String damageMechanism;
        String method;
        String coverage;
        String availability;
        String lastInspectionDate;
        String inspectionInterval;
        String dueDate;
        String system;
        public String ItemNo
        {
            set
            {
                itemNo = value;
            }
            get
            {
                return itemNo;
            }
        }
        public String DamageMechanism
        {
            set
            {
                damageMechanism = value;
            }
            get
            {
                return damageMechanism;
            }
        }
        public String Method
        {
            set
            {
                method = value;
            }
            get
            {
                return method;
            }
        }
        public String Coverage
        {
            set
            {
                coverage = value;
            }
            get
            {
                return coverage;
            }
        }
        public String Availability
        {
            set
            {
                availability = value;
            }
            get
            {
                return availability;
            }
        }
        public String LastInspectionDate
        {
            set
            {
                lastInspectionDate = value;
            }
            get
            {
                return lastInspectionDate;
            }
        }
        public String InspectionInterval
        {
            set
            {
                inspectionInterval = value;
            }
            get
            {
                return inspectionInterval;
            }
        }
        public String DueDate
        {
            set
            {
                dueDate = value;
            }
            get
            {
                return dueDate;
            }
        }
        public String System
        {
            set
            {
                system = value;
            }
            get
            {
                return system;
            }
        }
    }
}
