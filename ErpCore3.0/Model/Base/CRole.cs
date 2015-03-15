// File:    CRole.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��16�� 12:49:31
// Purpose: Definition of Class CRole

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;
using ErpCoreModel.UI;

namespace ErpCoreModel.Base
{
   public class CRole : CBaseObject
   {
        public CRole()
        {
            TbCode = "B_Role";
            ClassName = "ErpCoreModel.Base.CRole";

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
        public CDesktopGroupAccessInRoleMgr DesktopGroupAccessInRoleMgr
        {
            get
            {
                return (CDesktopGroupAccessInRoleMgr)this.GetSubObjectMgr("B_DesktopGroupAccessInRole", typeof(CDesktopGroupAccessInRoleMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_DesktopGroupAccessInRole", value);
            }
        }
        public CReportAccessInRoleMgr ReportAccessInRoleMgr
        {
            get
            {
                return (CReportAccessInRoleMgr)this.GetSubObjectMgr("B_ReportAccessInRole", typeof(CReportAccessInRoleMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_ReportAccessInRole", value);
            }
        }
        public CColumnAccessInRoleMgr ColumnAccessInRoleMgr
        {
            get
            {
                return (CColumnAccessInRoleMgr)this.GetSubObjectMgr("B_ColumnAccessInRole", typeof(CColumnAccessInRoleMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_ColumnAccessInRole", value);
            }
        }
        public CTableAccessInRoleMgr TableAccessInRoleMgr
        {
            get
            {
                return (CTableAccessInRoleMgr)this.GetSubObjectMgr("B_TableAccessInRole", typeof(CTableAccessInRoleMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_TableAccessInRole", value);
            }
        }


        public CUserInRoleMgr UserInRoleMgr
        {
            get
            {
                return (CUserInRoleMgr)this.GetSubObjectMgr("B_UserInRole", typeof(CUserInRoleMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_UserInRole", value);
            }
        }
        public CSystemAccessInRoleMgr SystemAccessInRoleMgr
        {
            get
            {
                return (CSystemAccessInRoleMgr)this.GetSubObjectMgr("B_SystemAccessInRole", typeof(CSystemAccessInRoleMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_SystemAccessInRole", value);
            }
        }
        public CViewAccessInRoleMgr ViewAccessInRoleMgr
        {
            get
            {
                return (CViewAccessInRoleMgr)this.GetSubObjectMgr("B_ViewAccessInRole", typeof(CViewAccessInRoleMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_ViewAccessInRole", value);
            }
        }
        public CRoleMenuMgr RoleMenuMgr
        {
            get
            {
                return (CRoleMenuMgr)this.GetSubObjectMgr("UI_RoleMenu", typeof(CRoleMenuMgr));
            }
            set
            {
                this.SetSubObjectMgr("UI_RoleMenu", value);
            }
        }

   }
}