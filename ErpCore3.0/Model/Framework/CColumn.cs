// File:    CColumn.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 12:40:36
// Purpose: Definition of Class CColumn

using System;
using System.Text;
using System.Collections.Generic;

namespace ErpCoreModel.Framework
{


    public class CColumn : CBaseObject
    {
        private string m_sUploadPath = "";//�����������ֶε��ļ��ϴ�·��

        public CColumn()
        {
            TbCode = "FW_Column";
            ClassName = "ErpCoreModel.Framework.CColumn";

            FW_Table_id = Guid.Empty;
            Name = "";
            Code = "";
            IsSystem = false;
            ColType = ColumnType.string_type;
            ColLen = 0;
            ColDecimal = 0;
            RefTable = Guid.Empty;
            RefCol = Guid.Empty;
            RefShowCol = Guid.Empty;
            Formula = "";
            DefaultValue = "";
            AllowNull = true;
            UIControl = "";
            WebUIControl = "";
            Commit();
        }

        public string UploadPath
        {
            get
            {
                if (this.m_sUploadPath != "")
                    return this.m_sUploadPath;
                else
                    return Ctx.UploadPath;
            }
            set
            {
                this.m_sUploadPath = value;
            }
        }
        public Guid FW_Table_id
        {
            get
            {
                if (m_arrNewVal.ContainsKey("fw_table_id"))
                    return m_arrNewVal["fw_table_id"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("fw_table_id"))
                    m_arrNewVal["fw_table_id"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("fw_table_id", val);
                }
            }
        }
        public string Name
        {
            get
            {
                if (m_arrNewVal.ContainsKey("name"))
                    return m_arrNewVal["name"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("name"))
                    m_arrNewVal["name"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("name", val);
                }
            }
        }

        public string Code
        {
            get
            {
                if (m_arrNewVal.ContainsKey("code"))
                    return m_arrNewVal["code"].StrVal;
                else
                    return "";
            }
            set
            {              
                if (m_arrNewVal.ContainsKey("code"))
                    m_arrNewVal["code"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("code", val);
                }
            }
        }

        public bool IsSystem
        {
            get
            {
                if (m_arrNewVal.ContainsKey("issystem"))
                    return m_arrNewVal["issystem"].BoolVal;
                else
                    return false;
            }
            set
            {             
                if (m_arrNewVal.ContainsKey("issystem"))
                    m_arrNewVal["issystem"].BoolVal = value;
                else
                {
                    CValue val = new CValue();
                    val.BoolVal = value;
                    m_arrNewVal.Add("issystem", val);
                }
            }
        }

        public ColumnType ColType
        {
            get
            {
                if (m_arrNewVal.ContainsKey("coltype"))
                    return (ColumnType)m_arrNewVal["coltype"].IntVal;
                else
                    return ColumnType.string_type;
            }
            set
            {          
                if (m_arrNewVal.ContainsKey("coltype"))
                    m_arrNewVal["coltype"].IntVal = Convert.ToInt32(value);
                else
                {
                    CValue val = new CValue();
                    val.IntVal = Convert.ToInt32(value);
                    m_arrNewVal.Add("coltype", val);
                }
            }
        }

        public int ColLen
        {
            get
            {
                if (m_arrNewVal.ContainsKey("collen"))
                    return m_arrNewVal["collen"].IntVal;
                else
                    return 0;
            }
            set
            {           
                if (m_arrNewVal.ContainsKey("collen"))
                    m_arrNewVal["collen"].IntVal = value;
                else
                {
                    CValue val = new CValue();
                    val.IntVal = value;
                    m_arrNewVal.Add("collen", val);
                }
            }
        }

        public int ColDecimal
        {
            get
            {
                //return colDecimal;
                if (m_arrNewVal.ContainsKey("coldecimal"))
                    return m_arrNewVal["coldecimal"].IntVal;
                else
                    return 0;
            }
            set
            {
                //this.colDecimal = value;           
                if (m_arrNewVal.ContainsKey("coldecimal"))
                    m_arrNewVal["coldecimal"].IntVal = value;
                else
                {
                    CValue val = new CValue();
                    val.IntVal = value;
                    m_arrNewVal.Add("coldecimal", val);
                }
            }
        }

        public Guid RefTable
        {
            get
            {
                if (m_arrNewVal.ContainsKey("reftable"))
                    return m_arrNewVal["reftable"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {        
                if (m_arrNewVal.ContainsKey("reftable"))
                    m_arrNewVal["reftable"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("reftable", val);
                }
            }
        }

        public Guid RefCol
        {
            get
            {
                if (m_arrNewVal.ContainsKey("refcol"))
                    return m_arrNewVal["refcol"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {       
                if (m_arrNewVal.ContainsKey("refcol"))
                    m_arrNewVal["refcol"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("refcol", val);
                }
            }
        }

        public Guid RefShowCol
        {
            get
            {
                if (m_arrNewVal.ContainsKey("refshowcol"))
                    return m_arrNewVal["refshowcol"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {    
                if (m_arrNewVal.ContainsKey("refshowcol"))
                    m_arrNewVal["refshowcol"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("refshowcol", val);
                }
            }
        }

        public string Formula
        {
            get
            {
                if (m_arrNewVal.ContainsKey("formula"))
                    return m_arrNewVal["formula"].StrVal;
                else
                    return "";
            }
            set
            {    
                if (m_arrNewVal.ContainsKey("formula"))
                    m_arrNewVal["formula"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("formula", val);
                }
            }
        }

        public string DefaultValue
        {
            get
            {
                if (m_arrNewVal.ContainsKey("defaultvalue"))
                    return m_arrNewVal["defaultvalue"].StrVal;
                else
                    return "";
            }
            set
            {  
                if (m_arrNewVal.ContainsKey("defaultvalue"))
                    m_arrNewVal["defaultvalue"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("defaultvalue", val);
                }
            }
        }
        public bool AllowNull
        {
            get
            {
                if (m_arrNewVal.ContainsKey("allownull"))
                    return m_arrNewVal["allownull"].BoolVal;
                else
                    return false;
            }
            set
            {  
                if (m_arrNewVal.ContainsKey("allownull"))
                    m_arrNewVal["allownull"].BoolVal = value;
                else
                {
                    CValue val = new CValue();
                    val.BoolVal = value;
                    m_arrNewVal.Add("allownull", val);
                }
            }
        }

        public string UIControl
        {
            get
            {
                if (m_arrNewVal.ContainsKey("uicontrol"))
                    return m_arrNewVal["uicontrol"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("uicontrol"))
                    m_arrNewVal["uicontrol"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("uicontrol", val);
                }
            }
        }

        public string WebUIControl
        {
            get
            {
                if (m_arrNewVal.ContainsKey("webuicontrol"))
                    return m_arrNewVal["webuicontrol"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("webuicontrol"))
                    m_arrNewVal["webuicontrol"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("webuicontrol", val);
                }
            }
        }

        public bool IsVisible
        {
            get
            {
                if (m_arrNewVal.ContainsKey("isvisible"))
                    return m_arrNewVal["isvisible"].BoolVal;
                else
                    return false;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("isvisible"))
                    m_arrNewVal["isvisible"].BoolVal = value;
                else
                {
                    CValue val = new CValue();
                    val.BoolVal = value;
                    m_arrNewVal.Add("isvisible", val);
                }
            }
        }
        public int Idx
        {
            get
            {
                if (m_arrNewVal.ContainsKey("idx"))
                    return m_arrNewVal["idx"].IntVal;
                else
                    return 0;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("idx"))
                    m_arrNewVal["idx"].IntVal = value;
                else
                {
                    CValue val = new CValue();
                    val.IntVal = value;
                    m_arrNewVal.Add("idx", val);
                }
            }
        }

        public bool IsUnique
        {
            get
            {
                if (m_arrNewVal.ContainsKey("isunique"))
                    return m_arrNewVal["isunique"].BoolVal;
                else
                    return false;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("isunique"))
                    m_arrNewVal["isunique"].BoolVal = value;
                else
                {
                    CValue val = new CValue();
                    val.BoolVal = value;
                    m_arrNewVal.Add("isunique", val);
                }
            }
        }

        static public string ConvertColTypeToString(ColumnType ColType)
        {
            switch (ColType)
            {
                case ColumnType.string_type:
                    return "�ַ���";
                case ColumnType.int_type:
                    return "����";
                case ColumnType.long_type:
                    return "������";
                case ColumnType.bool_type:
                    return "������";
                case ColumnType.numeric_type:
                    return "��ֵ��";
                case ColumnType.datetime_type:
                    return "������";
                case ColumnType.text_type:
                    return "��ע��";
                case ColumnType.object_type:
                    return "������";
                case ColumnType.ref_type:
                    return "������";
                case ColumnType.guid_type:
                    return "GUID";
                case ColumnType.enum_type:
                    return "ö����";
                case ColumnType.path_type:
                    return "������";
            }
            return "δ֪����";
        }
        static public ColumnType ConvertStringToColType(string sType)
        {
            switch (sType)
            {
                case "�ַ���":
                    return ColumnType.string_type;
                case "����":
                    return ColumnType.int_type;
                case "������":
                    return ColumnType.long_type;
                case "������":
                    return ColumnType.bool_type;
                case "��ֵ��":
                    return ColumnType.numeric_type;
                case "������":
                    return ColumnType.datetime_type;
                case "��ע��":
                    return ColumnType.text_type;
                case "������":
                    return ColumnType.object_type;
                case "������":
                    return ColumnType.ref_type;
                case "GUID":
                    return ColumnType.guid_type;
                case "ö����":
                    return ColumnType.enum_type;
                case "������":
                    return ColumnType.path_type;
            }
            return ColumnType.string_type;
        }



        public CColumnEnumValMgr ColumnEnumValMgr
        {
            get
            {
                return (CColumnEnumValMgr)this.GetSubObjectMgr("FW_ColumnEnumVal", typeof(CColumnEnumValMgr));
            }
            set
            {
                this.SetSubObjectMgr("FW_ColumnEnumVal", value);
            }
        }

    }
}