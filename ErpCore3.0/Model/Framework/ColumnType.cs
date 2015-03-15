// File:    ColumnType.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 22:42:57
// Purpose: Definition of Enum ColumnType

using System;
using System.Text;

namespace ErpCoreModel.Framework
{
    
    public enum ColumnType
    {
        string_type,
        int_type,
        long_type,
        bool_type,
        numeric_type,
        datetime_type,
        text_type,
        object_type,
        ref_type,
        guid_type,
        enum_type,
        path_type
    }
}