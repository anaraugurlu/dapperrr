using Dapper;
using dapperrr.Domain.Abstractions;
using dapperrr.Mapping;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace dapperrr.DataAcces.DupperServer
{
    public class DapperBookRepository : IBookRepository
    {
        public void AddData(Book book)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Books(Name,Price) VALUES(@ProductName,@ProductPrice)"
                    , new { ProductName = book.Name, ProductPrice = book.Price });

            }
        }
        
        public void DeleteData(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Books WHERE Id=@PId", new { PId = id });
                MessageBox.Show("book Deleted Successfully");
            }
        }
      
        public Book GetData(int id)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                var player = connection.QueryFirstOrDefault("select * from Books where Id=@PId",
                    new { PId = id });

                return new Book
                {
                    Id = player.Id,
                    Name = player.Name,
                    Authorname = player.AuthorName,
                    Price = player.Price

                };

            }
        }
        public void UpdateData(Book data)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Books SET Name=@PName,Price=@PPrice WHERE Id=@PId",
                    new { PId = data.Id, PName = data.Name, PPrice = data.Price });
            }
        }
        List <Book> IRepository<Book>.GetAllData()
        {
            List <Book> players = new List<Book> ();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString))
            {
                players = connection.Query<Book>("SELECT Id,Name,Price,AuthorName from Books").ToList ();
            }
            return players;
          
        }
    }
}
