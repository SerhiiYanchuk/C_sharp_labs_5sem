﻿using System;
using System.Linq;
using BLL.DTO;
using Microsoft.Extensions.DependencyInjection;
using BLL.Interfaces;

namespace lab3_DAL_BLL_PL_ConsoleVersion_
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = HotelServiceProvider.GetServiceProvider();
            Console.WriteLine("1 - Сделать заказ\n2 - Оплатить бронировку");
            int inputInt = int.Parse(Console.ReadLine());
            switch (inputInt)
            {
                case 1:
                    MakeOrder(provider.GetService<IHotelService>());
                    break;
                case 2:
                    ConfirmPayment(provider.GetService<IHotelService>());
                    break;
            }
        }
        public static void MakeOrder(IHotelService service)
        {           
                int inputInt;
                Console.WriteLine("Такс заполните форму для поиска нужной комнаты");
                HotelRoomSeachFilterDTO roomFilter = new HotelRoomSeachFilterDTO();

                Console.WriteLine("Какого типа комфорта вы желаете?\n1 - Standart, 2 - Suite, 3 - De_Luxe, 4 - Duplex, 5 - Family_Room, 6 - Honeymoon_Room, 0 - Not important");
                while(true)
                {
                    Console.Write("Введите номер: ");
                    if (int.TryParse(Console.ReadLine(), out inputInt))
                        if (inputInt >= 0 && inputInt <= 6)
                            break;
                    Console.WriteLine("Try again");
                    continue;
                }
                roomFilter.TypeComfort = (TypeComfortEnumDTO)inputInt;

                Console.WriteLine("Какого типа размера вы желаете?\n1 - SGL, 2 - DBL, 3- DBL_TWN, 4 - TRPL, 5 - DBL_EXB, 6 - TRPL_EXB, 0 - Not important");
                while (true)
                {
                    Console.Write("Введите номер: ");
                    if (int.TryParse(Console.ReadLine(), out inputInt))
                        if (inputInt >= 0 && inputInt <= 6)
                            break;
                    Console.WriteLine("Try again");
                    continue;
                }
                roomFilter.TypeSize = (TypeSizeEnumDTO)inputInt;

                Console.WriteLine("На которую дату хотите заселится?");
                Console.Write("Год: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Месяц: ");
                int month = int.Parse(Console.ReadLine());
                Console.Write("День: ");
                int day = int.Parse(Console.ReadLine());
                roomFilter.CheckInDate = new DateTime(year, month, day);

                var rooms = service.SearchFreeRooms(roomFilter);
                if (!rooms.Any())
                    Console.WriteLine("К сожалению свободных подобных комнат нет на данную дату");
                else
                {
                    Console.WriteLine("Найденные комнаты:");
                    foreach (var t in rooms)
                        Console.WriteLine("Номер: " + t.Number + " Цена за день: " + t.PricePerDay + " Комфорт: " + t.TypeComfort.ToString() + " Размер: " + t.TypeSize.ToString() + " Дата заезда: " + t.CheckInDate + " Макс дата отъезда: " + t.MaxCheckOutDate);

                    FreeHotelRoomDTO room;
                    string inputString;
                    while (true)
                    {
                        Console.Write("Какой номер предпочитаете: ");
                        inputString = Console.ReadLine();
                        room = rooms.SingleOrDefault(p => p.Number == inputString);
                        if (!(room is null))
                            break;
                        Console.WriteLine("У Вас проблемы с цифрами)))  Try Again");              
                        continue;
                    }

                    ActiveOrderDTO order = new ActiveOrderDTO();
                    order.HotelRoomId = room.HotelRoomId;
                    order.ChecknInDate = room.CheckInDate;
                    Console.Write("На которое количество дней: ");
                    int days = int.Parse(Console.ReadLine());
                    order.CheckOutDate = room.CheckInDate.AddDays(days);
                    //order.DateRegistration = DateTime.Now;
                    
                    ClientDTO client = new ClientDTO();
                    Console.Write("Ваше имя: ");
                    inputString = Console.ReadLine();
                    client.FirstName = inputString;
                    Console.Write("Ваша фамилия: ");
                    inputString = Console.ReadLine();
                    client.LastName = inputString;
                    Console.Write("Ваш номер телефона: ");
                    inputString = Console.ReadLine();
                    client.PhoneNumber = inputString;
                    //order.Client = client;

                    Console.Write("Бронь или оплата: 1 - Paid, 2 - Booked\n");
                    while (true)
                    {
                        Console.Write("Введите номер: ");
                        if (int.TryParse(Console.ReadLine(), out inputInt))
                            if (inputInt >= 1 && inputInt <= 2)
                                break;
                        Console.WriteLine("Try again");
                        continue;
                    }
                    order.PaymentState = (PaymentStateEnumDTO)inputInt;

                    service.AddClientActiveOrder(order, client);
                }
            service.Dispose();
        }
        public static void ConfirmPayment(IHotelService service)
        {
                Console.Write("Ваш номер телефона: ");
                string input = Console.ReadLine();

                var orders = service.FindClientActiveOrders(input, PaymentStateEnumDTO.B);
                if (!orders.Any())
                    Console.WriteLine("Вы ничего не заказывали");
                else
                {
                    Console.WriteLine("Ваши заказы:");
                    int i = 1;
                    foreach (var order in orders)
                        Console.WriteLine(i++ + ") " + order.HotelRoom.Number + " Дата заселение: " + order.ChecknInDate + " Цена за день: " + order.HotelRoom.PricePerDay + " " + order.PaymentState.ToString());
                    Console.WriteLine("Какой заказ Вы хотите оплитить?");
                    int inputInt;
                    while (true)
                    {
                        Console.Write("Введите номер: ");
                        if (int.TryParse(Console.ReadLine(), out inputInt))
                            if (inputInt >= 1 && inputInt <= orders.Count())
                                break;
                        Console.WriteLine("Try again");
                        continue;
                    }
                    var updateOrder = orders.ToList()[inputInt - 1];
                    service.ConfirmPayment(updateOrder.ActiveOrderId);
                }
            service.Dispose();
        }
    }
}
