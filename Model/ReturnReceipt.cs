namespace Model
{
    public class ReturnReceipt
    {
        public virtual Reservation FulfilledReservation { get; set; }
        public virtual Rental NextRental { get; set; }

        public ReturnReceipt()
        {
        }
    }
}