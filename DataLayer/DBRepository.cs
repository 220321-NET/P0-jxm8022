using Microsoft.Data.SqlClient;

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
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(@"INSERT INTO Customers(Username)
            VALUES(" + customer.UserName + ")", connection);

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            cmd = new SqlCommand(@"CREATE TABLE Customer(
                CustomerID INT PRIMARY KEY IDENTITY(1,1),
                Username VARCHAR(30) NOT NULL UNIQUE,
                IsEmployee BIT DEFAULT 0
            )");
        }

        connection.Close();
    }
}