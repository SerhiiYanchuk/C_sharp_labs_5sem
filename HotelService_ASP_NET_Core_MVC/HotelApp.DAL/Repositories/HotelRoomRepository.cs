﻿using HotelApp.DAL.Interfaces;
using HotelApp.DAL.Entities;
using HotelApp.DAL.EF;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace HotelApp.DAL.Repositories
{
    public class HotelRoomRepository: Repository<HotelRoom>, IHotelRoomRepository
    {
        public HotelRoomRepository(HotelDbContext context): base(context)
        {
        }
        public override IEnumerable<HotelRoom> FindAll(bool isTracked = true)
        {
            IQueryable<HotelRoom> set = context.HotelRooms.Include(p => p.TypeSize).Include(p => p.TypeComfort);
            if (!isTracked)
                set.AsNoTracking();
            return set.ToList();
        }
        public override HotelRoom FindById(int id, bool isTracked = true)
        {
            IQueryable<HotelRoom> set = context.HotelRooms.Where(p => p.HotelRoomId == id).Include(p => p.TypeComfort).Include(p => p.TypeSize);
            if (!isTracked)
                set.AsNoTracking();
            return set.SingleOrDefault();        
        }
        public override IEnumerable<HotelRoom> Find(Expression<Func<HotelRoom, bool>> predicate, bool isTracked = true)
        {
            IQueryable<HotelRoom> set = context.HotelRooms.Include(p => p.TypeComfort).Include(p => p.TypeSize).Where(predicate);
            if (!isTracked)
                return set.AsNoTracking();
            return set.ToList();
        }
        public override void Insert(HotelRoom item)
        {
            item.TypeComfort = context.Set<TypeComfort>().Where(p => p.Comfort == item.TypeComfort.Comfort).SingleOrDefault();
            item.TypeSize = context.Set<TypeSize>().Where(p => p.Size == item.TypeSize.Size).SingleOrDefault();
            context.Add(item);
        }
        public override void Update(HotelRoom item)
        {
            item.TypeComfortId = context.Set<TypeComfort>().Where(p => p.Comfort == item.TypeComfort.Comfort).Select(p => p.TypeComfortId).SingleOrDefault();
            item.TypeSizeId = context.Set<TypeSize>().Where(p => p.Size == item.TypeSize.Size).Select(p => p.TypeSizeId).SingleOrDefault();
            context.Update(item);
        }

        public IEnumerable<HotelRoom> FindFreeRooms(DateTime checkInDate, TypeSizeEnum size = 0, TypeComfortEnum comfort = 0)
        {            
            IQueryable<HotelRoom> rooms = context.HotelRooms.Include(p => p.TypeComfort).Include(p => p.TypeSize).Include(p => p.ActiveOrders);
            if (size != 0)
                rooms = rooms.Where(p => p.TypeSize.Size == size);
            if (comfort != 0)
                rooms = rooms.Where(p => p.TypeComfort.Comfort == comfort);
            return rooms.Where(p => p.ActiveOrders.All(t => t.ChecknInDate > checkInDate || t.CheckOutDate <= checkInDate)).AsNoTracking().ToList();
        }
        public IEnumerable<HotelRoom> FindFreeRooms(DateTime checkInDate, DateTime checkOutDate, TypeSizeEnum size = 0, TypeComfortEnum comfort = 0)
        {
            IQueryable<HotelRoom> rooms = context.HotelRooms.Include(p => p.TypeComfort).Include(p => p.TypeSize).Include(p => p.ActiveOrders);
            if (size != 0)
                rooms = rooms.Where(p => p.TypeSize.Size == size);
            if (comfort != 0)
                rooms = rooms.Where(p => p.TypeComfort.Comfort == comfort);
            return rooms.Where(p => p.ActiveOrders.All(t => (checkInDate > t.ChecknInDate && checkInDate >= t.CheckOutDate) || (checkOutDate <= t.ChecknInDate && checkOutDate < t.CheckOutDate)))
                .AsNoTracking().ToList();
        }
        public void LoadActiveOrders(HotelRoom room)
        {
            context.Entry(room).Collection(p => p.ActiveOrders).Load();
        }
        public void LoadClients(HotelRoom room)
        {
            context.Entry(room).Collection(p => p.Clients).Load();
        }
        public IEnumerable<HotelRoom> GetRoomsPage(int pageIndex, int pageSize = 3)
        {
            return context.HotelRooms.Include(p => p.TypeComfort).Include(p => p.TypeSize)
                .OrderBy(p => p.Number)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToList();
        }
    }
}