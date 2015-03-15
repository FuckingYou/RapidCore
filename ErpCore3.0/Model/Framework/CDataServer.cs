// File:    CDataServer.cs
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

namespace ErpCoreModel.Framework
{


    public class CDataServer : CBaseObject
    {

        public CDataServer()
        {
            TbCode = "FW_DataServer";
            ClassName = "ErpCoreModel.Framework.CDataServer";

            FW_Table_id = Guid.Empty;
            Server = "";
            DBName = "";
            UserID = "";
            Pwd = "";
            IsWrite = false;
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
        public string Server
        {
            get
            {
                //return name;
                if (m_arrNewVal.ContainsKey("server"))
                    return m_arrNewVal["server"].StrVal;
                else
                    return null;
            }
            set
            {
                //this.name = value;                
                if (m_arrNewVal.ContainsKey("server"))
                    m_arrNewVal["server"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("server", val);
                }
            }
        }

        public string DBName
        {
            get
            {
                //return name;
                if (m_arrNewVal.ContainsKey("dbname"))
                    return m_arrNewVal["dbname"].StrVal;
                else
                    return null;
            }
            set
            {
                //this.name = value;                
                if (m_arrNewVal.ContainsKey("dbname"))
                    m_arrNewVal["dbname"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("dbname", val);
                }
            }
        }

        public string UserID
        {
            get
            {
                //return name;
                if (m_arrNewVal.ContainsKey("userid"))
                    return m_arrNewVal["userid"].StrVal;
                else
                    return null;
            }
            set
            {
                //this.name = value;                
                if (m_arrNewVal.ContainsKey("userid"))
                    m_arrNewVal["userid"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("userid", val);
                }
            }
        }

        public string Pwd
        {
            get
            {
                //return name;
                if (m_arrNewVal.ContainsKey("pwd"))
                    return m_arrNewVal["pwd"].StrVal;
                else
                    return null;
            }
            set
            {
                //this.name = value;                
                if (m_arrNewVal.ContainsKey("pwd"))
                    m_arrNewVal["pwd"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("pwd", val);
                }
            }
        }


        public bool IsWrite
        {
            get
            {
                //return name;
                if (m_arrNewVal.ContainsKey("iswrite"))
                    return m_arrNewVal["iswrite"].BoolVal;
                else
                    return false;
            }
            set
            {
                //this.name = value;                
                if (m_arrNewVal.ContainsKey("iswrite"))
                    m_arrNewVal["iswrite"].BoolVal = value;
                else
                {
                    CValue val = new CValue();
                    val.BoolVal = value;
                    m_arrNewVal.Add("iswrite", val);
                }
            }
        }


    }
}