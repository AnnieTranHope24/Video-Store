namespace Model
{
    public class Rating
    {
        public virtual int Id { get; set; }
        public virtual int Score { get; set; }
        public virtual string Comment { get; set; }

        public Rating()
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
                Rating comparison = (Rating)obj;
                return Id == comparison.Id;
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }

    }
}
