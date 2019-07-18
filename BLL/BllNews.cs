using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Change.Model;
namespace Change.BLL
{
	/// <summary>
	/// 地址编号
	/// </summary>
	public partial class BllNews
	{
		private readonly Change.DAL.DalNews dal=new Change.DAL.DalNews();
		public BllNews()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int NewsID)
		{
			return dal.Exists(NewsID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Change.Model.ModelNews model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Change.Model.ModelNews model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int NewsID)
		{
			
			return dal.Delete(NewsID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string NewsIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(NewsIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Change.Model.ModelNews GetModel(int NewsID)
		{
			
			return dal.GetModel(NewsID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Change.Model.ModelNews GetModelByCache(int NewsID)
		{
			
			string CacheKey = "NewsModel-" + NewsID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(NewsID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Change.Model.ModelNews)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Change.Model.ModelNews> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Change.Model.ModelNews> DataTableToList(DataTable dt)
		{
			List<Change.Model.ModelNews> modelList = new List<Change.Model.ModelNews>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Change.Model.ModelNews model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

