using System;
using VideoStore.Utilities;

namespace Model
{
    public class Reservation
    {
        public virtual int Id { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual DateTime ReservationDate { get; set; }

        public Reservation()
        {
            ReservationDate = DateFactory.CurrentDate;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Reservation comparison = (Reservation)obj;
                return Movie.Equals(comparison.Movie) && Customer.Equals(comparison.Customer);
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
