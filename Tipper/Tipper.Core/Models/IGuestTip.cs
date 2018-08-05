namespace Tipper.Core.Models
{
	public interface IGuestTip
	{
		decimal Percent { get; set; }
		decimal BillTotal { get; set; }
		decimal Tip { get; set; }
	}
}