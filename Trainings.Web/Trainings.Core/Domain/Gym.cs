using System;

namespace Trainings.Core.Domain
{
    public class Gym
    {
        public Guid GymId { get; protected set; }
        public string Name { get; protected set; }
        public int Area { get; protected set; }
        public double Rating { get; protected set; }
        public Position Position { get; protected set; }

        protected Gym() { }

        public Gym(string name, Position position)
        {
            GymId = Guid.NewGuid();
            Name = name;
            Position = Position;
        }
    }
}