using System;
namespace Change.Model
{
	/// <summary>
	/// Category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ModelCategory
	{
		public ModelCategory()
		{}
		#region Model
		private int _cateid;
		private string _catename;
		private int? _parentid;
		/// <summary>
		/// 类别编号，主键自增
		/// </summary>
		public int CateId
		{
			set{ _cateid=value;}
			get{return _cateid;}
		}
		/// <summary>
		/// 类别名
		/// </summary>
		public string CateName
		{
			set{ _catename=value;}
			get{return _catename;}
		}
		/// <summary>
		/// 上级类别编号(外键)
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
        #endregion Model

        /// <summary>
        /// 覆写ToString方法
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Category [CateName=" + CateName + "]";
        }

    }
}

