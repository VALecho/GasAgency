using MvvmHelpers;

namespace GasAgency.Models
{
    public class Product : ObservableObject
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
