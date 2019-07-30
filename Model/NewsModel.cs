using System;
namespace Change.Model
{
	/// <summary>
	/// 地址编号，主键自增
	/// </summary>
	[Serializable]
	public partial class NewsModel
	{
		public NewsModel()
		{}
		#region Model
		private int _newsid;
		private string _title;
		private string _ntypes;
		private string _content;
		private string _photourl;
		private DateTime? _pushtime;
		private int? _states;
		/// <summary>
		/// 资讯编号，主键自增
		/// </summary>
		public int NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 分类
		/// </summary>
		public string NTypes
		{
			set{ _ntypes=value;}
			get{return _ntypes;}
		}
		/// <summary>
		/// 内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string PhotoUrl
		{
			set{ _photourl=value;}
			get{return _photourl;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public DateTime? PushTime
		{
			set{ _pushtime=value;}
			get{return _pushtime;}
		}
		/// <summary>
		/// 消息状态：0置顶，1热点
		/// </summary>
		public int? States
		{
			set{ _states=value;}
			get{return _states;}
		}
		#endregion Model

	}
}

