using Microsoft.Data.SqlClient;
using System.Data;

namespace DataLayer;
public class DBRepository : IRepository
{
    private readonly string _connectionString;

    public DBRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddCustomer(Customer customer)
    {
        DBCustomer.AddCustomer(customer, _connectionString);
    }

    public Customer GetCustomer(string username)
    {
        return DBCustomer.GetCustomer(username, _connectionString);
    }

    public void UpdateCustomer(Customer customer)
    {
        DBCustomer.UpdateCustomer(customer, _connectionString);
    }

    public List<Customer> GetAllCustomers(bool employee)
    {
        return DBCustomer.GetAllCustomers(employee, _connectionString);
    }

    public void AddStore(StoreFront store)
    {
        DBStoreFront.AddStore(store, _connectionString);
    }

    public StoreFront GetStore(string city)
    {
        return DBStoreFront.GetStore(city, _connectionString);
    }

    public List<StoreFront> GetStoreFronts()
    {
        return DBStoreFront.GetStoreFronts(_connectionString);
    }

    public void AddProduct(Product product)
    {
        DBProduct.AddProduct(product, _connectionString);
    }

    public void AddProduct(Product product, StoreFront store)
    {
        // get productID
        int amount = product.ProductQuantity;
        product = GetProduct(product.ProductName);
        if (product != null)
        {
            product.ProductQuantity = amount;
            if (PreviousInventory(product.ProductID) != -1)
            {
                product.ProductQuantity += PreviousInventory(product.ProductID);
                UpdateInventory(product);
            }
            else
            {
                AddInventory(product, store);
            }
        }
        else
        {
            Console.WriteLine("Could not add to inventory new product!");
        }
    }

    public int PreviousInventory(int id)
    {
        return DBInventory.PreviousInventory(id, _connectionString);
    }

    public void UpdateInventory(Product product)
    {
        DBInventory.UpdateInventory(product, _connectionString);
    }

    public void AddInventory(Product product, StoreFront store)
    {
        DBInventory.AddInventory(product, store, _connectionString);
    }

    public Product GetProduct(string name)
    {
        return DBProduct.GetProduct(name, _connectionString);
    }

    public List<Product> GetAllProducts()
    {
        return DBProduct.GetAllProducts(_connectionString);
    }
}