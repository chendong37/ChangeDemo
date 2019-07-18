using System;
namespace Change.Model
{
	/// <summary>
	/// 地址编号，主键自增
	/// </summary>
	[Serializable]
	public partial class ModelUsers
	{
		public ModelUsers()
		{}
		#region Model
		private int _userid;
		private string _username;
		private string _pwd;
		private string _email;
		private string _nick;
		private int? _deliveryid;
		/// <summary>
		/// 主键，标识列
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 用户登录名，唯一
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户密码
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 昵称
		/// </summary>
		public string Nick
		{
			set{ _nick=value;}
			get{return _nick;}
		}
		/// <summary>
		/// 默认收货地址编号(外键)
		/// </summary>
		public int? DeliveryID
		{
			set{ _deliveryid=value;}
			get{return _deliveryid;}
		}
		#endregion Model

	}
}

