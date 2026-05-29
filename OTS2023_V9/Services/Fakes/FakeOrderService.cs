using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_V9.Services.Fakes
{
    internal class FakeOrderService
    {
        public List<Order> Orders { get; set; }
        public double UpdateTotalDifference { get; set; }

        public FakeOrderService()
        {
            Orders = new List<Order>();
        }
        public FakeOrderService GetOrderById(Guid id)
        {
            return Orders[0];
        }
        public List<Order> GetUserOrdersWithDeadLineBetween(Guid id, DateTime monthBefore, DateTime Now)
        {
            return Orders;
        }
        public List<Order> deliveredOrders(string Status.Delivered)
        {
            return Orders = Orders.Status.Delivered;
        }
    }
}
