using System;

namespace Trainings.Core.Domain
{
    public class Gym
    {
        public Guid GymId { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string ContactNumber { get; protected set; }
        public int Area { get; protected set; }
        public double Rating { get; protected set; }
        public Position Position { get; protected set; }

        protected Gym() { }

        public Gym(string name, string email, Position position)
        {
            GymId = Guid.NewGuid();
            Name = name;
            Position = Position;
            Email = email;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetArea(int area)
        {
            Area = area;
        }

        public void SetRating(double rating)
        {
            Rating = rating;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetContactNumber(string number)
        {
            ContactNumber = number;
        }

        public void UpdateData(Gym gym)
        {
            Area = gym.Area;
            ContactNumber = gym.ContactNumber;
            Email = gym.Email;
            Name = gym.Name;
            Position = gym.Position;
        }
    }
}