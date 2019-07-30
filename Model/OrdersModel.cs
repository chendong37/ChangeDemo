using System;
namespace Change.Model
{
	/// <summary>
	/// 地址编号，主键自增
	/// </summary>
	[Serializable]
	public partial class OrdersModel
	{
		public OrdersModel()
		{}
		#region Model
		private int _ordersid;
		private DateTime _orderdate= DateTime.Now;
		private int _userid;
		private decimal? _total;
		private int? _deliveryid;
		private DateTime? _deliverydate;
		private int _states=0;
		private string _remark;
		/// <summary>
		/// 订单编号，主键自增
		/// </summary>
		public int OrdersID
		{
			set{ _ordersid=value;}
			get{return _ordersid;}
		}
		/// <summary>
		/// 下单时间
		/// </summary>
		public DateTime Orderdate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
		}
		/// <summary>
		/// 用户编号(外键)
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 订单总价
		/// </summary>
		public decimal? Total
		{
			set{ _total=value;}
			get{return _total;}
		}
		/// <summary>
		/// 用户收货地址编号(外键)
		/// </summary>
		public int? DeliveryID
		{
			set{ _deliveryid=value;}
			get{return _deliveryid;}
		}
		/// <summary>
		/// 收货日期
		/// </summary>
		public DateTime? DeliveryDate
		{
			set{ _deliverydate=value;}
			get{return _deliverydate;}
		}
		/// <summary>
		/// 订单状态：
	///0未付款，1已付款，2已发货，3已收货，4已评价
	///
		/// </summary>
		public int States
		{
			set{ _states=value;}
			get{return _states;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

