// File:    CValue.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 22:32:15
// Purpose: Definition of Class CValue

using System;
using System.Text;

namespace ErpCoreModel.Framework
{

    /// �������ݿ��ж������͵�ֵ
    public class CValue
    {
        private Guid guidVal = Guid.Empty;
        private string strVal = "";
        private int intVal = 0;
        private long longVal = 0;
        private bool boolVal = false;
        private double doubleVal = 0.0;
        private DateTime datetimeVal = DateTime.Now;
        private object objectVal = null;

        public Guid GuidVal
        {
            get
            {
                return guidVal;
            }
            set
            {
                this.guidVal = value;
            }
        }

        public string StrVal
        {
            get
            {
                return strVal;
            }
            set
            {
                this.strVal = value;
            }
        }

        public int IntVal
        {
            get
            {
                return intVal;
            }
            set
            {
                this.intVal = value;
            }
        }

        public long LongVal
        {
            get
            {
                return longVal;
            }
            set
            {
                this.longVal = value;
            }
        }

        public bool BoolVal
        {
            get
            {
                return boolVal;
            }
            set
            {
                this.boolVal = value;
            }
        }

        public double DoubleVal
        {
            get
            {
                return doubleVal;
            }
            set
            {
                this.doubleVal = value;
            }
        }

        public DateTime DatetimeVal
        {
            get
            {
                return datetimeVal;
            }
            set
            {
                this.datetimeVal = value;
            }
        }

        public object ObjectVal
        {
            get
            {
                return objectVal;
            }
            set
            {
                this.objectVal = value;
            }
        }

        public CValue Clone()
        {
            CValue val = new CValue();
            val.GuidVal = this.GuidVal;
            val.StrVal = this.StrVal;
            val.IntVal = this.IntVal;
            val.LongVal = this.LongVal;
            val.BoolVal = this.BoolVal;
            val.DatetimeVal = this.DatetimeVal;
            val.DoubleVal = this.DoubleVal;
            val.ObjectVal = this.ObjectVal;

            return val;
        }
    }
}