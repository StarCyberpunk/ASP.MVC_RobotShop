using second.DAL.Interfaces;
using second.Domain.Entity;
using second.Domain.Response;
using second.Domain.ViewModels;
using second.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace second.Service.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBaseRepository<Robot> _rbRepo;
        private readonly IBaseRepository<User> _usRepo;
        private readonly IBaseRepository<Basket> _bsRepo;
        private readonly IBaseRepository<Order> _orRepo;
        public BasketService(IBaseRepository<Robot> rbRepo, IBaseRepository<User> usRepo,
            IBaseRepository<Basket> bsRepo,IBaseRepository<Order> orRepo)
        {
            _rbRepo = rbRepo;
            _usRepo = usRepo;
            _bsRepo = bsRepo;
            _orRepo = orRepo;
        }
        public async Task<BaseResponse<IEnumerable<OrderViewModel>>> GetItems(string name)
        {
            var baseResponse = new  BaseResponse< IEnumerable<OrderViewModel>>();
            try
            {
                var user = await _usRepo.Select()
                    .Include(x=>x.Basket).ThenInclude(x=>x.Orders).FirstOrDefaultAsync(x=>x.Login==name)
                    ;
                if (user == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;

                }
                else
                {

                    var orders = user.Basket?.Orders;
                    var res = from p in orders
                              join r in (IEnumerable<Robot>)_rbRepo.Select() on p.RobotId equals r.Id
                              select new OrderViewModel()
                              {
                                  Id = p.Id,
                                  RobotName = r.Name,
                                  Speed = r.Speed,
                                  TypeRobot = r.TypeRobot,
                                  Model = r.Model

                              };

                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    baseResponse.Data = res;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<IEnumerable<OrderViewModel>>(); 
                z.Description = $"[GetItems]:{ex.Message}";

                return z;
            }
        }
        public async Task<BaseResponse<bool>> AddToBasket(int idrb,string name)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var user = await _usRepo.Select()
                    .Include(x=>x.Profile)
                    .Include(x => x.Basket).ThenInclude(x => x.Orders).FirstOrDefaultAsync(x => x.Login == name)
                    ;
                if (user == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;

                }
                else
                {
                    var basket = user.Basket;
                    if (basket == null)
                    {
                        Basket b = new Basket
                        {
                            UserId = user.Id,
                            User = user,
                            Orders = new List<Order>()

                        };
                        _bsRepo.Create(b);
                        user.Basket = b;
                    }
                     basket = user.Basket;
                    var order = new Order()
                    {
                        RobotId = idrb,
                        Address = user.Profile.Address,
                        DateCreated = DateTime.Now,
                        Basket = basket,
                        BasketId = basket.Id,
                    };
                    user.Basket.Orders.Add(order);
                   await _bsRepo.Update(user.Basket);
                   

                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    baseResponse.Data = true;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<bool>();
                z.Description = $"[GetItems]:{ex.Message}";

                return z;
            }
        }
        public async Task<BaseResponse<bool>> DeleteFromBasket(int idrb, string name)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var user = await _usRepo.Select()
                    .Include(x => x.Profile)
                    .Include(x => x.Basket).ThenInclude(x => x.Orders).FirstOrDefaultAsync(x => x.Login == name)
                    ;
                if (user == null)
                {
                    baseResponse.Description = "Не найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.UserNotFound;

                }
                else
                {
                    var orders = user.Basket.Orders;
                    Order r = orders.FirstOrDefault(x => x.Id == idrb);

                    user.Basket.Orders.Remove(r);
                    await _bsRepo.Update(user.Basket);


                    baseResponse.Description = "Найдено";
                    baseResponse.StatusCode = Domain.Enum.StatusCode.OK;
                    baseResponse.Data = true;
                }

                return baseResponse;

            }
            catch (Exception ex)
            {
                var z = new BaseResponse<bool>();
                z.Description = $"[GetItems]:{ex.Message}";

                return z;
            }
        }
    }
}
