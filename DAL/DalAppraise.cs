﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:Appraise
	/// </summary>
	public partial class DalAppraise
	{
		public DalAppraise()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("AppraiseId", "tb_Appraise"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AppraiseId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Appraise");
			strSql.Append(" where AppraiseId=@AppraiseId");
			SqlParameter[] parameters = {
					new SqlParameter("@AppraiseId", SqlDbType.Int,4)
			};
			parameters[0].Value = AppraiseId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ModelAppraise model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Appraise(");
			strSql.Append("UserId,ProductId,Content,Grade,RateTime)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@ProductId,@Content,@Grade,@RateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@RateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.RateTime;

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
		public bool Update(ModelAppraise model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Appraise set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("ProductId=@ProductId,");
			strSql.Append("Content=@Content,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("RateTime=@RateTime");
			strSql.Append(" where AppraiseId=@AppraiseId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@Grade", SqlDbType.Int,4),
					new SqlParameter("@RateTime", SqlDbType.DateTime),
					new SqlParameter("@AppraiseId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.Grade;
			parameters[4].Value = model.RateTime;
			parameters[5].Value = model.AppraiseId;

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
		public bool Delete(int AppraiseId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Appraise ");
			strSql.Append(" where AppraiseId=@AppraiseId");
			SqlParameter[] parameters = {
					new SqlParameter("@AppraiseId", SqlDbType.Int,4)
			};
			parameters[0].Value = AppraiseId;

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
		public bool DeleteList(string AppraiseIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Appraise ");
			strSql.Append(" where AppraiseId in ("+AppraiseIdlist + ")  ");
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
		public ModelAppraise GetModel(int AppraiseId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AppraiseId,UserId,ProductId,Content,Grade,RateTime from tb_Appraise ");
			strSql.Append(" where AppraiseId=@AppraiseId");
			SqlParameter[] parameters = {
					new SqlParameter("@AppraiseId", SqlDbType.Int,4)
			};
			parameters[0].Value = AppraiseId;

			ModelAppraise model=new ModelAppraise();
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
		public ModelAppraise DataRowToModel(DataRow row)
		{
			ModelAppraise model=new ModelAppraise();
			if (row != null)
			{
				if(row["AppraiseId"]!=null && row["AppraiseId"].ToString()!="")
				{
					model.AppraiseId=int.Parse(row["AppraiseId"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(row["ProductId"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Grade"]!=null && row["Grade"].ToString()!="")
				{
					model.Grade=int.Parse(row["Grade"].ToString());
				}
				if(row["RateTime"]!=null && row["RateTime"].ToString()!="")
				{
					model.RateTime=DateTime.Parse(row["RateTime"].ToString());
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
			strSql.Append("select AppraiseId,UserId,ProductId,Content,Grade,RateTime ");
			strSql.Append(" FROM tb_Appraise ");
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
			strSql.Append(" AppraiseId,UserId,ProductId,Content,Grade,RateTime ");
			strSql.Append(" FROM tb_Appraise ");
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
			strSql.Append("select count(1) FROM tb_Appraise ");
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
				strSql.Append("order by T.AppraiseId desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Appraise T ");
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
			parameters[0].Value = "tb_Appraise";
			parameters[1].Value = "AppraiseId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

