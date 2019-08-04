using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:Orders
	/// </summary>
	public partial class OrdersDal
	{
		public OrdersDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("OrdersID", "tb_Orders"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int OrdersID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_Orders");
			strSql.Append(" where OrdersID=@OrdersID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrdersID", SqlDbType.Int,4)
			};
			parameters[0].Value = OrdersID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(OrdersModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_Orders(");
			strSql.Append("Orderdate,UserId,Total,DeliveryID,DeliveryDate,States,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Orderdate,@UserId,@Total,@DeliveryID,@DeliveryDate,@States,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Orderdate", SqlDbType.Date,3),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Total", SqlDbType.Money,8),
					new SqlParameter("@DeliveryID", SqlDbType.Int,4),
					new SqlParameter("@DeliveryDate", SqlDbType.Date,3),
					new SqlParameter("@States", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.Orderdate;
			parameters[1].Value = model.UserId;
			parameters[2].Value = model.Total;
			parameters[3].Value = model.DeliveryID;
			parameters[4].Value = model.DeliveryDate;
			parameters[5].Value = model.States;
			parameters[6].Value = model.Remark;

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
		public bool Update(OrdersModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_Orders set ");
			strSql.Append("Orderdate=@Orderdate,");
			strSql.Append("UserId=@UserId,");
			strSql.Append("Total=@Total,");
			strSql.Append("DeliveryID=@DeliveryID,");
			strSql.Append("DeliveryDate=@DeliveryDate,");
			strSql.Append("States=@States,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where OrdersID=@OrdersID");
			SqlParameter[] parameters = {
					new SqlParameter("@Orderdate", SqlDbType.Date,3),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Total", SqlDbType.Money,8),
					new SqlParameter("@DeliveryID", SqlDbType.Int,4),
					new SqlParameter("@DeliveryDate", SqlDbType.Date,3),
					new SqlParameter("@States", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.NVarChar,500),
					new SqlParameter("@OrdersID", SqlDbType.Int,4)};
			parameters[0].Value = model.Orderdate;
			parameters[1].Value = model.UserId;
			parameters[2].Value = model.Total;
			parameters[3].Value = model.DeliveryID;
			parameters[4].Value = model.DeliveryDate;
			parameters[5].Value = model.States;
			parameters[6].Value = model.Remark;
			parameters[7].Value = model.OrdersID;

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
		public bool Delete(int OrdersID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Orders ");
			strSql.Append(" where OrdersID=@OrdersID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrdersID", SqlDbType.Int,4)
			};
			parameters[0].Value = OrdersID;

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
		public bool DeleteList(string OrdersIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_Orders ");
			strSql.Append(" where OrdersID in ("+OrdersIDlist + ")  ");
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
		public OrdersModel GetModel(int OrdersID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 OrdersID,Orderdate,UserId,Total,DeliveryID,DeliveryDate,States,Remark from tb_Orders ");
			strSql.Append(" where OrdersID=@OrdersID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrdersID", SqlDbType.Int,4)
			};
			parameters[0].Value = OrdersID;

			OrdersModel model=new OrdersModel();
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
		public OrdersModel DataRowToModel(DataRow row)
		{
			OrdersModel model=new OrdersModel();
			if (row != null)
			{
				if(row["OrdersID"]!=null && row["OrdersID"].ToString()!="")
				{
					model.OrdersID=int.Parse(row["OrdersID"].ToString());
				}
				if(row["Orderdate"]!=null && row["Orderdate"].ToString()!="")
				{
					model.Orderdate=DateTime.Parse(row["Orderdate"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["Total"]!=null && row["Total"].ToString()!="")
				{
					model.Total=decimal.Parse(row["Total"].ToString());
				}
				if(row["DeliveryID"]!=null && row["DeliveryID"].ToString()!="")
				{
					model.DeliveryID=int.Parse(row["DeliveryID"].ToString());
				}
				if(row["DeliveryDate"]!=null && row["DeliveryDate"].ToString()!="")
				{
					model.DeliveryDate=DateTime.Parse(row["DeliveryDate"].ToString());
				}
				if(row["States"]!=null && row["States"].ToString()!="")
				{
					model.States=int.Parse(row["States"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select UserName,Consignee,OrdersID,Orderdate,Total,DeliveryDate,States,Remark ");
			strSql.Append(" FROM tb_Orders ");
            strSql.Append(" join tb_Delivery on tb_Orders.DeliveryID=tb_Delivery.DeliveryID");
            strSql.Append(" join tb_Users on tb_Orders.UserId=tb_Users.UserId");
            if (strWhere.Trim()!="")
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
			strSql.Append(" OrdersID,Orderdate,UserId,Total,DeliveryID,DeliveryDate,States,Remark ");
			strSql.Append(" FROM tb_Orders ");
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
			strSql.Append("select count(1) FROM tb_Orders ");
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
				strSql.Append("order by T.OrdersID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_Orders T ");
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
			parameters[0].Value = "tb_Orders";
			parameters[1].Value = "OrdersID";
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

