using MvvmHelpers;

namespace GasAgency.Models
{
    public class Client : ObservableObject
    {
        public string ClientId { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }
    }
}
