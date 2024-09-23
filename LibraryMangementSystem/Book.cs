using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementSystem
{
    public  class Book
    {
        private int bookId;
        private string title;
        private string author;
        private string isbn;
        private bool isBorrowed;

        public Book()
        {


            this.bookId =0;
            this.title = "no title";
            this.author = "no author";
            this.isbn = String.Empty;
            this.isBorrowed = false;

        }

        public Book(int bookId, string title, string author, string isbn)
        {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
            this.isbn = isbn;
            this.isBorrowed = false;
        }



        public int BookId { get => bookId; set => bookId = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public bool IsBorrowed { get => isBorrowed; set => isBorrowed = value; }

        public override string ToString()
        {
            return $"Book id is {BookId} , Title is {Title} , it author is {Author} , isbn is {Isbn} , is barrow {IsBorrowed}"; 
        }

    }
}
