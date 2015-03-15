// File:    CTableAccessInUserMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��10�� 14:50:20
// Purpose: Definition of Class CTableAccessInUserMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CTableAccessInUserMgr : CBaseObjectMgr
    {
        public CTableAccessInUserMgr()
        {
            TbCode = "B_TableAccessInUser";
            ClassName = "ErpCoreModel.Base.CTableAccessInUser";
        }

        public CTableAccessInUser FindByTable(Guid FW_Table_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CTableAccessInUser taiu = (CTableAccessInUser)obj;
                if (taiu.FW_Table_id == FW_Table_id)
                    return taiu;
            }
            return null;
        }
    }
}