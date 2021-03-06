﻿using BLL.DTO;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IHotelService: IDisposable
    {
        public IEnumerable<FreeHotelRoomDTO> SearchFreeRooms(HotelRoomSeachFilterDTO filter);
        public void AddClientActiveOrder(ActiveOrderDTO _order, ClientDTO _client);
        public IEnumerable<ActiveOrderDTO> FindClientActiveOrders(string phoneNumber, PaymentStateEnumDTO paymentState = default);
        public void ConfirmPayment(int activeOrderId);
    }
}
