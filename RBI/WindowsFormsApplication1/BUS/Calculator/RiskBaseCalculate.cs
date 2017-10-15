using RBI.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RBI.BUS.Calculator
{
    class RiskBaseCalculate
    {
        RBICalculatorConn rbi = new RBICalculatorConn();
        ///<summary>
        /// Tinh toan PoF
        ///</summary>

        ///<summary>
        /// khai bao tham so truyen vao
        ///</summary>
        ///<summary>
        /// 1Mpa = 145.0377 Psia
        /// 1Kpa = 0.1450377 psig
        ///</summary>
        public String equipmentType { set; get; }
        public String componentType { set; get; }
        //public double gff { set; get; }// xac dinh xac suat loi thiet bi
        public double Fms { set; get; }// xac dinh diem quan ly he thong
        public bool crackPresent { set; get; }
        public bool internalLiner { set; get; } // check internal liner present
        public String thinning { set; get; }// check thinning local or general
        // DF_thinning
        public int noInsp { set; get; } // num of inspection
        public String catalog_thin { set; get; } // effective catalog
        public int age { set; get; } // thoi gian trong he thong ke tu lan inspec cuoi cung
        public double Trd { set; get; } // do day doc duoc( inc)
        public bool haveCladding { set; get; }// thanh phan co lop vo hay k?
        public bool protectionBarrier { set; get; }// neu la tank thi co protection barrier k?
        public double Crcm { set; get; } // toc do an mon lop vo
        public double Crbm { set; get; } // toc do an mon kim loai
        public double T { set; get; }// do day kim loai
        public double Tmin { set; get; }// do day toi thieu can thiet
        // su dung cach tinh Tmin khac de loi dung file temprate
        //public double DesignPressure { set; get; }// ap suat thiet ke (MPa)
        //public double InsideDiametter { set; get; }// duong kinh trong cua ong
        //public double WeldJoint { set; get; } // he so hieu qua moi han( <1)

        public double CA { set; get; } // tro cap an mon( inc)
        public int Fom_thin { set; get; }// Fom: table 5.13
        public int Fip { set; get; }// Fip: 1 or 3
        public int Fdl { set; get; }// Fdl: 1 or 3
        public int Fwd { set; get; }// Fwd: 1 or 10
        public int Fam { set; get; }// Fam: 1 or 5
        public int Fsm { set; get; }// Fsm(tank bottom only): 1,1.5,2
        // DF_linning
        public String linningType { set; get; }// xac dinh loai linning
        public int yearInService { set; get; }// dung de tra bang 6.5
        public double Fom_lin { set; get; }// Fom: 0.1 or 1.0
        public double Flc { set; get; }// Flc: poor-10, average-2, good-1
        // DF_caustic
        public String catalog_caustic { set; get; }// effect caustic
        public String level_caust { set; get; }// muc do crack: high, medium, low, none
        // DF_amine
        public String level_amine { set; get; }// muc do crack
        public String catalog_amine { set; get; }// effective amine
        // DF_sulfide
        public String catalog_sulf { set; get; } // effective sulfide
        public double pH { set; get; }// do PH cua nuoc, dung chung cho ca hic (dung chung toan bo)

        public bool isPWHT { set; get; } // he thong co su dung PWHT isPWHT ko dung?????
        public double ppm_sulf { set; get; } // chi so ppm - dung chung cho hic: nong do H2S trong nuoc
        public double PWHT { set; get; } //nhap vao gia tri cua PWHT
        // DF_HIC/SOHIC-H2S
        public String catalog_hicH2S { set; get; }// effective hic
        public double ppm_H2S { set; get; }
        // DF_cacbonate
        public String catalog_cacbon { set; get; } // effective cacbonate
        public double ppm_cacbon { set; get; } // nong do cacbonat trong nuoc
        // DF_pta
        public String catalog_pta { set; get; } // effective pta
        public String material { set; get; }// material
        public String fHT { set; get; }// function of heat treatment
        // DF_clscc
        public String catalog_clscc { set; get; } // effective clscc
        public double Temperature { set; get; }// xac dinh nhiet do( *F) khi do PH
        public double ppm_clo { set; get; }// xac dinh nong do cua clorua
        // DF_hf
        public String catalog_hf { set; get; }// effective hf
        public bool hfPresent { set; get; }// hf present?
        public bool carbonateSteel { set; get; }// cacbonate steel?
        public double BrinellHardness { set; get; }// do cung 
        // DF_hic_hf
        public String catalog_hic_hf { set; get; } // effective hic-hf
        public double ppm_S { set; get; } // nong do Sulfur
        // DF_extd_corrosion
        public String catalog_extd { set; get; }// effective extd
        public int Fps_ext { set; get; }// Fps_ext: 2 or 1
        public int Fip_ext { set; get; }// Fip_ext: 2 or 1
        public int comInstallDate { set; get; }// component install date
        public double opTemp { set; get; }// operating temperate
        public String driver_extd { set; get; }// driver extend
        public String coatQuality { set; get; }// coating quality
        // DF_cui
        public String catalog_cui { set; get; }// effective cui
        public String driver_cui { set; get; }// trinh dieu khien an mon
       // public bool expCR { set; get; }// chuyen gia co xac dinh he so an mon k
        public double CR { set; get; }// he so an mon co ban
        public String complexity { set; get; }// he so phuc tap
        public String insulation { set; get; }// he so cach nhiet
        public bool allowConfig { set; get; }// cho phep bao tri hay k
        public bool enterSoil { set; get; }// dat trong dat hay nuoc hay k
        public String isulationtype { set; get; }// insulation Type
        // DF_extd_clscc
        public String catalog_ext_clscc { set; get; }// effective extend clscc
        public String driver_ext_clscc { set; get; }// dieu khien ext_clscc
        // DF_extd_cui
        public String pipingComp { set; get; }// piping complexity
        public String insCondition { set; get; }// Insulation condition
        // DF_htha
        public String catalog_htha { set; get; }// effective htha
        public int age_htha { set; get; }// thoi gian hoat dong, hours
        public double T_htha { set; get; }// temperature (*F)
        public double P_h2 { set; get; } // Pressure (psi)
        public String materials { set; get; } // Material
        // DF_brittle
        public double tempMin { set; get; }// nhiet do thap nhat( *F)
        public double tempDesign { set; get; }// nhiet do thiet ke( *F)
        public double tempUpset { set; get; } // nhiet do upset (*F)
        public double tempBoiling { set; get; } // nhiet do soi cua chat long( *F)
        public double MDMT { set; get; }// nhiet do kim loai thiet ke toi thieu( *F)
        public double tImpact { set; get; }// nhiet do va cham
        public String curve { set; get; }// material curve
        public bool lowTemp { set; get; }// he thong tx nhieu nam voi nhiet do thap
        // DF_temp_embrittle
        public double SCE { set; get; }// he so SCE
        // DF_ 885
        public double tRef { set; get; }// nhiet do chuyen tiep ban dau
        public double tMin_885 { set; get; }// nhiet do ban dau thap nhat
        public bool adminControl { set; get; }// admin co ngan ngua ap suat duoi 1 so nhiet do
        public bool brittleCheck { set; get; }// nhiet do deo -> gion co biet hay k
        // DF_sigma
        public double tShutdown { set; get; }// nhiet do tat may
        public double pSigma { set; get; }// % sigma
        // DF_piping_mechan
        public String noPreFatFailure { set; get; }// number of previous Fatigue Failures
        public String vibrationSVI { set; get; }// severity of vibration 
        public double noWeeks { set; get; }// number of weeks pipe has been shaking
        public String cyclicType { set; get; }// type of cyclic loading connected directly or indirectly within approximately 50 feet
        public String correctiveActions { set; get; }// corrective actions take
        public double totalpipeFitting { set; get; }// total pipe fitting
        public String jointType { set; get; }// type of joint in this piping
        public String pipeCondition { set; get; }// condition of pipe
        public double branchDiameter { set; get; }// branch diameter

        //Find min_max
        private double min_max(double a, double b, bool IsMin)
        {
            if (IsMin) return a < b ? a : b; //IsMin = true find min
            else return a > b ? a : b;       //IsMin = false find max
        }
        #region Thinning Damage Factor
        //Step 1: xác định lại hệ số Tmin
        private double getTmin()
        {
            double t;
            if (componentType=="TANKBOTTOM")
            {
                t = protectionBarrier ? 0.125 : 0.25; //inc
            }
            else
            {
                //t = DesignPressure * (InsideDiametter + Crbm *age) /(WeldJoint*AllowableStress - 0.6*DesignPressure);
                t = Tmin;
            }
            return t;
        }
        //Step 2: nếu có lớp vỏ thì tính toán agerc
        private double agerc()
        {
            return min_max((Trd - T) / Crcm, 0, false);
        }
        //Step 3: Tính toán Art
        public double Art(int a)
        {
            if (!haveCladding)
            {
                return Math.Max(1 - (Trd - Crbm * a) / (getTmin() + CA), 0);
            }
            else
            {
                double x = 1 - (Trd - Crcm * agerc() - Crbm * (a - agerc())) / (getTmin() + CA);
                return Math.Max(x, 0);
            }
        }
        // B4: chuẩn hóa art
        public double chuanHoaArt(double a)
        {
            double art = 0;
            if (componentType != "TANKBOTTOM")
            {
                double[] data = { 0.02, 0.04, 0.06, 0.08, 0.1, 0.12, 0.14, 0.16, 0.18, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65 };
                if (a < (data[0] + data[1]) / 2)
                    art = data[0];
                else if (a < (data[1] + data[2]) / 2)
                    art = data[1];
                else if (a < (data[2] + data[3]) / 2)
                    art = data[2];
                else if (a < (data[3] + data[4]) / 2)
                    art = data[3];
                else if (a < (data[4] + data[5]) / 2)
                    art = data[4];
                else if (a < (data[5] + data[6]) / 2)
                    art = data[5];
                else if (a < (data[6] + data[7]) / 2)
                    art = data[6];
                else if (a < (data[7] + data[8]) / 2)
                    art = data[7];
                else if (a < (data[8] + data[9]) / 2)
                    art = data[8];
                else if (a < (data[9] + data[10]) / 2)
                    art = data[9];
                else if (a < (data[10] + data[11]) / 2)
                    art = data[10];
                else if (a < (data[11] + data[12]) / 2)
                    art = data[11];
                else if (a < (data[12] + data[13]) / 2)
                    art = data[12];
                else if (a < (data[13] + data[14]) / 2)
                    art = data[13];
                else if (a < (data[14] + data[15]) / 2)
                    art = data[14];
                else if (a < (data[15] + data[16]) / 2)
                    art = data[15];
                else if (a < (data[16] + data[17]) / 2)
                    art = data[16];
                else if (a < (data[17] + data[18]) / 2)
                    art = data[17];
                else art = data[18];
            }
            else
            {
                double[] data = { 0.05, 0.1, 0.15, 0.2, 0.25, 0.3, 0.35, 0.4, 0.45, 0.5, 0.55, 0.6, 0.65, 0.7, 0.75, 0.8, 0.85, 0.9, 0.95, 1 };
                if (a < (data[0] + data[1]) / 2)
                    art = data[0];
                else if (a < (data[1] + data[2]) / 2)
                    art = data[1];
                else if (a < (data[2] + data[3]) / 2)
                    art = data[2];
                else if (a < (data[3] + data[4]) / 2)
                    art = data[3];
                else if (a < (data[4] + data[5]) / 2)
                    art = data[4];
                else if (a < (data[5] + data[6]) / 2)
                    art = data[5];
                else if (a < (data[6] + data[7]) / 2)
                    art = data[6];
                else if (a < (data[7] + data[8]) / 2)
                    art = data[7];
                else if (a < (data[8] + data[9]) / 2)
                    art = data[8];
                else if (a < (data[9] + data[10]) / 2)
                    art = data[9];
                else if (a < (data[10] + data[11]) / 2)
                    art = data[10];
                else if (a < (data[11] + data[12]) / 2)
                    art = data[11];
                else if (a < (data[12] + data[13]) / 2)
                    art = data[12];
                else if (a < (data[13] + data[14]) / 2)
                    art = data[13];
                else if (a < (data[14] + data[15]) / 2)
                    art = data[14];
                else if (a < (data[15] + data[16]) / 2)
                    art = data[15];
                else if (a < (data[16] + data[17]) / 2)
                    art = data[16];
                else if (a < (data[17] + data[18]) / 2)
                    art = data[17];
                else if (a < (data[18] + data[19]) / 2)
                    art = data[18];
                else art = data[19];
            }
            return art;
        }
        // B5: get data from table 5.11 5.12 D_fb_thin
        private double getD_fb_thin(int a)
        {
            if (catalog_thin == null)
                return 0;
            else if (componentType=="TANKBOTOM")
            {
                return rbi.D_fb_tank(chuanHoaArt(Art(a)), catalog_thin);
            }
            else
                return rbi.getDfb(chuanHoaArt(Art(a)), noInsp, catalog_thin);
        }
        // B6: xác định kết quả cuối cùng từ bước 5 và các giá trị
        public double D_f_thin(int a)
        {
            double D_f_thin = 0;
            if(getD_fb_thin(a) == 1)
            {
                if (componentType == "TANKBOTOM")
                    D_f_thin = getD_fb_thin(a) * Fip * Fdl * Fwd * Fam * Fsm ;
                else
                    D_f_thin = getD_fb_thin(a) * Fip * Fdl * Fwd * Fam ;
            }
            else
            {
                if (componentType == "TANKBOTOM")
                    D_f_thin = getD_fb_thin(a) * Fip * Fdl * Fwd * Fam * Fsm / Fom_thin;
                else
                    D_f_thin = getD_fb_thin(a) * Fip * Fdl * Fwd * Fam / Fom_thin;
            }
            return D_f_thin; 
        }
        #endregion
        #region Linning Damage Factor
        //Step 1: tra bảng 6.4 ra 1 thành phần của Dfb
        private double D_fb_liner_inorganic(int a)
        {
            double dfb = rbi.getDf_liner_64(a, linningType);
            return dfb;
        }
        //Step 2: tra bảng 6.5 ra được thành phần còn lại Dfb
        private double D_fb_liner_organic(int a)
        {

            double dfb = rbi.getDf_liner_65(yearInService, a);
            return dfb;
        }
        // tính tổng 2 thành phần lại
        private double D_fb_liner(int a)
        {
            return D_fb_liner_inorganic(a) + D_fb_liner_organic(a);
        }
        //Step 3: xác định Df
        public double D_f_liner(int a)
        {
            return D_fb_liner(a) * Fom_lin * Flc;
        }
        #endregion
        #region SSC Damage Factor Caustic Cracking
        //Step 1: Determine SVI (table 7.3)
        private int SVI_Caustic()
        {
            int svi;
            if (level_caust=="High")
                svi = 5000;
            else if (level_caust=="Medium")
                svi = 500;
            else if (level_caust=="Low")
                svi = 50;
            else svi = 1;
            return svi;
        }
        // B2: xác định D_f_caustic từ bảng 7.4
        private int D_f_caustic()
        {
            if (catalog_caustic == null)
                return 0;
            else
            {
                String field = noInsp + catalog_caustic;
                return rbi.getD_f_scc(SVI_Caustic(), field);
            }
        }
        //B3: xác định D_f từ D_f_caustic và age
        public double D_f(int a)
        {
            return D_f_caustic() * Math.Pow(a, 1.1);
        }
        #endregion
        #region SSC Damage Factor Amine Cracking
        //Step 1: xác định SVI( table 8.3)
        private int SVI_Amine()
        {
            int svi;
            if (level_amine=="High")
                svi = 1000;
            else if (level_amine=="Medium")
                svi = 100;
            else if (level_amine=="Low")
                svi = 10;
            else
                svi = 1;
            return svi;
        }
        //Step 2: xác định D_f_amine( table 7.4)
        private int D_fb_amine()
        {
            if (catalog_amine == null)
                return 0;
            else
            {
                String field = noInsp + catalog_amine;
                return rbi.getD_f_scc(SVI_Amine(), field);
            }
        }
        //Step 3: xác định D_f theo công thức
        public double D_f_amine(int a)
        {
            return D_fb_amine() * Math.Pow(a, 1.1);
        }
        #endregion
        #region SSC Damage Factor Sulfide Stress Cracking
        //Step 1: xac dinh do anh huong toi moi truong( table 9.3)
        private String EnvSeveritySulfide()
        {
            String ppmString = null;
            if (ppm_sulf < 50)
                ppmString = "<50";
            else if (ppm_sulf >= 50 && ppm_sulf < 1000)
                ppmString = "50-1000";
            else if (ppm_sulf >= 1000 && ppm_sulf <= 10000)
                ppmString = "1000-10000";
            else
                ppmString = ">10000";

            String pHString = null;
            if (pH < 5.5)
                pHString = "<5.5";
            else if (pH >= 5.5 && pH <= 7.5)
                pHString = "5.5-7.5";
            else if (pH >= 7.6 && pH <= 8.3)
                pHString = "7.6-8.3";
            else if (pH >= 8.4 && pH <= 8.9)
                pHString = "8.4-8.9";
            else
                pHString = ">9.0";
            return rbi.getEnvironmental(ppmString, pHString);
        }
        //Step 2: xac dinh scc tu bang 9.4
        private String SSC()
        {
            String pwhtString = null;
            if (PWHT < 200)
                pwhtString = "<200";
            else if (PWHT >= 200 && PWHT <= 237)
                pwhtString = "200-237";
            else
                pwhtString = ">237";
            return rbi.getSulfideStressCracking(EnvSeveritySulfide(), pwhtString);
        }
        // Step 3: tu B2- xac dinh SVI
        private int SVI_sulfide()
        {
            String data = SSC();
            int svi;
            if (crackPresent == true)
            {
                svi = 100;
            }
            else
            {
                if (data=="High")
                    svi = 100;
                else if (data=="Medium")
                    svi = 10;
                else if (data=="Low")
                    svi = 1;
                else
                    svi = 1;
            }
            return svi;
        }
        //Step 4: tu buoc 3 tra bang 7.4 ra duoc he so D_fb_ssc
        private int D_fb_ssc()
        {
            if (catalog_sulf == null)
                return 0;
            else
            {
                String field = noInsp + catalog_sulf;
                return rbi.getD_f_scc(SVI_sulfide(), field);
            }
        }
        // B5: tinh ket qua cuoi cung D_f_ssc
        public double D_f_ssc(int a)
        {
            return D_fb_ssc() * Math.Pow(a, 1.1);
        }
        #endregion
        #region SSC Damage Factor HIC/SOHIC-H2S
        //B1: xac dinh muc do anh huong toi moi truong( table 10.3)
        private String EnvSeverityH2S()
        {
            String ppmString = null;
            if (ppm_H2S < 50)
                ppmString = "<50";
            else if (ppm_H2S >= 50 && ppm_H2S < 1000)
                ppmString = "50-1000";
            else if (ppm_H2S >= 1000 && ppm_H2S <= 10000)
                ppmString = "1000-10000";
            else
                ppmString = ">10000";

            String pHString = null;
            if (pH < 5.5)
                pHString = "<5.5";
            else if (pH >= 5.5 && pH <= 7.5)
                pHString = "5.5-7.5";
            else if (pH >= 7.6 && pH <= 8.3)
                pHString = "7.6-8.3";
            else if (pH >= 8.4 && pH <= 8.9)
                pHString = "8.4-8.9";
            else
                pHString = ">9.0";
            return rbi.getEnvironmental(ppmString, pHString);
        }
        // B2: xac dinh scc tu bang 10.4
        private String SCC()
        {
            String pwhtString = null;
            if (crackPresent)
                pwhtString = "High";
            else
            {
                if (PWHT > 0.01)
                    pwhtString = "High";
                else if (PWHT >= 0.002 && PWHT <= 0.01)
                    pwhtString = "Low";
                else
                    pwhtString = "Ultra";
            }
            return rbi.getHIC(EnvSeverityH2S(), pwhtString, isPWHT);
        }
        // B3: xac dinh svi
        public int SVI_H2S()
        {
            String data = SCC();
            int svi;
            if (crackPresent == true)
            {
                svi = 100;
            }
            else
            {
                if (data=="High")
                    svi = 100;
                else if (data=="Medium")
                    svi = 10;
                else
                    svi = 1;
            }
            return svi;
        }
        // B4: xac dinh D_fb_hic tu bang 7.4
        public int D_fb_hic()
        {
            if (catalog_hicH2S == null)
                return 0;
            else
            {
                String field = noInsp +""+ catalog_hicH2S;
                return rbi.getD_f_scc(SVI_H2S(), field);
            } 
        }
        // B5: tinh D_f_hic bang cong thuc
        public double D_f_hic(int a)
        {
            return D_fb_hic() * Math.Pow(a, 1.1);
        }
        #endregion
        #region SSC Damage Factor Carbonate Cracking
        //Step 1: Determine the number of inspections, and the corresponding inspection effectiveness category
        //Step 2: Determine the time in-service, age , since the last Level A, B, C or D inspection was performed
        //Step 3: Determine the susceptibility for cracking
        private String susceptibility()
        {
            String _pH = null;
            if (pH >= 7.6 && pH <= 8.3) _pH = "7.6-8.3";
            else if (pH > 8.3 && pH < 9.0) _pH = "8.3-9.0";
            else _pH = "=>9.0";
            String _ppm = null;
            if (ppm_cacbon < 100) _ppm = "<100";
            else if (ppm_cacbon >= 100 && ppm_cacbon <= 500) _ppm = "100-500";
            else if (ppm_cacbon > 500 && ppm_cacbon <= 1000) _ppm = "500-1000";
            else _ppm = ">1000";
            return rbi.getSusCarbonate(_pH, _ppm);
        }
        //Step 4: Determine the severity index, Svi
        private int SVI_Carbonate()
        {
            int svi = 0;
            if (crackPresent)
                svi = 1000;
            else
            {
                switch (susceptibility())
                {
                    case "High": svi = 1000; break;
                    case "Medium": svi = 100; break;
                    case "Low": svi = 10; break;
                    default: svi = 1; break;
                }
            }
            return svi;
        }
        //Step 5: Determine the base damage factor for carbonate cracking, D_carbonate_fB
        private int D_carbonate_fB()
        {
            if (catalog_cacbon == null)
                return 0;
            else
            {
                String field = noInsp + catalog_cacbon;
                return rbi.getD_f_scc(SVI_Carbonate(), field);
            }
            
        }
        //Step 6: Calculate D_carbonate_f
        public double D_f_cacbonate(int a)
        {
            return D_carbonate_fB() * Math.Pow(a, 1.1);
        }
        #endregion
        #region SSC Damage Factor PTA Cracking
        // B1: xac dinh muc do cracking HSC_HF su dung bang 14.3
        private String getsscp_pta()
        {
            String heatTreatment;
            if (opTemp < 427)
                heatTreatment = fHT + " (<800oF)";
            else
                heatTreatment = fHT + " (>=800oF)";

            return rbi.getSusceptibilityPTACracking(material, heatTreatment);
        }
        // B2: xac dinh SVI theo table 14.4
        private int SVI()
        {
            String sscp_pta = getsscp_pta();
            int svi;
            if (sscp_pta=="High")
                svi = 5000;
            else if (sscp_pta=="Medium")
                svi = 500;
            else if (sscp_pta=="Low")
                svi = 50;
            else
                svi = 1;
            return svi;
        }
        // B3: xac dinh D_fb_hsc tu bang 7.4
        private int D_fb_pta()
        {
            if (catalog_pta == null)
                return 0;
            else
            {
                String field = noInsp + catalog_pta;
                return rbi.getD_f_scc(SVI(), field);
            }
            
        }
        // B4: tinh D_f_hsc theo cong thuc
        public double D_f_pta(int a)
        {
            return D_fb_pta() * Math.Pow(a, 1.1);
        }
        #endregion
        #region SSC Damage Factor CLSCC
        //B1: Xac dinh muc do bang bang 13.3
        private String CLSCC()
        {
            String temString = null;
            String phString = null;
            String field = null;

            if (ppm_clo >= 1 && ppm_clo <= 10)
                field = "1-10";
            else if (ppm_clo >= 11 && ppm_clo <= 100)
                field = "11-100";
            else if (ppm_clo >= 101 && ppm_clo <= 1000)
                field = "101-1000";
            else
                field = ">1000";


            if (pH <= 10)
            {
                phString = "<=10";
                if (Temperature >= 100 && Temperature <= 150)
                    temString = "100-150";
                else if (Temperature > 150 && Temperature <= 200)
                    temString = ">150-200";
                else
                    temString = ">200-300";
            }
            else
            {
                phString = ">10";
                if (Temperature < 200)
                {
                    temString = "<200";
                }
                else
                {
                    temString = "200-300";
                }
            }

            return rbi.getCLSCC(temString, phString, field);
        }

        // B2: xac dinh SVI
        private int SVI_CLSCC()
        {
            int svi;
            String level = CLSCC();

            if (crackPresent == true)
                svi = 5000;
            else
            {
                if (level=="High")
                    svi = 5000;
                else if (level=="Medium")
                    svi = 500;
                else if (level=="Low")
                    svi = 50;
                else
                    svi = 1;
            }
            return svi;
        }

        //B3: xac dinh D_fb_clscc bang table 7.4
        private int D_fb_clscc()
        {
            if (catalog_clscc == null)
                return 0;
            else
            {
                String field = noInsp + catalog_clscc;
                return rbi.getD_f_scc(SVI_CLSCC(), field);
            }
            
        }
        // B4: tinh toan D_f_clscc
        public double D_f_clscc(int a)
        {
            return D_fb_clscc() * Math.Pow(a, 1.1);
        }
        #endregion
        #region SCC DAMAGE FACTOR – HSC-HF
        // B1: xac dinh muc do cracking HSC_HF su dung bang 14.3
        private String getHSC_HF()
        {
            String hsc_hf = null;
            String field = null;

            if (BrinellHardness < 200)
                field = "<200";
            else if (BrinellHardness >= 200 && BrinellHardness <= 237)
                field = "200-237";
            else
                field = ">237";


            if (crackPresent)
                hsc_hf = "High";
            else
            {
                if (hfPresent)
                {
                    if (carbonateSteel)
                        hsc_hf = rbi.getHSC_HF(isPWHT, field);
                    else
                        hsc_hf = "None";
                }
                else
                    hsc_hf = "None";
            }
            return hsc_hf;
        }
        // B2: xac dinh SVI theo table 14.4
        private int SVI_hf()
        {
            String hsc_hf = getHSC_HF();
            int svi;
            if (hsc_hf=="High")
                svi = 100;
            else if (hsc_hf=="Medium")
                svi = 10;
            else
                svi = 1;
            return svi;
        }
        // B3: xac dinh D_fb_hsc tu bang 7.4
        private int D_fb_hsc()
        {
            if (catalog_hf == null)
                return 0;
            else
            {
                String field = noInsp + catalog_hf;
                return rbi.getD_f_scc(SVI_hf(), field);
            }
            
        }
        // B4: tinh D_f_hsc theo cong thuc
        public double D_f_hsc(int a)
        {
            return D_fb_hsc() * Math.Pow(a, 1.1);
        }
        #endregion
        //VUNA
        #region SCC DAMAGE FACTOR HIC/SOHIC-HF
        private string getSuHF()
        {
            string _ppm = null;
            if (hfPresent)
            {
                if (ppm_S > 0.01) _ppm = ">0.01";
                else if (ppm_S >= 0.002 && ppm_S <= 0.01) _ppm = "0.002-0.01";
                else _ppm = "<0.002";
                return rbi.getSusHF(_ppm, isPWHT);
            }
            else return "None";
        }
        private int Svi()
        {
            int svi = 0;
            if (crackPresent)
            {
                svi = 100;
            }
            else
            {
                switch (getSuHF())
                {
                    case "High": svi = 100; break;
                    case "Medium": svi = 10; break;
                    default: svi = 1; break;
                }
            }
            return svi;
        }
        public double D_f_hic_hf(int a)
        {
            if(catalog_hic_hf == null)
            {
                return 0;
            }
            else
            {
                string field = noInsp + catalog_hic_hf;
                return rbi.getD_f_scc(Svi(), field) * Math.Pow(a, 1.1);
            }
            
        }
        #endregion
        #region Damage Factor - Externed Corrosion
        private double calculationDate()
        {
            double d;
            if (coatQuality == "Poor" || coatQuality == "No")
                d = comInstallDate;
            else if (coatQuality == "Medium")
                d = comInstallDate + 5;
            else
                d = comInstallDate + 15;
            return DateTime.Today.Year - d;
        }
        private double age_coat()
        {
            return min_max(0, calculationDate(), false);
        }
        private double age_ext(int a)
        {
            return min_max(a, age_coat(), true);
        }
        private double getTemp()
        {
            if (opTemp <= 14) return 10;
            else if (opTemp <= 30.5) return 18;
            else if (opTemp <= 66.5) return 43;
            else if (opTemp <= 125) return 90;
            else if (opTemp <= 192.5) return 160;
            else if (opTemp <= 237.5) return 225;
            else return 250;
        }
        private int C_rB()
        {
            return rbi.getCorrosionRate(getTemp(), driver_extd);
        }
        private double C_r()
        {
            return C_rB() * min_max(Fip_ext, Fps_ext, false);
        }
        private double A_rt(int a)
        {
            double temp = 1 - (Trd - C_r() * 0.001 * age_ext(a)) / (Tmin + CA);
            return min_max(temp, 0, false);
        }
        public double D_f_ext(int a)
        {
            if (catalog_extd == null)
                return 0;
            else if(componentType == "TANKBOTTOM")
            {
                string level = noInsp.ToString() + catalog_extd;
                return rbi.D_fb_tank(chuanHoaArt(A_rt(a)), level);
            }
            else
                return rbi.getDfb(chuanHoaArt(A_rt(a)), noInsp, catalog_extd);
        }
        #endregion
        #region CUI DAMAGE FACTOR

        private double getTemp_cui()
        {
            if (opTemp <= 14) return 10;
            else if (opTemp <= 30.5) return 18;
            else if (opTemp <= 66.5) return 43;
            else if (opTemp <= 125) return 90;
            else if (opTemp <= 192.5) return 160;
            else if (opTemp <= 250) return 225;
            else if (opTemp <= 300) return 275;
            else if (opTemp <= 337.5) return 325;
            else return 350;
        }
        private double Crb()
        {
            double crb = 0;
            if (CR != 0)
            {
                crb = CR;
            }
            else
            {

                crb = rbi.getCrb_CUI(getTemp_cui(), driver_cui);
            }
            return crb*0.001;
        }
        private double Cr_cui()
        {
            double Fcm_cui;
            double Fic_cui;
            double Fps_cui;
            double Fip_cui;
            double Fins_cui = rbi.getFins(isulationtype);

            if (complexity == "below average")
                Fcm_cui = 0.75;
            else if (complexity == "average")
                Fcm_cui = 1;
            else
                Fcm_cui = 1.25;

            if (insulation == "below average")
                Fic_cui = 1.25;
            else if (insulation == "average")
                Fic_cui = 1;
            else Fic_cui = 0.75;

            if (allowConfig)
                Fps_cui = 1;
            else Fps_cui = 2;

            if (enterSoil)
                Fip_cui = 2;
            else
                Fip_cui = 1;

            return Crb() * Fcm_cui * Fic_cui * Fins_cui * min_max(Fip_cui, Fps_cui, false);
        }
        private double Art_cui(int a)
        {
            double art = 1 - (Trd - Cr_cui() * age_ext(a)) / (Tmin + CA);
            return min_max(art, 0, false);
        }
        public double D_f_cui(int a)
        {
            if (catalog_cui == null)
                return 0;
            else if (componentType == "TANKBOTTOM")
            {
                string level = noInsp.ToString() + catalog_cui;
                return rbi.D_fb_tank(chuanHoaArt(Art_cui(a)), level);
            }
            else
                return rbi.getDfb(chuanHoaArt(Art_cui(a)), noInsp, catalog_cui);
        }
        #endregion
        #region EXTERNAL CLSCC DAMAGE FACTOR
        private String getStringOPTem()
        {
            String opTempString = null;
            if (opTemp < 120)
                opTempString = "<120";
            else if ((opTemp >= 120) & (opTemp < 200))
                opTempString = "120 to 200";
            else if ((opTemp >= 200) & (opTemp < 300))
                opTempString = "200 to 300";
            else
                opTempString = ">300";

            return rbi.getSusceptibilityExternalCLSCCAustenitic(opTempString, driver_ext_clscc);
        }
        private int SVI_ext_clscc()
        {
            String ext = getStringOPTem();
            if (ext=="High")
                return 50;
            else if (ext=="Medium")
                return 10;
            else
                return 1;
        }
        private int D_fb_extclscc()
        {
            if (catalog_ext_clscc == null)
                return 0;
            else
            {
                String field = noInsp + catalog_ext_clscc;
                return rbi.getD_f_scc(SVI_ext_clscc(), field);
            }
        }
        public double D_f_ext_clscc()
        {
            return D_fb_extclscc() * Math.Pow(age_coat(), 1.1);
        }
        #endregion
        #region EXTERNAL CUI CLSCC DAMAGE FACTOR
        private String getStringOPTem_cui()
        {
            String opTempString = null;
            if (opTemp < 120)
                opTempString = "<120";
            else if ((opTemp >= 120) & (opTemp < 200))
                opTempString = "120 to 200";
            else if ((opTemp >= 200) & (opTemp < 300))
                opTempString = "200 to 300";
            else
                opTempString = ">300";

            return rbi.getSusceptibilityExternalCUICLSCCAustenitic(opTempString, driver_ext_clscc);
        }
        private String adjust_sscp_piping_complexity()
        {
            String sscpString = getStringOPTem_cui();
            if (sscpString=="High")
            {
                if (pipingComp=="Below Average")
                    sscpString = "Medium";
                else
                    sscpString = "High";

            }
            else if (sscpString=="Medium")
            {
                if (pipingComp=="Below Average")
                    sscpString = "Low";
                else if (pipingComp=="Above Average")
                    sscpString = "High";
                else
                    sscpString = "Medium";
            }
            else
            {
                if (pipingComp=="Above Average")
                    sscpString = "Medium";
                else
                    sscpString = "Low";
            }
            return sscpString;
        }
        private String adjust_sscp_insulation_condition()
        {
            String sscpString1 = adjust_sscp_piping_complexity();
            if (sscpString1=="High")
            {
                if (insCondition=="Below Average")
                    sscpString1 = "Medium";
                else
                    sscpString1 = "High";
            }
            else if (sscpString1=="Medium")
            {
                if (insCondition=="Below Average")
                    sscpString1 = "Low";
                else if (pipingComp=="Above Average")
                    sscpString1 = "High";
                else
                    sscpString1 = "Medium";
            }
            else if (insCondition=="Low")
            {
                if (pipingComp=="Above Average")
                    sscpString1 = "Medium";
                else
                    sscpString1 = "Low";
            }
            return sscpString1;
        }
        private int SVI_cui_clscc()
        {
            String sscp = adjust_sscp_insulation_condition();
            int svi = 0;
            if (sscp=="High")
                svi = 50;
            else if (sscp=="Medium")
                svi = 10;
            else if (sscp=="Low")
                svi = 1;
            else
                svi = 0;
            return svi;
        }
        private int D_fb_extcuiclscc()
        {
            if (catalog_ext_clscc == null)
                return 0;
            else
            {
                String field = noInsp + catalog_ext_clscc;
                return rbi.getD_f_scc(SVI_cui_clscc(), field);
            }
        }
        public double D_f_extcuiclscc()
        {
            return D_fb_extcuiclscc() * Math.Pow(age_coat(), 1.1);
        }
        #endregion
        #region HTHA DAMAGE FACTOR
        public double Pv()
        {
            double t = (T_htha - 32) / 1.8; //doi sang do C
            double log1 = Math.Log10(P_h2 / 0.0979);
            double log2 = 3.09 * Math.Pow(10, -4) * (t + 273) * (Math.Log10(age_htha) + 14);
            return log1 + log2;
        }
        public String getSusceptibility()
        {
            double pv = Pv();
            String susceptibility = null;
            if (P_h2 > 8.274) materials = "1.25Cr-0.5Mo";
            switch (materials)
            {
                case "Carbon Steel":
                    {
                        if (pv > 4.7) susceptibility = "High";
                        else if (pv > 4.61 && pv <= 4.7) susceptibility = "Medium";
                        else if (pv > 4.53 && pv <= 4.61) susceptibility = "Low";
                        else susceptibility = "Not";
                        break;
                    }
                case "C-0.5Mo(Annealed)":
                    {
                        if (pv > 4.95) susceptibility = "High";
                        else if (pv > 4.87 && pv <= 4.95) susceptibility = "Medium";
                        else if (pv > 4.78 && pv <= 4.87) susceptibility = "Low";
                        else susceptibility = "Not";
                        break;
                    }
                case "C-0.5Mo(Normalized)":
                    {
                        if (pv > 5.6) susceptibility = "High";
                        else if (pv > 5.51 && pv <= 5.6) susceptibility = "Medium";
                        else if (pv > 5.43 && pv <= 5.51) susceptibility = "Low";
                        else susceptibility = "Not";
                        break;
                    }
                case "1Cr-0.5Mo":
                    {
                        if (pv > 5.8) susceptibility = "High";
                        else if (pv > 5.71 && pv <= 5.8) susceptibility = "Medium";
                        else if (pv > 5.63 && pv <= 5.71) susceptibility = "Low";
                        else susceptibility = "Not";
                        break;
                    }
                case "1.25Cr-0.5Mo":
                    {
                        if (pv > 6.0) susceptibility = "High";
                        else if (pv > 5.92 && pv <= 6.0) susceptibility = "Medium";
                        else if (pv > 5.83 && pv <= 5.92) susceptibility = "Low";
                        else susceptibility = "Not";
                        break;
                    }
                case "2.25Cr-1Mo":
                    {
                        if (pv > 6.53) susceptibility = "High";
                        else if (pv > 6.45 && pv <= 6.53) susceptibility = "Medium";
                        else if (pv > 6.36 && pv <= 6.45) susceptibility = "Low";
                        else susceptibility = "Not";
                        break;
                    }
                default: susceptibility = "NULL"; break;
            }
            return susceptibility;
        }
        public int D_f_htha()
        {
            if (T_htha <= 400 && P_h2 <= 80) //0.552)
                return 1;
            else
                return rbi.getHTHA(noInsp, catalog_htha, getSusceptibility());
        }
        #endregion
        #region BRITTLE FACTURE DAMAGE FACTOR
        private double getTmin_brittle()
        {
            if (tempMin != 0)
                return tempMin;
            else
                return min_max(min_max(tempDesign, tempUpset, true), tempBoiling, true);
        }
        private double getTestTemp_brittle()
        {
            return rbi.getTref(Trd, curve);
        }
        private double Tref_brittle()
        {
            return min_max(getTestTemp_brittle(), min_max(MDMT, tImpact, true), true);
        }
        private double Tmin_Tref()
        {
            double t = getTmin_brittle() - Tref_brittle();
            double result;
            if (t > (100 + 80) / 2)
                result = 100;
            else if (t <= 90 && t > 70)
                result = 80;
            else if (t <= 70 && t > 50)
                result = 60;
            else if (t <= 50 && t > 30)
                result = 40;
            else if (t <= 30 && t > 10)
                result = 20;
            else if (t <= 10 && t > -10)
                result = 0;
            else if (t <= -10 && t > -30)
                result = -20;
            else if (t <= -30 && t > -50)
                result = -40;
            else if (t <= -50 && t > -70)
                result = -60;
            else if (t <= -70 && t > -90)
                result = -80;
            else
                result = -100;
            return result;
        }
        private double comThickNew()
        {
            double comThick;
            if (Trd < (0.5 + 0.25) / 2)
                comThick = 0.25;
            else if (Trd >= (0.5 + 0.25) / 2 && Trd < (0.5 + 1) / 2)
                comThick = 0.5;
            else if (Trd >= (0.5 + 1) / 2 && Trd < (1 + 1.5) / 2)
                comThick = 1.0;
            else if (Trd >= (1 + 1.5) / 2 && Trd < (1.5 + 2) / 2)
                comThick = 1.5;
            else if (Trd >= (1.5 + 2) / 2 && Trd < (2 + 2.5) / 2)
                comThick = 2;
            else if (Trd >= (2 + 2.5) / 2 && Trd < (2.5 + 3) / 2)
                comThick = 2.5;
            else if (Trd >= (2.5 + 3) / 2 && Trd < (3 + 3.5) / 2)
                comThick = 3;
            else if (Trd >= (3 + 3.5) / 2 && Trd < (3.5 + 4) / 2)
                comThick = 3.5;
            else comThick = 4;
            return comThick;
        }
        private double D_fb_brittle()
        {
            if (curve == null)
                return 0;
            else
                return rbi.get_D_fb_brittle(isPWHT, Tmin_Tref(), comThickNew());
        }
        public double D_f_britfact()
        {
            double Fse;
            if (lowTemp)
                Fse = 0.01;
            else Fse = 1;
            return D_fb_brittle() * Fse;
        }
        #endregion
        #region TEMPER EMBRITTLE DAMAGE FACTOR
        private double getTmin_embrittle()
        {
            if (tempMin != 0)
                return tempMin;
            else
                return min_max(tempDesign, opTemp, true);
        }
        private double getT_exam()
        {
            return rbi.getTref(Trd, curve);
        }
        private double getTref_embrit()
        {
            return min_max(getT_exam(), min_max(MDMT, tImpact, true), true);
        }
        private double getFATT()
        {
            return 0.67 * Math.Log(age_htha - 0.91) * SCE;
        }
        private double getDeltaT_embrit()
        {
            double t = getTmin_embrittle() - getTref_embrit() - getFATT();
            double result;
            if (t > (100 + 80) / 2)
                result = 100;
            else if (t <= 90 && t > 70)
                result = 80;
            else if (t <= 70 && t > 50)
                result = 60;
            else if (t <= 50 && t > 30)
                result = 40;
            else if (t <= 30 && t > 10)
                result = 20;
            else if (t <= 10 && t > -10)
                result = 0;
            else if (t <= -10 && t > -30)
                result = -20;
            else if (t <= -30 && t > -50)
                result = -40;
            else if (t <= -50 && t > -70)
                result = -60;
            else if (t <= -70 && t > -90)
                result = -80;
            else
                result = -100;
            return result;
        }
        public double D_f_embrit()
        {
            if (curve == null)
                return 0;
            else
                return rbi.get_D_fb_brittle(isPWHT, getDeltaT_embrit(), comThickNew());
        }
        #endregion
        #region 885 DAMAGE FACTOR
        private double T_min_885()
        {
            if (adminControl)
                return tMin_885;
            else
                return min_max(tempDesign, opTemp, true);
        }
        private double T_ref_885()
        {
            if (brittleCheck)
                return tRef;
            else
                return 80;
        }
        private double estimate()
        {
            double refTemp1 = T_ref_885();
            double minTemp1 = T_min_885();
            double estimateTemp = 0;
            if ((minTemp1 - refTemp1) >= 90)
                estimateTemp = 100;
            else if (((minTemp1 - refTemp1) >= 70) & ((minTemp1 - refTemp1) < 90))
                estimateTemp = 80;
            else if (((minTemp1 - refTemp1) >= 50) & ((minTemp1 - refTemp1) < 70))
                estimateTemp = 60;
            else if (((minTemp1 - refTemp1) >= 30) & ((minTemp1 - refTemp1) < 50))
                estimateTemp = 40;
            else if (((minTemp1 - refTemp1) >= 10) & ((minTemp1 - refTemp1) < 30))
                estimateTemp = 20;
            else if (((minTemp1 - refTemp1) >= -10) & ((minTemp1 - refTemp1) < 10))
                estimateTemp = 0;
            else if (((minTemp1 - refTemp1) >= -30) & ((minTemp1 - refTemp1) < -10))
                estimateTemp = -20;
            else if (((minTemp1 - refTemp1) >= -50) & ((minTemp1 - refTemp1) < -30))
                estimateTemp = -40;
            else if (((minTemp1 - refTemp1) >= -70) & ((minTemp1 - refTemp1) < 50))
                estimateTemp = -60;
            else if (((minTemp1 - refTemp1) >= -90) & ((minTemp1 - refTemp1) < 70))
                estimateTemp = -80;
            else if ((minTemp1 - refTemp1) < -90)
                estimateTemp = -100;
            return estimateTemp;
        }
        public double D_f_885()
        {
            if (tMin_885 == 0 && tempDesign == 0 && opTemp == 0)
                return 0;
            else
                return rbi.get885EmbrittlementDamageFactor(estimate());
        }
        #endregion
        #region SIGMA DAMAGE FACTOR
        private double Tmin_sigma()
        {
            return min_max(tShutdown, min_max(tempUpset, opTemp, true), true);
        }
        public double D_f_sigma()
        {
            if (pSigma == 0)
                return 0;
            else
                return rbi.getDf_spe_243(pSigma, Tmin_sigma());
        }
        #endregion
        #region PIPING MECHANICAL DAMAGE FACTOR
        private double D_fB_pf()
        {
            double D_fB_pf = 0;
            if (noPreFatFailure== "Greater than one")
                D_fB_pf = 500;
            else if (noPreFatFailure=="One")
                D_fB_pf = 50;
            //else if (noPreFatFailure.Equals("Greater than one"))
            else
                D_fB_pf = 1;
            return D_fB_pf;
        }
        private double D_fB_as()
        {
            double D_fB_as = 0;
            if (vibrationSVI== "Severe")
                D_fB_as = 500;
            else if (vibrationSVI=="Moderate")
                D_fB_as = 50;
            //else if (vibrationSVI.Equals("Severe"))
            else
                D_fB_as = 1;
            return D_fB_as;
        }
        private double F_fB_as()
        {
            double F_fB_as = 0;
            if (noWeeks < 2)
                F_fB_as = 1;
            else if ((noWeeks >= 2) & (noWeeks < 13))
                F_fB_as = 0.2;
            else
                F_fB_as = 0.02;
            return F_fB_as;
        }
        private double D_fB_cf()
        {
            double D_fB_cf = 0;
            if (cyclicType=="Reciprocating Machinery")
                D_fB_cf = 50;
            else if (cyclicType=="PRV Chatter")
                D_fB_cf = 25;
            else if (cyclicType=="Valve with high pressure drop")
                D_fB_cf = 10;
            else
                D_fB_cf = 1;
            return D_fB_cf;
        }
        public double D_fB_mfat()
        {
            double D_fB_mfat = 0;
            double temp = D_fB_as() * F_fB_as();
            if (D_fB_pf() < temp)
            {
                if (temp < D_fB_cf())
                    D_fB_mfat = D_fB_cf();
                else
                    D_fB_mfat = temp;
            }
            else
            {
                if (D_fB_pf() < D_fB_cf())
                    D_fB_mfat = D_fB_cf();
                else
                    D_fB_mfat = D_fB_pf();
            }
            return D_fB_mfat;
        }
        public double F_ca()
        {
            double F_ca = 0;
            if (correctiveActions=="Modification based on complete engineering analysis")
                F_ca = 0.002;
            else if (correctiveActions=="Modification based on experience")
                F_ca = 0.2;
            else
                F_ca = 2;
            return F_ca;
        }
        public double F_pc()
        {
            double F_pc = 0;
            if ((totalpipeFitting >= 0) & (totalpipeFitting <= 5))
                F_pc = 0.5;
            else if ((totalpipeFitting >= 6) & (totalpipeFitting <= 10))
                F_pc = 1;
            else
                F_pc = 2;
            return F_pc;
        }
        public double F_cp()
        {
            double F_cp = 0;
            if (pipeCondition=="Missing or damaged supports, improper support")
                F_cp = 2;
            else if (pipeCondition=="Broken gussets, gussets welded directly to the pipe")
                F_cp = 2;
            else
                F_cp = 1;
            return F_cp;
        }
        public double F_jb()
        {
            double F_jb = 0;
            if ((jointType=="Threaded") || (jointType=="Socketweld") || (jointType=="Saddle on"))
                F_jb = 2;
            else if (jointType=="Saddle in fitting")
                F_jb = 1;
            else if ((jointType=="Piping tee") || (jointType=="Weldolets"))
                F_jb = 0.2;
            //else if (jointType.Equals("Sweepolets"))
            else
                F_jb = 0.02;
            return F_jb;
        }
        public double F_bd()
        {
            double F_bd = 0;
            if (branchDiameter <= 2)
                F_bd = 1;
            else
                F_bd = 0.02;
            return F_bd;
        }
        public double D_f_mfat()
        {
            return D_fB_mfat() * F_ca() * F_pc() * F_cp() * F_jb() * F_bd();
        }
        #endregion
        ///<summary>
        /// xac dinh DF tong hop
        ///</summary>
        #region DAMAGE FACTOR TOTAL
        public double D_ft_thin(int a)
        {
            if (internalLiner)
                return min_max(D_f_thin(a), D_f_liner(a), true);
            else
                return D_f_thin(a);
        }
        public double D_ft_scc(int ab)
        {
            double a = min_max(D_f(ab), D_f_amine(ab), false);
            double b = min_max(D_f_ssc(ab), D_f_hic(ab), false);
            double c = min_max(D_f_pta(ab), D_f_clscc(ab), false);
            double d = min_max(D_f_hsc(ab), D_f_hic_hf(ab), false);
            double e = min_max(a, b, false);
            double f = min_max(c, d, false);
            double g = min_max(e, f, false);
            return min_max(g, D_f_cacbonate(ab), false);
        }
        public double D_ft_extd(int ab)
        {
            double a = min_max(D_f_ext(ab), D_f_cui(ab), false);
            double b = min_max(D_f_ext_clscc(), D_f_extcuiclscc(), false);
            return min_max(a, b, false);
        }
        public double D_ft_brit()
        {
            double a = D_f_britfact() + D_f_embrit();
            double b = min_max(D_f_885(), D_f_sigma(), false);
            return min_max(a, b, false);
        }

        public double D_f_init(int ab)
        {
            double a, c, d, e, f;

            if (D_ft_thin(ab) <= 1.0)
                a = 0;
            else
                a = D_ft_thin(ab);

            if (D_ft_scc(ab + 27) <= 1.0)
                c = 0;
            else
                c = D_ft_scc(ab + 27);

            if (D_ft_brit() <= 1.0)
                d = 0;
            else
                d = D_ft_brit();

            if (D_f_htha() <= 1.0)
                e = 0;
            else
                e = D_f_htha();

            if (D_f_mfat() <= 1.0)
                f = 0;
            else
                f = D_f_mfat();

            return a + c + d + e + f;
        }
        public double D_f_total(int ab)
        {
            double a, b, c, d,e,f;

            if (D_ft_thin(ab) <= 1.0)
                a = 0;
            else
                a = D_ft_thin(ab);

            if (D_ft_extd(ab) <= 1.0)
                b = 0;
            else
                b = D_ft_extd(ab);

            if (D_ft_scc(ab + 27) <= 1.0)
                c = 0;
            else
                c = D_ft_scc(ab +27);

            if (D_ft_brit() <= 1.0)
                d = 0;
            else
                d = D_ft_brit();

            if (D_f_htha() <= 1.0)
                e = 0;
            else
                e = D_f_htha();

            if (D_f_mfat() <= 1.0)
                f = 0;
            else
                f = D_f_mfat();

            if (thinning == "Local")
                return min_max(a,b, false) + c + d + e + f;
            else
                return a + b + c + d + e + f;
        }
        #endregion
        ///<summary>
        /// xac dinh PoF cuoi cung
        ///</summary>
        #region PoF TOTAL

        public double PoF_total(int a)
        {
            return D_f_total(a) * double.Parse(rbi.getGff(componentType)) * Fms;
        }
        public double PoF_brit()
        {
            return D_ft_brit() * double.Parse(rbi.getGff(componentType)) * Fms;
        }
        #endregion

        ///<summary>
        /// xac dinh PoF cua hai truong hop dac biet
        ///</summary>
        
        // Pressure Relief Device
        public double Fc { set; get; }// yeu to dieu chinh van thong thuong 0.75( mo van de dong thiet bi) 1.0 cho th con lai
        public double Po { set; get; }// ap suat co the neu mo van k theo yeu cau( psig)
        public double MAWP { set; get; }// ap suat toi da cho phep thiet bi duoc bao ve (psig)
        public int Fenv { set; get; }// yeu to dieu chinh moi truong( table 7.6)
        public bool isPass { set; get; }// kiem tra xac dinh la pass or fail
        public String catalog_reliefDevice { set; get; }// effective Relief Device
        public String service { set; get; }// xac dinh fluid service de tra bang 7.5
        public int weibull { set; get; }// xac dinh weibull demand( table 7.5)
        public String servicePOL { set; get; }// xac dinh fluid service de tra bang 7.12
        public int weibullPOL { set; get; }// xac dinh weibull demand truong hop leakage( 7.12) 
        public double DR { set; get; }// xac dinh DR total
        public double Fs { set; get; }// Fs = 1.25 ( soft seated design) or 1.0( other cases)
        public bool isLeakage { set; get; }// xac dinh co xuat hien su leakage hay k?
        public String levelLeakage { set; get; }// xac dinh muc do leakage( dua vao lich su)
        

        #region PoF pressure relief device
        // xac suat mo van bi loi
        private double get_CF(bool f)
        {
            return rbi.get_CF(catalog_reliefDevice, f);
        }
        private double Fop_relief()
        {
            return (1 / 3.375) * (Po / MAWP - 1.3);
        }
        public double n_mod()
        {
            double n = rbi.get_n(service, weibull);
            return n * Fc * rbi.get_fenv(Fenv, true) * Fop_relief();
        }
        private double P_f_prior(int a)
        {
            return 1 - Math.Exp(-Math.Pow(a / n_mod(), 1.8));
        }
        private double P_p_prior(int a)
        {
            return 1 - P_f_prior(a);
        }
        private double P_f_cond(int a)
        {
            if (isPass) return (1 - get_CF(true) * P_p_prior(a));
            else return get_CF(false) * P_f_prior(a) + (1 - get_CF(true) * P_p_prior(a));
        }
        public double P_f_wgt(int a)
        {
            double p = 0;
            if (isPass)
            {
                p = P_f_prior(a) - 0.2 * P_f_prior(a) * (a / n_mod()) + 0.2 * P_f_cond(a) * (a / n_mod());
            }
            else
            {
                if ((catalog_reliefDevice=="Highly Effective") || (catalog_reliefDevice=="Usually Effective"))
                    p = P_f_cond(a);
                else
                    p = 0.5 * (P_f_prior(a) + P_f_cond(a));
            }
            return p;
        }
        public double n_upd(int a)
        {
            return (a / (Math.Pow(-Math.Log(1 - P_f_wgt(a)), 1 / 1.8)));
        }
        public double P_fod(int a)
        {
            return (1 - Math.Exp(-Math.Pow(a / n_upd(a), 1.8)));
        }
        public double P_f_open(int a)
        {
            double gffTotal = double.Parse(rbi.getGff(componentType));
            return PoF_total(a) + ((1 - gffTotal) / 3) * (Po / MAWP - 1);
        }
        public double P_prd_f(int a)
        {
            return P_fod(a) * DR * P_f_open(a);
        }
        // xac suat ro ri
        private double n_mod_l()
        {
            double n = rbi.get_n(servicePOL, weibullPOL);
            return n * Fs * rbi.get_fenv(Fenv, false);
        }
        public double P_f_l(int a)
        {
            return 1 - Math.Exp(-Math.Pow(a / n_mod_l(), 1.8));
        }
        public double P_p_l(int a)
        {
            return 1 - P_f_l(a);
        }
        public double P_fcond_l(int a)
        {
            if (isLeakage) return (get_CF(false) * P_f_l(a) + (1 - get_CF(true)) * P_p_l(a));
            else return (1 - get_CF(true)) * P_p_l(a);
        }
        public double P_l_wgt(int a)
        {
            double p = 0;
            if ((levelLeakage=="Highly Effective Pass") || (levelLeakage=="Usually Effective Pass") || (levelLeakage=="Fairly Effective Pass"))
            {
                p = P_f_l(a) - 0.2 * P_f_l(a) * (a / n_mod_l()) + 0.2 * P_fcond_l(a) * (a / n_mod_l());
            }
            else
            {
                if ((levelLeakage=="Highly Effective Fail") || (levelLeakage=="Usually Effective Fail"))
                    p = P_fcond_l(a);
                else
                    p = 0.5 * P_f_l(a) + 0.5 * P_fcond_l(a);
            }
            return p;
        }
        public double n_upd_l(int a)
        {
            return (a / (Math.Pow(-Math.Log(1 - P_l_wgt(a)), 1 / 1.8)));
        }
        public double P_prd_l(int a)
        {
            return (1 - Math.Exp(-Math.Pow(a / n_upd_l(a), 1.8)));
        }
        #endregion
        ///<summary>
        /// tinh toan pof cho truong hop Heat Exchange Tube Bundle
        ///</summary>
        #region HEAT EXCHANGE TUBE BUNDLE
        public double P_f_tube(int a)
        {
            return (1 - Math.Exp(-Math.Pow(a / 20.45, 2.568)));
        }
        #endregion

        ///<summary>
        /// tinh toan inspection interval( years)
        ///</summary>
        
        public double P_thin { set; get; }// P(t) target thinning
        public double P_scc { set; get; }// P(t) target cracking
        public double P_ext { set; get; }// P(t) target ext
        public double P_brit { set; get; }// P(t) target mbrit
        public double P_open_pressure { set; get; }// P(t) target open failure pressure relief device
        public double P_leakage_pressure { set; get; } //P(t) target leakage pressure relief device
        public double P_tube_Tube { set; get; }// P(t) target tube 
        public double Risk_target { set; get; }// risk target( $/year)
        public double CoF { set; get; }// $/failures
        public double PoF_thin(int a)
        {
            return D_ft_thin(a) * double.Parse(rbi.getGff(componentType)) * Fms;
        }
        public double PoF_scc(int a)
        {
            return D_ft_scc(a) * double.Parse(rbi.getGff(componentType)) * Fms;
        }
        public double PoF_ext(int a)
        {
            return D_ft_extd(a) * double.Parse(rbi.getGff(componentType)) * Fms;
        }
        public int inspection_thin()
        {
            int a = age, i = 0;
            double thamChieu = D_ft_thin(age);
            double Dthamchieu = P_thin / (double.Parse(rbi.getGff(componentType)) * Fms);
            if (thamChieu == 0)
                return 0;
            else
            {
                while (thamChieu < Dthamchieu)
                {
                    if (thamChieu == D_ft_thin(100))
                        break;
                    else
                    {
                        i++;
                        a += 1;
                        thamChieu = D_ft_thin(a);
                    }
                }
                return i;
            }
                
        }
        public int inspection_scc(int ag)
        {
            int a = ag, i = 0;
            double thamchieu = D_ft_scc(ag);
            double Dthamchieu = P_scc / (double.Parse(rbi.getGff(componentType)) * Fms);
            if (thamchieu == 0)
                return 0;
            else
            {
                while (thamchieu < Dthamchieu)
                {
                    i++;
                    a += 1;
                    thamchieu = D_ft_scc(a);
                }
                return i;
            }
            
        }
        public int inspection_ext()
        {
            int a = age, i = 0;
            double thamchieu = D_ft_extd(age);
            double Dthamchieu = P_ext / (double.Parse(rbi.getGff(componentType)) * Fms);
            if (thamchieu == 0)
                return 0;
            else
            {
                while (thamchieu < Dthamchieu)
                {
                    if (thamchieu == D_ft_extd(100))
                        break;
                    else
                    {
                        i++;
                        a += 1;
                        thamchieu = D_ft_extd(a);
                    }

                }
                return i;
            }    
        }
        public int inspection_pressure()
        {
            int a = age, b = age, i = 0, j = 0;
            double P_open_thamchieu = P_prd_f(age);
            double P_leak_thamchieu = P_prd_l(age);
            if (P_open_thamchieu == 0)
                i = 0;
            else
            {
                while (P_open_thamchieu < P_open_pressure)
                {
                    if (P_open_thamchieu == P_prd_f(100))
                        break;
                    else
                    {
                        i++;
                        a += 1;
                        P_open_thamchieu = P_prd_f(a);
                    }
                }
            }
            if (P_leak_thamchieu == 0)
                j = 0;
            else
            {
                while (P_leak_thamchieu < P_leakage_pressure)
                {
                    if (P_leak_thamchieu == P_prd_l(200))
                        break;
                    else
                    {
                        j++;
                        b += 1;
                        P_leak_thamchieu = P_prd_l(b);
                    }
                }
            }
            if (i == 0 || j == 0)
                return Math.Max(i, j);
            else
                return Math.Min(i, j);
        }
        public int inspection_tube()
        {
            int a = age, i = 0;
            double P_tube_thamchieu = P_f_tube(age);
            if (P_tube_thamchieu == 0)
                return 0;
            else
            {
                while (P_tube_thamchieu < P_tube_Tube)
                {
                    if (P_tube_thamchieu == P_f_tube(100))
                        break;
                    else
                    {
                        i++;
                        a += 1;
                        P_tube_thamchieu = P_f_tube(a);
                    }
                }
                return i;
            }
            
        }
        public double inspection_target()
        {
            double PoF_target = Risk_target / CoF;
            int a = age;
            double PoF = PoF_total(a);
            int i = 0;
            while (PoF < PoF_target)
            {
                a += 1;
                i++;
                PoF = PoF_total(a);
            }
            return i;
        }
     }
}
