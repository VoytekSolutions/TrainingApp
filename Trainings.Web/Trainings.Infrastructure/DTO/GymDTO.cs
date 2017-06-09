using Trainings.Core.Domain;

namespace Trainings.Infrastructure.DTO
{
    public class GymDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int Area { get; set; }
        public double Rating { get; set; }
        public Position Position { get; set; }
    }
}
