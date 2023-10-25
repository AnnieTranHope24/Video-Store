using System;

namespace Model
{
    public class Rental
    {
        public virtual int Id { get; set; }
        public virtual Video Video { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DateTime RentalDate { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime? ReturnDate { get; set; }
        public virtual Rating Rating { get; set; }

        public Rental()
        {
            
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Rental comparison = (Rental)obj;
                return (Video.Equals(comparison.Video) && Customer.Equals(comparison.Customer) && RentalDate.Equals(comparison.RentalDate));
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public virtual ReturnReceipt Return()
        {
            return null;
        }
    }
}
