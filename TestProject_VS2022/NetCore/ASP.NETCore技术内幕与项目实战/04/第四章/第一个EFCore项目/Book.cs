public class Book
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
    /// 发布日期
    /// </summary>
    public DateTime PubTime { get; set; }

    /// <summary>
    /// 单价
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// 作者名字
    /// </summary>
    public string AuthorName { get; set; }
}