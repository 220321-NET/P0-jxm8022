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
        DataSet customerSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT Username FROM Customer WHERE CustomerID = -1", connection);

        SqlDataAdapter customerAdapter = new SqlDataAdapter(cmd);

        customerAdapter.Fill(customerSet, "CustomerTable");

        DataTable? customerTable = customerSet.Tables["CustomerTable"];
        if (customerTable != null)
        {
            DataRow newRow = customerTable.NewRow();
            newRow["Username"] = customer.UserName;

            customerTable.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(customerAdapter);
            SqlCommand insert = commandBuilder.GetInsertCommand();

            customerAdapter.InsertCommand = insert;

            customerAdapter.Update(customerTable);
        }
    }

    public Customer GetCustomer(string username)
    {
        DataSet customerSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE Username = @username", connection);
        cmd.Parameters.AddWithValue("@username", username);

        SqlDataAdapter customerAdapter = new SqlDataAdapter(cmd);

        customerAdapter.Fill(customerSet, "CustomerTable");

        DataTable? customerTable = customerSet.Tables["CustomerTable"];
        if (customerTable != null && customerTable.Rows.Count > 0)
        {
            Customer customer = new Customer();
            customer.CustomerID = (int)customerTable.Rows[0]["CustomerID"];
            customer.UserName = (string)customerTable.Rows[0]["Username"];
            customer.Employee = (bool)customerTable.Rows[0]["IsEmployee"];
            return customer;
        }
        return null!;
    }

    public void UpdateCustomer(Customer customer)
    {
        DataSet customerSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE CustomerID = @CustomerID", connection);
        cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

        SqlDataAdapter customerAdapter = new SqlDataAdapter(cmd);

        customerAdapter.Fill(customerSet, "CustomerTable");

        DataTable? customerTable = customerSet.Tables["CustomerTable"];
        if (customerTable != null && customerTable.Rows.Count > 0)
        {
            DataColumn[] dt = new DataColumn[1];
            dt[0] = customerTable.Columns["CustomerID"]!;
            customerTable.PrimaryKey = dt;
            DataRow? customerRow = customerTable.Rows.Find(customer.CustomerID);
            if (customerRow != null)
            {
                customerRow["IsEmployee"] = !customer.Employee;
            }

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(customerAdapter);
            SqlCommand updateCmd = commandBuilder.GetUpdateCommand();

            customerAdapter.UpdateCommand = updateCmd;
            customerAdapter.Update(customerTable);
        }
    }

    public List<Customer> GetAllCustomers(bool employee)
    {
        List<Customer> customers = new List<Customer>();
        DataSet customerSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE IsEmployee = @employee", connection);
        cmd.Parameters.AddWithValue("@employee", employee);

        SqlDataAdapter customerAdapter = new SqlDataAdapter(cmd);

        customerAdapter.Fill(customerSet, "CustomerTable");

        DataTable? customerTable = customerSet.Tables["CustomerTable"];
        if (customerTable != null && customerTable.Rows.Count > 0)
        {
            foreach (DataRow row in customerTable.Rows)
            {
                Customer customer = new Customer
                {
                    CustomerID = (int)row["CustomerID"],
                    UserName = (string)row["Username"],
                    Employee = (bool)row["IsEmployee"]
                };
                customers.Add(customer);
            }
            return customers;
        }
        return null!;
    }

    public void AddStore(StoreFront store)
    {
        DataSet storeSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT City, State FROM Store WHERE StoreID = -1", connection);

        SqlDataAdapter storeAdapter = new SqlDataAdapter(cmd);

        storeAdapter.Fill(storeSet, "StoreTable");

        DataTable? storeTable = storeSet.Tables["StoreTable"];
        if (storeTable != null)
        {
            DataRow newRow = storeTable.NewRow();
            newRow["City"] = store.City;
            newRow["State"] = store.State;

            storeTable.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(storeAdapter);
            SqlCommand insert = commandBuilder.GetInsertCommand();

            storeAdapter.InsertCommand = insert;

            storeAdapter.Update(storeTable);
        }
    }

    public StoreFront GetStore(string city)
    {
        DataSet storeSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Store WHERE City = @city", connection);
        cmd.Parameters.AddWithValue("@city", city);

        SqlDataAdapter storeAdapter = new SqlDataAdapter(cmd);

        storeAdapter.Fill(storeSet, "storeTable");

        DataTable? storeTable = storeSet.Tables["storeTable"];
        if (storeTable != null && storeTable.Rows.Count > 0)
        {
            return new StoreFront
            {
                StoreID = (int)storeTable.Rows[0]["StoreID"],
                City = (string)storeTable.Rows[0]["City"],
                State = (string)storeTable.Rows[0]["State"]
            };
        }
        return null!;
    }

    public List<StoreFront> GetStoreFronts()
    {
        List<StoreFront> storeFronts = new List<StoreFront>();
        DataSet storeSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Store", connection);

        SqlDataAdapter storeAdapter = new SqlDataAdapter(cmd);

        storeAdapter.Fill(storeSet, "StoreTable");

        DataTable? storeTable = storeSet.Tables["StoreTable"];
        if (storeTable != null && storeTable.Rows.Count > 0)
        {
            foreach (DataRow row in storeTable.Rows)
            {
                StoreFront store = new StoreFront
                {
                    StoreID = (int)row["StoreID"],
                    City = (string)row["City"],
                    State = (string)row["State"]
                };
                storeFronts.Add(store);
            }
            return storeFronts;
        }
        return null!;
    }

    public void AddProduct(Product product)
    {
        DataSet productSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT Name, Price FROM Product WHERE ProductID = -1", connection);

        SqlDataAdapter productAdapter = new SqlDataAdapter(cmd);

        productAdapter.Fill(productSet, "ProductTable");

        DataTable? productTable = productSet.Tables["ProductTable"];
        if (productTable != null)
        {
            DataRow newRow = productTable.NewRow();
            newRow["Name"] = product.ProductName;
            newRow["Price"] = product.ProductPrice;

            productTable.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(productAdapter);
            SqlCommand insert = commandBuilder.GetInsertCommand();

            productAdapter.InsertCommand = insert;

            productAdapter.Update(productTable);
        }
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
        DataSet inventorySet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory WHERE ProductID = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataAdapter inventoryAdapter = new SqlDataAdapter(cmd);

        inventoryAdapter.Fill(inventorySet, "InventoryTable");

        DataTable? inventoryTable = inventorySet.Tables["InventoryTable"];
        if (inventoryTable != null && inventoryTable.Rows.Count > 0)
        {
            return (int)inventoryTable.Rows[0]["Quantity"];
        }
        return -1;
    }

    public void UpdateInventory(Product product)
    {
        DataSet inventorySet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory WHERE ProductID = @id", connection);
        cmd.Parameters.AddWithValue("@id", product.ProductID);

        SqlDataAdapter inventoryAdapter = new SqlDataAdapter(cmd);

        inventoryAdapter.Fill(inventorySet, "InventoryTable");

        DataTable? inventoryTable = inventorySet.Tables["InventoryTable"];
        if (inventoryTable != null && inventoryTable.Rows.Count > 0)
        {
            DataColumn[] dt = new DataColumn[1];
            dt[0] = inventoryTable.Columns["InventoryID"]!;
            inventoryTable.PrimaryKey = dt;
            DataRow? inventoryRow = inventoryTable.Rows.Find(product.ProductID);
            if (inventoryRow != null)
            {
                inventoryRow["Quantity"] = product.ProductQuantity;
            }

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(inventoryAdapter);
            SqlCommand updateCmd = commandBuilder.GetUpdateCommand();

            inventoryAdapter.UpdateCommand = updateCmd;
            inventoryAdapter.Update(inventoryTable);
        }
    }

    public void AddInventory(Product product, StoreFront store)
    {
        DataSet inventorySet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Inventory WHERE ProductID = -1", connection);

        SqlDataAdapter inventoryAdapter = new SqlDataAdapter(cmd);

        inventoryAdapter.Fill(inventorySet, "InventoryTable");

        DataTable? inventoryTable = inventorySet.Tables["InventoryTable"];
        if (inventoryTable != null)
        {
            DataRow newRow = inventoryTable.NewRow();
            newRow["ProductID"] = product.ProductID;
            newRow["Quantity"] = product.ProductQuantity;
            newRow["StoreID"] = store.StoreID;

            inventoryTable.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(inventoryAdapter);
            SqlCommand insert = commandBuilder.GetInsertCommand();

            inventoryAdapter.InsertCommand = insert;

            inventoryAdapter.Update(inventoryTable);
        }
    }

    public Product GetProduct(string name)
    {
        DataSet productSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE Name = @name", connection);
        cmd.Parameters.AddWithValue("@name", name);

        SqlDataAdapter productAdapter = new SqlDataAdapter(cmd);

        productAdapter.Fill(productSet, "productTable");

        DataTable? productTable = productSet.Tables["productTable"];
        if (productTable != null && productTable.Rows.Count > 0)
        {
            return new Product
            {
                ProductID = (int)productTable.Rows[0]["ProductID"],
                ProductName = (string)productTable.Rows[0]["Name"],
                ProductPrice = (decimal)productTable.Rows[0]["Price"]
            };
        }
        return null!;
    }

    public List<Product> GetAllProducts()
    {
        List<Product> products = new List<Product>();
        DataSet productSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Product", connection);

        SqlDataAdapter productAdapter = new SqlDataAdapter(cmd);

        productAdapter.Fill(productSet, "ProductTable");

        DataTable? productTable = productSet.Tables["ProductTable"];
        if (productTable != null && productTable.Rows.Count > 0)
        {
            foreach (DataRow row in productTable.Rows)
            {
                Product product = new Product
                {
                    ProductID = (int)row["ProductID"],
                    ProductName = (string)row["Name"],
                    ProductPrice = (decimal)row["Price"]
                };
                products.Add(product);
            }
            return products;
        }
        return null!;
    }
}