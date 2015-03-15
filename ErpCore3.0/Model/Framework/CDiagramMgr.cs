// File:    CDiagramMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:38:50
// Purpose: Definition of Class CDiagramMgr

using System;
using System.Text;
using System.Collections.Generic;

namespace ErpCoreModel.Framework
{
    public class CDiagramMgr : CBaseObjectMgr
    {

        public CDiagramMgr()
        {
            TbCode = "FW_Diagram";
            ClassName = "ErpCoreModel.Framework.CDiagram";
        }

        public CDiagram FindByName(string sName)
        {
            List<CBaseObject> lstTable = this.GetList();
            foreach (CBaseObject obj in lstTable)
            {
                CDiagram diagram = (CDiagram)obj;
                if (diagram.Name.Equals(sName, StringComparison.OrdinalIgnoreCase))
                    return diagram;
            }
            return null;
        }
    }
}