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
	public partial class BllPhoto
	{
		private readonly Change.DAL.DalPhoto dal=new Change.DAL.DalPhoto();
		public BllPhoto()
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
		public bool Exists(int PhotoId)
		{
			return dal.Exists(PhotoId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Change.Model.ModelPhoto model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Change.Model.ModelPhoto model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PhotoId)
		{
			
			return dal.Delete(PhotoId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PhotoIdlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(PhotoIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Change.Model.ModelPhoto GetModel(int PhotoId)
		{
			
			return dal.GetModel(PhotoId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Change.Model.ModelPhoto GetModelByCache(int PhotoId)
		{
			
			string CacheKey = "PhotoModel-" + PhotoId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PhotoId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Change.Model.ModelPhoto)objModel;
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
		public List<Change.Model.ModelPhoto> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Change.Model.ModelPhoto> DataTableToList(DataTable dt)
		{
			List<Change.Model.ModelPhoto> modelList = new List<Change.Model.ModelPhoto>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Change.Model.ModelPhoto model;
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

