using BookStoreProject.BLL.ViewModels.BookViewModels;
using BookStoreProject.BLL.ViewModels.DiscountCouponViewModels;
using BookStoreProject.BLL.ViewModels.OrderDetailsViewModels;
using BookStoreProject.BLL.ViewModels.OrderViewModels;
using BookStoreProject.DAL.Data.Models;
using BookStoreProject.DAL.Repositories.OrderRepository;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.BLL.Managers.OrderManager
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepo _orderRepo;

        public OrderManager(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public IEnumerable<OrderReadVM> GetAll()
        {
            var OrderModelList =_orderRepo.GetAll();

            var OrderReadVMList = OrderModelList.Select(a => new OrderReadVM
            {
                Id = a.Id,
                OrderDate = a.OrderDate,
                ShippingAddress = a.ShippingAddress,
                TotalAmount = a.TotalAmount,

                DiscountCouponReadVM = a.DiscountCoupon != null
            ? new DiscountCouponReadVM
            {
                Id = a.DiscountCoupon.Id,
                Code = a.DiscountCoupon.Code
            }
            : null,

                BookReadVMs = a.Books.Select(book => new BookReadVM
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    ImgUrl=book.ImgUrl,
                    Description =book.Description,
                    CategoryID = book.CategoryID
                }).ToList(),

                OrderDetailsReadVMs = a.Details.Select(d => new OrderDetailsReadVM
                {
                    Id = d.Id,
                    Price = d.Price,
                    Quantity = d.Quantity

                }).ToList(),
            }).ToList();

            return OrderReadVMList;
        }
        public OrderReadVM GetById(int id)
        {
            var OrderModel=_orderRepo.GetById(id);
            var OrderReadVM = new OrderReadVM
            {

                Id = id,
                ShippingAddress = OrderModel.ShippingAddress,
                OrderDate = OrderModel.OrderDate,
                TotalAmount = OrderModel.TotalAmount,
                DiscountCouponReadVM = OrderModel.DiscountCoupon != null
            ? new DiscountCouponReadVM
            {
                Id = OrderModel.DiscountCoupon.Id,
                Code = OrderModel.DiscountCoupon.Code
            }
            : null,
                BookReadVMs = OrderModel.Books.Select(book => new BookReadVM
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    Description = book.Description,
                    CategoryID = book.CategoryID
                }).ToList(),

                OrderDetailsReadVMs = OrderModel.Details.Select(d => new OrderDetailsReadVM
                {
                    Id = d.Id,
                    Price = d.Price,
                    Quantity = d.Quantity

                }).ToList(),
            };
            return OrderReadVM;
        }

        public void AddOrder(OrderAddVM orderAddVM)
        {
            Order order = new Order()
            {
                ShippingAddress = orderAddVM.ShippingAddress,

                DiscountCoupon = new DiscountCoupon
                {
                    Code = orderAddVM.DiscountCouponAddVM.Code
                },

             
                Books = orderAddVM.BookAddVM.Select(bookAddVM => new Book
                {
                    Id = bookAddVM.Id
                }).ToList()
            };
           _orderRepo.Add(order);
        }

        //public void UpdateOrder(OrderUpdateVM orderUpdateVM)
        //{
        //    var OrderModel = _orderRepo.GetById(orderUpdateVM.Id);

        //    OrderModel.ShippingAddress = orderUpdateVM.ShippingAddress;
        //    OrderModel.DiscountCoupon=new DiscountCoupon
        //    {
        //        Code= orderUpdateVM.DiscountCouponUpdateVM.Code
        //    };
        //    OrderModel.Books=orderUpdateVM.BookUpdateVM.Select(BookUpdateVM =>new Book
        //    {
        //        Id= orderUpdateVM.Id
        //    } 
        //    ).ToList();
        //    _orderRepo.Update(OrderModel);
        //}

        public void DeleteOrder(int id)
        {
           var OrderModel= _orderRepo.GetById(id);

            _orderRepo.Delete(OrderModel);
        }

    }
}
