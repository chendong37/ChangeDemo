using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:Product
	/// </summary>
	public partial class ProductDal
	{
		public ProductDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProductId", "tb_Product"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Product");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ProductModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Product(");
			strSql.Append("Title,CateId,MarketPrice,Price,Content,PostTime,Stock)");
			strSql.Append(" values (");
			strSql.Append("@Title,@CateId,@MarketPrice,@Price,@Content,@PostTime,@Stock)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@CateId", SqlDbType.Int,4),
					new SqlParameter("@MarketPrice", SqlDbType.Money,8),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Stock", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.CateId;
			parameters[2].Value = model.MarketPrice;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.Stock;

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
		public bool Update(ProductModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Product set ");
			strSql.Append("Title=@Title,");
			strSql.Append("CateId=@CateId,");
			strSql.Append("MarketPrice=@MarketPrice,");
			strSql.Append("Price=@Price,");
			strSql.Append("Content=@Content,");
			strSql.Append("PostTime=@PostTime,");
			strSql.Append("Stock=@Stock");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@CateId", SqlDbType.Int,4),
					new SqlParameter("@MarketPrice", SqlDbType.Money,8),
					new SqlParameter("@Price", SqlDbType.Money,8),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@PostTime", SqlDbType.DateTime),
					new SqlParameter("@Stock", SqlDbType.Int,4),
					new SqlParameter("@ProductId", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.CateId;
			parameters[2].Value = model.MarketPrice;
			parameters[3].Value = model.Price;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.PostTime;
			parameters[6].Value = model.Stock;
			parameters[7].Value = model.ProductId;

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
		public bool Delete(int ProductId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Product ");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductId;

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
		public bool DeleteList(string ProductIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Product ");
			strSql.Append(" where ProductId in ("+ProductIdlist + ")  ");
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
		public ProductModel GetModel(int ProductId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductId,Title,CateId,MarketPrice,Price,Content,PostTime,Stock from tb_Product ");
			strSql.Append(" where ProductId=@ProductId");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductId", SqlDbType.Int,4)
			};
			parameters[0].Value = ProductId;

			ProductModel model=new ProductModel();
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
		public ProductModel DataRowToModel(DataRow row)
		{
			ProductModel model=new ProductModel();
			if (row != null)
			{
				if(row["ProductId"]!=null && row["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(row["ProductId"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["CateId"]!=null && row["CateId"].ToString()!="")
				{
					model.CateId=int.Parse(row["CateId"].ToString());
				}
				if(row["MarketPrice"]!=null && row["MarketPrice"].ToString()!="")
				{
					model.MarketPrice=decimal.Parse(row["MarketPrice"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(row["Price"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["PostTime"]!=null && row["PostTime"].ToString()!="")
				{
					model.PostTime=DateTime.Parse(row["PostTime"].ToString());
				}
				if(row["Stock"]!=null && row["Stock"].ToString()!="")
				{
					model.Stock=int.Parse(row["Stock"].ToString());
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
			strSql.Append("select ProductId,Title,CateId,MarketPrice,Price,Content,PostTime,Stock ");
			strSql.Append(" FROM tb_Product ");
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
			strSql.Append(" ProductId,Title,CateId,MarketPrice,Price,Content,PostTime,Stock ");
			strSql.Append(" FROM tb_Product ");
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
			strSql.Append("select count(1) FROM tb_Product ");
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
				strSql.Append("order by T.ProductId desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Product T ");
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
			parameters[0].Value = "tb_Product";
			parameters[1].Value = "ProductId";
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

