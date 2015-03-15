// File:    CLinkMgr.cs
// Created: 2012/7/21 21:38:30
// Purpose: Definition of Class CLinkMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Workflow
{
    public class CLinkMgr : CBaseObjectMgr
    {

        public CLinkMgr()
        {
            TbCode = "WF_Link";
            ClassName = "ErpCoreModel.Workflow.CLink";
        }
        //ͨ��ǰ�û����
        public List<CLink> FindByPreActives(Guid PreActives)
        {
            GetList();
            List<CLink> lstRet = new List<CLink>();
            foreach (CBaseObject obj in m_lstObj)
            {
                CLink Link = (CLink)obj;
                if (Link.PreActives == PreActives)
                {
                    lstRet.Add(Link);
                }
            }
            return lstRet;
        }
        //ͨ�����û����
        public List<CLink> FindByNextActives(Guid NextActives)
        {
            GetList();
            List<CLink> lstRet = new List<CLink>();
            foreach (CBaseObject obj in m_lstObj)
            {
                CLink Link = (CLink)obj;
                if (Link.NextActives == NextActives)
                {
                    lstRet.Add(Link);
                }
            }
            return lstRet;
        }
    }
}