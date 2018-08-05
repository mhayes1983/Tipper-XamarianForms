using System;
using System.Collections.Generic;

using Tipper.Core.Models;

namespace Tipper.Core
{
    public class TipperCalculator
    {
		private decimal? m_bill = null;
		private IList<decimal> m_tipPercents = new List<decimal>() { 5m, 10m, 15m, 20m, 25m, 30m };
		public TipperCalculator(decimal? bill)
		{
			if (!bill.HasValue)
			{
				throw new Exception("bill is nothing");
			}

			m_bill = bill;
		}

		public TipperCalculator(decimal? bill, IList<decimal> tipPercents)
		{
			if (!bill.HasValue)
			{
				throw new Exception("bill is nothing");
			}
			m_bill = bill;

			if (tipPercents != null)
			{
				m_tipPercents = tipPercents;
			}			
		}

		public IDictionary<int, IList<IGuestTip>> CalculateTipForNumberOfGuests(int guests)
		{
			IDictionary<int, IList<IGuestTip>> dctGuestsTips = new Dictionary<int, IList<IGuestTip>>();
			IList<IGuestTip> guestTips;
			IGuestTip guestTip;
			decimal dcmRemainingBill = m_bill.Value;
			decimal dcmGuestBill = Math.Round(m_bill.Value / guests, 2);
			int intGuestNumber;
			for (int i = 0; i < guests; i++)
			{
				intGuestNumber = (i + 1);

				if (intGuestNumber == guests)
				{
					dcmGuestBill = dcmRemainingBill;
				}

				guestTips = new List<IGuestTip>();
				foreach (decimal tipPercent in m_tipPercents)
				{
					guestTip = new GuestTip();

					guestTip.Percent = tipPercent;
					guestTip.Tip = Math.Round(dcmGuestBill * (tipPercent / 100m), 2);
					guestTip.BillTotal = (dcmGuestBill + guestTip.Tip);

					guestTips.Add(guestTip);
				}

				dcmRemainingBill -= dcmGuestBill;

				dctGuestsTips.Add(intGuestNumber, guestTips);
			}

			return dctGuestsTips;
		}
	}
}
