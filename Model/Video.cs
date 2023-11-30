using System;
using VideoStore.Utilities;

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
            PurchaseDate = DateFactory.CurrentDate;
            NewArrival = true;
            Store = new Store();
        }

        public override bool Equals(object obj)
        {
            if (obj is Video)
            {
                Video v = (Video)obj;
                return v.Id.Equals(this.Id);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
