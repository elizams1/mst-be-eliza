using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mst_be.Services;
using mst_be_vm;
using System.Collections.Generic;

namespace mst_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        public PlayersServices playersServices;
        public IConfiguration config;
        public string connectionString;

        public PlayersController(PlayersServices _playersServices, IConfiguration _config)
        {
            playersServices = _playersServices;
            config = _config;
            connectionString = config.GetConnectionString("DefaultConnection");
        }
        
        [HttpGet]
        public List<VMPlayers> GetAllPlayers(string? birthPlace)
        {
            List<VMPlayers> players = new List<VMPlayers>();
            if (birthPlace == null)
            {
                players = playersServices.GetAllPlayers();
            }
            else
            {
                players = playersServices.GetPlayersByBirthPlace(birthPlace);
            }
           
            return players;
        }

        [HttpGet("{id?}")]
        public VMPlayers GetPlayersById(int  id) { 
            VMPlayers players = playersServices.GetPlayersById(id);
            return players;
        }

        [HttpPost]
        public List<VMPlayers> AddPlayers(int id, string name, int age, string birthPlace)
        {
            VMPlayers player = new VMPlayers();
            player.Id = id;
            player.Name = name;
            player.Age = age;
            player.BirthPlace  = birthPlace;

            List<VMPlayers> players = playersServices.AddPlayers(player);
            return players;
        }

        [HttpGet("[action]")]
        public string settings()
        {
            return connectionString;
        }


    }
}
