using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.DAL;
using System.Diagnostics;
namespace RBI.BUS.Calculator.StorageTank
{   
    /// <summary>
    ///Determine the Financial Consequences for Tank Shell Course
    /// </summary>
    class TankShellCourse
    {
        RBICalculatorConn rbi = new RBICalculatorConn();
        consequenceAnalysisLvl1 financial = new consequenceAnalysisLvl1();
        //public TankShellCourse()
        //{
        //    financial.componentType = "COURSE-1";
        //    financial.popdens = 2;
        //    financial.injcost = 2;
        //    financial.fluid = "C5";
        //    financial.mass_inv = 5;
        //    financial.envcost = 1;
        //    financial.releasePhase = "Liquid";
        //    financial.material = "Carbon Steel";
        //    financial.fluid = "C9-C12";
        //    financial.fluidPhase = "Liquid";
        //    financial.idealGasConstant = "B";
        //    financial.fluidType = "TYPE 0";
        //    financial.releasePhase = "Liquid";
        //    financial.detectionType = 1;
        //    financial.isolationType = 2;
        //    financial.p_s = 850;
        //    financial.p_atm = 101;
        //    financial.t_s = 980;
        //    financial.t_atm = 300;
        //    financial.r_e = 20;
        //    financial.mass_inv = 15000;
        //    financial.mass_comp = 800;
        //    financial.mitigationSystem = 2;
        //    financial.mfrac_tox = 0.3;
        //    financial.materialType = "1.25Cr-0.5Mo";
        //    financial.releaseDuration = "10";
        //    financial.nfntReleaseFluid = "Steam";
        //    financial.outage_mult = 5;
        //    financial.prodcost = 100000;
        //    financial.injcost = 10000;
        //    financial.envcost = 50000;
        //    financial.popdens = 0.15;
        //    financial.equipcost = 300000;
        //}
        #region Determine Release Rate and Volume
        const double g = 32.2; // ft/s2 gravity 
        public double h_liq { set; get; } //maximum fill height in the tank [ft]
        public String ReleaseHoleSize { set; get; }
        public double Cd = 0.61; //recommend = 0.61 
        private double dn { set; get; } //table 7.3 khong can nhap
        public int i_th { set; get; } //i_th shell course
        private double Bbl_avail_n { set; get; } //duoc gan gia tri o phia duoi ko can nhap
        public double D_tank { set; get; } //[ft]
        public double CHT { set; get; } //is the height of each shell course
        private double Bbl_rupture_n { set; get; } //duoc gan gia tri o phia duoi khong can nhap
        /*Calculate Parameter*/
        private double min_max(double a, double b, bool IsMin)
        {
            if (IsMin) return a < b ? a : b;
            else return a > b ? a : b;
        }
        //Step 1: Determine rate_n = W_n
        public double A_n()
        {
            if (ReleaseHoleSize == "Rupture") dn = 12 * D_tank / 4;
            else dn = rbi.getHoleDiameter(ReleaseHoleSize);
            return (Math.PI * Math.Pow(dn, 2)) / 4;
        }
        public double W_n() // [bbls/day]
        {
            return (rbi.getC(32)) * Cd * A_n() * Math.Sqrt(2 * g * h_liq);    
        }
        //Step 2: Determine t_ld
        public int t_ld() //is the leak time [day]
        {
            return dn <= 3.17 ? 7 : 1;
        }
        //Step 3: calculate the leak duration, ld_n
        public double ld_n()
        {
            Bbl_avail_n = (Math.PI * Math.Pow(D_tank, 2)) * (h_liq - (i_th - 1) * CHT) / (4*(rbi.getC(13)));
            Bbl_rupture_n = Bbl_avail_n;
            return min_max(Bbl_avail_n / W_n(), 7.0, true); //find min
        }
        //Step 4: calculate the release volume from leakage, Bbl_leak_n
        public double Bbl_leak_n()
        {
            return min_max(W_n() * ld_n(), Bbl_avail_n, true);
        }
        //Step 5: calculate the release volume from a rupture, Bbl_rupture_n = Bbl_avail_n  
        #endregion

        #region Determine the Financial Consequences for Tank Shell Course
        public String componentType { set; get; }
        public String EnvironSensitivity { set; get; }
        public double P_lvdike { set; get; }
        public double P_onsite { set; get; }
        public double P_offsite { set; get; }
        private double C_indike { set; get; } // table 7.6
        private double C_ss_onsite { set; get; } // table 7.6
        private double C_ss_offsite { set; get; } // table 7.6
        private double C_water { set; get; } // table 7.6
        //Step 1: Determine P_lvdike, P_onsite, P_offsite do chuyên gia nhập liệu
        //Step 2: Determine C_indike, C_ss_onsite, C_ss_offsite, C_water table 7.6
        public void getCost()
        {
            int[] val = rbi.getCost(EnvironSensitivity);
            C_indike = val[0];
            C_ss_onsite = val[1];
            C_ss_offsite = val[2];
            C_water = val[5];
        }
        
        //Step 3: Determine Bbl_leak_release
        public double Bbl_leak_release()
        {
            double sum = 0;
            for (int i = 1; i < 3; i++)
            {
                sum += Bbl_leak_n() * double.Parse(rbi.getGff(componentType, i));
            }
            return sum / double.Parse(rbi.getGff(componentType));
        }
        //Step 4: Compute 4 parameters Bbl_leak_indike, Bbl_leak_ssonsite, Bbl_leak_ssoffsite, Bbl_leak_water
        public double Bbl_leak_indike()
        {
            return Bbl_leak_release() * (1 - P_lvdike / 100);
        }
        public double Bbl_leak_ssonsite()
        {
            return P_onsite * (Bbl_leak_release() - Bbl_leak_indike()) / 100;
        }
        public double Bbl_leak_ssoffsite()
        {
            return P_offsite * (Bbl_leak_release() - Bbl_leak_indike() - Bbl_leak_ssonsite()) / 100;
        }
        public double Bbl_leak_water()
        {
            return Bbl_leak_release() - (Bbl_leak_indike() + Bbl_leak_ssonsite() + Bbl_leak_ssoffsite());
        }
        //Step 5: Compute FC_leakage_environ
        public double FC_leak_environ()
        {
            return Bbl_leak_indike() * C_indike + Bbl_leak_ssonsite() * C_ss_onsite + Bbl_leak_ssoffsite() * C_ss_offsite + Bbl_leak_water() * C_water;
        }
        //Step 6: Determine Bbl_rupture_release
        public double Bbl_rupture_release()
        {
            return Bbl_rupture_n * double.Parse(rbi.getGff(componentType, 4)) / double.Parse(rbi.getGff(componentType));
        }
        //Step 7: Compute 4 parameter Bbl_rupture_indike, Bbl_rupture_ssonsite, Bbl_rupture_ssoffsite, Bbl_rupture_water
        public double Bbl_rupture_indike()
        {
            return Bbl_rupture_release() * (1 - P_lvdike / 100);
        }
        public double Bbl_rupture_ssonsite()
        {
            return P_onsite * (Bbl_rupture_release() - Bbl_rupture_indike()) / 100;
        }
        public double Bbl_rupture_ssoffsite()
        {
            return P_offsite * (Bbl_rupture_release() - Bbl_rupture_indike() - Bbl_rupture_ssonsite()) / 100;
        }
        public double Bbl_rupture_water()
        {
            return Bbl_rupture_release() - (Bbl_rupture_indike() + Bbl_rupture_ssonsite() + Bbl_rupture_ssoffsite());
        }
        //Step 8: Compute FC_rupture_environ
        public double FC_rupture_environ()
        {
            return Bbl_rupture_indike() * C_indike + Bbl_rupture_ssonsite() * C_ss_onsite + Bbl_rupture_ssoffsite() * C_ss_offsite + Bbl_rupture_water() * C_water;
        }
        //Step 9: Compute FC_environ
        public double FC_environ()
        {
            return FC_leak_environ() + FC_rupture_environ();
        }
        //Step 10: Compute FC_cmd
        public double FC_cmd()
        {
            return financial.fc_cmd();
        }
        //Step 11: Compute FC_prod
        public double FC_prod()
        {
            return financial.fc_prod();
        }
        //Step 12: Compute total Financial
        public double FC_total_shell()
        {
            getCost();
            return FC_cmd() + FC_environ() + FC_prod();
        }
        #endregion
    }

    /// <summary>
    /// Determine the Fianancial for the Tank Bottom
    /// </summary>
    class TankBottom
    {
        RBICalculatorConn rbi = new RBICalculatorConn();
        consequenceAnalysisLvl1 financial = new consequenceAnalysisLvl1();
        //public TankBottom()
        //{
        //    //financial.Materials = "1.25Cr-0.5Mo";
        //    financial.componentType = "COURSE-1";
        //    financial.popdens = 2;
        //    financial.injcost = 2;
        //    financial.fluid = "C5";
        //    financial.mass_inv = 5;
        //    financial.envcost = 1;
        //    financial.releasePhase = "Liquid";
        //    financial.material = "Carbon Steel";
        //    financial.fluid = "C9-C12";
        //    financial.fluidPhase = "Liquid";
        //    financial.idealGasConstant = "B";
        //    financial.fluidType = "TYPE 0";
        //    financial.releasePhase = "Liquid";
        //    financial.detectionType = 1;
        //    financial.isolationType = 2;
        //    financial.p_s = 850;
        //    financial.p_atm = 101;
        //    financial.t_s = 980;
        //    financial.t_atm = 300;
        //    financial.r_e = 20;
        //    financial.mass_inv = 15000;
        //    financial.mass_comp = 800;
        //    financial.mitigationSystem = 2;
        //    financial.mfrac_tox = 0.3;
        //    financial.materialType = "1.25Cr-0.5Mo";
        //    financial.releaseDuration = "10";
        //    financial.nfntReleaseFluid = "Steam";
        //    financial.outage_mult = 5;
        //    financial.prodcost = 500000;
        //    financial.injcost = 10000;
        //    financial.envcost = 50000;
        //    financial.popdens = 0.15;
        //    financial.equipcost = 300000;
        //}
        #region Release Rate and Volume
        public double g = 32.2; // ft/s2
        public double dn { set; get; }
        public double h_liq { set; get; }
        public String tankType { set; get; } //for Step 2
        public double C_qo { set; get; } //C_qo = 0.21 for consequence analysis
        public double k_h { set; get; } // độ dẫn nước của đất [ft/day]
        public double Bbl_total { set; get; } //total volume
        public double D_tank { set; get; } //[m] or [ft]
        public double Bbl_rupture_n { set; get; } //Bbl_total
        public String EnvironSensitivity { set; get; }
        public String ReleaseHolSize { set; get; }
        private double min_max(double a, double b, bool IsMin)
        {
            if (IsMin) return a < b ? a : b;
            else return a > b ? a : b;
        }
        //Step 1: Determine rate_n = W_n
        public double n_rh()
        {
            double d_tank = 0;
            if (D_tank <= 150) d_tank = 100;
            else if (D_tank <= 250) d_tank = 200;
            else d_tank = 300;
            int nrh = rbi.getN_rh(d_tank, ReleaseHolSize);
            double C36 = (rbi.getC(36));
            double temp = min_max(Math.Round(Math.Pow(D_tank / C36, 2), 1), 1, false);
            if (temp <= 2.5) return 1;
            else if (temp <= 6.5) return 4;
            else return 9;
        }
        public double rate_n()
        {
            if (ReleaseHolSize == "Rupture") dn = 12 * (D_tank) / 4;
            else dn = rbi.getHoleDiameter(ReleaseHolSize);
            if (k_h >(rbi.getC(34)) * Math.Pow(dn, 2))
                return(rbi.getC(33)) * Math.PI * dn * Math.Sqrt(2 * g * h_liq) * n_rh();
            else
                return (rbi.getC(35)) * C_qo * Math.Pow(dn, 0.2) * Math.Pow(h_liq, 0.9) * Math.Pow(k_h, 0.74) * n_rh();
        }
        
        //Step 2: Determine t_ld, leak time duration
        public double t_ld() //[days]
        {
            if (tankType == "Concrete" || tankType == "Asphalt") return 7;
            else if (tankType == "Release Prevention") return 30;
            else return 360;
        }
        //Step 3: calculate the leak duration, ld_n
        public double ld_n()
        {
            Bbl_total = (Math.PI * Math.Pow(D_tank, 2) * h_liq) / (4 * (rbi.getC(13)));
            Bbl_rupture_n = Bbl_total;
            return min_max(Bbl_total / rate_n(), t_ld(), true);
        }
        //Step 4: release volume from leakage, Bbl_leak_n
        public double Bbl_leak_n()
        {
            return min_max(rate_n() * ld_n(), Bbl_total, true);  
        }
        //Step 5: Bbl_rupture = Bbl_total
        #endregion

        #region Consequence for Tank Bottom
        public String Fluid { set; get; } 
        private String SoilType { set; get; } //table 7.2
        private double uw = 3.732e-5; //tra bang tren internet tai 32oF
        private double pw = 62.43; // lb/ft3

        private double C_indike { set; get; } // table 7.6
        private double C_ss_onsite { set; get; } // table 7.6
        private double C_ss_offsite { set; get; } // table 7.6
        private double C_water { set; get; } // table 7.6
        private double C_subsoil { set; get; }
        private double C_groundwater { set; get; }
        public String componentType { set; get; }
        public double P_lvdike { set; get; } //do chuyên gia nhập liệu
        public double P_onsite { set; get; }
        public double P_offsite { set; get; }
        private double Ps { set; get; } //soil porosity table 7.2
        public String Material { set; get; }
        public double Swg { set; get; } //total distance to the ground water underneath the tank
        public double k_h_water()
        {
            double[] k_h = rbi.getK_h_water(SoilType); //k_hwater_lb = k_h[0], k_hwater_ub = k_h[1]
            Ps = k_h[2];
            return (rbi.getC(13)) * (k_h[0] + k_h[1]) / 2;
        }

        public double k_h_prod()
        {
            double[] pl_ul = rbi.get_pl_ul(Fluid); //pl = data[0], ul = data[1]
            return k_h_water() * (pl_ul[0] / pw) * (uw / pl_ul[1]);
        }
        /*result*/
        public double vel_s_prod()
        {
            return k_h_prod() / Ps;
        }
        //Step 1: Determine P_lvdike, P_onsite, P_offsite do chuyên gia nhập liệu
        //Step 2: Determine C_indike, C_ss_onsite, C_ss_offsite, C_water table 7.6
        public void getCost()
        {
            int[] val = rbi.getCost(EnvironSensitivity);
            C_indike = val[0];
            C_ss_onsite = val[1];
            C_ss_offsite = val[2];
            C_subsoil = val[3];
            C_groundwater = val[4];
            C_water = val[5];
        }
        //Step 3: Determine vel_s_prod đã xác định ở trên
        //Step 4: time to initiate leakage to the ground water t_gl
        public double t_gl()
        {
            return Swg / vel_s_prod();
        }
        //Step 5: determine the volume of the product in the subsoil and ground water, Bbl_leak_subsoil
        public double Bbl_leak_groundwater()
        {
            if (t_gl() > t_ld())
                return Bbl_leak_n() * ((t_ld() - t_gl()) / t_ld());
            else
                return 0;
        }
        public double Bbl_leak_subsoil()
        {
            return Bbl_leak_n() - Bbl_leak_groundwater();
        }
        //Step 6: determine the environmental financial consequence of a leak, FC_leak_environ
        public double FC_leak_environ()
        {
            double sum = 0;
            for (int i = 1; i < 4; i++)
            {
                sum += (Bbl_leak_groundwater() * C_groundwater + Bbl_leak_subsoil() * C_subsoil) * double.Parse(rbi.getGff(componentType, i));
            }
            return sum / double.Parse(rbi.getGff(componentType));
        }
        //Step 7: Determine the total barrels of fluid released by a tank bottom rupture, Bbl_rupture_release
        public double Bbl_rupture_release()
        {
            return (Bbl_total * double.Parse(rbi.getGff(componentType,4)))/double.Parse(rbi.getGff(componentType));
        }
        //Step 8: step 7 Tank Shell
        public double Bbl_rupture_indike()
        {
            return Bbl_rupture_release() * (1 - P_lvdike / 100);
        }
        public double Bbl_rupture_ssonsite()
        {
            return P_onsite * (Bbl_rupture_release() - Bbl_rupture_indike()) / 100;
        }
        public double Bbl_rupture_ssoffsite()
        {
            return P_offsite * (Bbl_rupture_release() - Bbl_rupture_indike() - Bbl_rupture_ssonsite()) / 100;
        }
        public double Bbl_rupture_water()
        {
            return Bbl_rupture_release() - (Bbl_rupture_indike() + Bbl_rupture_ssonsite() + Bbl_rupture_ssoffsite());
        }
        //Step 9: step 8 tank shell
        public double FC_rupture_environ()
        {
            return Bbl_rupture_indike() * C_indike + Bbl_rupture_ssonsite() * C_ss_onsite + Bbl_rupture_ssoffsite() * C_ss_offsite + Bbl_rupture_water() * C_water;
        }
        //Step 10: FC_environ
        public double FC_environ()
        {
            return FC_leak_environ() + FC_rupture_environ();
        }
        //Step 11: FC_cmd
        public double FC_cmd()
        {
            double sum = 0;
            for (int i = 1; i < 4; i++)
            {
                sum += double.Parse(rbi.getGff(componentType, i)) * rbi.getHolecost(componentType, i);
            }
            sum += rbi.getHolecost(componentType, 4) * Math.Pow(D_tank / (rbi.getC(36)), 2);
            Debug.WriteLine("sum = " + sum);
            return sum * rbi.getMatcost(Material) / double.Parse(rbi.getGff(componentType));
        }
        //Step 12: FC_prod same Tank Shell
        public double FC_prod()
        {
            return financial.fc_prod();
        }
        //Step 13: FC_total
        public double FC_total_bottom()
        {
            getCost();
            return FC_environ() + FC_cmd() + FC_prod();
        }
        #endregion
    }
}
