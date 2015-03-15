// File:    CSystem.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 12:40:36
// Purpose: Definition of Class CSystem

using System;
using System.Text;
using ErpCoreModel.Framework;

namespace ErpCoreModel.SubSystem
{

    public class CSystem : CBaseObject
    {
        public CSystem()
        {
            TbCode = "S_System";
            ClassName = "ErpCoreModel.SubSystem.CSystem";

            Name = "";
            FW_Diagram_id = Guid.Empty;
            Icon = null;
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
        public Guid FW_Diagram_id
        {
            get
            {
                if (m_arrNewVal.ContainsKey("fw_diagram_id"))
                    return m_arrNewVal["fw_diagram_id"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("fw_diagram_id"))
                    m_arrNewVal["fw_diagram_id"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("fw_diagram_id", val);
                }
            }
        }

        public object Icon
        {
            get
            {
                if (m_arrNewVal.ContainsKey("icon"))
                    return m_arrNewVal["icon"].ObjectVal;
                else
                    return null;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("icon"))
                    m_arrNewVal["icon"].ObjectVal = value;
                else
                {
                    CValue val = new CValue();
                    val.ObjectVal = value;
                    m_arrNewVal.Add("icon", val);
                }
            }
        }
        public Guid StartWindow
        {
            get
            {
                if (m_arrNewVal.ContainsKey("startwindow"))
                    return m_arrNewVal["startwindow"].GuidVal;
                else
                    return Guid.Empty;
            }
            set
            {
                if (m_arrNewVal.ContainsKey("startwindow"))
                    m_arrNewVal["startwindow"].GuidVal = value;
                else
                {
                    CValue val = new CValue();
                    val.GuidVal = value;
                    m_arrNewVal.Add("startwindow", val);
                }
            }
        }
    }
}