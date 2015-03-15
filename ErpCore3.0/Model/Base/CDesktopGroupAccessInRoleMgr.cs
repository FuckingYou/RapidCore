// File:    CAccessInOrgMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:43:37
// Purpose: Definition of Class CAccessInOrgMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CDesktopGroupAccessInRoleMgr : CBaseObjectMgr
    {

        public CDesktopGroupAccessInRoleMgr()
        {
            TbCode = "B_DesktopGroupAccessInRole";
            ClassName = "ErpCoreModel.Base.CDesktopGroupAccessInRole";
        }
        public CDesktopGroupAccessInRole FindByDesktopGroup(Guid UI_DesktopGroup_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CDesktopGroupAccessInRole dgair = (CDesktopGroupAccessInRole)obj;
                if (dgair.UI_DesktopGroup_id == UI_DesktopGroup_id)
                    return dgair;
            }
            return null;
        }
    }
}