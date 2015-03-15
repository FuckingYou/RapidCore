// File:    COrgMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:43:28
// Purpose: Definition of Class COrgMgr

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class COrgMgr : CBaseObjectMgr
    {
        public COrgMgr()
        {
            TbCode = "B_Org";
            ClassName = "ErpCoreModel.Base.COrg";
        }

        public COrg FindByName(string sName)
        {
            List<CBaseObject> lstObj = GetList();
            var varObj = from obj in lstObj
                         where (obj as COrg).Name.Equals(sName, StringComparison.OrdinalIgnoreCase)
                         select obj;
            if (varObj.Count() > 0)
                return varObj.First() as COrg;
            else
                return null;

        }

        public List<COrg> FindByUser(Guid B_User_id)
        {
            List<COrg> ret = new List<COrg>();
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                COrg Org = (COrg)obj;
                if (Org.UserInOrgMgr.FindByUser(B_User_id) != null)
                    ret.Add(Org);
            }
            return ret;
        }
        //��ȡ�¼�
        public List<CBaseObject> GetChildList(Guid Parent_id)
        {
            List<CBaseObject> lstObj =GetList();
            var varObj = from obj in lstObj where (obj as COrg).Parent_id == Parent_id select obj;
            return varObj.ToList();
        }
    }
}