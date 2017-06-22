namespace Trainings.Core.Domain
{
    public class Position
    {
        public string Adress { get; protected set; }
        public double Longitude { get; protected set; }
        public double Latitude { get; protected set; }

        protected Position()
        { }

        private Position(string adress, double longitude, double latitude)
        {
            SetAdress(adress);
            SetLongitude(longitude);
            SetLatitude(latitude);
        }

        public static Position Create(string adress, double longitude, double latitude)
            => new Position(adress, longitude, latitude);

        public void SetAdress(string adress)
        {
            Adress = adress;
        }

        public void SetLongitude(double longitude)
        {
            Longitude = longitude;
        }

        public void SetLatitude(double latitude)
        {
            Latitude = latitude;
        }
    }
}