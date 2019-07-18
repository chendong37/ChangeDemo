using System;
namespace Change.Model
{
	/// <summary>
	/// 地址编号，主键自增
	/// </summary>
	[Serializable]
	public partial class ModelPhoto
	{
		public ModelPhoto()
		{}
		#region Model
		private int _photoid;
		private int _productid;
		private string _photourl;
		/// <summary>
		/// 商品图片编号，主键自增
		/// </summary>
		public int PhotoId
		{
			set{ _photoid=value;}
			get{return _photoid;}
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
		/// 图片地址
		/// </summary>
		public string PhotoUrl
		{
			set{ _photourl=value;}
			get{return _photourl;}
		}
		#endregion Model

	}
}

