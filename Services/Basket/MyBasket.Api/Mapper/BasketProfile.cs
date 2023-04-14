using AutoMapper;
using MyBasket.Api.Entities;
using EventBus.Messages.Events;

namespace MyBasket.Api.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
