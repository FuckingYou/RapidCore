// File:    CUserInRoleMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��16�� 13:04:59
// Purpose: Definition of Class CUserInRoleMgr

using System;
using System.Text;
using ErpCoreModel.Framework;
using System.Collections.Generic;

namespace ErpCoreModel.Base
{
   public class CUserInRoleMgr : CBaseObjectMgr
   {
        public CUserInRoleMgr()
        {
            TbCode = "B_UserInRole";
            ClassName = "ErpCoreModel.Base.CUserInRole";
        }

        public CUserInRole FindByUserid( Guid B_User_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CUserInRole uir = (CUserInRole)obj;
                if (uir.B_User_id == B_User_id)
                    return uir;
            }
            return null;
        }
   }
}