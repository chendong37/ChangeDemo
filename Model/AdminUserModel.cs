using System;
namespace Change.Model
{
	/// <summary>
	/// AdminUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AdminUserModel
	{
		public AdminUserModel()
		{}
		#region Model
		private int _suid;
		private string _username;
		private string _pwd;
		private int _role=0;
		/// <summary>
		/// 管理员编号，主键自增
		/// </summary>
		public int SuId
		{
			set{ _suid=value;}
			get{return _suid;}
		}
		/// <summary>
		/// 登录名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 登录密码
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 0：普通管理员
	///1：超级管理员
	///
		/// </summary>
		public int role
		{
			set{ _role=value;}
			get{return _role;}
		}
		#endregion Model

	}
}

