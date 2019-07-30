using System;
namespace Change.Model
{
	/// <summary>
	/// 地址编号，主键自增
	/// </summary>
	[Serializable]
	public partial class DeliveryModel
	{
		public DeliveryModel()
		{}
		#region Model
		private int _deliveryid;
		private int _userid;
		private string _consignee;
		private string _complete;
		private string _phone;
		/// <summary>
		/// 地址编号，主键自增
		/// </summary>
		public int DeliveryID
		{
			set{ _deliveryid=value;}
			get{return _deliveryid;}
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
		/// 收件人姓名
		/// </summary>
		public string Consignee
		{
			set{ _consignee=value;}
			get{return _consignee;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string Complete
		{
			set{ _complete=value;}
			get{return _complete;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		#endregion Model

	}
}

