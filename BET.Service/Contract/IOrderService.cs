using BET.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Service.Contract
{
    public interface IOrderService
    {
        void SaveOrder(Order order);
    }
}
