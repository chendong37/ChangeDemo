﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Change.Model;
namespace Change.BLL
{
	/// <summary>
	/// 地址编号
	/// </summary>
	public partial class OrdersDetailBll
	{
		private readonly Change.DAL.OrdersDetailDal dal=new Change.DAL.OrdersDetailDal();
		public OrdersDetailBll()
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
		public bool Exists(int DetailID)
		{
			return dal.Exists(DetailID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Change.Model.OrdersDetailModel model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Change.Model.OrdersDetailModel model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DetailID)
		{
			
			return dal.Delete(DetailID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DetailIDlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(DetailIDlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Change.Model.OrdersDetailModel GetModel(int DetailID)
		{
			
			return dal.GetModel(DetailID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Change.Model.OrdersDetailModel GetModelByCache(int DetailID)
		{
			
			string CacheKey = "OrdersDetailModel-" + DetailID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DetailID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Change.Model.OrdersDetailModel)objModel;
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
		public List<Change.Model.OrdersDetailModel> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Change.Model.OrdersDetailModel> DataTableToList(DataTable dt)
		{
			List<Change.Model.OrdersDetailModel> modelList = new List<Change.Model.OrdersDetailModel>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Change.Model.OrdersDetailModel model;
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

