using RBI.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBI.BUS.Calculator
{
    class consequenceAnalysisLvl2
    {
        RBICalculatorConn rbi = new RBICalculatorConn();
        BusEquipmentTemp busTemp = new BusEquipmentTemp();
        // material
        public String material { set; get; }   
        // fluid
        public String fluid { set; get; }                        
        // component type
        public String componentType { set; get; }               
        // phase of stored fluid
        public String fluidPhase { set; get; }        
        // poolfire type
        public String poolfireType { set; get; }        
        // equipcost
        public double equipcost { set; get; }  
        // mass fraction liquid
        public double frac_l { set; get; }
        // vapor density
        public double p_v { set; get; }       
        // fraction of fluid flashed
        public double frac_fsh { set; get; }
        // liquid density
        public double p_l { set; get; }
        // stored pressure kPa
        public double p_s { set; get; }
        // atmospheric pressure kPa
        public double p_atm { set; get; }
        // stored fluid's saturation pressure kPa
        public double psat_s { set; get; }
        // stored temperature K
        public double t_s { set; get; }
        // bubble point temperature for flashed liquid K
        public double t_b { set; get; }
        // dew point temperature for flashed vapor K
        public double t_d { set; get; }
        // atmosphere temperature K
        public double t_atm { set; get; }
        // time for steady release of fluid
        public double t_pn { set; get; }
        // specific heat of pool liquid J/kg-K
        public double c_pl { set; get; }
        // reynold constant
        public double r_e { set; get; }        
        // fluid mass
        public double mass_inv { set; get; }
        // component mass
        public double mass_comp { set; get; }
        // mass of flammable material in vapor cloud
        public double mass_vce { set; get; }
        // detection type
        public double detectionType { set; get; }
        // isolation type
        public double isolationType { set; get; }        
        // mass fraction of release rate
        public double mfrac_flame { set; get; }
        // volume of liquid to establish fire pool m3
        public double V_pn { set; get; }
        // bubble-point pressure, corresponding to the ground temperature kPa
        public double P_bg { set; get; }
        // wind speed m/s
        public double u_w { set; get; }
        // area surface type
        public String surface { set; get; }
        // ground temperature K
        public double t_g { set; get; }
        // ambient condition
        public String ambientCondition { set; get; }
        // humidity %
        public double RH { set; get; }
        // mole fraction of release rate
        public double molefrac_tox { set; get; }       
        // toxic Component
        public String toxicComponent { set; get; }
        // criteria
        public String criteria { set; get; }
        // grade level cloud
        public double ca_n_cloud { set; get; }
        //represent Fluid
        public String representFluid { set; get; }        
        // moles flash from liquid to vapor
        public double n_v { set; get; }        
        // outage multiplier
        public double outage_mult { set; get; }
        // production cost ($)
        public double prodcost { set; get; }
        // injury cost that company would be incurred($)
        public double injcost { set; get; }
        // environment cost
        public double envcost { set; get; }
        // population density (person/m^2)
        public double popdens { set; get; } 
        // m hoang thieu tu day tro xuong
        public double xs_cmdn_pool { set; get; }
        //
        public double xs_injn_pool { set; get; }
        //
        public double xs_cmdn_jet { set; get; }
        //
        public double xs_injn_jet { set; get; }
        //
        public double xs_cmdn_fb { set; get; }
        //
        public double xs_injn_fb { set; get; }
        //
        public double xs_cmdn_vce { set; get; }
        //
        public double xs_injn_vce { set; get; }
        // grade cloud area
        public double gradecloudArea { set; get; }
        
        // 
        public double xs_cmdn_pexp { set; get; }
        // 
        public double xs_cmdn_bleve { set; get; }
        // 
        public double xs_injn_pexp { set; get; }
        // 
        public double xs_injn_bleve { set; get; }
        // Step 2 release rate calculation
        // 2.1
        public double d_n(int n)
        {
            double dn = 0;
            if (n == 1)
                dn = 0.25;
            else if (n == 2)
                dn = 1;
            else if (n == 3)
                dn = 4;
            else
                dn = 16;
            return dn;
        }
        // 2.2
        public double gff_n(int n)
        {
            double gff_n = 0;
            String size = null;
            if (n == 1)
            {
                size = "small";
                gff_n = rbi.getGffn(componentType, size);
            }
            else if (n == 2)
            {
                size = "medium";
                gff_n = rbi.getGffn(componentType, size);
            }
            else if (n == 3)
            {
                size = "large";
                gff_n = rbi.getGffn(componentType, size);
            }
            else
            {
                size = "rupture";
                gff_n = rbi.getGffn(componentType, size);
            }
            return gff_n;

        }

        public double gff_total()
        {
            double gff_total = 1;
            gff_total = double.Parse(rbi.getGff(componentType));
            return gff_total;
        }

        // Step 3 release hole size selection
        // 3.2
        public String releasePhase()
        {
            String release_phase = "";
            if ((p_s >= p_atm) && (p_s <= psat_s))
                release_phase = "Vapor";
            else if ((psat_s > p_atm) && (psat_s <= p_s))
                release_phase = "Two-phase";
            else
                release_phase = "Liquid";
            return release_phase;
        }
 
        // 3.3
        public double a_n(int n)
        {
            double a_n = 0;
            double dn = d_n(n);
            a_n = Math.PI * Math.Pow(dn, 2) / 4;
            return a_n;
        }
        // 3.4
        public double W_n(int n)
        {
            double W_n = 0;
            double an = a_n(n);
            String releasephase = releasePhase();
            double k = 0;
            double k_vn = 0;
            double mw = double.Parse(rbi.getMw(fluid));            
            double p_trans = 0;
            if (releasephase.Equals("Liquid") || releasephase.Equals("Two-phase"))
            {
                k = 0.9935 + 2.878 / Math.Pow(r_e, 0.5) + 342.75 / Math.Pow(r_e, 1.5);
                k_vn = Math.Pow(k, -1);
                W_n = 0.61 * k_vn * rbi.getPl(fluid) * an * Math.Sqrt(2 * 6.67 * Math.Exp(-11) * Math.Abs(p_s - p_atm) / rbi.getPl(fluid)) / (rbi.getC(1));
            }
            else
            {
                double R = 8.314;
                k = (Cp() / (Cp() - R)); 
                p_trans = p_atm * Math.Pow((k + 1) / 2, k / (k - 1));
                if (p_s > p_trans)
                {
                    double x = (k * mw * 6.67 * Math.Exp(-11) / (R * t_s)) * Math.Pow(2 / (k + 1), (k + 1) / (k - 1));
                    W_n = 0.9 * an * p_s * Math.Sqrt(x) / (rbi.getC(2));
                }
                else
                {
                    double x = (mw * 6.67 * Math.Exp(-11) / (8.314 * t_s)) * ((2 * k) / (k - 1)) * Math.Pow(p_atm / p_s, 2 / k) * (1 - Math.Pow(p_atm / p_s, (k - 1) / k));
                    W_n = 0.9 * an * p_s * Math.Sqrt(x) / (rbi.getC(2));
                }
            }
                               
            return W_n;
        }

        // cp
        public double Cp()
        {
            int idealCp = rbi.getCp_ideal(fluid);
            double cp = 0;
            double A = rbi.getCp(fluid, "A");
            double B = rbi.getCp(fluid, "B");
            double C = rbi.getCp(fluid, "C");
            double D = rbi.getCp(fluid, "D");
            double E = rbi.getCp(fluid, "E");            
            double CP_C2 = (C / t_s) / (Math.Sinh(C / t_s));
            double CP_E2 = (E / t_s) / (Math.Cosh(E / t_s));
            if (idealCp == 1)
            {
                cp = A + B * t_s + C * t_s * t_s + D * t_s * t_s * t_s;
            }
            else if (idealCp == 2)
            {
                cp = A + B * CP_C2 * CP_C2 + D * CP_E2 * CP_E2;
            }
            else if (idealCp == 3)
            {
                cp = A + B * t_s + C * Math.Pow(t_s, 2) + D * Math.Pow(t_s, 3) + E * Math.Pow(t_s, 4);
            }
            else
            {
                cp = 0;
            }
            return cp;
        }


        // Step 4 : fluid inventory available for release
        // 4.5
        public double W_max8()
        {
            double W_max8 = 0;
            double an = 32450;
            String releasephase = releasePhase();
            double k = 0;
            double k_vn = 0;
            double mw = double.Parse(rbi.getMw(fluid));
            double p_trans = 0;
            if (releasephase.Equals("Liquid") || releasephase.Equals("Two-phase"))
            {
                k = 0.9935 + 2.878 / Math.Pow(r_e, 0.5) + 342.75 / Math.Pow(r_e, 1.5);
                k_vn = Math.Pow(k, -1);
                W_max8 = 0.61 * k_vn * rbi.getPl(fluid) * an * Math.Sqrt(2 * 6.67 * Math.Exp(-11) * Math.Abs(p_s - p_atm) / rbi.getPl(fluid)) / (rbi.getC(1));
            }
            else
            { 
                double R = 8.314;
                k = (Cp() / (Cp() - R));
                p_trans = p_atm * Math.Pow((k + 1) / 2, k / (k - 1));
                if (p_s > p_trans)
                {
                    double x = (k * mw * 6.67 * Math.Exp(-11) / (R * t_s)) * Math.Pow(2 / (k + 1), (k + 1) / (k - 1));
                    W_max8 = 0.9 * an * p_s * Math.Sqrt(x) / (rbi.getC(2));
                }
                else
                {
                    double x = (mw * 6.67 * Math.Exp(-11) / (8.314 * t_s)) * ((2 * k) / (k - 1)) * Math.Pow(p_atm / p_s, 2 / k) * (1 - Math.Pow(p_atm / p_s, (k - 1) / k));
                    W_max8 = 0.9 * an * p_s * Math.Sqrt(x) / (rbi.getC(2));
                }
            }

            return W_max8;
        }
        // 4.6
        public double mass_addn(int n)
        {
            double mass_addn = 0;
            double Wmax8 = W_max8();
            double Wn = W_n(n);
            mass_addn = 180 * Math.Min(Wmax8, Wn);
            return mass_addn;
        }
        // 4.7
        public double mass_availn(int n)
        {
            double mass_availn = 0;
            double massaddn = mass_addn(n);            
            mass_availn = Math.Min(mass_comp + massaddn, mass_inv);
            return mass_availn;
        }

        // Step 5 : releaseType
        // 5.1 
        public double t_n(int n)
        {
            double t_n = 0;
            double Wn = W_n(n);
            t_n = (rbi.getC(3))/Wn;
            return t_n;
        }
        // 5.2
        public String releaseType(int n)
        {
            String releaseType = "";
            double tn = t_n(n);
            double dn = d_n(n);
            double massavailn = mass_availn(n);
            if (dn <= 6.35)
                releaseType = "Continuous";
            else if((tn <= 180) || (massavailn > 4536))
                releaseType = "Instantaneous";
            else
                releaseType = "Continuous";
            return releaseType;
        }

        // Step 6 : Impact of detection and isolation system on release magnitude
        // 6.4
        public double fact_di()
        {
            double fact_di = 0;
            if (detectionType == 1 && isolationType == 1)
            {
                fact_di = 0.25;
            }
            else if (detectionType == 1 && isolationType == 2)
            {
                fact_di = 0.2;
            }
            else if ((detectionType == 1 || detectionType == 2) && isolationType == 3)
            {
                fact_di = 0.1;
            }
            else if (detectionType == 2 && isolationType == 2)
            {
                fact_di = 0.15;
            }
            else fact_di = 0;
            return fact_di;
        }

        //6.5
        public double ld_n_max(int n)
        {
            double ld_max = 0;
            double dn = d_n(n);
            if (detectionType == 1 && isolationType == 1)
            {
                if (dn == 0.25)
                    ld_max = 20;
                else if (dn == 1)
                    ld_max = 10;
                else //if (dn == 4)
                    ld_max = 5;
            }
            else if (detectionType == 1 && isolationType == 2)
            {
                if (dn == 0.25)
                    ld_max = 30;
                else if (dn == 1)
                    ld_max = 20;
                else// if (dn == 4)
                    ld_max = 10;
            }
            else if (detectionType == 1 && isolationType == 3)
            {
                if (dn == 0.25)
                    ld_max = 40;
                else if (dn == 1)
                    ld_max = 30;
                else// if (dn == 4)
                    ld_max = 20;
            }
            else if ((isolationType == 1 || isolationType == 2) && detectionType == 2)
            {
                if (dn == 0.25)
                    ld_max = 40;
                else if (dn == 1)
                    ld_max = 30;
                else// if (dn == 4)
                    ld_max = 20;
            }
            else if (detectionType == 2 && isolationType == 3)
            {
                if (dn == 0.25)
                    ld_max = 60;
                else if (dn == 1)
                    ld_max = 30;
                else// if (dn == 4)
                    ld_max = 20;
            }
            else if (detectionType == 3 && (isolationType == 1 || isolationType == 2 || isolationType == 3))
            {
                if (dn == 0.25)
                    ld_max = 60;
                else if (dn == 1)
                    ld_max = 40;
                else// if (dn == 4)
                    ld_max = 20;
            }
            else
                ld_max = 0;
            return ld_max;
        }


        // Step 7 : Release rate and consequence for analysis
        // 7.1
        public double rate_n(int n)
        {
            double rate_n = 0;
            double Wn = W_n(n);
            double factdi = fact_di();

            rate_n = Wn * (1 - factdi);
            return rate_n;
        }
        // 7.2
        public double ld_n(int n)
        {
            double ld_n = 0;
            double raten = rate_n(n);
            double massavailn = mass_availn(n);
            double ldmax = ld_n_max(n);
            ld_n = Math.Min(massavailn / raten, 60 * ldmax);
            return ld_n;
        }
        // 7.3
        public double frac_ro()
        {
            double frac_ro = 0;
            if (frac_fsh < 0.5)
                frac_ro = 1 - 2 * frac_fsh;
            else
                frac_ro = 0;           
            return frac_ro;
        }
        // 7.4
        public double W_n_pool(int n)
        {
            double W_n_pool = 0;
            double raten = rate_n(n);
            double fracro = frac_ro();            
            W_n_pool = raten * fracro ;
            return W_n_pool;
        }
        // 7.5
        public double W_n_jet(int n)
        {
            double W_n_jet = 0;
            double raten = rate_n(n);
            double fracro = frac_ro();
            W_n_jet = raten * (1 - fracro);
            return W_n_jet;
        }
        // 7.6
        public double frac_entl()
        {
            double frac_entl = 0;
            double fracro = frac_ro();
            frac_entl = (frac_l * frac_fsh) / (1 - fracro);
            return frac_entl;
        }
        // 7.7
        public double erate_n(int n)
        {
            double erate_n = 0;
            String releasephase = releasePhase();
            double r_pn = Math.Sqrt(2 / 3) * Math.Pow((8 * 9.81 * V_pn) / (Math.PI), 0.25) * Math.Pow(t_pn, 0.75);
            double ksurf = rbi.getksurf(surface);
            double xsurf = rbi.getxsurf(surface);
            double alphasurf = rbi.getalphasurf(surface);

            if (releasephase.Equals("Vapor"))
                erate_n = W_n_jet(n);
            else// if (releasephase.Equals("Liquid"))
            {
                if (poolfireType.Equals("Non-boiling"))
                    erate_n = (rbi.getC(15)) * P_bg * double.Parse(rbi.getMw(fluid)) * Math.Pow(r_pn, 1.89) * Math.Pow(u_w, 0.78);
                else// if (poolfireType.Equals("Boiling"))
                    erate_n = Math.Pow(Math.PI, 1.5) * xsurf * ksurf * (t_g - t_b) * Math.Pow(2 * 9.81 * V_pn, 0.5) * t_pn / ((rbi.getC(14)) * 90 * Math.Sqrt(Math.PI * alphasurf));
            }
            return erate_n;
        }
         
        // Step 8 flamable explosive Consequences area
        // 8.2 flammable release rate
        public double rate_n_flame(int n)
        {
            return rate_n(n) * mfrac_flame;
        }
        public double rate_ln_flame(int n)
        {
            return rate_n_flame(n) * (1 - frac_fsh);
        }
        public double rate_vn_flame(int n)
        {
            return rate_n_flame(n) * frac_fsh;
        }


        // 8.4 probability of ignition of the release
        public double poi_ln_amb(int n)
        {
            return 1.00982 - 0.70372 * Math.Log(double.Parse(rbi.getMw(fluid))) - 0.013045 * Math.Log((rbi.getC(4)) * rate_ln_flame(n)) + 0.18554 * Math.Log(Math.Pow(double.Parse(rbi.getMw(fluid)), 2)) - 0.0014619 * Math.Log(Math.Pow((rbi.getC(4)) * rate_ln_flame(n), 2)) - 0.022131 * Math.Log(double.Parse(rbi.getMw(fluid))) * Math.Log((rbi.getC(4)) * rate_ln_flame(n)) - 0.016572 * Math.Log(Math.Pow(double.Parse(rbi.getMw(fluid)), 3)) + 0.00011281 * Math.Log(Math.Pow((rbi.getC(4)) * rate_ln_flame(n), 3)) + 0.00050697 * Math.Log(double.Parse(rbi.getMw(fluid))) * Math.Log(Math.Pow((rbi.getC(4)) * rate_ln_flame(n), 2)) - 0.0035535 * Math.Log(Math.Pow(double.Parse(rbi.getMw(fluid)), 2)) * Math.Log((rbi.getC(4)) * rate_ln_flame(n));

        }
        public double poi_vn_amb(int n)
        {
            return (1.16928 - 0.39309 * Math.Log(double.Parse(rbi.getMw(fluid))) - 0.053213 * Math.Log((rbi.getC(4)) * rate_vn_flame(n)) + 0.033904 * Math.Log(Math.Pow(double.Parse(rbi.getMw(fluid)), 2)) - 0.0028936 * Math.Log(Math.Pow((rbi.getC(4)) * rate_ln_flame(n), 2)) - 0.0067701 * Math.Log(double.Parse(rbi.getMw(fluid))) * Math.Log((rbi.getC(4)) * rate_ln_flame(n)) / (1 - 0.00110843 * Math.Log(double.Parse(rbi.getMw(fluid))) - 0.094276 * Math.Log((rbi.getC(4)) * rate_vn_flame(n)) + 0.029813 * Math.Log(Math.Pow(double.Parse(rbi.getMw(fluid)), 2)) + 0.0031951 * Math.Log(Math.Pow((rbi.getC(4)) * rate_ln_flame(n), 2)) - 0.058105 * Math.Log(double.Parse(rbi.getMw(fluid))) * Math.Log((rbi.getC(4)) * rate_vn_flame(n))));

        }
        public double poi_l_ait()
        {
            return 1.0;
        }
        public double poi_v_ait()
        {
            double max;
            double temp = (170 - double.Parse(rbi.getMw(fluid))) / (170 - 2);
            if (temp > 0)
                max = 0.7 + temp;
            else
                max = 0.7;
            return max;
        }
        public double poi_ln(int n)
        {
            return poi_ln_amb(n) + (poi_l_ait() - poi_ln_amb(n)) * (t_s - (rbi.getC(16))) / ((rbi.getAIT(fluid)) - (rbi.getC(16)));
        }
        public double poi_vn(int n)
        {
            return poi_vn_amb(n) + (poi_v_ait() - poi_vn_amb(n)) * (t_s - (rbi.getC(16))) / ((rbi.getAIT(fluid)) - (rbi.getC(16)));
        }
        public double poi_2n(int n)
        {
            return poi_ln(n) * frac_fsh + poi_vn(n) * (1 - frac_fsh);
        }


        // 8.5 probability of a immidiate ignition given ignition given immediate release 
        public double poii(String fp, int n)
        {
            double poii = 0;
            String releasetype = releaseType(n);
            if (releasetype.Equals("Continuous"))
            {
                if (fp.Equals("Liquid"))
                {
                    if (ambientCondition.Equals("Ambient Temperature"))
                        poii = rbi.getpoii_n_amb_ambientTemperature(releasetype, fp);
                    else// if (ambientCondition.Equals("AIT"))
                        poii = rbi.getpoii_AIT(releasetype, fp);
                }
                else// if (fp.Equals("Vapor"))
                {
                    if (ambientCondition.Equals("Ambient Temperature"))
                        poii = rbi.getpoii_n_amb_ambientTemperature(releasetype, fp);
                    else// if (ambientCondition.Equals("AIT"))
                        poii = rbi.getpoii_AIT(releasetype, fp);
                }
            }
            else// if (releasetype.Equals("Instantaneous"))
            {
                if (fp.Equals("Liquid"))
                {
                    if (ambientCondition.Equals("Ambient Temperature"))
                        poii = rbi.getpoii_n_amb_ambientTemperature(releasetype, fp);
                    else// if (ambientCondition.Equals("AIT"))
                        poii = rbi.getpoii_AIT(releasetype, fp);
                }
                else// if (fp.Equals("Vapor"))
                {
                    if (ambientCondition.Equals("Ambient Temperature"))
                        poii = rbi.getpoii_n_amb_ambientTemperature(releasetype, fp);
                    else// if (ambientCondition.Equals("AIT"))
                        poii = rbi.getpoii_AIT(releasetype, fp);
                }
            }
            return poii;
        }
        public double poii_ln(int n)
        {
            double poii_ln_amb = poii("Liquid", n);
            return poii_ln_amb + (1.0 - poii_ln_amb) * (t_s - (rbi.getC(16))) / ((rbi.getAIT(fluid)) - (rbi.getC(16)));
        }
        public double poii_vn(int n)
        {
            double poii_vn_amb = poii("Vapor", n);
            return poii_vn_amb + (1.0 - poii_vn_amb) * (t_s - (rbi.getC(16))) / ((rbi.getAIT(fluid)) - (rbi.getC(16)));
        }
        public double poii_2n(int n)
        {
            return frac_fsh * poii_ln(n) + (1 - frac_fsh) * poii_vn(n);
        }


        // 8.6 probability of a vce given delayed ignition
        public double pvce(String fp, int n)
        {
            String releasetype = releaseType(n);
            double pvce = rbi.getpvcedi(releasetype, fp);
            return pvce;
        }
        public double pvcedi_ln(int n)
        {
            return pvce("Liquid", n);
        }
        public double pvcedi_vn(int n)
        {
            return pvce("Vapor", n);
        }
        public double pvcedi_2n(int n)
        {
            return frac_fsh * pvcedi_ln(n) + (1 - frac_fsh) * pvcedi_vn(n);
        }


        // 8.7 probability of a flasf fire given delayed ignition 
        public double pffdi_ln(int n)
        {
            double pffdi_ln = 1 - pvcedi_ln(n);
            return pffdi_ln;
        }
        public double pffdi_vn(int n)
        {
            double pffdi_vn = 1 - pvcedi_vn(n);
            return pffdi_vn;
        }
        public double pffdi_2n(String fp, int n)
        {
            double pffdi_2n = frac_fsh * pffdi_ln(n) + (1 - frac_fsh) * pffdi_vn(n);
            return pffdi_2n;
        }


        // 8.8 probability of a fireball given immediate release 
        public double pfbii(String releasetype, String fluidPhase)
        {            
            double pfbii = 0;
            if ((releasetype.Equals("Instantaneous") || fluidPhase.Equals("Vapor")) & releasetype.Equals("Instantaneous") || fluidPhase.Equals("Two-phase"))
                pfbii = 1;
            else
                pfbii = 0;
            return pfbii;
        }


        // 8.9 select appropriate event tree type
        public String eventTreeType(int n)
        {
            String eventTreeType = "";
            if ((n == 1) || (n == 2) || (n == 3))
                eventTreeType = "Leakage";
            else// if (n == 4)
                eventTreeType = "Rupture";
            return eventTreeType;
        }


        // 8.10 probability of all possible event outcomes
        public double p_poolfire(int n)
        {
            double p_poolFire = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            String releasetype = releaseType(n);
            double poiln = poi_ln(n);
            double poiiln = poii_ln(n);
            double poi2n = poi_2n(n);
            double poii2n = poii_2n(n);
            double pvcedivn = pvcedi_vn(n);
            double pfbii2r = pfbii(releasetype, fluidPhase);
            if (eTT.Equals("Leakage"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_poolFire = 0;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_poolFire = poiln * poiiln;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    if (releasetype.Equals("Instantaneous"))
                        p_poolFire = poi2n * poii2n;
                    else
                        p_poolFire = 0;

                }
            }
            else// if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_poolFire = 0;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_poolFire = poiln * poiiln;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_poolFire = poi2n * poii2n * (1 - pfbii2r);
                }
            }

            return p_poolFire;
        }
        public double p_jetfire(int n)
        {
            double p_jetfire = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            String releasetype = releaseType(n);
            double poivn = poi_vn(n);
            double poiivn = poii_vn(n);
            double poi2n = poi_2n(n);
            double poii2n = poii_2n(n);

            if (eTT.Equals("Leakage"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    if (releasetype.Equals("Continuous"))
                        p_jetfire = poivn * poiivn;
                    else
                        p_jetfire = 0;

                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_jetfire = 0;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    if (releasetype.Equals("Continuous"))
                        p_jetfire = poi2n * poii2n;
                    else
                        p_jetfire = 0;
                }
            }
            else// if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_jetfire = 0;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_jetfire = 0;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_jetfire = 0;
                }
            }

            return p_jetfire;
        }
        public double p_fireball(int n)
        {
            double p_fireball = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            String releasetype = releaseType(n);
            double poivn = poi_vn(n);
            double poiivn = poii_vn(n);
            double poi2n = poi_2n(n);
            double poii2n = poii_2n(n);
            double pfbii2r = pfbii(releasetype, fluidPhase);
            if (eTT.Equals("Leakage"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    if (releasetype.Equals("Instantaneous"))
                        p_fireball = poivn * poiivn;
                    else
                        p_fireball = 0;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_fireball = 0;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    if (releasetype.Equals("Instantaneous"))
                        p_fireball = poi2n * poii2n;
                    else
                        p_fireball = 0;
                }
            }
            else //if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_fireball = poivn * poiivn;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_fireball = 0;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_fireball = poi2n * poii2n * pfbii2r;
                }
            }

            return p_fireball;
        }
        public double p_vce(int n)
        {
            double p_vce = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            String releasetype = releaseType(n);
            double poivn = poi_vn(n);
            double poiivn = poii_vn(n);
            double poiln = poi_ln(n);
            double poiiln = poii_ln(n);
            double poi2n = poi_2n(n);
            double poii2n = poii_2n(n);
            double pfbii2r = pfbii(releasetype, fluidPhase);
            double pvcedivn = pvcedi_vn(n);
            double pvcediln = pvcedi_ln(n);
            double pvcedi2n = pvcedi_2n(n);
            if (eTT.Equals("Leakage"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_vce = poivn * (1 - poiivn) * pvcedivn;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_vce = poiln * (1 - poiiln) * pvcediln;
                }
                else //if (releasephase.Equals("Two-phase"))
                {
                    p_vce = poi2n * (1 - poii2n) * pvcedi2n;
                }
            }
            else// if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_vce = poivn * (1 - poiivn) * pvcedivn;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_vce = poiln * (1 - poiiln) * pvcediln;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_vce = poi2n * (1 - poii2n) * pvcedi2n;
                }
            }

            return p_vce;
        }
        public double p_flashfire(int n)
        {
            double p_flashfire = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            String releasetype = releaseType(n);
            double poivn = poi_vn(n);
            double poiivn = poii_vn(n);
            double poiln = poi_ln(n);
            double poiiln = poii_ln(n);
            double poi2n = poi_2n(n);
            double poii2n = poii_2n(n);
            double pfbii2r = pfbii(releasetype, fluidPhase);
            double pvcedivn = pvcedi_vn(n);
            double pvcediln = pvcedi_ln(n);
            double pvcedi2n = pvcedi_2n(n);
            if (eTT.Equals("Leakage"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_flashfire = poivn * (1 - poiivn) * (1 - pvcedivn);
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_flashfire = poiln * (1 - poiiln) * (1 - pvcediln);
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_flashfire = poi2n * (1 - poii2n) * (1 - pvcedi2n);
                }
            }
            else// if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_flashfire = poivn * (1 - poiivn) * (1 - pvcedivn);
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_flashfire = poiln * (1 - poiiln) * (1 - pvcediln);
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_flashfire = poi2n * (1 - poii2n) * (1 - pvcedi2n);
                }
            }

            return p_flashfire;
        }
        public double p_safedispersion(int n)
        {
            double p_safedispersion = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            double poivn = poi_vn(n);
            double poiln = poi_vn(n);
            double poi2n = poi_2n(n);

            if (eTT.Equals("Leakage"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_safedispersion = 1 - poivn;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_safedispersion = 1 - poiln;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_safedispersion = 1 - poi2n;
                }
            }
            else// if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_safedispersion = poivn;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_safedispersion = 1 - poiln;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_safedispersion = 0;
                }
            }

            return p_safedispersion;
        }
        public double p_pe(int n)
        {
            double p_pe = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            double poivn = poi_vn(n);

            if (eTT.Equals("Leakage"))
            {
                p_pe = 0;
            }
            else// if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_pe = 1 - poivn;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_pe = 0;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_pe = 0;
                }
            }
            return p_pe;
        }
        public double p_bleve(int n)
        {
            double p_bleve = 0;
            String eTT = eventTreeType(n);
            String releasephase = releasePhase();
            double poi2n = poi_2n(n);

            if (eTT.Equals("Leakage"))
            {
                p_bleve = 0;
            }
            else// if (eTT.Equals("Rupture"))
            {
                if (releasephase.Equals("Vapor"))
                {
                    p_bleve = 0;
                }
                else if (releasephase.Equals("Liquid"))
                {
                    p_bleve = 0;
                }
                else// if (releasephase.Equals("Two-phase"))
                {
                    p_bleve = 1 - poi2n;
                }
            }
            return p_bleve;
        }

        // 8.11 component damage and personal injury of fire pool
        public double m_b()
        {
            double m_b = 0;
            if (poolfireType.Equals("Non-boiling"))
                m_b = ((rbi.getC(17)) * 45 * Math.Pow(10, 6)) / (c_pl * (t_b - t_atm) + 20 * Math.Pow(10, 5));
            else// if (poolfireType.Equals("Boiling"))
                m_b = ((rbi.getC(17)) * 45 * Math.Pow(10, 6)) / (20 * Math.Pow(10, 5));
            return m_b;
        }
        public double aburn_pfn(int n)
        {
            double aburn_pfn = 0;            
            aburn_pfn = W_n_pool(n) / m_b();
            return aburn_pfn;
        }
        public double a_max_pfn(int n)
        {
            double a_max_pfn = 0;
            a_max_pfn = mass_availn(n) / ((rbi.getC(18)) * frac_ro() * p_l);
            return a_max_pfn;
        }
        public double a_pfn(int n)
        {
            double a_pfn = 0;
            double amaxpfn = a_max_pfn(n);
            double aburnpfn = aburn_pfn(n);
            a_pfn = Math.Min(Math.Min(amaxpfn, aburnpfn), (rbi.getC(7)) * 929.1);
            return a_pfn;
        }
        public double r_pfn(int n)
        {
            double r_pfn = 0;
            double apfn = a_pfn(n);

            r_pfn = Math.Sqrt(apfn / Math.PI);
            return r_pfn;
        }
        public double u_sn(int n)
        {
            double u_sn = 0;
            double mb = m_b();
            double rpfn = r_pfn(n);
            u_sn = Math.Max(1.0, u_w * Math.Pow(p_v / (2 * 9.81 * mb * rpfn), 0.333));
            return u_sn;
        }
        public double l_pfn(int n)
        {
            double l_pfn = 0;
            double mb = m_b();
            double rpfn = r_pfn(n);
            double usn = u_sn(n);
            l_pfn = 110 * rpfn * Math.Pow(mb / (p_atm * Math.Sqrt(2 * 9.81 * rpfn)), 0.67) * Math.Pow(usn, -0.21);
            return l_pfn;
        }
        public double O_pfn(int n)
        {
            double O_pfn = 0;
            double usn = u_sn(n);
            O_pfn = Math.Acos(1 / usn);
            return O_pfn;
        }
        public double qrad_n_pool(int n)
        {
            double qrad_n_pool = 0;
            double lpfn = l_pfn(n);
            double rpfn = r_pfn(n);
            double mb = m_b();
            qrad_n_pool = ((rbi.getC(14)) * 0.35 * mb * 45 * Math.Pow(10, 6) * Math.PI * Math.Pow(rpfn, 2)) / (2 * Math.PI * rpfn * lpfn + Math.PI * Math.Pow(rpfn, 2));
            return qrad_n_pool;
        }
        public double t_aimn(double xs_n)
        {
            double t_aimn = 0;
            double pw = (rbi.getC(20)) * RH * Math.Exp(14.4114 - (rbi.getC(19)) / t_atm);

            t_aimn = 0.819 * Math.Pow(pw * xs_n, -0.09);
            return t_aimn;
        }
        public double f_cyln(double xs_n_pool, int n)
        {
            double f_cyln = 0;
            double lpfn = l_pfn(n);
            double rpfn = r_pfn(n);
            double opfn = O_pfn(n);
            double X = lpfn / rpfn;
            double Y = xs_n_pool / rpfn;
            double A = Math.Pow(X, 2) + Math.Pow(Y + 1, 2) - 2 * X * (Y + 1) * Math.Sin(opfn);
            double B = Math.Pow(X, 2) + Math.Pow(Y - 1, 2) - 2 * X * (Y - 1) * Math.Sin(opfn);
            double C = 1 + (Math.Pow(Y, 2) - 1) * Math.Pow(Math.Cos(opfn), 2);
            double fvn = (X * Math.Cos(opfn)) / (Y - X * Math.Sin(opfn)) * (Math.Pow(X, 2) + Math.Pow(Y + 1, 2) - 2 * Y * (1 + Math.Sin(opfn))) / (Math.PI * Math.Sqrt(A * B)) * Math.Atan((A * (Y - 1)) / (B * (Y + 1))) + (Math.Cos(opfn)) / (Math.PI * Math.Sqrt(C)) * (Math.Atan((X * Y - (Math.Pow(Y, 2) * Math.Sin(opfn))) / (Math.Sqrt(Math.Pow(Y, 2) - 1) * Math.Sqrt(C))) + Math.Atan((Math.Sin(opfn) * Math.Sqrt(Math.Pow(Y, 2) - 1)) / (Math.Sqrt(C)))) - (X * Math.Cos(opfn)) / (Math.PI * (Y - X * Math.Sin(opfn))) * Math.Atan(Math.Sqrt((Y - 1) / (Y + 1)));
            double fhn = 1 / Math.PI * Math.Atan(Math.Sqrt((Y + 1) / (Y - 1))) - (Math.Pow(X, 2) + Math.Pow(Y + 1, 2) - 2 * (Y + 1 + X * Y * Math.Sin(opfn))) / (Math.PI * Math.Sqrt(A * B)) * Math.Atan(Math.Sqrt((A * (Y - 1)) / (B * (Y + 1)))) + (Math.Sin(opfn)) / (Math.PI * Math.Sqrt(C)) * (Math.Atan((X * Y - (Math.Pow(Y, 2) - 1) * Math.Sin(opfn)) / (Math.Sqrt(Math.Pow(Y, 2) - 1) * Math.Sqrt(C)) + Math.Atan((Math.Sin(opfn) * Math.Sqrt(Math.Pow(Y, 2) - 1)) / (Math.Sqrt(C)))));

            f_cyln = Math.Sqrt(Math.Pow(fvn, 2) + Math.Pow(fhn, 2));
            return f_cyln;
        }
        public double ith_n_pool(double xs_n_pool, int n)
        {
            double ith_n_pool = 0;
            double tatmn = t_aimn(xs_n_pool);
            double qradnpool = qrad_n_pool(n);
            double fcyln = f_cyln(xs_n_pool, n);

            ith_n_pool = (rbi.getC(19)) * qradnpool * tatmn * fcyln;

            return ith_n_pool;
        }
        public double ca_pool(double xs_n_pool)
        {
            double ca_pool = 0;
            ca_pool = Math.PI * Math.Pow(xs_n_pool, 2);
            return ca_pool;
        }

        // 8.12 component damage and personal injury of jet fire
        public double qrad_n_jet(int n)
        {
            double qrad_n_jet = 0;
            double mb = m_b();
            qrad_n_jet = (rbi.getC(14)) * 0.35 * W_n_jet(n) * 55.50 * Math.Pow(10, 6);
            return qrad_n_jet;
        }
        public double fp_n(double xs_n_jet)
        {
            double fp_n = 0;
            fp_n = 1 / (4 * Math.PI * Math.Pow(xs_n_jet, 2));
            return fp_n;
        }
        public double ith_n_jet(double xs_n_jet, int n)
        {

            double ith_n_jet = 0;
            double tatmn = t_aimn(xs_n_jet);
            double qradnjet = qrad_n_jet(n);
            double fpn = fp_n(xs_n_jet);


            ith_n_jet = tatmn * qradnjet * fpn;

            return ith_n_jet;
        }
        public double ca_jet(double xs_n_jet)
        {
            double ca_jet = 0;
            ca_jet = Math.PI * Math.Pow(xs_n_jet, 2);
            return ca_jet;
        }

        // 8.13 component damage and personal injury of fireball
        public double mass_fb(int n)
        {
            double mass_fb = 0;
            mass_fb = mfrac_flame * mass_availn(n);
            return mass_fb;
        }
        public double d_max_fb(int n)
        {
            double d_max_fb = 0;
            double massfb = mass_fb(n);
            d_max_fb =(rbi.getC(22)) * Math.Pow(massfb, 0.333);
            return d_max_fb;
        }
        public double h_fb(int n)
        {
            double h_fb = 0;
            double dmaxfb = d_max_fb(n);
            h_fb = 0.75 * dmaxfb;
            return h_fb;
        }
        public double t_fb(int n)
        {
            double t_fb = 0;
            double massfb = mass_fb(n);
            if (massfb < 29.937)
                t_fb = (rbi.getC(23)) * Math.Pow(massfb, 0.333);
            else
                t_fb = (rbi.getC(24)) * Math.Pow(massfb, 0.167);
            return t_fb;
        }
        public double qrad_fball(int n)
        {
            double qrad_fball = 0;
            double massfb = mass_fb(n);
            double dmax = d_max_fb(n);
            double tfb = t_fb(n);
            double Bfb = (rbi.getC(25)) * Math.Pow(p_s, 0.32);
            qrad_fball = ((rbi.getC(14)) * Bfb * massfb * 45 * Math.Pow(10, 6)) / (Math.PI * Math.Pow(dmax, 2) * tfb);
            return qrad_fball;
        }
        public double fsph(double xs_n_fball, int n)
        {
            double fsph = 0;
            double dmax = d_max_fb(n);
            double cfb = Math.Sqrt(Math.Pow(dmax / 2, 2) + Math.Pow(xs_n_fball / 2, 2));
            fsph = Math.Pow(dmax, 2) / (4 * Math.Pow(cfb, 2));
            return fsph;
        }
        public double ith_n_fb(double xs_n_fb, int n)
        {
            double ith_n_fb = 0;
            double tatmn = t_aimn(xs_n_fb);
            double qradnjet = qrad_fball(n);
            double fsph1 = fsph(xs_n_fb, n);
            ith_n_fb = tatmn * qradnjet * fsph1;

            return ith_n_fb;
        }
        public double ca_fb(double xs_fball)
        {
            double ca_fb = 0;
            ca_fb = Math.PI * Math.Pow(xs_fball, 2);
            return ca_fb;
        }

        // 8.14 component damage and personal injury of vce
        public double W_tnt()
        {
            double W_tnt = 0;
            W_tnt = (0.09 * mass_vce * 90 * Math.Pow(10, 6)) / (4648);
            return W_tnt;
        }
        public double R_hsn(double xs_n_vce)
        {
            double R_hsn = 0;
            double wtnt = W_tnt();
            R_hsn = ((rbi.getC(27)) * xs_n_vce) / (Math.Pow(wtnt, 0.3333333333));
            return R_hsn;
        }
        public double P_son(double xs_n_vce)
        {
            double P_son = 0;
            double rhsn = R_hsn(xs_n_vce);
            P_son = Math.Abs(-0.059965896 + (1.1288697) / (Math.Log(rhsn)) - (7.9625216) / (Math.Pow(Math.Log(rhsn), 2)) + (25.106738) / (Math.Pow(Math.Log(rhsn), 3)) - (30.396707) / (Math.Pow(Math.Log(rhsn), 4)) + (19.399862) / (Math.Pow(Math.Log(rhsn), 5)) - (6.8853477) / (Math.Pow(Math.Log(rhsn), 6)) + (1.2825511) / (Math.Pow(Math.Log(rhsn), 7)) - (0.097705789) / (Math.Pow(Math.Log(rhsn), 8)));
            return P_son;
        }

        public double ca_vce(double xs_n_vce)
        {
            double ca_vce = 0;
            ca_vce = Math.PI * Math.Pow(xs_n_vce, 2);
            return ca_vce;
        }
        public double p_r(double xs_n_vce)
        {
            double p_r = 0;
            double pson = P_son(xs_n_vce);
            p_r = Math.Abs(-23.8 + 2.92 * Math.Log((rbi.getC(28)) * pson));
            return p_r;
        }

        // 8.15 component damage and personal injury of flash fire
        public double ca_cmdn_flash()
        {
            double ca_cmdn_flash = 0;
            ca_cmdn_flash = 0.25 * gradecloudArea;
            return ca_cmdn_flash;
        }

        // 8.16
        public double ca_cmdn_flame(int n)
        {
            double ca_cmdn_flame = 0;
            ca_cmdn_flame = p_poolfire(n) * ca_pool(xs_cmdn_pool) + p_jetfire(n) * ca_jet(xs_cmdn_jet) + p_fireball(n) * ca_fb(xs_cmdn_fb) + p_vce(n) * ca_vce(xs_cmdn_vce) + p_flashfire(n) * ca_cmdn_flash();
            return ca_cmdn_flame;
        }
        public double ca_injn_flame(int n)
        {
            double ca_injn_flame = 0;
            ca_injn_flame = p_poolfire(n) * ca_pool(xs_injn_pool) + p_jetfire(n) * ca_jet(xs_injn_jet) + p_fireball(n) * ca_fb(xs_injn_fb) + p_vce(n) * ca_vce(xs_injn_vce) + p_flashfire(n) * gradecloudArea;
            return ca_injn_flame;
        }

        //8.17
        public double ca_cmd_flame()
        {
            double ca_cmd_flame = 0;
            double t = 0;
            for (int i = 0; i < 5; i++)
            {
                t += gff_n(i) * ca_cmdn_flame(i);
            }
            ca_cmd_flame = t / gff_total();
            return ca_cmd_flame;
        }
        public double ca_inj_flame()
        {
            double ca_inj_flame = 0;
            double t = 0;
            for (int i = 0; i < 5; i++)
            {
                t += gff_n(i) * ca_injn_flame(i);
            }
            ca_inj_flame = t / gff_total();
            return ca_inj_flame;
        }
       


        // Step 9 toxic consequences area
        public double mass_n(int n)
        {
            double mass_n = 0;
            mass_n = Math.Min(rate_n(n) * ld_n(n), mass_availn(n));

            return mass_n;
        }

        // 9.2
        public double ld_n_tox(int n)
        {
            double ld_n_tox = 0;
            ld_n_tox = Math.Min(Math.Min(3600, (mass_n(n)) / (W_n(n))), 60 * ld_n_max(n));
            return ld_n_tox;
        }
        // 9.3
        public double tox_lim()
        {
            double tox_lim = 0;
            tox_lim = rbi.getToxicImpactCriteria(toxicComponent, criteria);
            return tox_lim;
        }
        // 9.4
        public double tox_lim_mod()
        {
            double tox_lim_mod = 0;
            double toxlim = tox_lim();
            tox_lim_mod = toxlim / molefrac_tox;
            return tox_lim_mod;
        }
        // 9.7
        public double ptox_n(int n)
        {
            double ptox_n = 0;
            ptox_n = p_safedispersion(n);
            return ptox_n;
        }
        public double ca_injn_tox(int n)
        {
            double ca_n_tox = 0;
            double pntox = ptox_n(n);
            ca_n_tox = pntox * ca_n_cloud;
            return ca_n_tox;
        }
        public double ca_tox()
        {
            double ca_tox = 0;
            double t = 0;
            for (int i = 0; i < 5; i++)
            {
                t += gff_n(i) * ca_injn_tox(i);
            }
            ca_tox = t / gff_total();
            return Math.Abs(ca_tox);
        }


        // Step 10 non flammable non toxic consequence area
        // 10.2
        public double ca_injn_cont(int n)
        {
            double ca_injn_cont = 0;
            double h = 0.31 - 0.0032 * Math.Pow((rbi.getC(11)) * (p_s - p_atm) - 40, 2);
            double g = 2696 - 21.9 * (rbi.getC(11)) * (p_s - p_atm) + 1.474 * Math.Pow((rbi.getC(11)) * (p_s - p_atm), 2);
            if (representFluid.Equals("Steam"))
                ca_injn_cont = (rbi.getC(9)) * rate_n(n);
            else// if (representFluid.Equals("Acids") || representFluid.Equals("Caustics"))
                ca_injn_cont = 0.2 * (rbi.getC(8)) * g * Math.Pow((rbi.getC(4)) * rate_n(n), h);

            return ca_injn_cont;
        }
        public double ca_injn_inst(int n)
        {
            double ca_injn_inst = 0;

            if (representFluid.Equals("Steam"))
                ca_injn_inst = (rbi.getC(10)) * Math.Pow(mass_n(n), 0.6384);
            else// if (representFluid.Equals("Acids") || representFluid.Equals("Caustics"))
                ca_injn_inst = 0;

            return ca_injn_inst;
        }
        public double fact_n_ic(int n)
        {
            if (representFluid.Equals("Steam"))
                return Math.Min(rate_n(n) / (rbi.getC(5)), 1);
            else// if (representFluid.Equals("Acids") || representFluid.Equals("Caustics"))
                return 0;
        }
        public double ca_injn_leak(int n)
        {
            double ca_injn_leak = 0;
            double cainjninst = ca_injn_inst(n);
            double factnic = fact_n_ic(n);
            double cainjncont = ca_injn_cont(n);
            ca_injn_leak = cainjninst * factnic + cainjncont * (1 - factnic);

            return ca_injn_leak;
        }               

        // 10.2
        public double ca_cmd_pexp()
        {
            double ca_cmd_pexp = 0;
            String eventtreeType = eventTreeType(4);
            if (eventtreeType.Equals("Rupture"))
            {
                ca_cmd_pexp = Math.PI * Math.Pow(xs_cmdn_pexp, 2);
            }
            return ca_cmd_pexp;
        }        
        public double ca_inj_pexp()
        {
            double ca_inj_pexp = 0;
            String eventtreeType = eventTreeType(4);
            if (eventtreeType.Equals("Rupture"))
            {
                ca_inj_pexp = Math.PI * Math.Pow(xs_injn_pexp, 2);
            }
            return ca_inj_pexp;
        }

        // 10.3
        public double W_tnt_bleve()
        {
            double Wtntbleve = 0;
            String releasephase = releasePhase();
            Wtntbleve = (rbi.getC(30)) * n_v * 8.314 * t_s * Math.Log(p_s / p_atm);
            double Wtnt = W_tnt();
            if (releasephase.Equals("Two-phase"))
                return Wtntbleve + Wtnt;
            else
                return Wtntbleve;
            //return Wtntbleve;
        }
        public double ca_cmd_bleve()
        {
            double ca_cmd_bleve = 0;
            ca_cmd_bleve = Math.PI * Math.Pow(xs_cmdn_bleve, 2);
            return ca_cmd_bleve;
        }

        public double ca_inj_bleve()
        {
            double ca_inj_bleve = 0;
            String eventtreeType = eventTreeType(4);
            if (eventtreeType.Equals("Rupture"))
            {
                ca_inj_bleve = Math.PI * Math.Pow(xs_injn_bleve, 2);
            }
            return ca_inj_bleve;
        }
        // 10.4
        public double ca_cmdn_nfnt()
        {
            double ca_cmdn_nfnt = 0;
            double cacmdpexp = ca_cmd_pexp();
            double cainjbleve = ca_cmd_bleve();

            ca_cmdn_nfnt = Math.Max(cacmdpexp, cainjbleve);
            return ca_cmdn_nfnt;
        }
        public double ca_injn_nfnt(int n)
        {
            double ca_injn_nfnt = 0;
            double cacmdpexp = ca_inj_pexp();
            double cainjbleve = ca_inj_bleve();
            double cainjleak = ca_injn_leak(n);

            ca_injn_nfnt = Math.Max(cacmdpexp, cainjbleve) + cainjleak;
            return ca_injn_nfnt;
        }
        // 10.5
        public double ca_cmd_nfnt()
        {
            double ca_cmd_nfnt = 0;
            double t = 0;
            for (int i = 0; i < 5; i++)
            {
                t += gff_n(i) * ca_cmdn_nfnt();
            }
            ca_cmd_nfnt = t / gff_total();
            return ca_cmd_nfnt;
        }
        public double ca_inj_nfnt()
        {
            double ca_inj_nfnt = 0;
            double t = 0;
            for (int i = 0; i < 5; i++)
            {
                t += gff_n(i) * ca_injn_nfnt(i);
            }
            ca_inj_nfnt = t / gff_total();
            return ca_inj_nfnt;
        }

        // Step 11 component and injury consequences
        // 11.1
        public double ca_cmd()
        {
            double ca_cmd = 0;
            double cacmdflame = ca_cmd_flame();
            double cacmdntft = ca_cmd_nfnt();
            ca_cmd = Math.Max(cacmdflame, cacmdntft);
            return ca_cmd;
        }

        // 11.2
        public double ca_inj()
        {
            double ca_inj = 0;
            double cainjflame = ca_inj_flame();
            double cainjnfnt = ca_inj_nfnt();
            double cainjtox = ca_tox();
            ca_inj = Math.Max(Math.Max(cainjflame, cainjtox), cainjnfnt);
            return ca_inj;
        }

        // Step 12: financial consequence
        // 12.1
        public double fc_cmd()
        {
            double fc_cmd = 0;
            double matcost = rbi.getMatcost(material);
            double t = 0;
            for (int i = 1; i < 5; i++)
            {
                t += gff_n(i) * rbi.getHoleSize(componentType, i) * matcost;
            }
            fc_cmd = t / gff_total();
            return fc_cmd;
        }

        //12.2
        public double fc_affa()
        {
            double fc_affa = 0;
            double cacmd = ca_cmd();

            fc_affa = cacmd * equipcost;
            return fc_affa;
        }

        // 12.3
        public double outage_cmd()
        {
            double t = 0;
            for (int i = 0; i < 5; i++)
            {
                t += gff_n(i) * rbi.getOutage(componentType, i) * outage_mult;
            }
            return t / gff_total(); 
        }
        public double outage_affa()
        {
            double outage_affa = 0;
            double fcaffa = fc_affa();

            outage_affa = Math.Pow(10, 1.242 + 0.585 * Math.Log10(fcaffa * Math.Pow(10, -6)));
            return outage_affa;
        }
        public double fc_prod()
        {
            double fc_prod = 0;
            double outagecmd = outage_cmd();
            double outageaffa = outage_affa();

            fc_prod = (outagecmd + outageaffa) * prodcost;
            return fc_prod;
        }

        // 12.4
        public double fc_inj()
        {
            double fc_inj = 0;
            double cainj = ca_inj();
            double outageaffa = outage_affa();

            fc_inj = cainj * popdens * injcost;
            return fc_inj;
        }

        // 12.5
        public double vol_n_env(int n)
        {
            double vol_n_env = 0;
            double massn = mass_n(n);
            double frac_evap = rbi.getfracEvap(fluid);

            vol_n_env = (rbi.getC(13)) * massn * (1 - frac_evap) / p_l;
            return vol_n_env;
        }
        public double fc_environ()
        {
            double fc_environ = 0;

            double t = 0;
            for (int i = 0; i < 5; i++)
            {
                double volnenv = vol_n_env(i);
                t += gff_n(i) * volnenv * envcost;
            }

            fc_environ = t / gff_total();
            return fc_environ;
        }


        // 12.6
        public double fc()
        {
            double fc = 0;
            double fccmd = fc_cmd();
            double fcaffa = fc_affa();
            double fcprod = fc_prod();
            double fcinj = fc_inj();
            double fcenviron = fc_environ();
            fc = fccmd + fcaffa + fcprod + fcinj + fcenviron;
            return fc;
        }

        // consequence analysis
        public double ca()
        {
            return ca_cmd() + ca_inj();
        }

        // catalog
        public int convertCatalog()
        {
            double c_a = ca();
            if (c_a <= 100)
                return 1;
            else if (c_a > 100 && c_a <= 1000)
                return 2;
            else if (c_a > 1000 && c_a <= 3000)
                return 3;
            else if (c_a > 3000 && c_a <= 10000)
                return 4;
            else return 5;
        }

    }
}
