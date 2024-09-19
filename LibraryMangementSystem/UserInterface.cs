using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console; 
namespace LibraryMangementSystem
{
    internal  class UserInterface :Library
    {
        private  static Library lib = new Library();
       

        internal static Library  Library { get => lib; set => lib = value; }

        public UserInterface( Library _lib)
        {
            lib = _lib; 
        }
      
      
        public static void ChoiceMood ()
        {
            bool isRunning = true;
            while (isRunning) 
            {

                Clear();                 
                Console.WriteLine("========================");
                Console.WriteLine("====Choice your mood====");
                Console.WriteLine("========================");
                Console.WriteLine("enter your choice");
                Console.WriteLine("1 : admin");
                Console.WriteLine("2 : customer");
                Console.WriteLine("3 : Exit library");
                Console.WriteLine("========================");

                var choiceInput = Input.ReadInt();

                switch (choiceInput)
                {
                    case 1:
                        Admin(); 
                        break;
                    case 2: 
                        Customer();
                        break; 
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                if(isRunning){
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }

            }

        }

        #region Adimn mood 
        public static void Admin ()
        {
            bool  isRunning = true;
            while (isRunning) 
            {
                Console.Clear();
                Console.WriteLine("==================");
                Console.WriteLine("====Admin mood====");
                Console.WriteLine("==================");
                Console.WriteLine("enter your choice");
                Console.WriteLine("------------------");
                Console.WriteLine("1:ADD Book");
                Console.WriteLine("2:Add Member");
                Console.WriteLine("3:Viwe Books");
                Console.WriteLine("4:Viwe Members");
                Console.WriteLine("5:Search book");
                Console.WriteLine("6:Delete Book");
                Console.WriteLine("7:Exit");
                Console.WriteLine("====================================");
                Console.Write("Select an option: ");

                var choice = Input.ReadInt();

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        AddMember();
                        break;
                    case 3:
                        ViewBooks();
                        break;
                    case 4 :
                        ViweMembers();
                        break; 
                    case 5 :
                        SearchBook();
                        break;
                     case 6 :
                        DeleteBook();
                        break ;
                    case 7: 
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;


                }
                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to return to the mode menu...");
                    Console.ReadKey();
                }

            }

          




        }

        private static void AddBook()
        {
            Clear();
            Console.WriteLine("Press 'Esc' to stop the function at any time...");
            var book = new Book();
                
                Console.WriteLine("======================");
                
                Console.WriteLine("enter book details");

                Console.WriteLine("=======================");

                int bookId = lib.Books.Count + 1;
                book.BookId = bookId;

                Console.WriteLine("enter book Title");
                string? name = Console.ReadLine() ?? string.Empty;

                book.Title = name;


                Console.WriteLine("============================");
                Console.WriteLine("enter author of book");
                string? author = Console.ReadLine() ?? string.Empty;

                book.Author = author;
                Console.WriteLine("=============================");

                Console.WriteLine("enter isbn of book");
                string isbn = Console.ReadLine() ?? string.Empty;

                book.Isbn = isbn;

                book.IsBorrowed = false;


            
              lib.AddBook(book);
                Console.WriteLine("==============================");
                Console.WriteLine("Book added successfully!");
           
        }



        private static void AddMember ()
        {
            Clear();    
            var memberId = lib.Members.Count + 1;
            Console.WriteLine("**************************");
            Console.WriteLine("enter member details");
            Console.WriteLine("**************************");

            Console.WriteLine("are you need subscrib as Premium member =====> ( yes / no ) ");
                                    
                 
            
            bool isRunning = true;
            bool isPremuim = false;

            while (isRunning) 
            {
                string  ? subscriptionType = ReadLine()?.Trim().ToLower() ?? string.Empty;
                switch (subscriptionType)
                {
                    case "yes": 
                        isRunning = false;
                        isPremuim = true; 
                        break;
                    case "no":
                        isRunning = false;
                        isPremuim = false;
                        break;
                    default:
                        Console.WriteLine("invalid option");
                        break;
                }
            }

            if (isPremuim)
            {
                Console.WriteLine("=======================");
                Console.WriteLine("enter member name");
                Console.WriteLine("========================");
                string ?  name = ReadLine() ?? string.Empty;
                Clear();
                Console.WriteLine("========================");
                Console.WriteLine("enter member email");
                Console.WriteLine("========================");
                string ? email = ReadLine() ?? string.Empty;
                Clear();

                Console.WriteLine("========================");
                Console.WriteLine("enter monthly fee");
                Console.WriteLine("========================");
                var monthlyFee = Input.ReadDecimal();
                Clear();

                Console.WriteLine("========================");
                Console.WriteLine("enter discount rate");
                Console.WriteLine("========================");
                var discountRate = Input.ReadDouble();
                Clear();


                Member premuimMember = new PremiumMember(memberId, name, email, monthlyFee, discountRate);

                lib.AddMember(premuimMember);
                Console.WriteLine("Member added successfully!");

            }
            else
            {
                Clear(); 
                Console.WriteLine("=======================");
                Console.WriteLine("enter member name");
                Console.WriteLine("========================");
                string? name = ReadLine() ?? string.Empty;

                while (name == null || name == string.Empty)
                {
                    Clear();
                    Console.WriteLine("======> can't enter empty name <========");
                    Console.WriteLine();
                    Console.WriteLine("========================");
                    Console.WriteLine("enter your name");
                    Console.WriteLine("========================");
                    name = ReadLine();
                }
                Clear();
                Console.WriteLine("========================");
                Console.WriteLine("enter member email");
                Console.WriteLine("========================");
                
                string? email = ReadLine() ?? string.Empty;
                while (email == string.Empty) 
                { 
                     Clear();
                    Console.WriteLine("======> can't enter empty email<========");
                    Console.WriteLine();
                    Console.WriteLine("========================");
                    Console.WriteLine("enter your email");
                    Console.WriteLine("========================");
                    email = ReadLine();
                }
                Clear(); 
                Member member = new Member(memberId, name, email);

                lib.AddMember(member);
                Console.WriteLine("Member added successfully!");


            }
        }

        private static void ViewBooks ()
        {
            var library = lib;                
            if(library.Books.Any())
            {
                foreach (var BooksViwer in library.Books)
                {

                    Console.WriteLine(BooksViwer);
                }
                
            }
            else
            {
                Console.WriteLine("our library is empty");
            }
        }
        private static void ViweMembers ()
        {


            Clear();    

            foreach( var Member in lib.Members)
            {
                Console.WriteLine(Member);
            }
        }
        
        private static void SearchBook()
        {
            Clear(); 
            Console.WriteLine("===================");
            Console.WriteLine("enter book name");
            Console.WriteLine("===================");

            string   bookName = ReadLine() ??  String.Empty;

            var res = lib[bookName];
            Console.WriteLine(res);

        }
        private static void  DeleteBook ()
        {
            Clear();
            
            if (!lib.Books.Any())
            {
                Console.WriteLine("our library is empty");
            }
            else
            {
                Console.WriteLine("===================");
                Console.WriteLine("enter book name");
                Console.WriteLine("===================");
                string bookName = ReadLine() ?? String.Empty;

                if (lib.FindBook(bookName) == null)
                {
                    Console.WriteLine("this book isn't avaiable");
                }
                else
                {

                    lib.Books.Remove(lib.FindBook(bookName));

                    Console.WriteLine("book deleted Successfully.");
                }
            }


        }
        #endregion

        #region Customer mood
        public static void Customer()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("==================");
                Console.WriteLine("====customer mood====");
                Console.WriteLine("==================");
                Console.WriteLine("enter your choice");
                Console.WriteLine("------------------");
                Console.WriteLine("1:Viwe Books");
                Console.WriteLine("2:Barrow books");
                Console.WriteLine("3:return Books");
                Console.WriteLine("4:Exit");
                Console.WriteLine("====================================");
                Console.Write("Select an option: ");

                var choice = Input.ReadInt();

                switch (choice)
                {
                    case 1:
                        ViewBooks();
                        break;
                    case 2:
                        BarrowBook();
                        break;
                    case 3:
                        ReturnBook(); 
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to return to the mode menu...");
                    Console.ReadKey();
                }

            }

        }

        private static void BarrowBook ()
        {
            int  ? bookId ,  memberId; 
            Clear(); 
            Console.WriteLine("========================");
            Console.WriteLine("enter book name");
            Console.WriteLine("========================");

            string? name = ReadLine() ?? string.Empty;
            while (name == null || name == string.Empty)
            {
                Clear ();
                Console.WriteLine("======> can't enter empty name <========");
                Console.WriteLine();
                Console.WriteLine("========================");
                Console.WriteLine("enter book name");
                Console.WriteLine("========================");
                name = ReadLine();
            }
            if(lib.FindBook(name) !=null)
            {
                
                bookId = lib.FindBook(name).BookId;
            }
            else
            {
                Console.WriteLine("invalid book name");
                return; 
            }
            Clear ();
            Console.WriteLine("======================");
            Console.WriteLine("enter your member id");
            Console.WriteLine("=====================");
             memberId = Input.ReadInt();

            while (memberId == null)
            {
                Clear();
                Console.WriteLine("======> can't enter empty ID <========");
                Console.WriteLine("======================");
                Console.WriteLine("enter your member id");
                Console.WriteLine("=====================");
                memberId = Input.ReadInt();
            }

            
            
                if(lib.FindMember (memberId) != null )
                {
                    var res = lib.BorrowBook(memberId, bookId);
                    Console.WriteLine(res);
                }
                else
                {
                    Console.WriteLine("this is invalid id");
                    return;
                }
            
            
        }

        private static void ReturnBook()
        {
            int? bookId, memberId;
            Clear();
            Console.WriteLine("========================");
            Console.WriteLine("enter book name");
            Console.WriteLine("========================");

            string? name = ReadLine();
            while (name == null)
            {
                Clear();
                Console.WriteLine("======> can't enter empty name <========");
                Console.WriteLine();
                Console.WriteLine("========================");
                Console.WriteLine("enter book name");
                Console.WriteLine("========================");
                name = ReadLine();
            }
            if (lib.FindBook(name) != null)
            {

                bookId = lib.FindBook(name).BookId;
            }
            else
            {
                Console.WriteLine("invalid book name");
                return;
            }
            Clear();
            Console.WriteLine("======================");
            Console.WriteLine("enter your member id");
            Console.WriteLine("=====================");
            memberId = Input.ReadInt();

            while (memberId == null)
            {
                Clear();
                Console.WriteLine("======> can't enter empty ID <========");
                Console.WriteLine("======================");
                Console.WriteLine("enter your member id");
                Console.WriteLine("=====================");
                memberId = Input.ReadInt();
            }



            if (lib.FindMember(memberId) != null)
            {
                var res = lib.ReturnBook(memberId, bookId);
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("this is invalid id");
                return;
            }
        }

        #endregion










    }
}
