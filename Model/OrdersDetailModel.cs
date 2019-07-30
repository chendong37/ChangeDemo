using System;
namespace Change.Model
{
	/// <summary>
	/// 地址编号，主键自增
	/// </summary>
	[Serializable]
	public partial class OrdersDetailModel
	{
		public OrdersDetailModel()
		{}
		#region Model
		private int _detailid;
		private int _ordersid;
		private int _productid;
		private int _quantity;
		private int? _states=0;
		/// <summary>
		/// 订单详情编号，主键自增
		/// </summary>
		public int DetailID
		{
			set{ _detailid=value;}
			get{return _detailid;}
		}
		/// <summary>
		/// 订单编号(外键)
		/// </summary>
		public int OrdersID
		{
			set{ _ordersid=value;}
			get{return _ordersid;}
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
		/// 商品数量
		/// </summary>
		public int Quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 明细状态：0正常，1退货中，2已退货
		/// </summary>
		public int? States
		{
			set{ _states=value;}
			get{return _states;}
		}
		#endregion Model

	}
}

