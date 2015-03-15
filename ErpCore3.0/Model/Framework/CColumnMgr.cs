// File:    CColumnMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:38:28
// Purpose: Definition of Class CColumnMgr

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ErpCoreModel.Framework
{
    public class CColumnMgr : CBaseObjectMgr
    {
        public CColumnMgr()
        {
            TbCode = "FW_Column";
            ClassName = "ErpCoreModel.Framework.CColumn";
        }

        public CColumn FindByName(string sName)
        {
            List<CBaseObject> lstColumn = this.GetList();
            foreach (CBaseObject obj in lstColumn)
            {
                CColumn column = (CColumn)obj;
                if (column.Name.Equals(sName, StringComparison.OrdinalIgnoreCase))
                    return column;
            }
            return null;
        }
        public CColumn FindByCode(string sCode)
        {
            List<CBaseObject> lstColumn = this.GetList();
            foreach (CBaseObject obj in lstColumn)
            {
                CColumn column = (CColumn)obj;
                if (column.Code.Equals(sCode, StringComparison.OrdinalIgnoreCase))
                    return column;
            }
            return null;
        }

        //Ĭ�ϰ���������
        public override List<CBaseObject> GetList()
        {
            List<CBaseObject> lstObj = base.GetList();
            var varObj = from obj in lstObj orderby (obj as CColumn).Idx select obj;
            return varObj.ToList();
        }
    }
}