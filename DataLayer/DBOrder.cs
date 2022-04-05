using Microsoft.Data.SqlClient;
using System.Data;

namespace DataLayer;

public static class DBOrder
{
    public static void AddOrder(List<Product> products, StoreFront store, Customer customer, string _connectionString)
    {
        DataSet orderSet = new DataSet();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE OrderID = -1", connection);
        using SqlCommand cmdID = new SqlCommand("SELECT CAST(IDENT_CURRENT('Orders') AS INT)", connection);

        connection.Open();
        int currentID = (int)cmdID.ExecuteScalar();
        connection.Close();

        SqlDataAdapter orderAdapter = new SqlDataAdapter(cmd);

        orderAdapter.Fill(orderSet, "OrderTable");

        DataTable? orderTable = orderSet.Tables["OrderTable"];
        if (orderTable != null)
        {
            foreach (Product product in products)
            {
                DataRow newRow = orderTable.NewRow();
                newRow["ProductID"] = product.ProductID;
                newRow["Quantity"] = product.ProductQuantity;
                newRow["CustomerID"] = customer.CustomerID;
                newRow["TransactionID"] = currentID;
                newRow["StoreID"] = store.StoreID;

                orderTable.Rows.Add(newRow);
            }

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(orderAdapter);
            SqlCommand insert = commandBuilder.GetInsertCommand();

            orderAdapter.InsertCommand = insert;

            orderAdapter.Update(orderTable);
        }

        foreach (Product product in products)
        {
            store.InventoryID = DBInventory.GetInventoryID(product, store, _connectionString);
            product.ProductQuantity = store.Inventory.Find(x => x.ProductName == product.ProductName).ProductQuantity;
            DBInventory.UpdateInventory(product, store, _connectionString);
        }
    }
}