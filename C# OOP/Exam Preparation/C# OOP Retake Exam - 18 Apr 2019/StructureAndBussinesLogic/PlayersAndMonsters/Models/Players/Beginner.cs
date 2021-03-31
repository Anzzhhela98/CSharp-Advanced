using PlayersAndMonsters.Repositories.Contracts;
namespace PlayersAndMonsters.Models.Players.Contracts
{
    public class Beginner : Player
    {
        private const int InitialHealthPoint = 50;
        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, InitialHealthPoint)
        {

        }
    }
}
