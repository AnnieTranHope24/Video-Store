namespace Model
{
    public class Genre
    {
        public virtual string Name { get; set; }

        public Genre()
        {
            
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Genre comparison = (Genre)obj;
                return Name.Equals(comparison.Name);
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
