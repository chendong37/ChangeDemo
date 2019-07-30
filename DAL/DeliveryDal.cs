using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:Delivery
	/// </summary>
	public partial class DeliveryDal
	{
		public DeliveryDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DeliveryID", "tb_Delivery"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DeliveryID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Delivery");
			strSql.Append(" where DeliveryID=@DeliveryID");
			SqlParameter[] parameters = {
					new SqlParameter("@DeliveryID", SqlDbType.Int,4)
			};
			parameters[0].Value = DeliveryID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DeliveryModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Delivery(");
			strSql.Append("UserId,Consignee,Complete,Phone)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@Consignee,@Complete,@Phone)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Consignee", SqlDbType.NVarChar,50),
					new SqlParameter("@Complete", SqlDbType.NVarChar,200),
					new SqlParameter("@Phone", SqlDbType.NVarChar,12)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Consignee;
			parameters[2].Value = model.Complete;
			parameters[3].Value = model.Phone;

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
		public bool Update(DeliveryModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Delivery set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("Consignee=@Consignee,");
			strSql.Append("Complete=@Complete,");
			strSql.Append("Phone=@Phone");
			strSql.Append(" where DeliveryID=@DeliveryID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Consignee", SqlDbType.NVarChar,50),
					new SqlParameter("@Complete", SqlDbType.NVarChar,200),
					new SqlParameter("@Phone", SqlDbType.NVarChar,12),
					new SqlParameter("@DeliveryID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.Consignee;
			parameters[2].Value = model.Complete;
			parameters[3].Value = model.Phone;
			parameters[4].Value = model.DeliveryID;

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
		public bool Delete(int DeliveryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Delivery ");
			strSql.Append(" where DeliveryID=@DeliveryID");
			SqlParameter[] parameters = {
					new SqlParameter("@DeliveryID", SqlDbType.Int,4)
			};
			parameters[0].Value = DeliveryID;

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
		public bool DeleteList(string DeliveryIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Delivery ");
			strSql.Append(" where DeliveryID in ("+DeliveryIDlist + ")  ");
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
		public DeliveryModel GetModel(int DeliveryID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DeliveryID,UserId,Consignee,Complete,Phone from tb_Delivery ");
			strSql.Append(" where DeliveryID=@DeliveryID");
			SqlParameter[] parameters = {
					new SqlParameter("@DeliveryID", SqlDbType.Int,4)
			};
			parameters[0].Value = DeliveryID;

			DeliveryModel model=new DeliveryModel();
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
		public DeliveryModel DataRowToModel(DataRow row)
		{
			DeliveryModel model=new DeliveryModel();
			if (row != null)
			{
				if(row["DeliveryID"]!=null && row["DeliveryID"].ToString()!="")
				{
					model.DeliveryID=int.Parse(row["DeliveryID"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["Consignee"]!=null)
				{
					model.Consignee=row["Consignee"].ToString();
				}
				if(row["Complete"]!=null)
				{
					model.Complete=row["Complete"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
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
			strSql.Append("select DeliveryID,UserId,Consignee,Complete,Phone ");
			strSql.Append(" FROM tb_Delivery ");
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
			strSql.Append(" DeliveryID,UserId,Consignee,Complete,Phone ");
			strSql.Append(" FROM tb_Delivery ");
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
			strSql.Append("select count(1) FROM tb_Delivery ");
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
				strSql.Append("order by T.DeliveryID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Delivery T ");
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
			parameters[0].Value = "tb_Delivery";
			parameters[1].Value = "DeliveryID";
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

