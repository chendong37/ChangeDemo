using System;
namespace Change.Model
{
	/// <summary>
	/// 地址编号，主键自增
	/// </summary>
	[Serializable]
	public partial class ModelFavorite
	{
		public ModelFavorite()
		{}
		#region Model
		private int _favoriteid;
		private int _productid;
		private int _userid;
		/// <summary>
		/// 收藏夹编号，主键自增
		/// </summary>
		public int FavoriteID
		{
			set{ _favoriteid=value;}
			get{return _favoriteid;}
		}
		/// <summary>
		/// 商品编号(外键)
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 用户编号(外键)
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

