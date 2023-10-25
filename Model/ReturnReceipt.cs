using System;

namespace Model
{
    public class ReturnReceipt
    {
        public virtual Reservation FulfilledReservation { get; set; }
        public virtual Rental NextRental { get; set; }

        public ReturnReceipt()
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
                ReturnReceipt comparison = (ReturnReceipt)obj;
                return (FulfilledReservation.Equals(comparison.FulfilledReservation) && (NextRental.Equals(comparison.NextRental)));
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}