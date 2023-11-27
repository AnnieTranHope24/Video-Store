using System.Net.Mail;
using System.Text;

namespace Model
{
    public class Name
    {
        public virtual string Title { get; set; }
        public virtual string First { get; set; }
        public virtual string Middle { get; set; }
        public virtual string Last { get; set; }
        public virtual string Suffix { get; set; }

        public Name() { }

        public override string ToString()
        {
            string result = "";
            if (Title != null)
            {
                result += Title;
                result += " ";
            }

            if (First != null)
            {
                result += First;
                result += " ";
            }

            if (Middle != null)
            {
                result += Middle;
                result += " ";
            }

            if (Last != null)
            {
                result += Last;
                result += " ";
            }

            if (Suffix != null)
            {
                result += Suffix;
                result += " ";
            }
            return result;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Name comparison = (Name)obj;
                return ToString().Equals(comparison.ToString());
            }
        }
    }
}
