﻿using RBI.BUS.BUSMSSQL;
using RBI.Object.ObjectMSSQL;
using RBI.Object.ObjectMSSQL_CAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBI.DAL.MSSQL_CAL;
namespace RBI.BUS.BUSMSSQL_CAL
{
    class MSSQL_CA_CAL
    {
        API_COMPONENT_TYPE_BUS API_COMPONENT_BUS = new API_COMPONENT_TYPE_BUS();
        MSSQL_RBI_CAL_ConnUtils DAL_CAL = new MSSQL_RBI_CAL_ConnUtils();
        public float MATERIAL_COST { set; get; }
        public String FLUID { set; get; }
        public String FLUID_PHASE { set; get; }
        public String API_COMPONENT_TYPE_NAME { set; get; }
        public String DETECTION_TYPE { set; get; }
        public String ISULATION_TYPE { set; get; }
        public float STORED_PRESSURE { set; get; }
        public float ATMOSPHERIC_PRESSURE { set; get; }//kPa
        public float STORED_TEMP { set; get; }//K
        public float ATMOSPHERIC_TEMP { set; get; }
        public float MASS_INVERT { set; get; }
        public float MASS_COMPONENT { set; get; }
        public String MITIGATION_SYSTEM { set; get; }// mitigation factor
        public float TOXIC_PERCENT { set; get; }// mfrac_toxic
        public String RELEASE_DURATION { set; get; }// duration time
        public float PRODUCTION_COST { set; get; }
        public float INJURE_COST { set; get; }
        public float ENVIRON_COST { set; get; }
        public float PERSON_DENSITY { set; get; }
        public float EQUIPMENT_COST { set; get; }
        private String TYPE_FLUID()
        {
            String API_TYPE = null;
            if (FLUID == null || FLUID == "")
                API_TYPE = "TYPE 0";
            else
            {
                switch (FLUID)
                {
                    case "C1-C2":
                    case "C13-C16":
                    case "C17-C25":
                    case "C25+":
                    case "C3-C4":
                    case "C5":
                    case "C6-C8":
                    case "C9-C12":
                    case "Acid":
                    case "AlCl3":
                    case "H2":
                    case "H2S":
                    case "HCl":
                    case "HF":
                    case "Nitric Acid":
                    case "NO2":
                    case "Phosgene":
                    case "Pyrophoric":
                    case "Steam":
                    case "TDI":
                    case "Water":
                        API_TYPE = "TYPE 0";
                        break;
                    case "CO":
                    case "DEE":
                    case "EE":
                    case "EEA":
                    case "EG":
                    case "EO":
                    case "Methanol":
                    case "PO":
                    case "Styrene":
                        API_TYPE = "TYPE 1";
                        break;
                    default:
                        API_TYPE = "TYPE 0";
                        break;
                }
            }
            return API_TYPE;
        }
        private API_COMPONENT_TYPE GET_DATA_API_COM()
        {
            return API_COMPONENT_BUS.getData(API_COMPONENT_TYPE_NAME);
        }

        private String GET_RELEASE_PHASE()
        {
            return DAL_CAL.GET_RELEASE_PHASE(FLUID);
        }
        // Step 2 release hole size
        private float d_n(int i)
        {
            float dn = 0;
            if(API_COMPONENT_TYPE_NAME == "TANKBOTTOM")
            {
                if (i == 1)
                {
                    if (PREVENTION_BARRIER)
                        dn = 3.175f;
                    else
                        dn = 12.7f;
                }
                else if (i == 2)
                    dn = 0;
                else if (i == 3)
                    dn = 0;
                else if (i == 4 && PREVENTION_BARRIER)
                    dn = 250 * TANK_DIAMETER;
                else
                    dn = 0;
            }
            else if(API_COMPONENT_TYPE_NAME == "COURSE-1" || API_COMPONENT_TYPE_NAME == "COURSE-10" || API_COMPONENT_TYPE_NAME == "COURSE-2" || API_COMPONENT_TYPE_NAME == "COURSE-3" ||
                    API_COMPONENT_TYPE_NAME == "COURSE-4" || API_COMPONENT_TYPE_NAME == "COURSE-5" || API_COMPONENT_TYPE_NAME == "COURSE-6" || API_COMPONENT_TYPE_NAME == "COURSE-7" ||
                    API_COMPONENT_TYPE_NAME == "COURSE-8" || API_COMPONENT_TYPE_NAME == "COURSE-9")
            {
                if (i == 1)
                    dn = 3.175f;
                else if (i == 2)
                    dn = 6.35f;
                else if (i == 3)
                    dn = 50.8f;
                else
                    dn = 250*TANK_DIAMETER;
            }
            else
            {
                if (i == 1)
                    dn = 6.4f;
                else if (i == 2)
                    dn = 25;
                else if (i == 3)
                    dn = 102;
                else
                    dn = (float)Math.Min(TANK_DIAMETER, 406);
            }
            return dn;
        }
        private float a_n(int i)
        {
            return (float)Math.Round(Math.PI * Math.Pow(d_n(i), 2) / 4,2);
        }
        private float C_P()
        {
            float[] data = DAL_CAL.GET_TBL_52(FLUID);
            float CP_C2 = (float)Math.Round((data[6] / STORED_TEMP) / (Math.Sinh(data[6] / STORED_TEMP)),2);
            float CP_E2 = (float)Math.Round((data[8] / STORED_TEMP) / (Math.Cosh(data[8] / STORED_TEMP)),2);
            if (data[3] == 1)
                return data[4] + data[5] * STORED_TEMP + data[6] * (float)Math.Pow(STORED_TEMP, 2) + data[7] * (float)Math.Pow(STORED_TEMP, 3);
            else if (data[3] == 2)
                return data[4] + data[5] * CP_C2 * CP_C2 + data[6] * CP_E2 * CP_E2;
            else if (data[3] == 3)
                return data[4] + data[5] * STORED_TEMP + data[6] * (float)Math.Pow(STORED_TEMP, 2) + data[7] * (float)Math.Pow(STORED_TEMP, 3) + data[8] * (float)Math.Pow(STORED_TEMP, 4);
            else
                return 0;
        }
        private float W_n(int i)
        {
            float[] data = DAL_CAL.GET_TBL_52(FLUID);
            float W_n = 0;
            float an = a_n(i);
            float k = 0;
            float m_w = data[0];
            float p_trans = 0;
            float gc = 1;
            if(FLUID_PHASE == "Liquid" || FLUID_PHASE == "Two-phase")
            {
                W_n = (float)Math.Round(0.61 * 1 * data[1]*16.02 * an * Math.Sqrt(2 * gc * Math.Abs(STORED_PRESSURE - ATMOSPHERIC_PRESSURE) / (data[1])*16.02) / (DAL_CAL.GET_TBL_3B21(1)),2);
            }
            else
            {
                float R = 8.314f;
                k = (C_P() / (C_P() - R));
                p_trans = (float)Math.Round(ATMOSPHERIC_PRESSURE * Math.Pow((k + 1) / 2, k / (k - 1)),2);
                if(STORED_PRESSURE > p_trans)
                {
                    float x = (float)((k * m_w * gc / (R * STORED_TEMP)) * Math.Pow(2 / (k + 1), (k + 1) / (k - 1)));
                    W_n = (float)Math.Round(0.9 * an * STORED_PRESSURE * Math.Sqrt(Math.Abs(x)) / (DAL_CAL.GET_TBL_3B21(2)),2);
                }
                else
                {
                    float x = (float)Math.Round((m_w * gc / (R * STORED_TEMP)) * ((2 * k) / (k - 1)) * Math.Pow(ATMOSPHERIC_PRESSURE / STORED_PRESSURE, 2 / k) * (1 - Math.Pow(ATMOSPHERIC_PRESSURE / STORED_PRESSURE, (k - 1) / k)),2);
                    W_n = (float)Math.Round(0.9 * an * STORED_PRESSURE * Math.Sqrt(Math.Abs(x)) / (DAL_CAL.GET_TBL_3B21(2)),2);
                }
            }
            return W_n;
        }
        private float W_max8()
        {
            float[] data = DAL_CAL.GET_TBL_52(FLUID);
            float W_max8 = 0;
            float an = 32450;
            float k = 0;
            float mw = data[0];
            float p_trans = 0;
            float gc = 1;
            if (FLUID_PHASE == "Liquid" || FLUID_PHASE == "Two-phase")
            {
                W_max8 = (float)Math.Round(0.61 * 1 * data[1] * 16.02 * an * Math.Sqrt(2 * gc * Math.Abs(STORED_PRESSURE - ATMOSPHERIC_PRESSURE) / (data[1] * 16.02)) / (DAL_CAL.GET_TBL_3B21(1)),2);
            }
            else
            {
                float R = 8.314f;
                k = (C_P() / (C_P() - R));
                p_trans = (float)(ATMOSPHERIC_PRESSURE * Math.Pow((k + 1) / 2, k / (k - 1)));
                if (STORED_PRESSURE > p_trans)
                {
                    float x = (float)((k * mw * gc / (R * STORED_TEMP)) * Math.Pow(2 / (k + 1), (k + 1) / (k - 1)));
                    W_max8 = (float)Math.Round(0.9 * an * STORED_PRESSURE * Math.Sqrt(Math.Abs(x)) / (DAL_CAL.GET_TBL_3B21(2)), 2);
                }
                else
                {
                    float x = (float)Math.Round((mw * gc / (R * STORED_TEMP)) * ((2 * k) / (k - 1)) * Math.Pow(ATMOSPHERIC_PRESSURE / STORED_PRESSURE, 2 / k) * (1 - Math.Pow(ATMOSPHERIC_PRESSURE / STORED_PRESSURE, (k - 1) / k)), 2);
                    W_max8 = (float)Math.Round(0.9 * an * STORED_PRESSURE * Math.Sqrt(Math.Abs(x)) / (DAL_CAL.GET_TBL_3B21(2)), 2);
                }
            }
            return W_max8;
        }
        private float mass_addn(int n)
        {
            float mass_addn = 0;
            float Wmax8 = W_max8();
            float Wn = W_n(n);
            mass_addn = 180 * Math.Min(Wmax8, Wn);
            return mass_addn;
        }
        public float mass_availn(int n)
        {
            float mass_availn = 0;
            float massaddn = mass_addn(n);
            mass_availn = Math.Min(MASS_COMPONENT + massaddn, MASS_INVERT);
            return mass_availn;
        }
        public float t_n(int n)
        {
            float t_n = 0;
            float Wn = W_n(n);
            t_n = (DAL_CAL.GET_TBL_3B21(3)) / Wn;
            return t_n;
        }
        public String releaseType(int n)
        {
            double tn = t_n(n);
            double dn = d_n(n);
            double massavailn = mass_availn(n);
            if (dn <= 6.35)
                return "Continuous";
            else if ((tn <= 180) || (massavailn > 4536))
                return "Instantaneous";
            else
                return "Continuous";
        }
        public float fact_di()
        {
            float fact_di = 0;
            if (DETECTION_TYPE == "A" && ISULATION_TYPE == "A")
            {
                fact_di = 0.25f;
            }
            else if (DETECTION_TYPE == "A" && ISULATION_TYPE == "B")
            {
                fact_di = 0.2f;
            }
            else if ((DETECTION_TYPE == "A" || DETECTION_TYPE == "B") && ISULATION_TYPE == "C")
            {
                fact_di = 0.1f;
            }
            else if (DETECTION_TYPE == "B" && ISULATION_TYPE == "B")
            {
                fact_di = 0.15f;
            }
            else fact_di = 0;
            return fact_di;
        }
        public float ld_n_max(int n)
        {
            float ld_max = 0;
            float dn = d_n(n);
            if (DETECTION_TYPE == "A" && ISULATION_TYPE == "A")
            {
                if (dn == 6.4f)
                    ld_max = 20;
                else if (dn == 25)
                    ld_max = 10;
                else if (dn == 102)
                    ld_max = 5;
                else
                    ld_max = 0;
            }
            else if (DETECTION_TYPE == "A" && ISULATION_TYPE == "B")
            {
                if (dn == 6.4f)
                    ld_max = 30;
                else if (dn == 25)
                    ld_max = 20;
                else if (dn == 102)
                    ld_max = 10;
                else
                    ld_max = 0;
            }
            else if (DETECTION_TYPE == "A" && ISULATION_TYPE == "C")
            {
                if (dn == 6.4f)
                    ld_max = 40;
                else if (dn == 25)
                    ld_max = 30;
                else if (dn == 102)
                    ld_max = 20;
                else
                    ld_max = 0;
            }
            else if ((ISULATION_TYPE == "A" || ISULATION_TYPE == "B") && DETECTION_TYPE == "B")
            {
                if (dn == 6.4f)
                    ld_max = 40;
                else if (dn == 25)
                    ld_max = 30;
                else if (dn == 102)
                    ld_max = 20;
                else
                    ld_max = 0;
            }
            else if (DETECTION_TYPE == "B" && ISULATION_TYPE == "C")
            {
                if (dn == 6.4f)
                    ld_max = 60;
                else if (dn == 25)
                    ld_max = 30;
                else if (dn == 102)
                    ld_max = 20;
                else
                    ld_max = 0;
            }
            else if (DETECTION_TYPE == "C" && (ISULATION_TYPE == "A" || ISULATION_TYPE == "B" || ISULATION_TYPE == "C"))
            {
                if (dn == 6.4f)
                    ld_max = 60;
                else if (dn == 25)
                    ld_max = 40;
                else if (dn == 102)
                    ld_max = 20;
                else
                    ld_max = 0;
            }
            else
                ld_max = 0;
            return ld_max;
        }
        public float rate_n(int n)
        {
            float rate_n = 0;
            float Wn = W_n(n);
            float factdi = fact_di();
            rate_n = Wn * (1 - factdi);
            return rate_n;
        }
        public float ld_n(int n)
        {
            float ldmax = ld_n_max(n);
            if (ldmax != 0)
                return (float)Math.Min(mass_availn(n) / rate_n(n), 60 * ldmax);
            else
                return (float)(mass_availn(n) / rate_n(n));
        }
        public float mass_n(int n)
        {
            return Math.Min(rate_n(n) * ld_n(n), mass_availn(n));
        }
        public float fact_mit()
        {
            float fact_mit = 0;
            if (MITIGATION_SYSTEM == "A")
                fact_mit = 0.25f;
            else if (MITIGATION_SYSTEM == "B")
                fact_mit = 0.2f;
            else if (MITIGATION_SYSTEM == "C")
                fact_mit = 0.05f;
            else
                fact_mit = 0.15f;
            return fact_mit;
        }
        public float eneff_n(int n)
        {
            return (float)(4 * Math.Log10(DAL_CAL.GET_TBL_3B21(4) * mass_n(n)) - 15);
        }
        public float a_cont(int select)
        {
            float[] data = DAL_CAL.GET_TBL_58(FLUID);
            float[] a_cont = { 0, 0, 0, 0 };
            if (FLUID_PHASE == "Gas" || FLUID_PHASE == "Vapor")
            {
                a_cont[0] = data[0];
                a_cont[1] = data[4];
                a_cont[2] = data[8];
                a_cont[3] = data[12];
            }
            else
            {
                a_cont[0] = data[2];
                a_cont[1] = data[6];
                a_cont[2] = data[10];
                a_cont[3] = data[14];
            }
            if (a_cont[select-1] == 0)
                return 1;
            else
                return a_cont[select-1];
        }
        public float b_cont(int select)
        {
            float[] data = DAL_CAL.GET_TBL_58(FLUID);
            float[] b_cont = { 0, 0, 0, 0 };
            if (FLUID_PHASE == "Gas" || FLUID_PHASE == "Vapor" )
            {
                b_cont[0] = data[1];
                b_cont[1] = data[5];
                b_cont[2] = data[9];
                b_cont[3] = data[13];
            }
            else
            {
                b_cont[0] = data[3];
                b_cont[1] = data[7];
                b_cont[2] = data[11];
                b_cont[3] = data[15];
            }
            return b_cont[select-1];
        }
        private float a_inj(int select)
        {
            float[] data = DAL_CAL.GET_TBL_59(FLUID);
            float[] a_inj = { 0, 0, 0, 0 };
            if (FLUID_PHASE == "Gas" || FLUID_PHASE == "Vapor")
            {
                a_inj[0] = data[0];
                a_inj[1] = data[4];
                a_inj[2] = data[8];
                a_inj[3] = data[12];
            }
            else
            {
                a_inj[0] = data[2];
                a_inj[1] = data[6];
                a_inj[2] = data[10];
                a_inj[3] = data[14];
            }
            return a_inj[select-1];
        }
        private float b_inj(int select)
        {
            float[] data = DAL_CAL.GET_TBL_59(FLUID);
            float[] b_inj = { 0, 0, 0, 0 };//{ data[1], data[3], data[5], data[7], data[9], data[11], data[13], data[15] };
            if (FLUID_PHASE == "Gas" || FLUID_PHASE == "Vapor")
            {
                b_inj[0] = data[1];
                b_inj[1] = data[5];
                b_inj[2] = data[9];
                b_inj[3] = data[13];
            }
            else
            {
                b_inj[0] = data[3];
                b_inj[1] = data[7];
                b_inj[2] = data[11];
                b_inj[3] = data[15];
            }
            return b_inj[select-1];
        }
        private float ca_cmdn_cont(int select, int n)
        {
            float ca_cmdn_cont = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            if ((GET_RELEASE_PHASE() == "Liquid") && (API_FLUID_TYPE == "TYPE 0"))
                ca_cmdn_cont = (float)Math.Round(Math.Min(a_cont(select) * Math.Pow(rate_n(n), b_cont(select)), DAL_CAL.GET_TBL_3B21(7)) * (1 - fact_mit()),2);
            else
                ca_cmdn_cont = (float)Math.Round(a_cont(select) * Math.Pow(rate_n(n), b_cont(select)) * (1 - fact_mit()),2);
            return ca_cmdn_cont;
        }
        private float effrate_n(int select, int n)
        {
            float effrate_n = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            if ((GET_RELEASE_PHASE() == "Liquid") && (API_FLUID_TYPE == "TYPE 0"))
                effrate_n = (float)Math.Round((1 / (DAL_CAL.GET_TBL_3B21(4)) * Math.Exp(Math.Log10(ca_cmdn_cont(select, n) / (a_cont(select) * (DAL_CAL.GET_TBL_3B21(8)))) * Math.Pow(b_cont(select), -1))),2);
            else
                effrate_n = rate_n(n);
            return effrate_n;
        }
        private float ca_cmdn_inst(int select, int n)
        {
            float ca_cmdn_inst = 0;
            String API_FLUID_TYPE = TYPE_FLUID();
            if ((GET_RELEASE_PHASE() == "Liquid") && (API_FLUID_TYPE == "TYPE 0"))
                ca_cmdn_inst = (float)Math.Round(Math.Min(a_cont(select) * Math.Pow(mass_n(n), b_cont(select)), (DAL_CAL.GET_TBL_3B21(7))) * ((1 - fact_mit()) / eneff_n(n)),2);
            else
                ca_cmdn_inst = (float)Math.Round(a_cont(select) * Math.Pow(mass_n(n), b_cont(select)) * (1 - fact_mit()),2);
            return ca_cmdn_inst;
        }
        public float ca_injn_cont(int select, int n)
        {
            float ca_injn_cont = 0;
            ca_injn_cont = (float)Math.Round(a_inj(select) * Math.Pow(effrate_n(select, n), b_inj(select)) * (1 - fact_mit()),2);
            return ca_injn_cont;
        }
        public float ca_injn_inst(int select, int n)
        {
            float ca_injn_inst = 0;
            ca_injn_inst = (float)Math.Round(a_inj(select) * Math.Pow(effrate_n(select, n), b_inj(select)) * ((1 - fact_mit()) / eneff_n(n)),2);
            return ca_injn_inst;
        }
        public double fact_n_ic(int n)
        {
            String releasetype = releaseType(n);
            if (releasetype == "Continuous")
                return Math.Min(rate_n(n) / (DAL_CAL.GET_TBL_3B21(5)), 1.0);
            else
                return 1.0;
        }
        public float fact_ait()
        {
            float[] data = DAL_CAL.GET_TBL_52(FLUID);
            float fact_ait = 0;
            float ait = (float)Math.Round((data[9]-32)/1.8,2);
            if ((STORED_TEMP + (DAL_CAL.GET_TBL_3B21(6))) <= ait)
                fact_ait = 0;
            else if ((STORED_TEMP - (DAL_CAL.GET_TBL_3B21(6))) >= ait)
                fact_ait = 1;
            else
                fact_ait = (STORED_TEMP - ait + (DAL_CAL.GET_TBL_3B21(6))) / (2 * (DAL_CAL.GET_TBL_3B21(6)));
            return fact_ait;
        }
        public float ca_cmdn_flame(int n)
        {
            float ca_cmdn_flame = 0;
            float caailcmdn = (float)(ca_cmdn_cont(2, n) * fact_n_ic(n) + ca_cmdn_inst(4, n) * (1 - fact_n_ic(n)));
            float caainlcmdn = (float)(ca_cmdn_cont(1, n) * fact_n_ic(n) + ca_cmdn_inst(3, n) * (1 - fact_n_ic(n)));
            ca_cmdn_flame = caailcmdn * fact_ait() + caainlcmdn * (1 - fact_ait());
            return ca_cmdn_flame;
        }
        public float ca_injn_flame(int n)
        {
            float caailinjn = (float)(Math.Abs(ca_injn_cont(2, n)) * fact_n_ic(n) + Math.Abs(ca_injn_inst(4, n)) * (1 - fact_n_ic(n)));
            float caainlinjn = (float)(Math.Abs(ca_injn_cont(1, n)) * fact_n_ic(n) + Math.Abs(ca_injn_inst(3, n)) * (1 - fact_n_ic(n)));
            return caailinjn * fact_ait() + caainlinjn * (1 - fact_ait());
        }
        public float ca_cmd_flame()
        {
            float t = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            t = obj.GFFSmall * ca_cmdn_flame(1) + obj.GFFMedium * ca_cmdn_flame(2) + obj.GFFLarge * ca_cmdn_flame(3) + obj.GFFRupture * ca_cmdn_flame(4);
            float ca_cmd_flame = t / obj.GFFTotal;
            return Math.Abs(ca_cmd_flame);
        }
        public float ca_inj_flame()
        {
            float t = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            t = obj.GFFSmall * ca_injn_flame(1) + obj.GFFMedium * ca_injn_flame(2) + obj.GFFLarge * ca_injn_flame(3) + obj.GFFRupture * ca_injn_flame(4);
            float ca_inj = t / obj.GFFTotal;
            return Math.Abs(ca_inj);
        }
        // TOXIC CONSEQUENCE
        public float rate_tox_n(int n)
        {
            return TOXIC_PERCENT * W_n(n);
        }
        public float mass_tox_n(int n)
        {
            return TOXIC_PERCENT * mass_n(n);
        }
        //public TOXIC_511_512 getToxic()
        //{
        //    TOXIC_511_512 obj = new TOXIC_511_512();
        //    List<TOXIC_511_512> list = DAL_CAL.GET_TBL_511_512();
        //    for(int i=0; i< list.Count; i++)
        //    {
        //        if (list[i].ToxicName == FLUID && list[i].ReleaseDuration == RELEASE_DURATION)
        //            obj = list[i];
        //    }
        //    return obj;
        //}
        //public TOXIC_513 getToxic513()
        //{
        //    TOXIC_513 obj = new TOXIC_513();
        //    List<TOXIC_513> list = DAL_CAL.GET_TBL_513();
        //    for(int i = 0; i< list.Count; i++)
        //    {
        //        if (list[i].TOXIC_NAME == FLUID && list[i].TOXIC_TYPE == FLUID_PHASE && list[i].DURATION == RELEASE_DURATION)
        //            obj = list[i];
        //    }
        //    return obj;
        //}
        //public float ca_injn_tox(int n)
        //{
            //TOXIC_511_512 obj = getToxic();
            //TOXIC_513 obj1 = getToxic513();
            //float C8 = DAL_CAL.GET_TBL_3B21(8);
            //float C4 = DAL_CAL.GET_TBL_3B21(4);
            //String releasetype = releaseType(n);

            //if (obj.ToxicName == "HF" || obj.ToxicName == "H2S")
            //{
            //    //c = cd[0], d = cd[1]
            //    double log = 0;
            //    if (releasetype == "Continuous")
            //        log = obj.a * Math.Log10(C4 * rate_tox_n(n)) + obj.b;
            //    else
            //        log = obj.a * Math.Log10(C4 * mass_tox_n(n)) + obj.b;
            //    return (float)Math.Round(C8 * Math.Pow(10, log), 4);
            //}
            //else if (obj.ToxicName == "Ammonia" || obj.ToxicName == "Chlorine")
            //{
            //    if (releasetype == "Continuous")
            //        return (float)Math.Round(obj.a * Math.Pow(rate_tox_n(n), obj.b), 4);
            //    else
            //        return (float)Math.Round(obj.a * Math.Pow(mass_tox_n(n), obj.b), 4);
            //}
            //else if (obj1.TOXIC_NAME == "Aluminum Chloride" || obj1.TOXIC_NAME == "CO" || obj1.TOXIC_NAME == "HCL" || obj1.TOXIC_NAME == "Nitric Acid" || obj1.TOXIC_NAME == "NO2"
            //        || obj1.TOXIC_NAME == "Phosgene" || obj1.TOXIC_NAME == "TDI" || obj1.TOXIC_NAME == "EE" || obj1.TOXIC_NAME == "EO" || obj1.TOXIC_NAME == "PO")
            //{
            //    if (releasetype == "Continuous")
            //        return (float)Math.Round(obj.a * Math.Pow(rate_tox_n(n), obj.b), 4);
            //    else
            //        return (float)Math.Round(obj.a * Math.Pow(mass_tox_n(n), obj.b), 4);
            //}
            //else
            //    return 0;
        //}
        //public float ca_inj_tox()
        //{
        //    API_COMPONENT_TYPE obj = GET_DATA_API_COM();
        //    float t = 0;
        //    t = obj.GFFSmall * ca_injn_tox(1) + obj.GFFMedium * ca_injn_tox(2) + obj.GFFLarge * ca_injn_tox(3) + obj.GFFRupture * ca_injn_tox(4);
        //    float ca_inj_tox = t / obj.GFFTotal;
        //    return Math.Abs(ca_inj_tox);
        //}
        // Step 10 non flammable non toxic consequence
        public float ca_injn_contnfnt(int n)
        {
            float ca_injn_cont = 0;
            float g = (float)Math.Round(2696 - 21.9 * (DAL_CAL.GET_TBL_3B21(11)) * (STORED_PRESSURE - ATMOSPHERIC_PRESSURE) + 1.474 * Math.Pow(((DAL_CAL.GET_TBL_3B21(11)) * (STORED_PRESSURE - ATMOSPHERIC_PRESSURE)), 2),4);
            float h = (float)Math.Round(0.31 - 0.00032 * Math.Pow(((DAL_CAL.GET_TBL_3B21(11)) * (STORED_PRESSURE - ATMOSPHERIC_PRESSURE) - 40), 2),4);
            if (FLUID == "Steam")
                ca_injn_cont = (float)Math.Round((DAL_CAL.GET_TBL_3B21(9)) * rate_n(n),4);
            else
                ca_injn_cont = (float)Math.Round(0.2 * (DAL_CAL.GET_TBL_3B21(8)) * g * Math.Pow((DAL_CAL.GET_TBL_3B21(4)) * rate_n(n), h),2);
            return ca_injn_cont;
        }
        public float ca_injn_instnfnt(int n)
        {
            float ca_injn_inst = 0;
            if (FLUID == "Steam")
                ca_injn_inst = (float)Math.Round((DAL_CAL.GET_TBL_3B21(10)) * Math.Pow(mass_n(n), 0.6384),4);
            else
                ca_injn_inst = 0;
            return ca_injn_inst;
        }
        public float fact_n_icnfnt(int n)
        {
            float fact_n_icnfnt = 0;
            if (FLUID == "Steam")
                fact_n_icnfnt = Math.Min(rate_n(n) / (DAL_CAL.GET_TBL_3B21(5)), 1);
            else
                fact_n_icnfnt = 0;
            return fact_n_icnfnt;
        }
        public float ca_injn_leaknfnt(int n)
        {
            return ca_injn_instnfnt(n) * fact_n_icnfnt(n) + ca_injn_contnfnt(n) * (1 - fact_n_icnfnt(n));
        }
        public float ca_inj_nfnt()
        {
            float t = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            t = obj.GFFSmall * ca_injn_leaknfnt(1) + obj.GFFMedium * ca_injn_leaknfnt(2) + obj.GFFLarge * ca_injn_leaknfnt(3) + obj.GFFRupture * ca_injn_leaknfnt(4);
            float ca_inj_nfnt = t / obj.GFFTotal;
            return Math.Abs(ca_inj_nfnt);
        }
        // Step 11 Component and Injure consequence
        public float ca_cmd()
        {
            return ca_cmd_flame();
        }
        //public float ca_inj()
        //{
        //    float cainjflame = ca_inj_flame();
        //    float cainjtox = ca_inj_tox();
        //    float cainjnfnt = ca_inj_nfnt();
        //    return Math.Max(Math.Max(cainjflame, cainjtox), cainjnfnt);
        //}
        // Step 12: financial
        public float fc_cmd()
        {
            float fc_cmd = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            float t = 0;
            t = obj.GFFSmall * obj.HoleCostSmall + obj.GFFMedium * obj.HoleCostMedium + obj.GFFLarge * obj.HoleCostLarge + obj.GFFRupture * obj.GFFTotal;
            fc_cmd = t * MATERIAL_COST / obj.GFFTotal;
            return fc_cmd;
        }
        public float fc_affa()
        {
            float fc_affa = 0;
            float cacmd = ca_cmd();
            fc_affa = cacmd * EQUIPMENT_COST;
            return fc_affa;
        }
        public float outage_cmd()
        {
            float outage_cmd = 0;
            float t = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            t = obj.GFFSmall * obj.OutageSmall + obj.GFFMedium * obj.OutageMedium + obj.GFFLarge * obj.OutageLarge + obj.GFFRupture * obj.GFFRupture;
            outage_cmd = t / obj.GFFTotal;
            return outage_cmd;
        }
        public float outage_affa()
        {
            float outage_affa = 0;
            float fcaffa = Math.Abs(fc_affa());
            float b = (float)(1.242 + 0.585 * Math.Log10(fcaffa * Math.Pow(10, -6)));
            outage_affa = (float)Math.Pow(10, b);
            return outage_affa;
        }
        public float fc_prod()
        {
            float fc_prod = (outage_cmd() + outage_affa()) * PRODUCTION_COST;
            return fc_prod;
        }
        //public float fc_inj()
        //{
        //    float fc_inj = ca_inj() * PERSON_DENSITY * INJURE_COST;
        //    return fc_inj;
        //}
        public float vol_n_env(int n)
        {
            float vol_n_env = 0;
            float massn = mass_n(n);
            float frac_evap = 1;
            switch (FLUID)
            {
                case "C6-C8":
                case "Acid":
                    frac_evap = 0.9f;
                    break;
                case "C9-C12":
                    frac_evap = 0.5f;
                    break;
                case "C13-C16":
                    frac_evap = 0.1f;
                    break;
                case "C17-C25":
                    frac_evap = 0.05f;
                    break;
                case "C25+":
                    frac_evap = 0.02f;
                    break;
                case "Nitric Acid":
                    frac_evap = 0.8f;
                    break;
                case "NO2":
                case "EE":
                    frac_evap = 0.75f;
                    break;
                case "TDI":
                    frac_evap = 0.15f;
                    break;
                case "Styrene":
                    frac_evap = 0.6f;
                    break;
                case "EEA":
                    frac_evap = 0.65f;
                    break;
                case "EG":
                    frac_evap = 0.45f;
                    break;
                default:
                    frac_evap = 1;
                    break;
            }
            float[] data = DAL_CAL.GET_TBL_52(FLUID);
            vol_n_env = (float)((DAL_CAL.GET_TBL_3B21(13)) * massn * (1 - frac_evap) / (data[1]* 16.02));
            return vol_n_env;
        }
        public float fc_environ()
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            float fc_environ = 0;
            float t = 0;
            t = obj.GFFSmall * vol_n_env(1) + obj.GFFMedium * vol_n_env(2) + obj.GFFLarge * vol_n_env(3) + obj.GFFRupture * vol_n_env(4);
            fc_environ = t * ENVIRON_COST / obj.GFFTotal;
            return fc_environ;
        }
        //public float fc()
        //{
        //    float fc = 0;
        //    float fccmd = fc_cmd();
        //    float fcaffa = fc_affa();
        //    float fcprod = fc_prod();
        //    float fcinj = fc_inj();
        //    float fcenviron = fc_environ();
        //    fc = fccmd + fcaffa + fcprod + fcinj + fcenviron;
        //    return fc;
        //} 

        // Storage tank
        /*
         * Tank Shell Course
         * */
        public float FLUID_HEIGHT { set; get; }
        public float Cd = 0.61f;
        public float SHELL_COURSE_HEIGHT { set; get; }
        public float TANK_DIAMETER { set; get; }
        public float BBL_RUPTURE_N;
        public Boolean PREVENTION_BARRIER { set; get; }//Release Prevention Barrier
        public String EnvironSensitivity { set; get; }
        public float P_lvdike { set; get; }
        public float P_onsite { set; get; }
        public float P_offsite { set; get; }

        private float W_n_Tank(int n)
        {
            return (float)(DAL_CAL.GET_TBL_3B21(32) * Cd * a_n(n) * Math.Sqrt(2 * FLUID_HEIGHT));
        }
        private float Bbl_avail(int n)
        {
            int i = (int)(FLUID_HEIGHT / SHELL_COURSE_HEIGHT);
            //if (n <= i)
            //{
            //    return (float)(Math.PI * Math.Pow(TANK_DIAMETER, 2)) * (FLUID_HEIGHT - (n - 1) * SHELL_COURSE_HEIGHT) / (4 * (DAL_CAL.GET_TBL_3B21(13)));
            //}
            //else
            //{
            //    return 0;
            //}
            return (float)(Math.PI * Math.Pow(TANK_DIAMETER, 2)) * (FLUID_HEIGHT - (n - 1) * SHELL_COURSE_HEIGHT) / (4 * (DAL_CAL.GET_TBL_3B21(13)));
        }
        private float ld_tank(int n)
        {
            if (d_n(n) <= 3.17)
            {
                return Math.Min(Bbl_avail(n) / W_n_Tank(n), 7);
            }
            else
            {
                return 1;
            }
        }
        public float Bbl_leak_n(int n)
        {
            if (d_n(n) <= 50.8)
            {
                return Math.Min(W_n(n) * ld_tank(n), Bbl_avail(n));
            }
            else
                return Bbl_avail(n);
        }
        public int[] getCost()
        {
            int[] costTANK = { 0, 0, 0, 0, 0, 0 };
            if(EnvironSensitivity == "High")
            {
                costTANK[0] = 10;
                costTANK[1] = 50;
                costTANK[2] = 500;
                costTANK[3] = 3000;
                costTANK[4] = 10000;
                costTANK[5] = 5000;
            }
            else if(EnvironSensitivity == "Medium")
            {
                costTANK[0] = 10;
                costTANK[1] = 50;
                costTANK[2] = 250;
                costTANK[3] = 1500;
                costTANK[4] = 5000;
                costTANK[5] = 1500;
            }
            else if(EnvironSensitivity == "Low")
            {
                costTANK[0] = 10;
                costTANK[1] = 50;
                costTANK[2] = 100;
                costTANK[3] = 500;
                costTANK[4] = 1000;
                costTANK[5] = 500;
            }
            else
            {
                costTANK[0] = 0;
                costTANK[1] = 0;
                costTANK[2] = 0;
                costTANK[3] = 0;
                costTANK[4] = 0;
                costTANK[5] = 0;
            }
            return costTANK;
        }
        public float Bbl_leak_release()
        {
            float sum = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            sum = Bbl_leak_n(1) * obj.GFFSmall + Bbl_leak_n(2) * obj.GFFMedium + Bbl_leak_n(3) * obj.GFFLarge;
            return sum / obj.GFFTotal;
        }
        public float Bbl_leak_indike()
        {
            return Bbl_leak_release() * (1 - P_lvdike / 100);
        }
        public float Bbl_leak_ssonsite()
        {
            return P_onsite * (Bbl_leak_release() - Bbl_leak_indike()) / 100;
        }
        public float Bbl_leak_ssoffsite()
        {
            return P_offsite * (Bbl_leak_release() - Bbl_leak_indike() - Bbl_leak_ssonsite()) / 100;
        }
        public float Bbl_leak_water()
        {
            return Bbl_leak_release() - (Bbl_leak_indike() + Bbl_leak_ssonsite() + Bbl_leak_ssoffsite());
        }
        //Step 5: Compute FC_leakage_environ
        public float FC_leak_environ()
        {
            int[] cost = getCost();
            return Bbl_leak_indike() * cost[0] + Bbl_leak_ssonsite() * cost[1] + Bbl_leak_ssoffsite() * cost[2] + Bbl_leak_water() * cost[5];
        }
        //Step 6: Determine Bbl_rupture_release
        public float Bbl_rupture_release()
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            return Bbl_leak_n(4) * obj.GFFRupture / obj.GFFTotal;
        }
        //Step 7: Compute 4 parameter Bbl_rupture_indike, Bbl_rupture_ssonsite, Bbl_rupture_ssoffsite, Bbl_rupture_water
        public float Bbl_rupture_indike()
        {
            return Bbl_rupture_release() * (1 - P_lvdike / 100);
        }
        public float Bbl_rupture_ssonsite()
        {
            return P_onsite * (Bbl_rupture_release() - Bbl_rupture_indike()) / 100;
        }
        public float Bbl_rupture_ssoffsite()
        {
            return P_offsite * (Bbl_rupture_release() - Bbl_rupture_indike() - Bbl_rupture_ssonsite()) / 100;
        }
        public float Bbl_rupture_water()
        {
            return Bbl_rupture_release() - (Bbl_rupture_indike() + Bbl_rupture_ssonsite() + Bbl_rupture_ssoffsite());
        }
        //Step 8: Compute FC_rupture_environ
        public float FC_rupture_environ()
        {
            int[] cost = getCost();
            return Bbl_rupture_indike() * cost[0] + Bbl_rupture_ssonsite() * cost[1] + Bbl_rupture_ssoffsite() * cost[2] + Bbl_rupture_water() * cost[5];
        }
        //Step 9: Compute FC_environ
        public float FC_environ_shell()
        {
            return FC_leak_environ() + FC_rupture_environ();
        }
        //Step 12: Compute total Financial
        public double FC_total_shell()
        {
            return fc_cmd() + FC_environ_shell() + fc_prod();
        }

        /*
         * TANK BOTTOM
         * */
        public String Soil_type { set; get; }
        public String TANK_FLUID { set; get; }
        public float Swg { set; get; } //total distance to the ground water underneath the tank
        private float uw = 0.001f; //tra bang tren internet tai 27C
        private float pw = 1000; // kg/m3

        //STEP 1: Determine Release Rate and Volum
        private int n_rh()
        {
            return (int)Math.Round(Math.Max(Math.Pow(TANK_DIAMETER / DAL_CAL.GET_TBL_3B21(36), 2), 1), 0);
        }
        private float[] k_h_bottom()
        {
            float[] k_h = { 0, 0, 0 };
            if (Soil_type == "Coarse Sand")
            {
                k_h[0] = 0.1f;
                k_h[1] = 0.01f;
                k_h[2] = 0.33f;
            }
            else if (Soil_type == "Fine Sand")
            {
                k_h[0] = 0.01f;
                k_h[1] = 0.001f;
                k_h[2] = 0.33f;
            }
            else if (Soil_type == "Very Fine Sand")
            {
                k_h[0] = (float)Math.Pow(10, -3);
                k_h[1] = (float)Math.Pow(10, -5);
                k_h[2] = 0.33f;
            }
            else if (Soil_type == "Silt")
            {
                k_h[0] = (float)Math.Pow(10, -5);
                k_h[1] = (float)Math.Pow(10, -6);
                k_h[2] = 0.41f;
            }
            else if (Soil_type == "Sandy Clay")
            {
                k_h[0] = (float)Math.Pow(10, -6);
                k_h[1] = (float)Math.Pow(10, -7);
                k_h[2] = 0.45f;
            }
            else if (Soil_type == "Clay")
            {
                k_h[0] = (float)Math.Pow(10, -7);
                k_h[1] = (float)Math.Pow(10, -8);
                k_h[2] = 0.5f;
            }
            else
            {
                k_h[0] = (float)Math.Pow(10, -10);
                k_h[1] = (float)Math.Pow(10, -11);
                k_h[2] = 0.99f;
            }
            return k_h;
        }
        public float k_h_water()
        {
            float[] k_h = k_h_bottom();
            return (DAL_CAL.GET_TBL_3B21(13)) * (k_h[0] + k_h[1]) / 2;
        }
        public float rate_n_tank_bottom()
        {
            if (k_h_water() > (DAL_CAL.GET_TBL_3B21(34)) * Math.Pow(d_n(1), 2))
                return (float)(DAL_CAL.GET_TBL_3B21(33) * Math.PI * d_n(1) * Math.Sqrt(2 * 1 * FLUID_HEIGHT) * n_rh());
            else
                return (float)(DAL_CAL.GET_TBL_3B21(35) * 0.21 * Math.Pow(d_n(1), 0.2) * Math.Pow(FLUID_HEIGHT, 0.9) * Math.Pow(k_h_water(), 0.74) * n_rh());
        }
        public float t_ld_tank_bottom()
        {
            if (Soil_type == "Concrete-Asphalt") return 7;
            else if (PREVENTION_BARRIER) return 30;
            else return 360;
        }
        public float ld_n_tank_bottom()
        {
            float Bbl_total_tank_bottom = (float)(Math.PI * Math.Pow(TANK_DIAMETER, 2) * FLUID_HEIGHT) / (4 * (DAL_CAL.GET_TBL_3B21(13)));
            return Math.Min(Bbl_total_tank_bottom / rate_n_tank_bottom(), t_ld_tank_bottom());
        }
        public float Bbl_leak_n_bottom()
        {
            float Bbl_total_tank_bottom = (float)(Math.PI * Math.Pow(TANK_DIAMETER, 2) * FLUID_HEIGHT) / (4 * (DAL_CAL.GET_TBL_3B21(13)));
            return Math.Min(rate_n_tank_bottom() * ld_n_tank_bottom(), Bbl_total_tank_bottom);
        }
        //STEP 2: Consequence Tank Bottom
        private float[] GET_PL_UL()
        {
            float[] data = { 0, 0 };
            if(TANK_FLUID == "Gasoline")
            {
                data[0] = 684.018f;
                data[1] = (float)(4.01 * Math.Pow(10, -3));
            }
            else if(TANK_FLUID == "Light Diesel Oil")
            {
                data[0] = 734.011f;
                data[1] = (float)(1.04 * Math.Pow(10, -3));
            }
            else if(TANK_FLUID == "Heavy Diesel Oil")
            {
                data[0] = 764.527f;
                data[1] = (float)(2.46 * Math.Pow(10, -3));
            }
            else if (TANK_FLUID == "Fuel Oil")
            {
                data[0] = 775.019f;
                data[1] = (float)(3.69 * Math.Pow(10, -2));
            }
            else if (TANK_FLUID == "Crude Oil")
            {
                data[0] = 775.019f;
                data[1] = (float)(3.69 * Math.Pow(10, -2));
            }
            else
            {
                data[0] = 900.026f;
                data[1] = (float)(4.6 * Math.Pow(10, -2));
            }
            return data;
        }
        public float k_h_prod()
        {
            float[] pl_ul = GET_PL_UL();
            return k_h_water() * (pl_ul[0] / pw) * (uw / pl_ul[1]);
        }
        public float vel_s_prod()
        {
            float[] kh = k_h_bottom();
            return k_h_prod() / kh[2];
        }
        public float t_gl_bottom()
        {
            return Swg / vel_s_prod();
        }
        public float Bbl_leak_groundwater()
        {
            if (t_gl_bottom() > t_ld_tank_bottom())
                return Bbl_leak_n_bottom() * ((t_ld_tank_bottom() - t_gl_bottom()) / t_ld_tank_bottom());
            else
                return 0;
        }
        public float Bbl_leak_subsoil()
        {
            return Bbl_leak_n_bottom() - Bbl_leak_groundwater();
        }
        public float FC_leak_environ_bottom()
        {
            float sum = 0;
            int[] cost = getCost();
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            sum = Bbl_leak_groundwater() * cost[4] + Bbl_leak_subsoil() * cost[3];
            return sum * obj.GFFSmall / obj.GFFTotal;
        }
        public float Bbl_rupture_release_bottom()
        {
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            float Bbl_total_tank_bottom = (float)(Math.PI * Math.Pow(TANK_DIAMETER, 2) * FLUID_HEIGHT) / (4 * (DAL_CAL.GET_TBL_3B21(13)));
            return (Bbl_total_tank_bottom * obj.GFFRupture) / obj.GFFTotal;
        }
        public float Bbl_rupture_indike_bottom()
        {
            return Bbl_rupture_release_bottom() * (1 - P_lvdike / 100);
        }
        public float Bbl_rupture_ssonsite_bottom()
        {
            return P_onsite * (Bbl_rupture_release_bottom() - Bbl_rupture_indike_bottom()) / 100;
        }
        public float Bbl_rupture_ssoffsite_bottom()
        {
            return P_offsite * (Bbl_rupture_release_bottom() - Bbl_rupture_indike_bottom() - Bbl_rupture_ssonsite_bottom()) / 100;
        }
        public float Bbl_rupture_water_bottom()
        {
            return Bbl_rupture_release_bottom() - (Bbl_rupture_indike_bottom() + Bbl_rupture_ssonsite_bottom() + Bbl_rupture_ssoffsite_bottom());
        }
        public float FC_rupture_environ_bottom()
        {
            int[] cost = getCost();
            return Bbl_rupture_indike_bottom() * cost[0] + Bbl_rupture_ssonsite_bottom() * cost[1] + Bbl_rupture_ssoffsite_bottom() * cost[2] + Bbl_rupture_water_bottom() * cost[5];
        }
        public float FC_environ_bottom()
        {
            return FC_leak_environ_bottom() + FC_rupture_environ_bottom();
        }
        public float FC_cmd_bottom()
        {
            float sum = 0;
            API_COMPONENT_TYPE obj = GET_DATA_API_COM();
            sum = (float)(obj.GFFSmall * obj.HoleCostSmall + obj.GFFMedium * obj.HoleCostMedium + obj.GFFLarge * obj.HoleCostLarge + obj.HoleCostRupture * Math.Pow(DAL_CAL.GET_TBL_3B21(36), 2));
            return sum * MATERIAL_COST / obj.GFFTotal;
        }
        public double FC_total_bottom()
        {
            return FC_environ_bottom() + FC_cmd_bottom() + fc_prod();
        }
    }
}