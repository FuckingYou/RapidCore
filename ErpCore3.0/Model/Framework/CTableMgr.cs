// File:    CTableMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:37:16
// Purpose: Definition of Class CTableMgr

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ErpCoreModel.Framework
{
    public class CTableMgr : CBaseObjectMgr
    {
        public CTableMgr()
        {
            TbCode = "FW_Table";
            ClassName = "ErpCoreModel.Framework.CTable";
        }

        public CTable FindByName(string sName)
        {
            List<CBaseObject> lstTable = this.GetList();
            foreach (CBaseObject obj in lstTable)
            {
                CTable table = (CTable)obj;
                if (table.Name.Equals(sName, StringComparison.OrdinalIgnoreCase))
                    return table;
            }
            return null;
        }
        public CTable FindByCode(string sCode)
        {
            List<CBaseObject> lstTable = this.GetList();
            foreach (CBaseObject obj in lstTable)
            {
                CTable table = (CTable)obj;
                if (table.Code.Equals(sCode, StringComparison.OrdinalIgnoreCase))
                    return table;
            }
            return null;
        }

        //Ĭ�ϰ���������
        public override List<CBaseObject> GetList()
        {
            List<CBaseObject> lstObj = base.GetList();
            var varObj = from obj in lstObj orderby (obj as CTable).Code select obj;
            return varObj.ToList();
        }
    }
}