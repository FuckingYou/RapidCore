// File:    CDiagram.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 12:40:36
// Purpose: Definition of Class CDiagram

using System;
using System.Text;
using System.Collections.Generic;

namespace ErpCoreModel.Framework
{
    
    public enum DiagramType
    {
        Normal,
        SubSystem
    }
    public class CDiagram : CBaseObject
    {

        public CDiagram()
        {
            TbCode = "FW_Diagram";
            ClassName = "ErpCoreModel.Framework.CDiagram";

            Name = "";
            DType = DiagramType.Normal;
        }
        public string Name
        {
            get
            {
                if (m_arrNewVal.ContainsKey("name"))
                    return m_arrNewVal["name"].StrVal;
                else
                    return "";
            }
            set
            {
                if (m_arrNewVal.ContainsKey("name"))
                    m_arrNewVal["name"].StrVal = value;
                else
                {
                    CValue val = new CValue();
                    val.StrVal = value;
                    m_arrNewVal.Add("name", val);
                }
            }
        }


        public DiagramType DType
        {
            get
            {
                if (m_arrNewVal.ContainsKey("dtype"))
                    return (DiagramType)m_arrNewVal["dtype"].IntVal;
                else
                    return DiagramType.Normal;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("dtype"))
                    m_arrNewVal["dtype"].IntVal = (int)value;
                else
                {
                    CValue val = new CValue();
                    val.IntVal = (int)value;
                    m_arrNewVal.Add("dtype", val);
                }
            }
        }


        public CTableInDiagramMgr TableInDiagramMgr
        {
            get
            {
                return (CTableInDiagramMgr)this.GetSubObjectMgr("FW_TableInDiagram", typeof(CTableInDiagramMgr));
            }
            set
            {
                this.SetSubObjectMgr("FW_TableInDiagram", value);
            }
        }

    }
}