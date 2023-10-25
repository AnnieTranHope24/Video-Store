using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Reservation comparison = (Reservation)obj;
                return (Movie.Equals(comparison.Movie) && (Customer.Equals(comparison.Customer)));
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
