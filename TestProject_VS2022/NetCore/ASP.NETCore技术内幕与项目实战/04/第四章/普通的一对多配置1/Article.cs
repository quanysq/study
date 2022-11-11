public class Article
{
	/// <summary>
	/// 主键
	/// </summary>
	public long Id { get; set; }

	/// <summary>
	/// 标题
	/// </summary>
	public string Title { get; set; }

	/// <summary>
	/// 内容
	/// </summary>
	public string Content { get; set; }

	/// <summary>
	/// 此文章的若干条评论
	/// </summary>
	public List<Comment> Comments { get; set; } = new List<Comment>(); 
}

