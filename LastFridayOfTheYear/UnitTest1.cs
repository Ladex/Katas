using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LastFridayOfTheYear
{
    [TestClass]
    public class UnitTest1
    {
        private List<DateTime> list(params DateTime[] dates)
        {
            List<DateTime> dateList = new List<DateTime>();
            foreach (var item in dates)
            {
                dateList.Add(item);
            }

            return dateList;
        }

        private DateTime CreateDate(int year, int month, int day = 1)
        {
            return new DateTime(year, month, day);
        }

        Fridaycalculator fc = null;

        [TestInitialize]
        public void SetUp()
        {
            fc = new Fridaycalculator();
        }

        [TestMethod]
        public void LastFriday_ZeroInput_ReturnDate()
        {
            DateTime lastFridays = fc.LastFridays(default(DateTime));
            Assert.AreEqual(default(DateTime), lastFridays);
        }

        /*
         *      01/27/2012
                02/24/2012
                03/30/2012
                04/27/2012
                05/25/2012
                06/29/2012
                07/27/2012
                08/31/2012
                09/28/2012
                10/26/2012
                11/30/2012
                12/28/2012
         * */
        [TestMethod]
        public void LastFridays_January2012_ReturnDates()
        {
            Assert.AreEqual(CreateDate(2012, 1, 27), fc.LastFridays(CreateDate(2012, 1)));
        }

        [TestMethod]
        public void LastFriday_feb2012_ReturnDates()
        {
            Assert.AreEqual(CreateDate(2012, 2, 24), fc.LastFridays(CreateDate(2012, 02)));
        }
    }





     public class Fridaycalculator
    {
        internal DateTime LastFridays(DateTime date)
        {   
            if (date == default(DateTime)) return date;

            var lastFridayDay = date.AddMonths(1).AddDays(-1);
            while (lastFridayDay.DayOfWeek != DayOfWeek.Friday)
            {
                lastFridayDay = lastFridayDay.AddDays(-1);
            }

            return lastFridayDay;
        }
    }
}
