// File:    CColumnAccessInUserMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��10�� 14:50:21
// Purpose: Definition of Class CColumnAccessInUserMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CColumnAccessInUserMgr : CBaseObjectMgr
    {
        public CColumnAccessInUserMgr()
        {
            TbCode = "B_ColumnAccessInUser";
            ClassName = "ErpCoreModel.Base.CColumnAccessInUser";
        }

        public CColumnAccessInUser FindByColumn(Guid FW_Column_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CColumnAccessInUser caiu = (CColumnAccessInUser)obj;
                if (caiu.FW_Column_id == FW_Column_id)
                    return caiu;
            }
            return null;
        }
    }
}