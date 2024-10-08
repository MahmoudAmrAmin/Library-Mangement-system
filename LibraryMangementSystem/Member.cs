﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementSystem
{
    public  class Member:INotification 
    {
         public Member()
        {

        }
        private int memberId;
        private string memberName;
        private string memberEmail; 
        private List<Book> BorrowedBooks = new List<Book>();
        private bool isPremium = false;



        public Member(int memberId, string memberName, string memberEmail , bool isPremium)
        {
            this.memberId = memberId;
            this.memberName = memberName;
            this.memberEmail = memberEmail;  
            this.isPremium = isPremium;
        }

        public static string  Name { get; protected set; }

        public int MemberId { get => memberId; set => memberId = value; }
        
        public string MemberName { get => memberName; set => memberName = value; }
        
        public string MemberEmail { get => memberEmail; set => memberEmail = value; }
        
        
        public List<Book> BorrowedBooks1 { get => BorrowedBooks; set => BorrowedBooks = value; }
        
        protected bool IsPremium { get => isPremium; set => isPremium = value; }

        public virtual string BarrowBook (Book book)
        {
            if ( book is not null )
            {
                BorrowedBooks.Add ( book ); 
                book.IsBorrowed = true;
            }
            return SendNotification($"Book '{book.Title}' borrowed successfully.");
        }

        public virtual string ReturnBook ( Book book)
        {
            if (book is not null)
            {
                BorrowedBooks.Remove ( book ); 
                book.IsBorrowed = false;
            }

            return SendNotification($"Book '{book.Title}' returned successfully.");

        }


        public virtual string SendNotification(string massage)
        {
            return massage; 
        }

        public override string ToString()
        {
            return $" name is {memberName},id:{MemberId},email:{MemberEmail}, The number of books is borrowed:{BorrowedBooks1.Count} , Ispremium {IsPremium}";
        }

    }
}
