using System;
using VideoStore.Utilities;

namespace Model
{
    public class Rental
    {
        public virtual int Id { get; set; }
        public virtual Video Video { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DateTime RentalDate { get; set; }
        public virtual DateTime DueDate { get; protected internal set; }
        public virtual DateTime? ReturnDate { get; set; }
        public virtual Rating Rating { get; set; }

        public Rental()
        {
            RentalDate = DateFactory.CurrentDate;
            if (Video.NewArrival)
            {
                DueDate = RentalDate.AddDays(3);
            }
            else
            {
                DueDate = RentalDate.AddDays(7);
            }
        }

        public Rental(Video video)
        {
            Video = video;
            RentalDate = DateFactory.CurrentDate;
            if (Video.NewArrival)
            {
                DueDate = RentalDate.AddDays(3);
            }
            else
            {
                DueDate = RentalDate.AddDays(7);
            }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Rental comparison = (Rental)obj;
                return Video.Equals(comparison.Video) && Customer.Equals(comparison.Customer) && RentalDate.Equals(comparison.RentalDate);
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
