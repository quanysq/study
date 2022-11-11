class Leave
{
	public long Id { get; set; }

	/// <summary>
	/// 申请者
	/// </summary>
	public User Requester { get; set; }

	/// <summary>
	/// 审批者
	/// </summary>
	public User? Approver { get; set; }

	/// <summary>
	/// 说明
	/// </summary>
	public string Remarks { get; set; }

	/// <summary>
	/// 开始日期
	/// </summary>
	public DateTime From { get; set; }

	/// <summary>
	/// 结束日期
	/// </summary>
	public DateTime To { get; set; }

	/// <summary>
	/// 状态
	/// </summary>
	public int Status { get; set; }
}