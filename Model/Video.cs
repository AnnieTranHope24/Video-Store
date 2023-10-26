using System;

namespace Model
{
    public class Video
    {
        public virtual int Id { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual DateTime PurchaseDate { get; set; }

        public virtual bool NewArrival { get; set; }

        public virtual Store Store { get; set; }

        public Video()
        {
            PurchaseDate = DateTime.Now;
            NewArrival = true;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Video comparison = (Video)obj;
                return Id == comparison.Id;
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
