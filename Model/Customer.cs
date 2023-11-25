using System;
using System.Collections.Generic;
using System.Linq;
using VideoStore.Utilities;

namespace Model
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual Name Name { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string StreetAddress { get; set; }
        public virtual string Phone { get; set; }
        public virtual ZipCode ZipCode { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual IList<Rental> Rentals { get; protected internal set; }
        public virtual IList<Store> PreferredStores { get; protected internal set; }
        public virtual ISet<CommunicationMethod> CommunicationTypes { get; protected internal set; }
        public virtual string FullName 
        {
            get 
            { 
                return Name.First + " " + Name.Last;
            }
        }
        public virtual IList<Rental> LateRentals 
        { 
            get
            {
                IEnumerable<Rental> lateRentals = Rentals.Where(rental => rental.ReturnDate == null && rental.DueDate < DateFactory.CurrentDate).OrderByDescending(rental => rental.DueDate);

                return lateRentals.ToList();
            }
        }
        private string password;
        public virtual string Password {
            get 
            { 
                return password;
            }
            set { 
                if(value.Length < 6)
                {
                    throw new ArgumentException("Password is too short.  It must be at least 6 characters long.");
                }

                if(!value.Any(char.IsUpper))
                {
                    throw new ArgumentException("The password must contain at least 1 uppercase letter.");
                }

                if (!value.Any(char.IsLower))
                {
                    throw new ArgumentException("The password must contain at least 1 lowercase letter.");
                }

                if (!value.Any(char.IsDigit))
                {
                    throw new ArgumentException("The password must contain at least 1 number.");
                }

                password = value;
            }
        }

        public Customer()
        {
            Rentals = new List<Rental>();
            PreferredStores = new List<Store>();
            CommunicationTypes = new HashSet<CommunicationMethod>();
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

        public virtual void AddPreferredStore(Store store, int pos = -1)
        {
        
        }

        public virtual void RemovePreferredStore(Store store)
        {

        }
    }
}
