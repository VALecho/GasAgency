using System;
using GasAgency.MobileAppServices.RepositoryHelper;
using GasAgency.Models;
using Microsoft.AspNetCore.Mvc;

namespace GasAgency.MobileAppServices.Controllers
{
    [Route("api/[controller]")]
    
    public class ClientController : Controller
    {
        private readonly IClientRepository ClientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            ClientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(ClientRepository.GetAll());
        }

        // GET: api/Client
        [HttpGet("{id}")]
        public Client Get(string id)
        {
            Client client = ClientRepository.Get(id);
            return client;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Client client)
        {
            try
            {
                if(client == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
            }
            catch(Exception)
            {
                return BadRequest("Error while creating");
            }
            return Ok(client);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Client client)
        {
            try
            {
                if (client == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid State");
                }
                ClientRepository.Update(client);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ClientRepository.Remove(id);
        }
    }
}
