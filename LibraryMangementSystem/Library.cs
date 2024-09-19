using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementSystem
{
    internal class Library 
    {

        private  List<Book> books = new List<Book>();  
        private  List<Member> members  = new List<Member>();


        internal List<Book> Books { get => books; set => books = value; }
        internal List<Member> Members { get => members; set => members = value; }

        public string this[string bookName]
        {
            get
            {
                var IsAvailable = Books.FirstOrDefault(book => bookName == book.Title);

                if (IsAvailable == null)
                {
                    return "this book isn't available";
                }
                else
                {
                    return IsAvailable.ToString();
                }
            }

        }

       


        public  Book FindBook( int ? bookId)
        {
            return Books.FirstOrDefault(book => book.BookId == bookId) ?? new Book(); 
        }

        public   Book FindBook( string name)
        {
            var isAvaiable =  Books.FirstOrDefault(book => book.Title == name);
            return isAvaiable ;
        }
        
        public Member FindMember(int ? memberId) {
            return Members.FirstOrDefault(member => member.MemberId == memberId); 
        }

        public  Book IsBorrow(Member member, int bookId) => member.BorrowedBooks1.FirstOrDefault(book => book.BookId == bookId);  


        public void  AddBook( Book book)
        {
            if(book is null )
            {
                Console.WriteLine("can't add empty book");
                return;
            }
            Books.Add(book); 
        }

        public void AddMember(Member member) 
        {
            if(member is null )
            {
                Console.WriteLine("can't add empty member");
                return;
            }
            Members.Add(member);         
        }

        public string BorrowBook (int ? memberId , int ? bookId)
        {

            if (!Books.Any() || !members.Any()) return "Library is Empty"; 

            var bookToBarrow =FindBook(bookId); 

            if( bookToBarrow == null )
            {
                return "This book is not available."; 
            }


            if (bookToBarrow.IsBorrowed)
            {
                return "this book is already borrowed"; 
            }

            // cheack about member 

            var memberNeedBorrow = FindMember(memberId);

            if( memberNeedBorrow == null )
            {
                return " this id not assign to member"; 
            }

             
            return memberNeedBorrow.BarrowBook(bookToBarrow);

        }

        public string ReturnBook(int ? memberId , int ? bookId)
        {
            if (!Books.Any() || !members.Any()) return "Library is Empty";




            var bookToReturn = FindBook(bookId);
            
            var memberNeedReturn = FindMember(memberId);

            
            if (bookToReturn is null)
            {
                return "This book is not available."; 
            }
            
            if(memberNeedReturn is null )
            {
                    return " this id not assign to member";
            }
            if (!bookToReturn.IsBorrowed)
            {
                return "This book has never been borrowed before.";
            }

            var BarrowBook = IsBorrow(memberNeedReturn , (int)bookId); 
            

            if (BarrowBook is null )
            {
                return "this member doesn't borrow this book or this book is not available"; 
            }

            

            return memberNeedReturn.ReturnBook(bookToReturn);   
            
        }

    }
}
