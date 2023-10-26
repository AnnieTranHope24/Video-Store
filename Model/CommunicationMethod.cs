using System.Collections.Generic;

namespace Model
{
    public class CommunicationMethod
    {
        public enum TimeUnit
        {
            Day,
            Week,
            Month,
            Year
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Frequency { get; set; }
        public virtual TimeUnit Units { get; set; }
        public virtual ISet<Customer> Customers { get; protected internal set; }

        public CommunicationMethod()
        {
            Customers = new HashSet<Customer>();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CommunicationMethod comparison = (CommunicationMethod)obj;
                return Name.Equals(comparison.Name);
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }

    }
}
