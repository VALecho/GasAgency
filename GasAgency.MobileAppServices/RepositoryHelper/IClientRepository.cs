using GasAgency.Models;
using System.Collections.Generic;

namespace GasAgency.MobileAppServices.RepositoryHelper
{
    public interface IClientRepository
    {
        void Add(Client client);
        void Update(Client client);
        Client Remove(string key);
        Client Get(string id);
        IEnumerable<Client> GetAll();
    }
}
