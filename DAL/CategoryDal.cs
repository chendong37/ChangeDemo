using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:Category
	/// </summary>
	public partial class CategoryDal
	{
		public CategoryDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CateId", "tb_Category"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CateId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Category");
			strSql.Append(" where CateId=@CateId");
			SqlParameter[] parameters = {
					new SqlParameter("@CateId", SqlDbType.Int,4)
			};
			parameters[0].Value = CateId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(CategoryModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Category(");
			strSql.Append("CateName,ParentId)");
			strSql.Append(" values (");
			strSql.Append("@CateName,@ParentId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CateName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4)};
			parameters[0].Value = model.CateName;
			parameters[1].Value = model.ParentId;

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
		public bool Update(CategoryModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Category set ");
			strSql.Append("CateName=@CateName,");
			strSql.Append("ParentId=@ParentId");
			strSql.Append(" where CateId=@CateId");
			SqlParameter[] parameters = {
					new SqlParameter("@CateName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@CateId", SqlDbType.Int,4)};
			parameters[0].Value = model.CateName;
			parameters[1].Value = model.ParentId;
			parameters[2].Value = model.CateId;

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
		public bool Delete(int CateId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Category ");
			strSql.Append(" where CateId=@CateId");
			SqlParameter[] parameters = {
					new SqlParameter("@CateId", SqlDbType.Int,4)
			};
			parameters[0].Value = CateId;

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
		public bool DeleteList(string CateIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Category ");
			strSql.Append(" where CateId in ("+CateIdlist + ")  ");
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
		public CategoryModel GetModel(int CateId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CateId,CateName,ParentId from tb_Category ");
			strSql.Append(" where CateId=@CateId");
			SqlParameter[] parameters = {
					new SqlParameter("@CateId", SqlDbType.Int,4)
			};
			parameters[0].Value = CateId;

			CategoryModel model=new CategoryModel();
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
		public CategoryModel DataRowToModel(DataRow row)
		{
			CategoryModel model=new CategoryModel();
			if (row != null)
			{
				if(row["CateId"]!=null && row["CateId"].ToString()!="")
				{
					model.CateId=int.Parse(row["CateId"].ToString());
				}
				if(row["CateName"]!=null)
				{
					model.CateName=row["CateName"].ToString();
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(row["ParentId"].ToString());
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
			strSql.Append("select CateId,CateName,ParentId ");
			strSql.Append(" FROM tb_Category ");
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
			strSql.Append(" CateId,CateName,ParentId ");
			strSql.Append(" FROM tb_Category ");
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
			strSql.Append("select count(1) FROM tb_Category ");
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
				strSql.Append("order by T.CateId desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Category T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@OrderfldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@StatfldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                       };
            parameters[0].Value = "tb_Category";
            parameters[1].Value = "*";
            parameters[2].Value = "CateId";
            parameters[3].Value = "*";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 1;
            parameters[7].Value = 0;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

