using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ZipCode
    {
        public virtual string Code { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }

        public ZipCode()
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
                ZipCode comparison = (ZipCode)obj;
                return (String.Equals(Code, comparison.Code));
            }
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

    }
}
