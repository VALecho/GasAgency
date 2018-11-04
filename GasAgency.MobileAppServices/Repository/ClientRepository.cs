using GasAgency.MobileAppServices.RepositoryHelper;
using GasAgency.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GasAgency.MobileAppServices.Repository
{
    public class ClientRepository : IClientRepository
    {
        private static ConcurrentDictionary<string, Client> clients =
            new ConcurrentDictionary<string, Client>();

        public ClientRepository()
        {
            Add(new Client { ClientId = Guid.NewGuid().ToString(), Name = "Client1", AddressLine1="1", AddressLine2="2", Mobile = "3743743743", Phone="582019"});
        }
        public void Add(Client client)
        {
            client.ClientId = Guid.NewGuid().ToString();
            clients[client.ClientId] = client;
        }

        public Client Get(string id)
        {
            return clients[id];
        }

        public IEnumerable<Client> GetAll()
        {
            return clients.Values;
        }

        public Client Remove(string key)
        {
            Client client;
            clients.TryRemove(key, out client);

            return client;
        }

        public void Update(Client client)
        {
            clients[client.ClientId] = client;
        }
    }
}
