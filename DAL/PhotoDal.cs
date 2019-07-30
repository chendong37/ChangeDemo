using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:Photo
	/// </summary>
	public partial class PhotoDal
	{
		public PhotoDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PhotoId", "tb_Photo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PhotoId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Photo");
			strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoId", SqlDbType.Int,4)
			};
			parameters[0].Value = PhotoId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(PhotoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Photo(");
			strSql.Append("ProductId,PhotoUrl)");
			strSql.Append(" values (");
			strSql.Append("@ProductId,@PhotoUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,200)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.PhotoUrl;

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
		public bool Update(PhotoModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Photo set ");
			strSql.Append("ProductId=@ProductId,");
			strSql.Append("PhotoUrl=@PhotoUrl");
			strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4),
					new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@PhotoId", SqlDbType.Int,4)};
			parameters[0].Value = model.ProductId;
			parameters[1].Value = model.PhotoUrl;
			parameters[2].Value = model.PhotoId;

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
		public bool Delete(int PhotoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Photo ");
			strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoId", SqlDbType.Int,4)
			};
			parameters[0].Value = PhotoId;

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
		public bool DeleteList(string PhotoIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Photo ");
			strSql.Append(" where PhotoId in ("+PhotoIdlist + ")  ");
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
		public PhotoModel GetModel(int PhotoId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 PhotoId,ProductId,PhotoUrl from tb_Photo ");
			strSql.Append(" where PhotoId=@PhotoId");
			SqlParameter[] parameters = {
					new SqlParameter("@PhotoId", SqlDbType.Int,4)
			};
			parameters[0].Value = PhotoId;

			PhotoModel model=new PhotoModel();
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
		public PhotoModel DataRowToModel(DataRow row)
		{
			PhotoModel model=new PhotoModel();
			if (row != null)
			{
				if(row["PhotoId"]!=null && row["PhotoId"].ToString()!="")
				{
					model.PhotoId=int.Parse(row["PhotoId"].ToString());
				}
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(row["ProductId"].ToString());
				}
				if(row["PhotoUrl"]!=null)
				{
					model.PhotoUrl=row["PhotoUrl"].ToString();
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
			strSql.Append("select PhotoId,ProductId,PhotoUrl ");
			strSql.Append(" FROM tb_Photo ");
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
			strSql.Append(" PhotoId,ProductId,PhotoUrl ");
			strSql.Append(" FROM tb_Photo ");
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
			strSql.Append("select count(1) FROM tb_Photo ");
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
				strSql.Append("order by T.PhotoId desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Photo T ");
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
			parameters[0].Value = "tb_Photo";
			parameters[1].Value = "PhotoId";
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

