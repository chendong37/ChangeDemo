using System;
namespace Change.Model
{
	/// <summary>
	/// Appraise:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ModelAppraise
	{
		public ModelAppraise()
		{}
		#region Model
		private int _appraiseid;
		private int _userid;
		private int _productid;
		private string _content;
		private int _grade;
		private DateTime? _ratetime= DateTime.Now;
		/// <summary>
		/// 评价编号，主键自增
		/// </summary>
		public int AppraiseId
		{
			set{ _appraiseid=value;}
			get{return _appraiseid;}
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
		/// 商品编号(外键)
		/// </summary>
		public int ProductId
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 评价内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 评价等级：
	///0好评，1中评，2差评
	///
		/// </summary>
		public int Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 评价时间
		/// </summary>
		public DateTime? RateTime
		{
			set{ _ratetime=value;}
			get{return _ratetime;}
		}
		#endregion Model

	}
}

