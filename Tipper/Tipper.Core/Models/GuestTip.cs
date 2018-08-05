namespace Tipper.Core.Models
{
	class GuestTip : IGuestTip
	{
		public decimal Percent { get; set; }
		public decimal BillTotal { get; set; }
		public decimal Tip { get; set; }
	}
}
