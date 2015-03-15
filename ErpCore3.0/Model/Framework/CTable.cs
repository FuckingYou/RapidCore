// File:    CTable.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 12:40:36
// Purpose: Definition of Class CTable

using System;
using System.Text;
using System.Collections.Generic;

namespace ErpCoreModel.Framework
{
    public class CTable : CBaseObject
    {

        public CTable()
        {
            TbCode = "FW_Table";
            ClassName = "ErpCoreModel.Framework.CTable";
            
            Name = "";
            Code = "";
            IsSystem = false;
            IsFinish = false;
            Commit();
        }
        public bool IsSystem
        {
            get
            {
                //return isSystem;
                if (m_arrNewVal.ContainsKey("issystem"))
                    return m_arrNewVal["issystem"].BoolVal;
                else
                    return false;
            }
            set
            {
                //this.isSystem = value;              
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

        public string Name
        {
            get
            {
                //return name;
                if (m_arrNewVal.ContainsKey("name"))
                    return m_arrNewVal["name"].StrVal;
                else
                    return "";
            }
            set
            {
                //this.name = value;                
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
                //return code;
                if (m_arrNewVal.ContainsKey("code"))
                    return m_arrNewVal["code"].StrVal;
                else
                    return "";
            }
            set
            {
                //this.code = value;               
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

        public bool IsFinish
        {
            get
            {
                if (m_arrNewVal.ContainsKey("isfinish"))
                    return m_arrNewVal["isfinish"].BoolVal;
                else
                    return false;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("isfinish"))
                    m_arrNewVal["isfinish"].BoolVal = value;
                else
                {
                    CValue val = new CValue();
                    val.BoolVal = value;
                    m_arrNewVal.Add("isfinish", val);
                }
            }
        }


        public CColumnMgr ColumnMgr
        {
            get
            {
                string sTbCode = "FW_Column";
                string sKey = sTbCode.ToLower();
                if (m_sortSubObjectMgr.ContainsKey(sKey))
                    return (CColumnMgr)m_sortSubObjectMgr[sKey];

                CColumnMgr objMgr = new CColumnMgr();
                objMgr.Ctx = Ctx;
                objMgr.m_Parent = this;
                string sWhere = string.Format(" {0}_id='{1}'", this.TbCode, this.Id);
                string sOrderby = "idx";
                objMgr.Load(sWhere,sOrderby, false);

                m_sortSubObjectMgr.Add(sKey, objMgr);
                return objMgr;
            }
            set
            {
                this.SetSubObjectMgr("FW_Column", value);
            }
        }

        public CDataServerMgr DataServerMgr
        {
            get
            {
                return (CDataServerMgr)this.GetSubObjectMgr("FW_DataServer", typeof(CDataServerMgr));
            }
            set
            {
                this.SetSubObjectMgr("FW_DataServer", value);
            }
        }


    }
}