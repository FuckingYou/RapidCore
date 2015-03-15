// File:    DbHelperSQLite.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:37:16
// Purpose: Definition of Class DbHelperSQLite
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Data.SQLite;

namespace ErpCoreModel.Framework
{
    /// <summary>
    /// ���ݷ��ʻ�����
    /// </summary>
    public class DbHelperSqlite
    {
        //public string m_connectionString = "Data Source=Test.db3;Pooling=true;FailIfMissing=false";     		
        private string m_connectionString = "";
        SQLiteConnection m_conn = new SQLiteConnection();
        SQLiteTransaction m_transaction = null;
        string m_sPwd = "";//��������

        public DbHelperSqlite(string connStr)
        {
            ConnectionString = connStr;
        }

        public string Pwd
        {
            get { return m_sPwd; }
            set { m_sPwd = value; }
        }
        public SQLiteConnection Conn
        {
            get { return m_conn; }
            set { m_conn = value; }
        }
        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                this.m_connectionString = value;
            }
        }
        public SQLiteTransaction Transaction
        {
            get { return m_transaction; }
        }

        #region �򿪹ر�
        public bool OpenConn()
        {
            if (Conn.State != ConnectionState.Open)
            {
                try { Conn.Close(); }
                catch { }
                try
                {
                    Conn.ConnectionString = ConnectionString;
                    Conn.Open();
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public bool CloseConn()
        {
            try
            {
                Conn.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region ����
        public void BeginTransaction()
        {
            try
            {
                m_transaction = Conn.BeginTransaction();
            }
            catch { }
        }
        public void CommitTransaction()
        {
            try
            {
                if (m_transaction != null)
                    m_transaction.Commit();
            }
            catch { }
            m_transaction = null;
        }
        public void RollbackTransaction()
        {
            try
            {
                if (m_transaction != null)
                    m_transaction.Rollback();
            }
            catch { }
            m_transaction = null;
        }
        #endregion

        #region ���÷���
       
        public  int GetMaxID(string FieldName, string TableName)
        {
            string sSql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(sSql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public  bool Exists(string sSql)
        {
            object obj = GetSingle(sSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public  bool Exists(string sSql, List<SQLiteParameter> cmdParms)
        {
            object obj = GetSingle(sSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        #endregion

        #region  ִ�м�SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="sSql">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public  int ExecuteSql(string sSql)
        {
            if(!OpenConn())
                return -1;

            using (SQLiteCommand cmd = new SQLiteCommand(sSql, Conn))
            {
                try
                {
                    if (Transaction != null)
                        cmd.Transaction = Transaction;
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SQLite.SQLiteException E)
                {
                    //throw new Exception(E.Message);
                    return -1;
                }
            }
        }

        /// <summary>
        /// �����ݿ������/�޸�ͼ���ʽ���ֶ�
        /// </summary>
        /// <param name="sSql">SQL���</param>
        /// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public int ExecuteSqlImg(string sSql, byte[] fs)
        {
            if (!OpenConn())
                return -1;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sSql, Conn))
                {
                    if (Transaction != null)
                        cmd.Transaction = Transaction;
                    System.Data.SQLite.SQLiteParameter myParameter = new System.Data.SQLite.SQLiteParameter("@fs", DbType.Binary);
                    myParameter.Value = fs;
                    cmd.Parameters.Add(myParameter);
                    
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="sSql">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public  object GetSingle(string sSql)
        {
            if (!OpenConn())
                return null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sSql, Conn))
                {
                    if (Transaction != null)
                        cmd.Transaction = Transaction;
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// ִ�в�ѯ��䣬����SQLiteDataReader
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>SQLiteDataReader</returns>
        public  SQLiteDataReader ExecuteReader(string sSql)
        {
            if (!OpenConn())
                return null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sSql, Conn))
                {
                    if (Transaction != null)
                        cmd.Transaction = Transaction;
                    SQLiteDataReader myReader = cmd.ExecuteReader();
                    return myReader;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataSet</returns>
        public  DataSet Query(string sSql)
        {
            if (!OpenConn())
                return null;
            try
            {
                DataSet ds = new DataSet();
                SQLiteDataAdapter Adapter = new SQLiteDataAdapter(sSql, Conn);
                Adapter.Fill(ds, "T");

                return ds;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataSet</returns>
        public DataTable QueryT(string sSql)
        {
            if (!OpenConn())
                return null;
            try
            {
                DataSet ds = new DataSet();
                SQLiteDataAdapter Adapter = new SQLiteDataAdapter(sSql, Conn);
                Adapter.Fill(ds, "T");

                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="sSql">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public  int ExecuteSql(string sSql, List<SQLiteParameter> cmdParms)
        {
            if (!OpenConn())
                return -1;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    PrepareCommand(cmd, Conn, Transaction, sSql, cmdParms);
                    int rows = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return rows;
                }
            }
            catch
            {
                return -1;
            }
        }



        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="sSql">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public  object GetSingle(string sSql, List<SQLiteParameter> cmdParms)
        {
            if (!OpenConn())
                return null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    PrepareCommand(cmd, Conn, Transaction, sSql, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����SQLiteDataReader
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>SQLiteDataReader</returns>
        public  SQLiteDataReader ExecuteReader(string sSql, List<SQLiteParameter> cmdParms)
        {
            if (!OpenConn())
                return null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    PrepareCommand(cmd, Conn, Transaction, sSql, cmdParms);
                    SQLiteDataReader myReader = cmd.ExecuteReader();
                    cmd.Parameters.Clear();
                    return myReader;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataSet</returns>
        public  DataSet Query(string sSql, List<SQLiteParameter> cmdParms)
        {
            if (!OpenConn())
                return null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    PrepareCommand(cmd, Conn, Transaction, sSql, cmdParms);
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds, "T");
                        cmd.Parameters.Clear();
                        return ds;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataTable</returns>
        public DataTable QueryT(string sSql, List<SQLiteParameter> cmdParms)
        {
            if (!OpenConn())
                return null;
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    PrepareCommand(cmd, Conn, Transaction, sSql, cmdParms);
                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds, "T");
                        cmd.Parameters.Clear();
                        return ds.Tables[0];
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        private  void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, SQLiteTransaction trans, string cmdText,List<SQLiteParameter> cmdParms)
        {
            if (!OpenConn())
                return;

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

    

    }
}

