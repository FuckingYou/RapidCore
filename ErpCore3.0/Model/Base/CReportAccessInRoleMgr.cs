// File:    CRowAccessInOrgMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��10�� 14:46:36
// Purpose: Definition of Class CRowAccessInOrgMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CReportAccessInRoleMgr : CBaseObjectMgr
    {
        public CReportAccessInRoleMgr()
        {
            TbCode = "B_ReportAccessInRole";
            ClassName = "ErpCoreModel.Base.CReportAccessInRole";
        }
        public CReportAccessInRole FindByReport(Guid RPT_Report_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CReportAccessInRole rair = (CReportAccessInRole)obj;
                if (rair.RPT_Report_id == RPT_Report_id)
                    return rair;
            }
            return null;
        }
    }
}