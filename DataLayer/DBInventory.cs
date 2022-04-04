using Microsoft.Data.SqlClient;
using System.Data;

namespace DataLayer;
public static class DBInventory
{
    public static int PreviousInventory(int id, string _connectionString)
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

    public static void AddInventory(Product product, StoreFront store, string _connectionString)
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

    public static void UpdateInventory(Product product, string _connectionString)
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
}