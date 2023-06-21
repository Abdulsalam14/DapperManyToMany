using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp006
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ManyToMany;Integrated Security=True;";
            using (var conn = new SqlConnection(connectionString))
            {
                var sql = @"SELECT *
                            FROM Authors AS A
                            INNER JOIN AuthorBook AS AB
                            ON AB.[AuthorId]=A.[Id]
                            INNER JOIN Books AS B
                            ON B.[Id]=AB.[BookId]";

                var authors = conn.Query<Author, Book, Author>(sql,
                    (author, book) =>
                {
                    author.Books.Add(book);
                    return author;
                });
                var result=authors.Select(a => new
                {
                    Author = a.Name,
                    Book = a.Books[0].Name,
                    Price = a.Books[0].Price
                });
                Datagrid.ItemsSource =result;
            }
        }
    }
 }
