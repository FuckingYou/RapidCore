// File:    CSystemMgr.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:43:28
// Purpose: Definition of Class CSystemMgr

using System;
using System.Text;
using ErpCoreModel.Framework;

namespace ErpCoreModel.SubSystem
{

    public class CSystemMgr : CBaseObjectMgr
    {
        public CSystemMgr()
        {
            TbCode = "S_System";
            ClassName = "ErpCoreModel.SubSystem.CSystem";
        }
    }
}