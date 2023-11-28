using System;
using System.Collections.Generic;

namespace Model
{
    public class Store
    {
        public virtual int Id { get; set; }
        public virtual string StreetAddress { get; set; }
        public virtual ZipCode ZipCode { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual IList<Employee> Managers { get; protected internal set; }
        public virtual IList<Video> Videos { get; protected internal set; }

        public Store()
        {
            Managers = new List<Employee>();
            Videos = new List<Video>();
        }

        public override bool Equals(object obj)
        {
            if (obj is Store)
            {
                Store s = (Store)obj;
                return s.StreetAddress.Equals(this.StreetAddress) && s.ZipCode.Equals(this.ZipCode);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public virtual void AddManager(Employee employee)
        {

        }

        public virtual void RemoveManager(Employee employee)
        {

        }

        public virtual void AddVideo(Video video)
        {
            video.Store = this;
            Videos.Add(video);
        }

        public virtual void RemoveVideo(Video video)
        {
            if (!Videos.Remove(video))
            {
                string message = $"Attempted to remove video with ID {video.Id} from store with ID {Id}; the store does not own this video";
                throw new ArgumentException(message);
            }
        }
    }
}
