using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movie
    {
        public virtual int Id { get; set; }
        public virtual int Year { get; set; }
        public virtual string Title { get; set; }
        public virtual string OriginalTitle { get; set; }
        public virtual int RunningTimeInMinutes { get; set; }
        public virtual string Director { get; set; }
        public virtual string Rating { get; set; }
        public virtual float IMDBRating { get; set; }
        public virtual int NumberOfRatings { get; set; }
        public virtual Genre PrimaryGenre { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Movie comparison = (Movie)obj;
                return (Title == comparison.Title) && (Year == comparison.Year);
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public virtual Reservation AddReservation(Customer customer)
        {
            return null;
        }
    }
}
