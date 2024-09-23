using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMangementSystem
{
    public  class PremiumMember: Member 
    {
        private decimal monthlyFee;
        private double discountRate;

        public PremiumMember( int memberId ,string memberName ,bool isPremuim ,  string memberEmail,decimal monthlyFee, double discountRate)
        :base(memberId , memberName , memberEmail ,true)  
        {
            this.monthlyFee = monthlyFee;
            this.discountRate = discountRate;
        }

        public decimal MonthlyFee { get => monthlyFee; set => monthlyFee = value; }
        public double DiscountRate { get => discountRate; set => discountRate = value; }

        public override string BarrowBook(Book book)
        {
            /*if (book is not null)
            {
                BorrowedBooks1.Add(book);
                book.IsBorrowed = true;
            }*/

            base.BarrowBook(book);

            return $"Premium member {Name} borrowed a book with a discount.";
           
        }

    }
}
