using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectQueryFromDataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Show products program");
            
            string sqlQuery = "" +
                "SELECT Products.Title as 'ProductsTitle', Categories.Title as 'CategoriesTitle' \r\n" +
                "FROM Products\r\n" +
                "INNER JOIN CatigoriesIdProductId\r\n" +
                "ON Products.Id = CatigoriesIdProductId.Product_Id\r\n" +
                "INNER JOIN Categories\r\n" +
                "ON Categories.Id = CatigoriesIdProductId.Category_Id";

            SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\programs\visualStudio\Projects\SelectQueryFromDataBase\SelectQueryFromDataBase\Products.mdf;Integrated Security=True");
            connect.Open();

            SqlCommand searchAllProductAndCategories = new SqlCommand(sqlQuery, connect);
            SqlDataReader searchAllProductsAndCategoriesReade = searchAllProductAndCategories.ExecuteReader();

            while(searchAllProductsAndCategoriesReade.Read())
            {
                Console.WriteLine($"Product name: {Convert.ToString(searchAllProductsAndCategoriesReade["ProductsTitle"])}, Category: {Convert.ToString(searchAllProductsAndCategoriesReade["CategoriesTitle"])}");
            }

            connect.Close();
            Console.ReadLine();
        }
    }
}
