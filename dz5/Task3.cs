using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dz5
{
    internal class Task3
    {
        public static void Run()
        {
            BooksToRead books = new BooksToRead();
            string action;
            do
            {
                Console.Write("Enter what to do(add, remove, show, find, exit): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "add":
                        Book book = new Book();
                        book.Init();
                        books = books + book;
                        break;
                    case "remove":
                        Console.Write("Enter title of book to remove: ");
                        string title = Console.ReadLine();
                        books = books - title;
                        break;
                    case "show":
                        Console.WriteLine("Books list:");
                        books.Show();
                        break;
                    case "find":
                        Console.Write("Enter what to find by(title, author, description): ");
                        string criterion = Console.ReadLine();
                        string choice;
                        switch(criterion)
                        {
                            case "title":
                                Console.Write("Enter title to find: ");
                                choice = Console.ReadLine();
                                criterion = criterion + "/" + choice;
                                break;
                            case "author":
                                Console.Write("Enter author to find: ");
                                choice = Console.ReadLine();
                                criterion = criterion + "/" + choice;
                                break;
                            case "description":
                                Console.Write("Enter description to find: ");
                                choice = Console.ReadLine();
                                criterion = criterion + "/" + choice;
                                break;
                        }
                        BooksToRead result = books / criterion;
                        Console.WriteLine("Results of search:");
                        result.Show();
                        break;
                }
            } while (action != "exit");
        }
    }

    struct Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }

        public void Init()
        {
            Console.Write("Enter books title: ");
            this.title = Console.ReadLine();
            Console.Write("Enter book's author: ");
            this.author = Console.ReadLine();
            Console.WriteLine("Enter book's description:");
            this.description = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Book's title: {this.title}");
            Console.WriteLine($"Book's author: {this.author}");
            Console.WriteLine($"Book's description:\n{this.description}");
            Console.WriteLine("---------------------------------------------------");
        }
    }

    class BooksToRead
    {
        private Book[] books { get; set; }

        public BooksToRead()
        {
            this.books = new Book[0];
        }

        public void AddBook(Book book)
        {
            this.books = this.books.Append(book).ToArray();
        }

        public void RemoveBook(string name)
        {
            this.books = this.books.Where(b => b.title != name).ToArray();
        }

        public void Show()
        {
            if (this.books.Length == 0)
            {
                Console.WriteLine("Empty");
                return;
            }
            foreach (Book b in this.books)
                b.Show();
        }

        public static BooksToRead operator +(BooksToRead books, Book book)
        {
            books.AddBook(book);
            return books;
        }
        public static BooksToRead operator -(BooksToRead books, string name)
        {
            books.RemoveBook(name);
            return books;
        }

        public static BooksToRead operator /(BooksToRead books, string search)
        {
            BooksToRead result = new BooksToRead();
            string[] input = search.Split('/');
            if (input.Length != 2)
                return null;
            foreach (Book book in books.books)
            {
                if (input[0] == "title" && book.title == input[1])
                    result = result + book;
                else if (input[0] == "author" && book.author == input[1])
                    result = result + book;
                else if (input[0] == "description" && book.description == input[1])
                    result = result + book;
            }
            return result;
        }
    }
}
