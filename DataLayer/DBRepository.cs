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
        throw new NotImplementedException();
    }
}

// FOR REFERENCE ON HOW TO CONNECT TO DB AND READ INFORMATION
/*
    public List<Issue> GetAllIssues()
    {
        List<Issue> allQuestions = new List<Issue>();

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Issues", connection);
        SqlDataReader reader = cmd.ExecuteReader();

        //This returns true if there are more rows to read, if not false
        //This also advances the datareader to the next row
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            DateTime dateCreated = reader.GetDateTime(2);
            string content = reader.GetString(3);
            Boolean isClosed = reader.GetBoolean(4);
            int score = reader.GetInt32(5);

            Issue question = new Issue{
                Id = id,
                Title = title,
                DateCreated = dateCreated,
                Content = content,
                IsClosed = isClosed,
                Score = score
            };
            allQuestions.Add(question);
        }

        reader.Close();
        connection.Close();

        return allQuestions;
    }
*/