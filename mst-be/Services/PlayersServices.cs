using mst_be_vm;

namespace mst_be.Services
{
    public class PlayersServices
    {

        private static readonly string[] Name = new[]
        {
            "Christiano Ronaldo", "Lionel Messi", "Karim Benzema", "Erling Haaland", "Kylian Mbappe"
        };

        private static readonly int[] Age = new[]
        {
            38, 36,35,23,24
        };

        private static readonly string[] BirthPlace = new[]
        {
            "Europe","South America", "Europe","Europe","Europe"
        };

        public List<VMPlayers> GetAllPlayers()
        {
            List<VMPlayers> players = new List<VMPlayers>();
            for (int i = 0; i < Name.Length; i++)
            {
                VMPlayers player = new VMPlayers();
                player.Id = i + 1;
                player.Name = Name[i];
                player.Age = Age[i];
                player.BirthPlace = BirthPlace[i];
                players.Add(player);
            }
            return players;
        }

        public List<VMPlayers>? GetPlayersByBirthPlace(string? birthPlace) {
            List<VMPlayers> players = GetAllPlayers().Where(a=>a.BirthPlace.ToLower()==birthPlace.ToLower()).ToList();
            return players;
        }

        public VMPlayers GetPlayersById(int? id)
        {
            VMPlayers players = GetAllPlayers().Where(a => a.Id == id).FirstOrDefault();
            return players;
        }

        public List<VMPlayers> AddPlayers(VMPlayers player)
        {
            List<VMPlayers> players = GetAllPlayers();
            players.Add(player);

            return players;
        }

    }
}
