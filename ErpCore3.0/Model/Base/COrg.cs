// File:    COrg.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 12:40:36
// Purpose: Definition of Class COrg

using System;
using System.Text;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class COrg : CBaseObject
    {
        public COrg()
        {
            TbCode = "B_Org";
            ClassName = "ErpCoreModel.Base.COrg";

            Name = "";
            Parent_id = Guid.Empty;
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
        public Guid Parent_id
        {
            get
            {
                if (m_arrNewVal.ContainsKey("parent_id"))
                    return m_arrNewVal["parent_id"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("parent_id"))
                    m_arrNewVal["parent_id"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("parent_id", val);
                }
            }
        }
        public Guid B_Company_id
        {
            get
            {
                if (m_arrNewVal.ContainsKey("b_company_id"))
                    return m_arrNewVal["b_company_id"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("b_company_id"))
                    m_arrNewVal["b_company_id"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("b_company_id", val);
                }
            }
        }

        public CUserInOrgMgr UserInOrgMgr
        {
            get
            {
                return (CUserInOrgMgr)this.GetSubObjectMgr("B_UserInOrg", typeof(CUserInOrgMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_UserInOrg", value);
            }
        }
    }
}