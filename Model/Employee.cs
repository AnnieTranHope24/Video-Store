using System;
using VideoStore.Utilities;

namespace Model
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual Name Name { get; set; }
        public virtual DateTime DateHired { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual Store Store { get; set; }
        public virtual bool IsManager { get; }
        public virtual Employee Supervisor { get; set; }

        public Employee()
        {
            DateHired = DateFactory.CurrentDate;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Employee comparison = (Employee)obj;
                return Name.First.Equals(comparison.Name.First) && Name.Last.Equals(comparison.Name.Last) && DateOfBirth.Equals(comparison.DateOfBirth);
            }
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
