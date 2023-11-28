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
            if (obj is ZipCode)
            {
                ZipCode z = (ZipCode)obj;
                return z.Code.Equals(this.Code);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }
    }
}
