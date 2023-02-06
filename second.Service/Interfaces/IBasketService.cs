using second.Domain.Entity;
using second.Domain.Response;
using second.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace second.Service.Interfaces
{
    public interface IBasketService
    {
        Task<BaseResponse<IEnumerable<OrderViewModel>>> GetItems(string name);
        Task<BaseResponse<bool>> AddToBasket(int idrb, string name);
        Task<BaseResponse<bool>> DeleteFromBasket(int idrb, string name);
    }
}
