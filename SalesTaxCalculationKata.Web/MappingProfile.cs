using System.Linq;
using AutoMapper;
using SalesTaxCalculationKata.Core.Models;
using SalesTaxCalculationKata.Data.Models;

namespace SalesTaxCalculationKata.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateOrderMaps();
            CreateMap<OrderItem, OrderItemModel>();
            CreateMap<OrderItemModel, OrderItem>();
            CreateMap<Category, CategoryModel>();
            CreateMap<CategoryModel, Category>();
            CreateProductMaps();
            CreateMap<Tax, TaxModel>();
            CreateMap<TaxModel, Tax>();
            CreateMap<TaxCategory, TaxCategoryModel>();
            CreateMap<TaxCategoryModel, TaxCategory>();
        }

        private void CreateOrderMaps()
        {
            CreateMap<Order, OrderModel>();
            CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.Ignore())
                .AfterMap(PopulateOrderItems);
        }

        private static void PopulateOrderItems(OrderModel dest, Order src)
        {
            foreach (var oi in dest.OrderItems)
            {
                PopulateOrderItem(src, oi);
            }
        }

        private static void PopulateOrderItem(Order src, OrderItemModel oi)
        {
            bool isOrderItemPersisted = oi.OrderItemId == 0;

            if (isOrderItemPersisted)
            {
                src.OrderItems.Add(new OrderItem
                {
                    OrderId = src.OrderId,
                    ProductId = oi.ProductId,
                    SalesTax = oi.SalesTax
                });
            }
            else
            {
                MapOrder(src, oi);
            }
        }

        private static void MapOrder(Order src, OrderItemModel oi)
        {
            var item = src.OrderItems.Single(x => x.OrderItemId == oi.OrderItemId);
            item.ProductId = oi.ProductId;
            item.OrderItemId = oi.OrderItemId;
            item.OrderId = src.OrderId;
            item.SalesTax = oi.SalesTax;
        }

        private void CreateProductMaps()
        {
            CreateMap<ProductModel, Product>()
                .ForMember(dest => dest.ProductCategories,
                    opt => opt.MapFrom(src => src.Categories.Select(c => new ProductCategory
                    {
                        CategoryId = c.CategoryId,
                        ProductId = src.ProductId
                    })));
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.Categories,
                    opt => opt.MapFrom(src => src.ProductCategories.Select(pc => new Category
                    {
                        CategoryId = pc.CategoryId,
                        Description = pc.Category.Description
                    })));
        }
    }
}
