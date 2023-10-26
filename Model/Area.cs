using System.Collections.Generic;

namespace Model
{
    public class Area
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual ISet<ZipCode> ZipCodes { get; protected internal set; }

        public Area()
        {
            ZipCodes = new HashSet<ZipCode>();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Area comparison = (Area)obj;
                return Name.Equals(comparison.Name);
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public virtual void AddZipCode(ZipCode zipCode)
        {

        }

        public virtual void RemoveZipCode(ZipCode zipCode)
        {

        }
    }
}
