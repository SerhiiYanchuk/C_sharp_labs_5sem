﻿using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using HotelApp.BLL.DTO;
using HotelApp.DAL.Entities;

namespace HotelApp.BLL.Infrastructure
{
    public class HotelServiceMapperProfile: Profile
    {
        public HotelServiceMapperProfile()
        {
            CreateMap<TypeComfortEnumDTO, TypeComfortEnum>().ConvertUsingEnumMapping(p => p.MapByName().MapValue(TypeComfortEnumDTO.Undefined, default)).ReverseMap();
            CreateMap<TypeSizeEnumDTO, TypeSizeEnum>().ConvertUsingEnumMapping(p => p.MapByName().MapValue(TypeSizeEnumDTO.Undefined, default)).ReverseMap();
            CreateMap<HotelRoom, FreeHotelRoomDTO>()
                .ForMember(p => p.TypeComfort, p => p.MapFrom(t => t.TypeComfort.Comfort))
                .ForMember(p => p.TypeSize, p => p.MapFrom(t => t.TypeSize.Size));
            CreateMap<HotelRoom, HotelRoomDTO>()
                .ForMember(p => p.TypeComfort, p => p.MapFrom(t => t.TypeComfort.Comfort))
                .ForMember(p => p.TypeSize, p => p.MapFrom(t => t.TypeSize.Size));

            CreateMap<HotelRoomDTO, HotelRoom>()
                .ForPath(p => p.TypeComfort.Comfort, p => p.MapFrom(t => t.TypeComfort))
                .ForPath(p => p.TypeSize.Size, p => p.MapFrom(t => t.TypeSize));

            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<PaymentStateEnumDTO, PaymentStateEnum>().ConvertUsingEnumMapping(p => p.MapByName().MapValue(PaymentStateEnumDTO.Undefined, default)).ReverseMap();
            CreateMap<ActiveOrderDTO, ActiveOrder>().ReverseMap();
        }
    }
}