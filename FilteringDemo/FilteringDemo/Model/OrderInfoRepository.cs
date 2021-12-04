using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FilteringDemo
{
    public class OrderInfoRepository
    {
        public OrderInfoRepository()
        {
        }

        #region private variables

        private Random random = new Random();

        #endregion

        #region GetOrderDetails

        public ObservableCollection<OrderInfo> GetOrderDetails(int count)
        {
            ObservableCollection<OrderInfo> orderDetails = new ObservableCollection<OrderInfo>();

            for (int i = 10001; i <= count + 10000; i++)
            {
                var ord = new OrderInfo()
                {
                    OrderID = i,
                    CustomerID = CustomerID[random.Next(15)],
                    Freight = (Math.Round(random.Next(1000) + random.NextDouble(), 2)).ToString(),
                    Country = country[random.Next(20)]
                };
                orderDetails.Add(ord);
            }
            return orderDetails;
        }

        #endregion

        string[] CustomerID = new string[] {
            "Alfki",
            "Frans",
            "Merep",
            "Folko",
            "Simob",
            "Warth",
            "Vaffe",
            "Furib",
            "Seves",
            "Linod",
            "Riscu",
            "Picco",
            "Blonp",
            "Welli",
            "Folig"
        };

        string[] country = new string[]
        {
            "US",
            "Australia",
            "Canada",
            "UK",
            "India",
            "Italy",
            "China",
            "Japan",
            "Belgium",
            "Mexico",
            "Brazil",
            "Singapore",
            "North Korea",
            "Greece",
            "Norway",
            "Netherland",
            "Austria",
            "Sweden",
            "Poland",
            "Hungary",
            "Russia"
        };

    }
}
