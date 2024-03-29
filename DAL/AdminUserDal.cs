﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:AdminUser
	/// </summary>
	public partial class AdminUserDal
	{
		public AdminUserDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("SuId", "tb_AdminUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SuId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_AdminUser");
			strSql.Append(" where SuId=@SuId");
			SqlParameter[] parameters = {
					new SqlParameter("@SuId", SqlDbType.Int,4)
			};
			parameters[0].Value = SuId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(AdminUserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_AdminUser(");
			strSql.Append("UserName,Pwd,role)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Pwd,@role)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,50),
					new SqlParameter("@role", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.role;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(AdminUserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_AdminUser set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("role=@role");
			strSql.Append(" where SuId=@SuId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Pwd", SqlDbType.NVarChar,50),
					new SqlParameter("@role", SqlDbType.Int,4),
					new SqlParameter("@SuId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.role;
			parameters[3].Value = model.SuId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int SuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_AdminUser ");
			strSql.Append(" where SuId=@SuId");
			SqlParameter[] parameters = {
					new SqlParameter("@SuId", SqlDbType.Int,4)
			};
			parameters[0].Value = SuId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string SuIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_AdminUser ");
			strSql.Append(" where SuId in ("+SuIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public AdminUserModel GetModel(int SuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 SuId,UserName,Pwd,role from tb_AdminUser ");
			strSql.Append(" where SuId=@SuId");
			SqlParameter[] parameters = {
					new SqlParameter("@SuId", SqlDbType.Int,4)
			};
			parameters[0].Value = SuId;

			AdminUserModel model=new AdminUserModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdminUserModel DataRowToModel(DataRow row)
		{
			AdminUserModel model=new AdminUserModel();
			if (row != null)
			{
				if(row["SuId"]!=null && row["SuId"].ToString()!="")
				{
					model.SuId=int.Parse(row["SuId"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["Pwd"]!=null)
				{
					model.Pwd=row["Pwd"].ToString();
				}
				if(row["role"]!=null && row["role"].ToString()!="")
				{
					model.role=int.Parse(row["role"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SuId,UserName,Pwd,role ");
			strSql.Append(" FROM tb_AdminUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" SuId,UserName,Pwd,role ");
			strSql.Append(" FROM tb_AdminUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_AdminUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.SuId desc");
			}
			strSql.Append(")AS Row, T.*  from tb_AdminUser T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_AdminUser";
			parameters[1].Value = "SuId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        /// <summary>
        /// 得到一个对象实体Login
        /// </summary>
        public AdminUserModel GetModelLogin(AdminUserModel loginAdminUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SuId,UserName,Pwd,role from tb_AdminUser");
            strSql.Append(" where UserName=@UserName");
            strSql.Append(" and Pwd=@Pwd");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName", loginAdminUser.UserName),
                    new SqlParameter("@Pwd", loginAdminUser.Pwd)
            };
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                loginAdminUser = DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return loginAdminUser;
        }
        
        #endregion  ExtensionMethod
    }
}

