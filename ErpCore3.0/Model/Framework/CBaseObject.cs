// File:    CBaseObject.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:22:52
// Purpose: Definition of Class CBaseObject

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ErpCoreModel.UI;

namespace ErpCoreModel.Framework
{

    public enum CmdType { None=0, AddNew, Update, Delete };

    public class CBaseObject : PO
    {

        public CBaseObjectMgr m_ObjectMgr = null;

        public object m_objTempData = null; //����������ʱ����

        public CmdType m_CmdType = CmdType.None; 

        //�¼�����������
        public SortedList<string/*TbCode*/, CBaseObjectMgr> m_sortSubObjectMgr = new SortedList<string, CBaseObjectMgr>();

        public CBaseObject()
        {
            ClassName = "ErpCoreModel.Framework.CBaseObject";

            Id = Guid.NewGuid();
            Created = DateTime.Now;
            Creator = Guid.Empty;
            Updated = DateTime.Now;
            Updator = Guid.Empty;
            Commit();
        }
        #region ����
        public Guid Id
        {
            get
            {
                if (m_arrNewVal.ContainsKey("id"))
                    return m_arrNewVal["id"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {        
                if (m_arrNewVal.ContainsKey("id"))
                    m_arrNewVal["id"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("id", val);
                }
            }
        }

        public DateTime Created
        {
            get
            {
                if (m_arrNewVal.ContainsKey("created"))
                    return m_arrNewVal["created"].DatetimeVal;
                else
                    return DateTime.Now;
            }
            set
            {       
                if (m_arrNewVal.ContainsKey("created"))
                    m_arrNewVal["created"].DatetimeVal = value;
                else
                {
                    CValue val = new CValue();
                    val.DatetimeVal = value;
                    m_arrNewVal.Add("created", val);
                }
            }
        }

        public Guid Creator
        {
            get
            {
                if (m_arrNewVal.ContainsKey("creator"))
                    return m_arrNewVal["creator"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {      
                if (m_arrNewVal.ContainsKey("creator"))
                    m_arrNewVal["creator"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("creator", val);
                }
            }
        }

        public DateTime Updated
        {
            get
            {
                if (m_arrNewVal.ContainsKey("updated"))
                    return m_arrNewVal["updated"].DatetimeVal;
                else
                    return DateTime.Now;
            }
            set
            {      
                if (m_arrNewVal.ContainsKey("updated"))
                    m_arrNewVal["updated"].DatetimeVal = value;
                else
                {
                    CValue val = new CValue();
                    val.DatetimeVal = value;
                    m_arrNewVal.Add("updated", val);
                }
            }
        }

        public Guid Updator
        {
            get
            {
                if (m_arrNewVal.ContainsKey("updator"))
                    return m_arrNewVal["updator"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            { 
                if (m_arrNewVal.ContainsKey("updator"))
                    m_arrNewVal["updator"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("updator", val);
                }
            }
        }
        #endregion

        #region ���¼�
        //�¼�����������
        public CBaseObjectMgr GetSubObjectMgr(string sTbCode,Type type)
        {
            string sKey=sTbCode.ToLower();
            if (m_sortSubObjectMgr.ContainsKey(sKey))
                return m_sortSubObjectMgr[sKey];

            CTable table = (CTable)Ctx.TableMgr.FindByCode(sTbCode);
            if (table == null)
                return null;
            if(table.ColumnMgr.FindByCode(string.Format("{0}_id",this.TbCode))
                ==null)
                return null;

            object obj = Activator.CreateInstance(type);
            CBaseObjectMgr objMgr = (CBaseObjectMgr)obj;
            objMgr.Ctx = Ctx;
            objMgr.TbCode = sTbCode;
            objMgr.m_Parent = this;
            string sWhere = string.Format(" {0}_id='{1}'", this.TbCode, this.Id);
            objMgr.Load(sWhere, false);
            Ctx.AddBaseObjectMgrCache(sTbCode, this.Id, objMgr);

            m_sortSubObjectMgr.Add(sKey, objMgr);
            return objMgr;
        }
        public void SetSubObjectMgr(string sTbCode, CBaseObjectMgr objMgr)
        {
            string sKey = sTbCode.ToLower();
            m_sortSubObjectMgr.Remove(sKey);
            m_sortSubObjectMgr.Add(sKey, objMgr);
        }
        #endregion 

        #region ����־û�
        public virtual bool AddNew()
        {
            if (m_CmdType != CmdType.AddNew)
                return false;
            if (AddNewPO())
                m_CmdType = CmdType.None;
            else
                return false;
            return true;
        }

        public virtual bool Update()
        {
            if (m_CmdType != CmdType.Update)
                return false;
            if (UpdatePO())
                m_CmdType = CmdType.None;
            else
                return false;
            return true;
        }

        public virtual bool Delete()
        {
            if (m_CmdType != CmdType.Delete)
                return false;
            return DeletePO();
        }

        public override bool Save()
        {
            if (m_CmdType == CmdType.AddNew)
            {
                if (!AddNew())
                    return false;
            }
            else if (m_CmdType == CmdType.Update)
            {
                if (!Update())
                    return false;
            }
            else if (m_CmdType == CmdType.Delete)
            {
                if (!Delete())
                    return false;
            }

            //�����¼�����
            foreach (KeyValuePair<string, CBaseObjectMgr> pair in m_sortSubObjectMgr)
            {
                if (!pair.Value.Save())
                    return false;
            }

            return true;
        }
        public override void Commit()
        {
            base.Commit();
            foreach (KeyValuePair<string, CBaseObjectMgr> pair in m_sortSubObjectMgr)
            {
                pair.Value.Commit();
            }
        }
        public override void Cancel()
        {
            base.Cancel();
            foreach (KeyValuePair<string, CBaseObjectMgr> pair in m_sortSubObjectMgr)
            {
                pair.Value.Cancel();
            }
        }

        public virtual CBaseObject Clone()
        {
            CBaseObject obj = null;
            if (m_ObjectMgr != null)
                obj = m_ObjectMgr.CreateBaseObject();
            else
            {
                obj = new CBaseObject();
                obj.TbCode = this.TbCode;
            }
            obj.Ctx = this.Ctx;
            foreach (KeyValuePair<string, CValue> kv in this.m_arrOldVal)
            {
                obj.m_arrOldVal[kv.Key] = kv.Value.Clone();
            }
            foreach (KeyValuePair<string, CValue> kv in this.m_arrNewVal)
            {
                obj.m_arrNewVal[kv.Key] = kv.Value.Clone();
            }
            //id���ܿ�¡
            obj.Id = Guid.NewGuid();

            return obj;
        }
        #endregion

        #region ���ز�������
        public static bool operator == (CBaseObject obj1,CBaseObject obj2)
        {
            if ((object)obj1 == null && (object)obj2 == null)
                return true;
            else if ((object)obj1 == null || (object)obj2 == null)
                return false;

            return (obj1.Id == obj2.Id && obj1.ClassName == obj2.ClassName);
        }
        public static bool operator !=(CBaseObject obj1, CBaseObject obj2)
        {
            if ((object)obj1 == null && (object)obj2 == null)
                return false;
            else if ((object)obj1 == null || (object)obj2 == null)
                return true;

            return !(obj1.Id == obj2.Id && obj1.ClassName == obj2.ClassName);
        }
        public virtual bool Equals(CBaseObject obj)
        {
            if ((object)obj == null)
                return false;
            return !(Id == obj.Id);
        }
        #endregion

        #region ����
        //���鵥����¼��������
        public virtual bool FilterByView(CViewFilter vf)
        {
            CColumn col = (CColumn)Table.ColumnMgr.Find(vf.FW_Column_id);
            if (col == null)
                return false;
            switch (col.ColType)
            {
                case ColumnType.string_type:
                case ColumnType.text_type:
                    {
                        return CompareStr(vf.Sign, m_arrOldVal[col.Code.ToLower()].StrVal, vf.Val);
                        break;
                    }
                case ColumnType.int_type:
                case ColumnType.enum_type:
                    {
                        return CompareInt(vf.Sign, m_arrOldVal[col.Code.ToLower()].IntVal, vf.Val);
                        break;
                    }
                case ColumnType.long_type:
                    {
                        return CompareLong(vf.Sign, m_arrOldVal[col.Code.ToLower()].LongVal, vf.Val);
                        break;
                    }
                case ColumnType.numeric_type:
                    {
                        return CompareDouble(vf.Sign, m_arrOldVal[col.Code.ToLower()].DoubleVal, vf.Val);
                        break;
                    }
                case ColumnType.bool_type:
                    {
                        return CompareBool(vf.Sign, m_arrOldVal[col.Code.ToLower()].BoolVal, vf.Val);
                        break;
                    }
                case ColumnType.datetime_type:
                    {
                        return CompareDateTime(vf.Sign, m_arrOldVal[col.Code.ToLower()].DatetimeVal, vf.Val);
                        break;
                    }
                case ColumnType.guid_type:
                case ColumnType.ref_type:
                    {
                        object objVal = GetRefShowColVal(col);
                        return CompareStr(vf.Sign, objVal!=null?objVal.ToString():"", vf.Val);
                        break;
                    }
                case ColumnType.object_type:
                    {
                        return CompareObject(vf.Sign, m_arrOldVal[col.Code.ToLower()].ObjectVal, vf.Val);
                        break;
                    }
                case ColumnType.path_type:
                    {
                        return ComparePath(vf.Sign, m_arrOldVal[col.Code.ToLower()].StrVal, vf.Val);
                        break;
                    }
                default:
                    break;
            }
            return false;
        }
        //�ַ����Ƚ�
        protected bool CompareStr(CompareSign Sign, string val1, string val2)
        {
            switch (Sign)
            {
                case CompareSign.Equals: //"="
                    return val1.Equals( val2, StringComparison.OrdinalIgnoreCase);
                case CompareSign.Greater://">"
                    return val1.CompareTo( val2)>0;
                case CompareSign.Less://"<"
                    return val1.CompareTo(val2) < 0;
                case CompareSign.GreaterAndEquals://">="
                    return val1.CompareTo(val2) >= 0;
                case CompareSign.LessAndEquals://"<="
                    return val1.CompareTo(val2) <= 0;
                case CompareSign.NotEquals://"!="
                    return !val1.Equals(val2, StringComparison.OrdinalIgnoreCase);
                case CompareSign.Like://"like"
                    return val1.IndexOf(val2, StringComparison.OrdinalIgnoreCase) > -1;
                default:
                    break;
            }
            return false;
        }
        //���ͱȽ�
        protected bool CompareInt(CompareSign Sign, int val1, string val2)
        {
            if (Util.IsInt(val2))
            {
                int V2 = Convert.ToInt32(val2);
                switch (Sign)
                {
                    case CompareSign.Equals: //"="
                        return val1 == V2;
                    case CompareSign.Greater://">"
                        return val1 > V2;
                    case CompareSign.Less://"<"
                        return val1 < V2;
                    case CompareSign.GreaterAndEquals://">="
                        return val1 >= V2;
                    case CompareSign.LessAndEquals://"<="
                        return val1 <= V2;
                    case CompareSign.NotEquals://"!="
                        return val1 != V2;
                    default:
                        break;
                }
            }
            return false;
        }
        //�����ͱȽ�
        protected bool CompareLong(CompareSign Sign, long val1, string val2)
        {
            if (Util.IsInt(val2))
            {
                long V2 = Convert.ToInt64(val2);
                switch (Sign)
                {
                    case CompareSign.Equals: //"="
                        return val1 == V2;
                    case CompareSign.Greater://">"
                        return val1 > V2;
                    case CompareSign.Less://"<"
                        return val1 < V2;
                    case CompareSign.GreaterAndEquals://">="
                        return val1 >= V2;
                    case CompareSign.LessAndEquals://"<="
                        return val1 <= V2;
                    case CompareSign.NotEquals://"!="
                        return val1 != V2;
                    default:
                        break;
                }
            }
            return false;
        }
        //double�ͱȽ�
        protected bool CompareDouble(CompareSign Sign, double val1, string val2)
        {
            if (val2 == "")
                val2 = "0";
            if (Util.IsNum(val2))
            {
                double V2 = Convert.ToInt32(val2);
                switch (Sign)
                {
                    case CompareSign.Equals: //"="
                        return val1 == V2;
                    case CompareSign.Greater://">"
                        return val1 > V2;
                    case CompareSign.Less://"<"
                        return val1 < V2;
                    case CompareSign.GreaterAndEquals://">="
                        return val1 >= V2;
                    case CompareSign.LessAndEquals://"<="
                        return val1 <= V2;
                    case CompareSign.NotEquals://"!="
                        return val1 != V2;
                    default:
                        break;
                }
            }
            return false;
        }
        //bool�ͱȽ�
        protected bool CompareBool(CompareSign Sign, bool val1, string val2)
        {
            bool V2 = false;
            if (val2 == "0" || val2.Equals("false", StringComparison.OrdinalIgnoreCase))
                V2 = false;
            else
                V2 = true;

            switch (Sign)
            {
                case CompareSign.Equals: //"="
                    return val1 == V2;
                case CompareSign.NotEquals://"!="
                    return val1 != V2;
                default:
                    break;
            }
            return false;
        }
        //datetime�ͱȽ�
        protected bool CompareDateTime(CompareSign Sign, DateTime val1, string val2)
        {
            try
            {
                if (val2 == "")
                    val2 = "1900-1-1";
                DateTime V2 = DateTime.Parse(val2);

                //�����Ƚ�������
                switch (Sign)
                {
                    case CompareSign.Equals: //"="
                        if (val1.Year == V2.Year
                            && val1.Month == V2.Month
                            && val1.Day == V2.Day)
                            return true;
                        else
                            return false;
                    case CompareSign.Greater://">"
                        return val1 > V2;
                    case CompareSign.Less://"<"
                        return val1 < V2;
                    case CompareSign.GreaterAndEquals://">="
                        if (val1.Year == V2.Year
                            && val1.Month == V2.Month
                            && val1.Day == V2.Day)
                            return true;
                        else
                            return val1 > V2;
                    case CompareSign.LessAndEquals://"<="
                        if (val1.Year == V2.Year
                            && val1.Month == V2.Month
                            && val1.Day == V2.Day)
                            return true;
                        else
                            return val1< V2;
                    case CompareSign.NotEquals://"!="
                        if (val1.Year == V2.Year
                            && val1.Month == V2.Month
                            && val1.Day == V2.Day)
                            return false;
                        else
                            return true;
                    default:
                        break;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        //object�ͱȽ�
        //�����ƽ��ж��Ƿ�Ϊ��
        protected bool CompareObject(CompareSign Sign, object val1, string val2)
        {
            bool bIsNull = false;
            if (string.IsNullOrEmpty(val2) || val2.Equals("null", StringComparison.OrdinalIgnoreCase))
                bIsNull = true;

            switch (Sign)
            {
                case CompareSign.Equals: //"="
                    if (bIsNull)
                        return val1 == null;
                    else
                        return val1 != null;
                case CompareSign.NotEquals://"!="
                    if (bIsNull)
                        return val1 != null;
                    else
                        return val1 == null;
                default:
                    break;
            }
            return false;
        }
        //path�ͱȽ�
        //�����ͽ��ж��Ƿ�Ϊ��
        protected bool ComparePath(CompareSign Sign, string val1, string val2)
        {
            bool bIsNull = false;
            if (string.IsNullOrEmpty(val2) || val2.Equals("null", StringComparison.OrdinalIgnoreCase))
                bIsNull = true;

            switch (Sign)
            {
                case CompareSign.Equals: //"="
                    if (bIsNull)
                        return string.IsNullOrEmpty(val1);
                    else
                        return !string.IsNullOrEmpty(val1);
                case CompareSign.NotEquals://"!="
                    if (bIsNull)
                        return !string.IsNullOrEmpty(val1);
                    else
                        return string.IsNullOrEmpty(val1);
                default:
                    break;
            }
            return false;
        }
        #endregion ����

        #region �����ֶ�����
                
        //��ȡ�����ֶε���ʾֵ
        public object GetRefShowColVal(CColumn col)
        {
            CTable RefTable = (CTable)Ctx.TableMgr.Find(col.RefTable);
            CColumn RefCol = (CColumn)RefTable.ColumnMgr.Find(col.RefCol);
            CColumn RefShowCol = (CColumn)RefTable.ColumnMgr.Find(col.RefShowCol);
            object localVal = GetColValue(col);
            //������������
            CBaseObjectMgr BaseObjectMgr = Ctx.FindBaseObjectMgrCache(RefTable.Code, Guid.Empty);
            if (BaseObjectMgr == null)
            {
                BaseObjectMgr = new CBaseObjectMgr();
                BaseObjectMgr.TbCode = RefTable.Code;
                BaseObjectMgr.Ctx = Ctx;
                string sWhere =string.Format("{0}=",RefCol.Code);
                string sVal = localVal.ToString();
                if (col.ColType == ColumnType.string_type
                    || col.ColType == ColumnType.guid_type
                    || col.ColType == ColumnType.ref_type
                    || col.ColType == ColumnType.enum_type
                    || col.ColType == ColumnType.datetime_type
                    || col.ColType == ColumnType.text_type
                    || col.ColType == ColumnType.path_type)
                    sVal = string.Format("'{0}'",sVal);
                sWhere += sVal;
                BaseObjectMgr.Load(sWhere);
                List<CBaseObject> lstObjRef = BaseObjectMgr.GetList();
                if (lstObjRef.Count == 0)
                    return null;
                return lstObjRef[0].GetColValue(RefShowCol);
            }
            else
            {
                List<CBaseObject> lstObjRef = BaseObjectMgr.GetList();

                var varObj = from objRef in lstObjRef 
                             where (localVal.ToString().Equals( objRef.GetColValue(RefCol).ToString(), StringComparison.OrdinalIgnoreCase)) 
                             select objRef;

                if (varObj.Count() == 0)
                    return null;
                CBaseObject obj = varObj.ToList().First();
                return obj.GetColValue(RefShowCol);
            }
        }
        #endregion
    }
}