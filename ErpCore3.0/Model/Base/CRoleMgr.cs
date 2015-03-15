// File:    CRoleMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��16�� 12:49:34
// Purpose: Definition of Class CRoleMgr

using System;
using System.Text;
using ErpCoreModel.Framework;
using System.Collections.Generic;

namespace ErpCoreModel.Base
{
   public class CRoleMgr : CBaseObjectMgr
   {

       public CRoleMgr()
       {
           TbCode = "B_Role";
           ClassName = "ErpCoreModel.Base.CRole";
       }

       public CRole FindByName(string sName)
       {
           List<CBaseObject> lstObj = GetList();
           foreach (CBaseObject obj in lstObj)
           {
               CRole role = (CRole)obj;
               if (role.Name.Equals(sName, StringComparison.OrdinalIgnoreCase))
                   return role;
           }
           return null;
       }
   }
}