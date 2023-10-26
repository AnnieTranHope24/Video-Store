using System.Collections.Generic;

namespace Model
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual Name Name { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string StreetAddress { get; set; }
        public virtual string Password { get; set; }
        public virtual string Phone { get; set; }
        public virtual ZipCode ZipCode { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual IList<Rental> Rentals { get; protected internal set; }
        public virtual IList<Store> PreferredStores { get; protected internal set; }
        public virtual ISet<CommunicationMethod> CommunicationTypes { get; protected internal set; }
        public virtual string FullName { get; }
        public virtual IList<Rental> LateRentals { get; }

        public Customer()
        {
            Rentals = new List<Rental>();
            PreferredStores = new List<Store>();
            CommunicationTypes = new HashSet<CommunicationMethod>();
            LateRentals = new List<Rental>();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Customer comparison = (Customer)obj;
                return EmailAddress.Equals(comparison.EmailAddress);
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public virtual Reservation AddReservation(Movie movie)
        {
            return null;
        }

        public virtual Rental Rent(Video video)
        {
            return null;
        }

        public virtual void Allow(CommunicationMethod communicationMethod)
        {

        }

        public virtual void Deny(CommunicationMethod communicationMethod)
        {

        }

        public virtual void AddPreferredStore(Store store, int pos)
        {
        
        }

        public virtual void RemovePreferredStore(Store store)
        {

        }
    }
}
