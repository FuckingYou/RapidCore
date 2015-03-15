// File:    CUser.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 12:40:36
// Purpose: Definition of Class CUser

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;
using ErpCoreModel.UI;
using ErpCoreModel.IM;

namespace ErpCoreModel.Base
{
    //�û�Ȩ�����ã�0-Ĭ��ӵ�����б�Ȩ�ޣ�1-ͨ������Ȩ��
    public enum enumAccessSetting {All,Setting };
    public class CUser : CBaseObject
    {
        //��¼�û���������ʱ�䣬���ʱ�䳬��20���ӣ�����Ϊ�û�����
        DateTime m_dtimeOnline = DateTime.Now;
        //����û���¼�������3�Σ�����ͣ10���Ӻ�����ٵ�¼
        public DateTime m_dtimeLoginErr = DateTime.Now;
        public int m_iLoginErrCount = 0;

        public CUser()
        {
            TbCode = "B_User";
            ClassName = "ErpCoreModel.Base.CUser";

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
        public int Type
        {
            get
            {
                if (m_arrNewVal.ContainsKey("type"))
                    return m_arrNewVal["type"].IntVal;
                else
                    return 0;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("type"))
                    m_arrNewVal["type"].IntVal = value;
                else
                {
                    CValue val = new CValue();
                    val.IntVal = value;
                    m_arrNewVal.Add("type", val);
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

        public string Pwd
        {
            get
            {
                if (m_arrNewVal.ContainsKey("pwd"))
                    return m_arrNewVal["pwd"].StrVal;
                else
                    return "";
            }
            set
            {
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
        public string TName
        {
            get
            {
                if (m_arrNewVal.ContainsKey("tname"))
                    return m_arrNewVal["tname"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("tname"))
                    m_arrNewVal["tname"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("tname", val);
                }
            }
        }
        public string Sex
        {
            get
            {
                if (m_arrNewVal.ContainsKey("sex"))
                    return m_arrNewVal["sex"].StrVal;
                else
                    return "��";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("sex"))
                    m_arrNewVal["sex"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("sex", val);
                }
            }
        }
        public string QQ
        {
            get
            {
                if (m_arrNewVal.ContainsKey("qq"))
                    return m_arrNewVal["qq"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("qq"))
                    m_arrNewVal["qq"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("qq", val);
                }
            }
        }
        public string Email
        {
            get
            {
                if (m_arrNewVal.ContainsKey("email"))
                    return m_arrNewVal["email"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("email"))
                    m_arrNewVal["email"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("email", val);
                }
            }
        }
        public string Phone
        {
            get
            {
                if (m_arrNewVal.ContainsKey("phone"))
                    return m_arrNewVal["phone"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("phone"))
                    m_arrNewVal["phone"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("phone", val);
                }
            }
        }


        public enumAccessSetting AccessSetting
        {
            get
            {
                if (m_arrNewVal.ContainsKey("accesssetting"))
                    return (enumAccessSetting)m_arrNewVal["accesssetting"].IntVal;
                else
                    return enumAccessSetting.All;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("accesssetting"))
                    m_arrNewVal["accesssetting"].IntVal = (int)value;
                else
                {
                    CValue val = new CValue();
                    val.IntVal = (int)value;
                    m_arrNewVal.Add("accesssetting", val);
                }
            }
        }

        //�Ƿ�ĳ�ֽ�ɫ
        public bool IsRole(string sRoleName)
        {
            CCompany Company = (CCompany)Ctx.CompanyMgr.Find(B_Company_id);
            CRole role = Company.RoleMgr.FindByName(sRoleName);
            if (role == null)
                return false;
            if (role.UserInRoleMgr.FindByUserid(this.Id)
                != null)
                return true;
            else
                return false;
        }

        //�ж��û��Ƿ�����
        public bool IsOnline()
        {
            //���ʱ�䳬��20���ӣ�����Ϊ�û�����
            DateTime dtimeNow = DateTime.Now;
            TimeSpan span = dtimeNow - m_dtimeOnline;
            if (span.TotalSeconds > 20)
                return false;
            return true;
        }
        //�����û�����ʱ��
        public void UpdateOnlineTime()
        {
            m_dtimeOnline = DateTime.Now;
        }

        public CDesktopGroupAccessInUserMgr DesktopGroupAccessInUserMgr
        {
            get
            {
                return (CDesktopGroupAccessInUserMgr)this.GetSubObjectMgr("B_DesktopGroupAccessInUser", typeof(CDesktopGroupAccessInUserMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_DesktopGroupAccessInUser", value);
            }
        }
        public CColumnAccessInUserMgr ColumnAccessInUserMgr
        {
            get
            {
                return (CColumnAccessInUserMgr)this.GetSubObjectMgr("B_ColumnAccessInUser", typeof(CColumnAccessInUserMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_ColumnAccessInUser", value);
            }
        }
        public CTableAccessInUserMgr TableAccessInUserMgr
        {
            get
            {
                return (CTableAccessInUserMgr)this.GetSubObjectMgr("B_TableAccessInUser", typeof(CTableAccessInUserMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_TableAccessInUser", value);
            }
        }
        public CReportAccessInUserMgr ReportAccessInUserMgr
        {
            get
            {
                return (CReportAccessInUserMgr)this.GetSubObjectMgr("B_ReportAccessInUser", typeof(CReportAccessInUserMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_ReportAccessInUser", value);
            }
        }
        public CViewAccessInUserMgr ViewAccessInUserMgr
        {
            get
            {
                return (CViewAccessInUserMgr)this.GetSubObjectMgr("B_ViewAccessInUser", typeof(CViewAccessInUserMgr));
            }
            set
            {
                this.SetSubObjectMgr("B_ViewAccessInUser", value);
            }
        }
        public CUserMenuMgr UserMenuMgr
        {
            get
            {
                return (CUserMenuMgr)this.GetSubObjectMgr("UI_UserMenu", typeof(CUserMenuMgr));
            }
            set
            {
                this.SetSubObjectMgr("UI_UserMenu", value);
            }
        }
        public CDesktopMgr DesktopMgr
        {
            get
            {
                return (CDesktopMgr)this.GetSubObjectMgr("UI_Desktop", typeof(CDesktopMgr));
            }
            set
            {
                this.SetSubObjectMgr("UI_Desktop", value);
            }
        }
        public CDesktopAppMgr DesktopAppMgr
        {
            get
            {
                return (CDesktopAppMgr)this.GetSubObjectMgr("UI_DesktopApp", typeof(CDesktopAppMgr));
            }
            set
            {
                this.SetSubObjectMgr("UI_DesktopApp", value);
            }
        }

        public CFriendMgr FriendMgr
        {
            get
            {
                return (CFriendMgr)this.GetSubObjectMgr("IM_Friend", typeof(CFriendMgr));
            }
            set
            {
                this.SetSubObjectMgr("IM_Friend", value);
            }
        }

        //��ȡ�û�������Ȩ��
        //��д���ȣ�ֻ����֮����ֹ���
        public AccessType GetDesktopGroupAccess(Guid UI_DesktopGroup_id)
        {
            //����Ա������Ȩ��
            if (IsRole("����Ա"))
                return AccessType.write;
            //
            AccessType accessType = AccessType.forbide;
            CDesktopGroupAccessInUser dgaiu = DesktopGroupAccessInUserMgr.FindByDesktopGroup(UI_DesktopGroup_id);
            if (dgaiu != null)
            {
                accessType = dgaiu.Access;
                if(accessType== AccessType.write)
                    return AccessType.write;
            }
            
            CCompany Company = (CCompany)Ctx.CompanyMgr.Find(B_Company_id);
            List<CBaseObject> lstObj = Company.RoleMgr.GetList();
            foreach(CBaseObject obj in lstObj)
            {
                CRole role = (CRole)obj;
                if(role.UserInRoleMgr.FindByUserid(Id)!=null)
                {
                    CDesktopGroupAccessInRole dgair=role.DesktopGroupAccessInRoleMgr.FindByDesktopGroup(UI_DesktopGroup_id);
                    if (dgair != null)
                    {
                        if (dgair.Access == AccessType.write)
                            return AccessType.write;
                        else if (dgair.Access == AccessType.read)
                            accessType = AccessType.read;
                    }
                }
            }

            return accessType;
        }
        //��ȡ�û���ͼȨ��
        //��д���ȣ�ֻ����֮����ֹ���
        public AccessType GetViewAccess(Guid UI_View_id)
        {
            //����Ա������Ȩ��
            if (IsRole("����Ա"))
                return AccessType.write;
            //
            //Ĭ��ӵ������Ȩ�޵��û�
            if (AccessSetting == enumAccessSetting.All)
                return AccessType.write;

            AccessType accessType = AccessType.forbide;
            CViewAccessInUser vaiu = ViewAccessInUserMgr.FindByView(UI_View_id);
            if (vaiu != null)
            {
                accessType = vaiu.Access;
                if (accessType == AccessType.write)
                    return AccessType.write;
            }

            CCompany Company = (CCompany)Ctx.CompanyMgr.Find(B_Company_id);
            List<CBaseObject> lstObj = Company.RoleMgr.GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CRole role = (CRole)obj;
                if (role.UserInRoleMgr.FindByUserid(Id) != null)
                {
                    CViewAccessInRole vair = role.ViewAccessInRoleMgr.FindByView(UI_View_id);
                    if (vair != null)
                    {
                        if (vair.Access == AccessType.write)
                            return AccessType.write;
                        else if (vair.Access == AccessType.read)
                            accessType = AccessType.read;
                    }
                }
            }

            return accessType;
        }
        //��ȡ�û���Ȩ��
        //��д���ȣ�ֻ����֮����ֹ���
        public AccessType GetTableAccess(Guid FW_Table_id)
        {
            //����Ա������Ȩ��
            if (IsRole("����Ա"))
                return AccessType.write;
            //Ĭ��ӵ������Ȩ�޵��û�
            if (AccessSetting == enumAccessSetting.All)
                return AccessType.write;

            AccessType accessType = AccessType.forbide;
            CTableAccessInUser taiu = TableAccessInUserMgr.FindByTable(FW_Table_id);
            if (taiu != null)
            {
                accessType = taiu.Access;
                if (accessType == AccessType.write)
                    return AccessType.write;
            }

            CCompany Company = (CCompany)Ctx.CompanyMgr.Find(B_Company_id);
            List<CBaseObject> lstObj = Company.RoleMgr.GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CRole role = (CRole)obj;
                if (role.UserInRoleMgr.FindByUserid(Id) != null)
                {
                    CTableAccessInRole tair = role.TableAccessInRoleMgr.FindByTable(FW_Table_id);
                    if (tair != null)
                    {
                        if (tair.Access == AccessType.write)
                            return AccessType.write;
                        else if (tair.Access == AccessType.read)
                            accessType = AccessType.read;
                    }
                }
            }

            return accessType;
        }
        //��ȡ�û��ֶ�Ȩ��
        //��д���ȣ�ֻ����֮����ֹ���
        public AccessType GetColumnAccess(CColumn col)
        {
            //����Ա������Ȩ��
            if (IsRole("����Ա"))
                return AccessType.write;
            //
            //�����ϵͳ�ֶΣ���Ȩ�޶�Ϊֻ���������������ܶ�ȡ�����ֶ�ֵ
            if (col.IsSystem)
                return AccessType.read;
            //

            bool bHasSetAccess = false; //�Ƿ��ֶ������ֶ�Ȩ��
            AccessType accessType = AccessType.forbide;
            CColumnAccessInUser caiu = ColumnAccessInUserMgr.FindByColumn(col.Id);
            if (caiu != null)
            {
                bHasSetAccess = true;
                accessType = caiu.Access;
                if (accessType == AccessType.write)
                    return AccessType.write;
            }

            CCompany Company = (CCompany)Ctx.CompanyMgr.Find(B_Company_id);
            List<CBaseObject> lstObj = Company.RoleMgr.GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CRole role = (CRole)obj;
                if (role.UserInRoleMgr.FindByUserid(Id) != null)
                {
                    CColumnAccessInRole cair = role.ColumnAccessInRoleMgr.FindByColumn(col.Id);
                    if (cair != null)
                    {
                        bHasSetAccess = true;
                        if (cair.Access == AccessType.write)
                            return AccessType.write;
                        else if (cair.Access == AccessType.read)
                            accessType = AccessType.read;
                    }
                }
            }

            //���û���ֶ������ֶ�Ȩ�ޣ�Ĭ���ֶ�Ȩ��Ϊ��д��������б�Ȩ�ޣ���Ĭ��ӵ�������ֶ�дȨ��
            if (!bHasSetAccess)
                accessType = AccessType.write;

            return accessType;
        }
        //��ȡ�������������ֶ�Ȩ��
        public SortedList<Guid, AccessType> GetRestrictColumnAccessTypeList(CTable table)
        {
            SortedList<Guid, AccessType> sortRestrictColumnAccessType=new SortedList<Guid,AccessType>();
            if (table == null)
                return sortRestrictColumnAccessType;

            List<CBaseObject> lstObj = table.ColumnMgr.GetList();
            foreach (CBaseObject obj in lstObj)
            {
                AccessType accessType = GetColumnAccess((CColumn)obj);
                if (accessType != AccessType.write)
                    sortRestrictColumnAccessType.Add(obj.Id, accessType);
            }
            return sortRestrictColumnAccessType;
        }
    }
}