// File:    CUserInRole.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��16�� 13:05:01
// Purpose: Definition of Class CUserInRole

using System;
using System.Text;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{
   public class CUserInRole : CBaseObject
   {
       public CUserInRole()
       {
           TbCode = "B_UserInRole";
           ClassName = "ErpCoreModel.Base.CUserInRole";
       }

       public Guid B_Role_id
       {
           get
           {
               if (m_arrNewVal.ContainsKey("b_role_id"))
                   return m_arrNewVal["b_role_id"].GuidVal;
               else
                   return Guid.Empty;
           }
           set
           {
               if (m_arrNewVal.ContainsKey("b_role_id"))
                   m_arrNewVal["b_role_id"].GuidVal = value;
               else
               {
                   CValue val = new CValue();
                   val.GuidVal = value;
                   m_arrNewVal.Add("b_role_id", val);
               }
           }
       }
       public Guid B_User_id
       {
           get
           {
               if (m_arrNewVal.ContainsKey("b_user_id"))
                   return m_arrNewVal["b_user_id"].GuidVal;
               else
                   return Guid.Empty;
           }
           set
           {
               if (m_arrNewVal.ContainsKey("b_user_id"))
                   m_arrNewVal["b_user_id"].GuidVal = value;
               else
               {
                   CValue val = new CValue();
                   val.GuidVal = value;
                   m_arrNewVal.Add("b_user_id", val);
               }
           }
       }
   }
}