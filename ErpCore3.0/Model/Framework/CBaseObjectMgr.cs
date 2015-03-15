// File:    CBaseObjectMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:30:41
// Purpose: Definition of Class CBaseObjectMgr

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Linq;
using ErpCoreModel.Workflow;
using ErpCoreModel.UI;

namespace ErpCoreModel.Framework
{

    public class CBaseObjectMgr : PO
    {
        public CBaseObject m_Parent = null;
        protected bool m_bIsLoad = false;
        public string m_sWhere = "";
        public string m_sOrderby = "";
        private CWorkflowMgr workflowMgr = null;
        

        public CBaseObjectMgr()
        {
            ClassName = "ErpCoreModel.Framework.CBaseObject";
        }

        #region ��������
        public CBaseObject CreateBaseObject()
        {
            if (ObjType == null)
            {
                //Assembly assembly = Assembly.LoadFrom(Assembly.GetExecutingAssembly().Location);
                ObjType = Type.GetType(ClassName);
            }
            object objPO = Activator.CreateInstance(ObjType);
            return (CBaseObject)objPO;
        }
        #endregion

        public  bool AddNew(CBaseObject obj)
        {
            return AddNew(obj,false);
        }
        public virtual bool AddNew(CBaseObject obj,bool bSave)
        {
            //�����ɾ����Ԫ�ز��һ�û���棬���ٴ����
            if (m_sortObj.ContainsKey(obj.Id))
            {
                if (obj.m_CmdType == CmdType.Delete)
                {
                    obj.m_CmdType = CmdType.Update;
                    return Update(obj, bSave);
                }
                obj.Ctx = this.Ctx;
                obj.m_ObjectMgr = this;
                return true;
            }
            obj.m_CmdType = CmdType.AddNew;
            obj.Ctx = this.Ctx;
            obj.m_ObjectMgr = this;
            m_lstObj.Add(obj);
            m_sortObj.Add(obj.Id, obj);

            if (bSave)
            {
                if (obj.AddNew())
                {
                    obj.Commit();
                    return true;
                }
                else
                {
                    obj.Rollback();
                    return false;
                }
            }
            else
                return true;
        }

        public  bool Update(CBaseObject obj)
        {
            return Update(obj,false);
        }

        public virtual bool Update(CBaseObject obj,bool bSave)
        {
            if (obj.m_CmdType != CmdType.AddNew && obj.m_CmdType != CmdType.Delete)
                obj.m_CmdType = CmdType.Update;
            if (bSave)
            {
                if (obj.Update())
                {
                    obj.Commit();
                    return true;
                }
                else
                {
                    obj.Rollback();
                    return false;
                }
            }
            else
                return true;
        }

        public  bool Delete(CBaseObject obj)
        {
            return Delete(obj,false);
        }

        public virtual bool Delete(CBaseObject obj, bool bSave)
        {
            //ɾ���¼�����
            foreach (KeyValuePair<string, CBaseObjectMgr> pair in obj.m_sortSubObjectMgr)
            {
                if (!pair.Value.RemoveAll(bSave))
                    return false;
            }
            //
            obj.m_CmdType = CmdType.Delete;
            if (bSave)
            {
                if (obj.Delete())
                {
                    m_sortObj.Remove(obj.Id);
                    m_lstObj.Remove(obj);
                }
                else
                    return false;
            }
            return true;
        }

        public  bool Delete(Guid id)
        {
            return Delete(id,false);
        }
        public virtual bool Delete(Guid id,bool bSave)
        {
            CBaseObject obj = Find(id);
            if (obj == null)
                return false;
            return Delete(obj,bSave);
        }
        public  bool RemoveAll()
        {
            return RemoveAll(false);
        }
        public virtual bool RemoveAll(bool bSave)
        {
            foreach (CBaseObject obj in m_lstObj)
            {
                if (!Delete(obj))
                    return false;
            }
            if (bSave)
            {
                if (!Save())
                    return false;
            }
            return true;
        }
        
        public override bool Save()
        {
            List<CBaseObject> lstDel= new List<CBaseObject>();
            foreach (CBaseObject obj in m_lstObj)
            {
                CmdType cmdType = obj.m_CmdType;
                if (!obj.Save())
                    return false;
                if (cmdType == CmdType.Delete)
                    lstDel.Add(obj);
            }
            foreach (CBaseObject obj in lstDel)
            {
                m_sortObj.Remove(obj.Id);
                m_lstObj.Remove(obj);
            }
            return true;
        }
        
        public override void Commit()
        {
            List<CBaseObject> lstDel = new List<CBaseObject>();
            foreach (CBaseObject obj in m_lstObj)
            {
                obj.Commit();
            }
        }
        public override void Cancel()
        {
            List<CBaseObject> lstAdd = new List<CBaseObject>();
            foreach (CBaseObject obj in m_lstObj)
            {
                if (obj.m_CmdType == CmdType.AddNew)
                    lstAdd.Add(obj);
                else
                {
                    obj.Rollback();
                    obj.m_CmdType = CmdType.None;
                }
            }
            foreach (CBaseObject obj in lstAdd)
            {
                m_sortObj.Remove(obj.Id);
                m_lstObj.Remove(obj);
            }
        }

        public virtual List<CBaseObject> GetList()
        {
            return GetList(m_sWhere, null,m_sOrderby);
        }
        public List<CBaseObject> GetList(string sWhere)
        {
            return GetList(sWhere, null, m_sOrderby);
        }
        public List<CBaseObject> GetList(string sWhere, string sOrderby)
        {
            return GetList(sWhere, null, sOrderby);
        }
        public List<CBaseObject> GetList(string sWhere, List<DbParameter> cmdParas)
        {
            return GetList(sWhere, cmdParas, m_sOrderby);
        }
        public List<CBaseObject> GetList(string sWhere, List<DbParameter> cmdParas, string sOrderby)
        {
            if (!Load(sWhere, cmdParas, sOrderby,false))
                return null;
            //�ų�ɾ����Ԫ��
            List<CBaseObject> lstRet = new List<CBaseObject>();
            foreach (CBaseObject obj in m_lstObj)
            {
                if (obj.m_CmdType != CmdType.Delete)
                    lstRet.Add(obj);
            }
            return lstRet;
        }
        public List<CBaseObject> GetList(string sWhere, List<DbParameter> cmdParas,int nTop,string sOrderby)
        {
            m_bIsLoad = true;
            m_sWhere = sWhere;
            m_sOrderby = sOrderby;

            if (GetListPO(sWhere, cmdParas, nTop,sOrderby) == null)
                return null;

            //�ų�ɾ����Ԫ��
            List<CBaseObject> lstRet = new List<CBaseObject>();
            foreach (CBaseObject obj in m_lstObj)
            {
                if (obj.m_CmdType != CmdType.Delete)
                    lstRet.Add(obj);
            }
            return lstRet;
        }

        public virtual bool Load(string sWhere, List<DbParameter> cmdParas, string sOrderby, bool bReload)
        {
            if (m_bIsLoad && (!bReload)
                && m_sWhere.Equals(sWhere, StringComparison.OrdinalIgnoreCase)
                && m_sOrderby.Equals(sOrderby, StringComparison.OrdinalIgnoreCase))
                return true;
            m_bIsLoad = true;
            m_sWhere = sWhere;
            m_sOrderby = sOrderby;

            if (GetListPO(sWhere, cmdParas, sOrderby) == null)
                return false;
            return true;
        }

        public bool Load(string sWhere, string sOrderby, bool bReload)
        {
            return Load(sWhere, null,sOrderby, bReload);
        }
        public bool Load(string sWhere, string sOrderby)
        {
            return Load(sWhere, null,sOrderby, false);
        }
        public bool Load(string sWhere, bool bReload)
        {
            return Load(sWhere, null, "", bReload);
        }
        public bool Load(string sWhere)
        {
            return Load(sWhere, null, "", false);
        }
        public bool Load()
        {
            return Load("", null, "", false);
        }

        public CBaseObject Find(Guid id)
        {
            //foreach (CBaseObject obj in m_lstObj)
            //{
            //    if (obj.Id == id || obj.Id.ToString().Equals(id.ToString(), StringComparison.OrdinalIgnoreCase))
            //        return obj;
            //}
            if (m_sortObj.ContainsKey(id))
                return m_sortObj[id];

            return null;
        }
        //ͨ���ֶ�ֵ����,���ֶα�����Ψһ��, ���ص�һ����¼
        public CBaseObject FindByValue(CColumn col, object objVal)
        {
            if (col.Code.Equals("id", StringComparison.OrdinalIgnoreCase))
                return Find((Guid)objVal);
            else
            {
                List<CBaseObject> lstObj = GetList();
                var varObj = from obj in lstObj where obj.GetColValue(col) == objVal select obj;
                if (varObj.Count() > 0)
                    return varObj.First();
                else
                    return null;
            }
        }

        public CBaseObject GetFirstObj()
        {
            foreach (CBaseObject obj in m_lstObj)
            {
                if (obj.m_CmdType!= CmdType.Delete)
                    return obj;
            }
            return null;
        }

        //��Щ��ʱ����������Ҫ�����ݿ�װ�أ�ֱ������װ�ر�־
        public bool IsLoad
        {
            get{return m_bIsLoad;}
            set { m_bIsLoad = value; }
        }
        #region ��ͼ������������
        //��ͼ������������
        //and or ��sqlһ��,��and����or
        //�㷨:������or�ָ�ɶ��and�Ķ���,�ӵ�һ�����俪ʼѭ�����ж���,
        //ֻҪ��һ�������������������˳�ѭ��
        public List<CBaseObject> FilterByView(CView view)
        {
            List<CViewFilter> sortFilter = new List<CViewFilter>();
            List<CBaseObject> lstFilter = view.ViewFilterMgr.GetList();
            foreach (CBaseObject objF in lstFilter)
            {
                CViewFilter vf = (CViewFilter)objF;
                sortFilter.Add(vf);
            }
            sortFilter.Sort();//������idx����

            List<CBaseObject> lstRet = new List<CBaseObject>();
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                bool bPass = false;//����ͨ��
                bool bPassAnd = true;//��һ��andͨ��
                if (sortFilter.Count == 0)
                    bPass = true;
                else
                {
                    for (int i = 0; i < sortFilter.Count; i++)
                    {
                        CViewFilter vf = (CViewFilter)sortFilter[i];
                        if (i == 0)//��һ������and or
                        {
                            if (!obj.FilterByView(vf))
                                bPassAnd = false;
                        }
                        else
                        {
                            if (vf.AndOr.Equals("and", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!bPassAnd) //�����䲻ͨ��,ת����һ������
                                    continue;
                                if (!obj.FilterByView(vf))
                                    bPassAnd = false;
                            }
                            else // or
                            {
                                if (bPassAnd) //������ȫ��ͨ��,�����������������
                                {
                                    bPass = true;
                                    break;
                                }
                                bPassAnd = true;//һ�����俪ʼ
                                if (!obj.FilterByView(vf))
                                    bPassAnd = false;
                            }
                        }

                        if (i == sortFilter.Count - 1) //���һ��
                        {
                            if (bPassAnd)
                            {
                                bPass = true;
                            }
                            break;
                        }
                    }
                }
                if (bPass)
                    lstRet.Add(obj);
            }
            return lstRet;
        }

        //����ʱ���������Ĺ���
        public List<CBaseObject> FilterByView(CView view, CViewFilterMgr ViewFilterMgr)
        {
            List<CViewFilter> sortFilter = new List<CViewFilter>();
            List<CBaseObject> lstFilter = ViewFilterMgr.GetList();
            foreach (CBaseObject objF in lstFilter)
            {
                CViewFilter vf = (CViewFilter)objF;
                sortFilter.Add(vf);
            }
            sortFilter.Sort();//������idx����

            List<CBaseObject> lstRet = new List<CBaseObject>();
            List<CBaseObject> lstObj = FilterByView(view);
            if (sortFilter.Count == 0)
                return lstObj;
            foreach (CBaseObject obj in lstObj)
            {
                bool bPass = false;//����ͨ��
                bool bPassAnd = true;//��һ��andͨ��
                if (sortFilter.Count == 0)
                    bPass = true;
                else
                {
                    for (int i = 0; i < sortFilter.Count; i++)
                    {
                        CViewFilter vf = (CViewFilter)sortFilter[i];
                        if (i == 0)//��һ������and or
                        {
                            if (!obj.FilterByView(vf))
                                bPassAnd = false;
                        }
                        else
                        {
                            if (vf.AndOr.Equals("and", StringComparison.OrdinalIgnoreCase))
                            {
                                if (!bPassAnd) //�����䲻ͨ��,ת����һ������
                                    continue;
                                if (!obj.FilterByView(vf))
                                    bPassAnd = false;
                            }
                            else // or
                            {
                                if (bPassAnd) //������ȫ��ͨ��,�����������������
                                {
                                    bPass = true;
                                    break;
                                }
                                bPassAnd = true;//һ�����俪ʼ
                                if (!obj.FilterByView(vf))
                                    bPassAnd = false;
                            }
                        }

                        if (i == sortFilter.Count - 1) //���һ��
                        {
                            if (bPassAnd)
                            {
                                bPass = true;
                            }
                            break;
                        }
                    }
                }
                if (bPass)
                    lstRet.Add(obj);
            }
            return lstRet;
        }
        #endregion ��ͼ������������

        public CWorkflowMgr WorkflowMgr
        {
            get
            {
                if (workflowMgr == null)
                {
                    workflowMgr = new CWorkflowMgr();
                    workflowMgr.Ctx = this.Ctx;
                    string sWhere = string.Format(" WF_WorkflowDef_id in (select id from WF_WorkflowDef where FW_Table_id='{0}')", this.Table.Id);
                    workflowMgr.Load(sWhere, false);
                }
                return workflowMgr;
            }
            set
            {
                this.workflowMgr = value;
            }
        }
    }
}