// File:    DB.cs
// Author:  ��Т��
// email:   ganxiaojian@hotmail.com 
// QQ:      154986287
// http://www.8088net.com
// Э�������������Ϊ��Դϵͳ����ѭ���ʿ�Դ��֯Э�顣�κε�λ����˿���ʹ�û��޸ı����Դ�룬
//          ����������Ϊ����ҵ����ҵ��;��������ʹ�ñ�Դ���������һ�к���������޹ء�
//          δ��������ɣ���ֹ�κ���ҵ�����ֱ�ӳ��۱�Դ����߰ѱ������Ϊ�����Ĺ��ܽ������ۻ��
//          ���߽�����׷�����ε�Ȩ����
// Created: 2011��7��9�� 13:37:16
// Purpose: Definition of Class DbHelperOleDb
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace ErpCoreModel.Framework
{
    public enum DatabaseType { OleDb,Sqlite,MySql};
    /// <summary>
    /// ���ݷ��ʻ�����
    /// </summary>
    public class DB
    {
        //public string m_connectionString = "Provider=SQLOLEDB.1;Password=sa;Persist Security Info=True;User ID=sa;Initial Catalog=ErpCore;Data Source=(local)";     		
        private string m_connectionString = "";

        public DatabaseType m_DbType = DatabaseType.OleDb;
        DbHelperOleDb m_DbHelperOleDb = null;
        DbHelperSqlite m_DbHelperSqlite = null;
        DbHelperMySql m_DbHelperMySql = null;

        public DB(string connStr)
        {
            ConnectionString = connStr;
        }
        ~DB()
        {
            CloseConn();
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
                if (this.m_connectionString.IndexOf("OleDb", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    m_DbType = DatabaseType.OleDb;
                    if (m_DbHelperOleDb == null)
                        m_DbHelperOleDb = new DbHelperOleDb(this.m_connectionString);
                }
                else if (this.m_connectionString.IndexOf("Port", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    m_DbType = DatabaseType.MySql;
                    if(m_DbHelperMySql==null)
                        m_DbHelperMySql = new DbHelperMySql(this.m_connectionString);
                }
                else
                {
                    m_DbType = DatabaseType.Sqlite;
                    if(m_DbHelperSqlite==null)
                        m_DbHelperSqlite = new DbHelperSqlite(this.m_connectionString);
                }
            }
        }


        #region �򿪹ر�
        public bool OpenConn()
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.OpenConn();
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.OpenConn();
            else
                return m_DbHelperSqlite.OpenConn();
        }
        public bool CloseConn()
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.CloseConn();
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.CloseConn();
            else
                return m_DbHelperSqlite.CloseConn();
        }
        #endregion

        #region ����
        public void BeginTransaction()
        {
            if (m_DbType == DatabaseType.OleDb)
                m_DbHelperOleDb.BeginTransaction();
            else if (m_DbType == DatabaseType.MySql)
                m_DbHelperMySql.BeginTransaction();
            else
                m_DbHelperSqlite.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (m_DbType == DatabaseType.OleDb)
                m_DbHelperOleDb.CommitTransaction();
            else if (m_DbType == DatabaseType.MySql)
                m_DbHelperMySql.CommitTransaction();
            else
                m_DbHelperSqlite.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            if (m_DbType == DatabaseType.OleDb)
                m_DbHelperOleDb.RollbackTransaction();
            else if (m_DbType == DatabaseType.MySql)
                m_DbHelperMySql.RollbackTransaction();
            else
                m_DbHelperSqlite.RollbackTransaction();
        }
        #endregion

        #region ���÷���

        public  int GetMaxID(string sFieldName, string sTableName)
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.GetMaxID(sFieldName, sTableName);
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.GetMaxID(sFieldName, sTableName);
            else
                return m_DbHelperSqlite.GetMaxID(sFieldName, sTableName);
        }
        public  bool Exists(string sSql)
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.Exists(sSql);
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.Exists(sSql);
            else
                return m_DbHelperSqlite.Exists(sSql);
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
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.ExecuteSql(sSql);
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.ExecuteSql(sSql);
            else
                return m_DbHelperSqlite.ExecuteSql(sSql);
        }

        /// <summary>
        /// �����ݿ������/�޸�ͼ���ʽ���ֶ�
        /// </summary>
        /// <param name="sSql">SQL���</param>
        /// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public int ExecuteSqlImg(string sSql, byte[] fs)
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.ExecuteSqlImg(sSql, fs);
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.ExecuteSqlImg(sSql, fs);
            else
                return m_DbHelperSqlite.ExecuteSqlImg(sSql, fs);
        }

        /// <summary>
        /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
        /// </summary>
        /// <param name="sSql">�����ѯ������</param>
        /// <returns>��ѯ�����object��</returns>
        public  object GetSingle(string sSql)
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.GetSingle(sSql);
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.GetSingle(sSql);
            else
                return m_DbHelperSqlite.GetSingle(sSql);

        }
        
        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataSet</returns>
        public  DataSet Query(string sSql)
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.Query(sSql);
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.Query(sSql);
            else
                return m_DbHelperSqlite.Query(sSql);

        }

        /// <summary>
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataTable</returns>
        public DataTable QueryT(string sSql)
        {
            if (m_DbType == DatabaseType.OleDb)
                return m_DbHelperOleDb.QueryT(sSql);
            else if (m_DbType == DatabaseType.MySql)
                return m_DbHelperMySql.QueryT(sSql);
            else
                return m_DbHelperSqlite.QueryT(sSql);

        }

        #endregion

        #region ִ�д�������SQL���

        /// <summary>
        /// ִ��SQL��䣬����Ӱ��ļ�¼��
        /// </summary>
        /// <param name="sSql">SQL���</param>
        /// <returns>Ӱ��ļ�¼��</returns>
        public  int ExecuteSql(string sSql, List<DbParameter> cmdParms)
        {
            if (m_DbType == DatabaseType.OleDb)
            {
                List<OleDbParameter> lstParam = new List<OleDbParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        OleDbParameter opara = new OleDbParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperOleDb.ExecuteSql(sSql, lstParam);
            }
            else if (m_DbType == DatabaseType.MySql)
            {
                List<MySqlParameter> lstParam = new List<MySqlParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        MySqlParameter opara = new MySqlParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperMySql.ExecuteSql(sSql, lstParam);
            }
            else
            {
                List<SQLiteParameter> lstParam = new List<SQLiteParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        SQLiteParameter opara = new SQLiteParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperSqlite.ExecuteSql(sSql, lstParam);
            }
        }


        /// <summary>
        /// ִ�в�ѯ��䣬����DataSet
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataSet</returns>
        public  DataSet Query(string sSql, List<DbParameter> cmdParms)
        {
            if (m_DbType == DatabaseType.OleDb)
            {
                List<OleDbParameter> lstParam = new List<OleDbParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        OleDbParameter opara = new OleDbParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperOleDb.Query(sSql, lstParam);
            }
            else if (m_DbType == DatabaseType.MySql)
            {
                List<MySqlParameter> lstParam = new List<MySqlParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        MySqlParameter opara = new MySqlParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperMySql.Query(sSql, lstParam);
            }
            else
            {
                List<SQLiteParameter> lstParam = new List<SQLiteParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        SQLiteParameter opara = new SQLiteParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperSqlite.Query(sSql, lstParam);
            }
        }


        /// <summary>
        /// ִ�в�ѯ��䣬����DataTable
        /// </summary>
        /// <param name="sSql">��ѯ���</param>
        /// <returns>DataTable</returns>
        public DataTable QueryT(string sSql, List<DbParameter> cmdParms)
        {
            if (m_DbType == DatabaseType.OleDb)
            {
                List<OleDbParameter> lstParam = new List<OleDbParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        OleDbParameter opara = new OleDbParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperOleDb.QueryT(sSql, lstParam);
            }
            else if (m_DbType == DatabaseType.MySql)
            {
                List<MySqlParameter> lstParam = new List<MySqlParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        MySqlParameter opara = new MySqlParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperMySql.QueryT(sSql, lstParam);
            }
            else
            {
                List<SQLiteParameter> lstParam = new List<SQLiteParameter>();
                if (cmdParms != null)
                {
                    foreach (DbParameter p in cmdParms)
                    {
                        SQLiteParameter opara = new SQLiteParameter();
                        opara.ParameterName = p.ParameterName;
                        opara.Value = p.Value;
                        lstParam.Add(opara);
                    }
                }
                return m_DbHelperSqlite.QueryT(sSql, lstParam);
            }
        }


        #endregion


    }
}
