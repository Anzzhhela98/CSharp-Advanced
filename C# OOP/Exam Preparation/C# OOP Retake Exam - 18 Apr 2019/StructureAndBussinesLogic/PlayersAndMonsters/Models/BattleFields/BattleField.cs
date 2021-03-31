using System;
using System.Linq;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                IncreaseHealth(enemyPlayer);
            }
            if (attackPlayer.GetType().Name == "Beginner")
            {
                IncreaseHealth(attackPlayer);
            }

            BonusPoints(attackPlayer);
            BonusPoints(enemyPlayer);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                int attackerPower = TotalDamagePoints(attackPlayer);
                int enemyPower = TotalDamagePoints(enemyPlayer);

                enemyPlayer.TakeDamage(attackerPower);

                if (enemyPlayer.IsDead)
                {
                    continue;
                }

                attackPlayer.TakeDamage(enemyPower);
            }
        }

        private int TotalDamagePoints(IPlayer player)
        {
            return player.CardRepository.Cards.Sum(x => x.DamagePoints);
        }

        private void BonusPoints(IPlayer player)
        {
            int sum = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += sum;
        }

        private static void IncreaseHealth(IPlayer player)
        {
            player.Health += 40;
            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}