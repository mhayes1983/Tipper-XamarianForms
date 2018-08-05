using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tipper.Core;
using Tipper.Core.Models;

namespace Tipper.Tests
{
	[TestClass]
	public class TipperCalculatorTests
	{
		[TestMethod]
		public void CalculateDefaultTipsFor1Guest()
		{
			TipperCalculator tipperCalculator = new TipperCalculator(36.33m);
			IDictionary<int, IList<IGuestTip>> guestsTips = tipperCalculator.CalculateTipForNumberOfGuests(1);

			Assert.IsTrue(guestsTips.Count == 1);
			Assert.IsTrue(guestsTips.ContainsKey(1));

			IList<IGuestTip> lstGuestTips;
			guestsTips.TryGetValue(1, out lstGuestTips);

			foreach (IGuestTip guestTip in lstGuestTips)
			{
				switch (guestTip.Percent)
				{
					case 5:
						Assert.IsTrue(guestTip.Tip == 1.82m);
						Assert.IsTrue(guestTip.BillTotal == 38.15m);
						break;
					case 10:
						Assert.IsTrue(guestTip.Tip == 3.63m);
						Assert.IsTrue(guestTip.BillTotal == 39.96m);
						break;
					case 15:
						Assert.IsTrue(guestTip.Tip == 5.45m);
						Assert.IsTrue(guestTip.BillTotal == 41.78m);
						break;
					case 20:
						Assert.IsTrue(guestTip.Tip == 7.27m);
						Assert.IsTrue(guestTip.BillTotal == 43.6m);
						break;
					case 25:
						Assert.IsTrue(guestTip.Tip == 9.08m);
						Assert.IsTrue(guestTip.BillTotal == 45.41m);
						break;
					case 30:
						Assert.IsTrue(guestTip.Tip == 10.9m);
						Assert.IsTrue(guestTip.BillTotal == 47.23m);
						break;
					default:
						Assert.Fail(string.Format("Guest Percent Not Valid!", guestTip.Percent));
						break;
				}

			}
		}

		[TestMethod]
		public void CalculateDefaultTipsFor2Guest()
		{
			TipperCalculator tipperCalculator = new TipperCalculator(36.33m);
			IDictionary<int, IList<IGuestTip>> guestsTips = tipperCalculator.CalculateTipForNumberOfGuests(2);

			Assert.IsTrue(guestsTips.Count == 2);
			Assert.IsTrue(guestsTips.ContainsKey(1));
			Assert.IsTrue(guestsTips.ContainsKey(2));

			IList<IGuestTip> lstGuestTips;
			guestsTips.TryGetValue(1, out lstGuestTips);
			foreach (IGuestTip guestTip in lstGuestTips)
			{
				switch (guestTip.Percent)
				{
					case 5:
						Assert.IsTrue(guestTip.Tip == .91m);
						Assert.IsTrue(guestTip.BillTotal == 19.07m);
						break;
					case 10:
						Assert.IsTrue(guestTip.Tip == 1.82m);
						Assert.IsTrue(guestTip.BillTotal == 19.98m);
						break;
					case 15:
						Assert.IsTrue(guestTip.Tip == 2.72m);
						Assert.IsTrue(guestTip.BillTotal == 20.88m);
						break;
					case 20:
						Assert.IsTrue(guestTip.Tip == 3.63m);
						Assert.IsTrue(guestTip.BillTotal == 21.79m);
						break;
					case 25:
						Assert.IsTrue(guestTip.Tip == 4.54m);
						Assert.IsTrue(guestTip.BillTotal == 22.70m);
						break;
					case 30:
						Assert.IsTrue(guestTip.Tip == 5.45m);
						Assert.IsTrue(guestTip.BillTotal == 23.61m);
						break;
					default:
						Assert.Fail(string.Format("Guest Percent Not Valid!", guestTip.Percent));
						break;
				}
			}

			guestsTips.TryGetValue(2, out lstGuestTips);
			foreach (IGuestTip guestTip in lstGuestTips)
			{
				switch (guestTip.Percent)
				{
					case 5:
						Assert.IsTrue(guestTip.Tip == .91m);
						Assert.IsTrue(guestTip.BillTotal == 19.08m);
						break;
					case 10:
						Assert.IsTrue(guestTip.Tip == 1.82m);
						Assert.IsTrue(guestTip.BillTotal == 19.99m);
						break;
					case 15:
						Assert.IsTrue(guestTip.Tip == 2.73m);
						Assert.IsTrue(guestTip.BillTotal == 20.9m);
						break;
					case 20:
						Assert.IsTrue(guestTip.Tip == 3.63m);
						Assert.IsTrue(guestTip.BillTotal == 21.8m);
						break;
					case 25:
						Assert.IsTrue(guestTip.Tip == 4.54m);
						Assert.IsTrue(guestTip.BillTotal == 22.71m);
						break;
					case 30:
						Assert.IsTrue(guestTip.Tip == 5.45m);
						Assert.IsTrue(guestTip.BillTotal == 23.62m);
						break;
					default:
						Assert.Fail(string.Format("Guest Percent Not Valid!", guestTip.Percent));
						break;
				}
			}
		}
	}
}
