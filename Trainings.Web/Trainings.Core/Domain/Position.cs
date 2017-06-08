namespace Trainings.Core.Domain
{
    public class Position
    {
        public string Adress { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }

        protected Position()
        { }

        public Position(string adress, double longitude, double latitude)
        {
            Adress = adress;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}