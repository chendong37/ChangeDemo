using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Change.Model;//Please add references
namespace Change.DAL
{
	/// <summary>
	/// 数据访问类:News
	/// </summary>
	public partial class NewsDal
	{
		public NewsDal()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("NewsID", "tb_News"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NewsID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_News");
			strSql.Append(" where NewsID=@NewsID");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(NewsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_News(");
			strSql.Append("Title,NTypes,Content,PhotoUrl,PushTime,States)");
			strSql.Append(" values (");
			strSql.Append("@Title,@NTypes,@Content,@PhotoUrl,@PushTime,@States)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@NTypes", SqlDbType.NVarChar,10),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@PushTime", SqlDbType.DateTime),
					new SqlParameter("@States", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.NTypes;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.PhotoUrl;
			parameters[4].Value = model.PushTime;
			parameters[5].Value = model.States;

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
		public bool Update(NewsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_News set ");
			strSql.Append("Title=@Title,");
			strSql.Append("NTypes=@NTypes,");
			strSql.Append("Content=@Content,");
			strSql.Append("PhotoUrl=@PhotoUrl,");
			strSql.Append("PushTime=@PushTime,");
			strSql.Append("States=@States");
			strSql.Append(" where NewsID=@NewsID");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@NTypes", SqlDbType.NVarChar,10),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@PhotoUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@PushTime", SqlDbType.DateTime),
					new SqlParameter("@States", SqlDbType.Int,4),
					new SqlParameter("@NewsID", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.NTypes;
			parameters[2].Value = model.Content;
			parameters[3].Value = model.PhotoUrl;
			parameters[4].Value = model.PushTime;
			parameters[5].Value = model.States;
			parameters[6].Value = model.NewsID;

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
        /// 更新状态
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateNewsStatus(int newsId, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_News");
            strSql.Append(" set States=@Status");
            strSql.Append(" where NewsID=@NewsID");
            SqlParameter[] parameters = {
                    new SqlParameter("@NewsID", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.Int,4)
            };
            parameters[0].Value = newsId;
            parameters[1].Value = status;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int NewsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_News ");
			strSql.Append(" where NewsID=@NewsID");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsID;

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
		public bool DeleteList(string NewsIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_News ");
			strSql.Append(" where NewsID in ("+NewsIDlist + ")  ");
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
		public NewsModel GetModel(int NewsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 NewsID,Title,NTypes,Content,PhotoUrl,PushTime,States from tb_News ");
			strSql.Append(" where NewsID=@NewsID");
			SqlParameter[] parameters = {
					new SqlParameter("@NewsID", SqlDbType.Int,4)
			};
			parameters[0].Value = NewsID;

			NewsModel model=new NewsModel();
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
		public NewsModel DataRowToModel(DataRow row)
		{
			NewsModel model=new NewsModel();
			if (row != null)
			{
				if(row["NewsID"]!=null && row["NewsID"].ToString()!="")
				{
					model.NewsID=int.Parse(row["NewsID"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["NTypes"]!=null)
				{
					model.NTypes=row["NTypes"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["PhotoUrl"]!=null)
				{
					model.PhotoUrl=row["PhotoUrl"].ToString();
				}
				if(row["PushTime"]!=null && row["PushTime"].ToString()!="")
				{
					model.PushTime=DateTime.Parse(row["PushTime"].ToString());
				}
				if(row["States"]!=null && row["States"].ToString()!="")
				{
					model.States=int.Parse(row["States"].ToString());
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
			strSql.Append("select NewsID,Title,NTypes,Content,PhotoUrl,PushTime,States ");
			strSql.Append(" FROM tb_News ");
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
			strSql.Append(" NewsID,Title,NTypes,Content,PhotoUrl,PushTime,States ");
			strSql.Append(" FROM tb_News ");
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
			strSql.Append("select count(1) FROM tb_News ");
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
				strSql.Append("order by T.NewsID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_News T ");
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
                    //@tblName varchar(255), -- 表名
                    //@fldName varchar(255), -- 显示字段名
                    //@OrderfldName varchar(255), -- 排序字段名
                    //@StatfldName varchar(255), -- 统计字段名
                    //@PageSize int = 10, -- 页尺寸
                    //@PageIndex int = 1, -- 页码
                    //@IsReCount bit = 0, -- 返回记录总数, 非 0 值则返回
                    //@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
                    //@strWhere varchar(1000) = '' -- 查询条件 (注意: 不要加 where)
                    };
			parameters[0].Value = "tb_News";
			parameters[1].Value = "*";
            parameters[2].Value = "NewsID";
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

