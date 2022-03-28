using ModelLayer;

namespace BusinessLayer;

public interface IBusinessLayer
{
    void AddProduct(Product product);
    List<Product> GetProducts();
    List<Order> GetOrders();
}