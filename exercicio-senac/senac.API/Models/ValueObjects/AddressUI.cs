using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class AddressUI 
    {
        protected AddressUI(){}

        public AddressUI(string street, string number, string neighborhood, string city, string state)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
    }
}
