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

    public void AddCustomer()
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
            newRow["Username"] = Customer.UserName;

            customerTable.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(customerAdapter);
            SqlCommand insert = commandBuilder.GetInsertCommand();

            customerAdapter.InsertCommand = insert;

            customerAdapter.Update(customerTable);
        }
    }

    public void GetCustomer(string username)
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
            Customer.EmployeeID = (int)customerTable.Rows[0]["CustomerID"];
            Customer.UserName = (string)customerTable.Rows[0]["Username"];
            Customer.Employee = (bool)customerTable.Rows[0]["IsEmployee"];
        }
    }
}