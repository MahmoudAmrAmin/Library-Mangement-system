using System;
using static System.Console;



namespace LibraryMangementSystem
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            var library = new Library();
            InitializeLibrary(ref library);

            var userInterface = new UserInterface(library); 
              

            UserInterface.ChoiceMood(); 




        }

        private static void InitializeLibrary(ref Library library)
        {

            library.AddBook(new Book { BookId = 1, Author = "mahmoud", Isbn = "123456789", IsBorrowed = false ,Title ="c++"});
            library.AddBook(new Book { BookId = 2, Author = "mansour amr ", Isbn = "2345678910", IsBorrowed = false , Title = "power pi"});

            library.AddMember(new Member{ MemberId = 1 , BorrowedBooks1 = new List<Book>() ,MemberName = "amr amin mohamed mansour" , MemberEmail = "mahmoudamr500@gmail.com" });
            library.AddMember(new Member { MemberId = 2, BorrowedBooks1 = new List<Book>(), MemberName = "amin mohamed mansour", MemberEmail = "mansouramr500@gmail.com" });
        }

        
    }
}
