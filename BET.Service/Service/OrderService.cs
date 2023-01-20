using BET.Data.GenericRepository;
using BET.Data.Model;
using BET.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _iRepository;
        public OrderService(IRepository iRepository)
        {
            _iRepository = iRepository;
        }

        public async void SaveOrder(Order order)
        {
             _iRepository.Create(order);
            await _iRepository.SaveAsync();
        }
    }
}
