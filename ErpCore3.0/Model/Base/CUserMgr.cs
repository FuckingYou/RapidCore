// File:    CUserMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:43:29
// Purpose: Definition of Class CUserMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CUserMgr : CBaseObjectMgr
    {
        public CUserMgr()
        {
            TbCode = "B_User";
            ClassName = "ErpCoreModel.Base.CUser";
        }

        public CUser FindByName(string sName)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CUser user = (CUser)obj;
                if (user.Name.Equals(sName, StringComparison.OrdinalIgnoreCase))
                    return user;
            }
            return null;
        }

    }
}