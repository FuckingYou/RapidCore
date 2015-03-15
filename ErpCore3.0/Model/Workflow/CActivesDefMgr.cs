// File:    CActivesDefMgr.cs
// Created: 2012/7/21 21:38:30
// Purpose: Definition of Class CActivesDefMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Workflow
{
    public class CActivesDefMgr : CBaseObjectMgr
    {

        public CActivesDefMgr()
        {
            TbCode = "WF_ActivesDef";
            ClassName = "ErpCoreModel.Workflow.CActivesDef";
        }

        public int NewIdx()
        {
            int iMaxIdx = 0;
            foreach (CBaseObject obj in m_lstObj)
            {
                CActivesDef ActivesDef = (CActivesDef)obj;
                if (ActivesDef.Idx > iMaxIdx)
                    iMaxIdx = ActivesDef.Idx;
            }
            return iMaxIdx + 1;
        }
        //���������
        public CActivesDef FindStart()
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CActivesDef ActivesDef = (CActivesDef)obj;
                if (ActivesDef.WType == ActivesType.Start)
                    return ActivesDef;
            }
            return null;
        }
        //���ҳɹ������
        public CActivesDef FindSuccess()
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CActivesDef ActivesDef = (CActivesDef)obj;
                if (ActivesDef.WType == ActivesType.Success)
                    return ActivesDef;
            }
            return null;
        }
        //����ʧ�ܽ����
        public CActivesDef FindFailure()
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CActivesDef ActivesDef = (CActivesDef)obj;
                if (ActivesDef.WType == ActivesType.Failure)
                    return ActivesDef;
            }
            return null;
        }
    }
}