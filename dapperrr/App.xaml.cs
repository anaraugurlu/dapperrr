using dapperrr.DataAcces.DupperServer;
using dapperrr.Domain.Abstractions;
using dapperrr.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace dapperrr
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;
        public App()
        {
            //creation db

            //using (var context = new MyContext())
            //{
            //    context.Database.CreateIfNotExists();
            //}
            DB = new DapperUnitOfWork();
            if (DB.BookRepository .GetAllData().Count == 0)
            {
                var book1 = new Book
                {
                    Authorname ="dostoyevski",
                    Name ="pristupleniye i nakazaniye",
                    Price =10
                };
                var book2 = new Book
                {
                    Authorname = "dostoyevski",
                    Name = "pristupleniye i nakazaniye",
                    Price = 10
                };

                DB.BookRepository.AddData(book1);
                DB.BookRepository.AddData(book2);


            }
        }
    }
}
