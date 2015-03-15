// File:    CRowAccessInUserMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��10�� 14:50:19
// Purpose: Definition of Class CRowAccessInUserMgr

using System;
using System.Text;
using System.Collections.Generic;
using ErpCoreModel.Framework;

namespace ErpCoreModel.Base
{

    public class CReportAccessInUserMgr : CBaseObjectMgr
    {
        public CReportAccessInUserMgr()
        {
            TbCode = "B_ReportAccessInUser";
            ClassName = "ErpCoreModel.Base.CReportAccessInUser";
        }
        public CReportAccessInUser FindByReport(Guid RPT_Report_id)
        {
            List<CBaseObject> lstObj = GetList();
            foreach (CBaseObject obj in lstObj)
            {
                CReportAccessInUser raiu = (CReportAccessInUser)obj;
                if (raiu.RPT_Report_id == RPT_Report_id)
                    return raiu;
            }
            return null;
        }
    }
}