using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriveEcommerce.BusinessLibrary.Model;

namespace ThriveEcommerce.BusinessLibrary.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> CheckOut(OrderModel orderModel);
    }
}
