// File:    CWorkflowMgr.cs
// Created: 2012/7/21 21:38:30
// Purpose: Definition of Class CWorkflowMgr

using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using ErpCoreModel.Framework;
using ErpCoreModel.Base;

namespace ErpCoreModel.Workflow
{
    public class CWorkflowMgr : CBaseObjectMgr
    {

        public CWorkflowMgr()
        {
            TbCode = "WF_Workflow";
            ClassName = "ErpCoreModel.Workflow.CWorkflow";
        }
        //��ȡһ����¼���й�����
        public List<CWorkflow> FindByRowid(Guid Row_id)
        {
            GetList();
            List<CWorkflow> lstRet = new List<CWorkflow>();
            foreach (CBaseObject obj in m_lstObj)
            {
                CWorkflow Workflow = (CWorkflow)obj;
                if (Workflow.Row_id == Row_id)
                    lstRet.Add(Workflow);
            }
            return lstRet;
        }
        //��ȡһ����¼���µĹ�����
        public List<CWorkflow> FindLastByRowid(Guid Row_id)
        {
            GetList();
            List<CWorkflow> lstRet = new List<CWorkflow>();
            foreach (CBaseObject obj in m_lstObj)
            {
                CWorkflow Workflow = (CWorkflow)obj;
                if (Workflow.Row_id == Row_id)
                {
                    bool bHas = false;
                    foreach (CWorkflow wf in lstRet)
                    {
                        if (wf.WF_WorkflowDef_id == Workflow.WF_WorkflowDef_id)
                        {
                            if (wf.Created > Workflow.Created)
                                bHas = true;
                            else
                                lstRet.Remove(wf);
                            break;
                        }
                    }
                    if(!bHas)
                        lstRet.Add(Workflow);
                }
            }
            return lstRet;
        }

        //����������
        public bool StartWorkflow(CWorkflow wf,out string sErr)
        {
            
            sErr = "";
            CCompany Company = null;
            if (wf.B_Company_id == Guid.Empty)
                Company = (CCompany)Ctx.CompanyMgr.FindTopCompany();
            else
                Company = (CCompany)Ctx.CompanyMgr.Find(wf.B_Company_id);
            CWorkflowDef WorkflowDef = (CWorkflowDef)Company.WorkflowDefMgr.Find(wf.WF_WorkflowDef_id);
            if (WorkflowDef == null)
            {
                sErr = "���������岻���ڣ�";
                return false;
            }
            CActivesDef start = WorkflowDef.ActivesDefMgr.FindStart();
            if (start == null)
            {
                sErr = "����������ڣ�";
                return false;
            }
            List<CLink> lstLink = WorkflowDef.LinkMgr.FindByPreActives(start.Id);
            if (lstLink.Count == 0)
            {
                sErr = "�����û�����ӣ�";
                return false;
            }
            //��������ҽ���һ������
            CLink Link = lstLink[0];
            CActivesDef next = (CActivesDef)WorkflowDef.ActivesDefMgr.Find(Link.NextActives);
            if (next == null)
            {
                sErr = "�����û�����ӣ�";
                return false;
            }
            //��������
            if(!ValidateCond(WorkflowDef,wf,Link.Condiction,out sErr))
            {
                return false;
            }

            Update(wf);
            wf.State = enumApprovalState.Running;
            //ʵ�����
            CActives Actives = new CActives();
            Actives.Ctx = Ctx;
            Actives.WF_Workflow_id = wf.Id;
            Actives.WF_ActivesDef_id = next.Id;
            Actives.Result = enumApprovalResult.Init;
            Actives.AType = next.AType;
            if(Actives.AType=="���û�")
                Actives.B_User_id = next.B_User_id;
            else
                Actives.B_Role_id = next.B_Role_id;
            wf.ActivesMgr.AddNew(Actives);
            //���Ƿ��ʼ���֪ͨ��ʽ

            //if (!Save(true))
            //{
            //    sErr = "����ʧ�ܣ�";
            //    return false;
            //}

            return true;
        }
        //ȡ��������
        public bool CancelWorkflow(CWorkflow wf)
        {
            Update(wf);
            wf.State = enumApprovalState.Cancel;
            return Save(true);
        }
        //�����
        public bool Approval(CWorkflow wf, CActives Actives, out string sErr)
        {
            sErr = "";

            CCompany Company = null;
            if (wf.B_Company_id==Guid.Empty)
                Company = (CCompany)Ctx.CompanyMgr.FindTopCompany();
            else
                Company = (CCompany)Ctx.CompanyMgr.Find(wf.B_Company_id);
            if (Company == null)
            {
                sErr = "��λ�����ڣ�";
                return false;
            }
            CWorkflowDef WorkflowDef = (CWorkflowDef)Company.WorkflowDefMgr.Find(wf.WF_WorkflowDef_id);
            if (WorkflowDef == null)
            {
                sErr = "���������岻���ڣ�";
                return false;
            }
            List<CLink> lstLink = WorkflowDef.LinkMgr.FindByPreActives(Actives.WF_ActivesDef_id);
            if (lstLink.Count == 0)
            {
                sErr = "�û�����ӣ�";
                return false;
            }
            //�ҳ���������������,����ȡ��һ���
            CActivesDef next = null;
            foreach (CLink link in lstLink)
            {
                if (Actives.Result == link.Result)
                {
                    //�����������ʽ
                    if (!ValidateCond(WorkflowDef,wf, link.Condiction, out sErr))
                    {
                        if (sErr != "")
                            return false;
                        else
                            continue;
                    }

                    next = (CActivesDef)WorkflowDef.ActivesDefMgr.Find( link.NextActives);
                    break;
                }
            }
            if (next == null)
            {
                sErr = "�û�����ӣ�";
                return false;
            }


            Update(wf);
            wf.ActivesMgr.Update(Actives);
            //����ǽ�����������������
            if (next.WType == ActivesType.Success)
                wf.State = enumApprovalState.Accept;
            else if (next.WType == ActivesType.Failure)
                wf.State = enumApprovalState.Reject;
            else
            {
                //ʵ������һ���
                CActives nextActives = new CActives();
                nextActives.Ctx = Ctx;
                nextActives.WF_Workflow_id = wf.Id;
                nextActives.WF_ActivesDef_id = next.Id;
                nextActives.Result = enumApprovalResult.Init;
                nextActives.AType = next.AType;
                if (nextActives.AType == "���û�")
                    nextActives.B_User_id = next.B_User_id;
                else
                    nextActives.B_Role_id = next.B_Role_id;
                wf.ActivesMgr.AddNew(nextActives);
                //���Ƿ��ʼ���֪ͨ��ʽ

            }

            if (!Save(true))
            {
                sErr = "����ʧ�ܣ�";
                return false;
            }

            return true;
        }
        //�����������ʽ��ʹ��sql��ѯ����
        bool ValidateCond(CWorkflowDef WorkflowDef, CWorkflow wf, string sCond, out string sErr)
        {
            sErr = "";
            if (sCond.Trim() == "")
                return true;
            //����������������滻���ֶ���
            CTable Table = (CTable)Ctx.TableMgr.Find(WorkflowDef.FW_Table_id);
            if (Table == null)
            {
                sErr = "����󲻴��ڣ�";
                return false;
            }
            List<CBaseObject> lstObj = Table.ColumnMgr.GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CColumn Column = (CColumn)obj;
                sCond = sCond.Replace(string.Format("[{0}]", Column.Name), string.Format("[{0}]",Column.Code));
            }
            string sSql = string.Format("select id from [{0}] where id='{1}' and ({2})",Table.Code,wf.Row_id, sCond);
            DataTable dt = Ctx.MainDB.QueryT(sSql);
            if (dt == null)
            {
                sErr = "�������ʽ�﷨����";
                return false;
            }
            if (dt.Rows.Count == 0) //����������
            {
                sErr = "���������ϣ�";
                return false;
            }

            return true;
        }
    }
}