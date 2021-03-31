using PlayersAndMonsters.Repositories.Contracts;
namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int InitialHealthPoint = 250;
        public Advanced(  ICardRepository cardRepository, string username)
            : base(cardRepository, username, InitialHealthPoint)
        {

        }
    }
}
