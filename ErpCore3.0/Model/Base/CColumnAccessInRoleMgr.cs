// File:    CColumnAccessInOrgMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��10�� 14:46:37
// Purpose: Definition of Class CColumnAccessInOrgMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CColumnAccessInRoleMgr : CBaseObjectMgr
    {
        public CColumnAccessInRoleMgr()
        {
            TbCode = "B_ColumnAccessInRole";
            ClassName = "ErpCoreModel.Base.CColumnAccessInRole";
        }

        public CColumnAccessInRole FindByColumn(Guid FW_Column_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CColumnAccessInRole cair = (CColumnAccessInRole)obj;
                if (cair.FW_Column_id == FW_Column_id)
                    return cair;
            }
            return null;
        }
    }
}