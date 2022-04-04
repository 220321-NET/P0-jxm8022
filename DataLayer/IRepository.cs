﻿namespace DataLayer;
public interface IRepository
{
    void AddCustomer(Customer customer);
    Customer GetCustomer(string username);
    List<Customer> GetAllCustomers(bool employee);
    void UpdateCustomer(Customer customer);
    void AddStore(StoreFront store);
    StoreFront GetStore(string city);
    List<StoreFront> GetStoreFronts();
    void AddProduct(Product product);
    void AddProduct(Product product, StoreFront store);
    Product GetProduct(string name);
    List<Product> GetAllProducts();
}
