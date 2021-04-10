using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characterRepo;
        private List<Item> itemRepo;

        public WarController()
        {
            characterRepo = new List<Character>();
            itemRepo = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string characterName = args[1];

            Character hero = null;

            if (characterType == "Priest")
            {
                hero = new Priest(characterName);
            }
            else if (characterType == "Warrior")
            {
                hero = new Warrior(characterName);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
            }

            this.characterRepo.Add(hero);
            return String.Format(SuccessMessages.JoinParty, characterName);
        }

        public string AddItemToPool(string[] args)
        {
            string itemType = args[0];

            Item item = null;

            if (itemType == "FirePotion")
            {
                item = new FirePotion();
            }
            else if (itemType == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidItem, itemType);
            }
            this.itemRepo.Add(item);
            return String.Format(SuccessMessages.JoinParty, itemType);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (!this.characterRepo.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!this.itemRepo.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item pichUpItem = this.itemRepo.Last();
            Character character = this.characterRepo.FirstOrDefault(x => x.Name == characterName);
            character.Bag.AddItem(pichUpItem);
            this.itemRepo.Remove(pichUpItem);

            return String.Format(SuccessMessages.PickUpItem, characterName, pichUpItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = this.characterRepo.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return String.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            var sortedCharacters =
                this.characterRepo.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);

            foreach (var character in sortedCharacters)
            {
                string status = character.IsAlive ? "Alive" : "Dead";

                sb.AppendLine(String.Format
                (SuccessMessages.CharacterStats,
                character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, status));
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string attackerName = args[0];
            string recieverName = args[1];

            if (!this.characterRepo.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (!this.characterRepo.Any(x => x.Name == recieverName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, recieverName));
            }

            Warrior attacker = (Warrior)this.characterRepo.FirstOrDefault(x => x.Name == attackerName);
            Character reciever = this.characterRepo.FirstOrDefault(x => x.Name == recieverName);

            if (!attacker.IsAlive)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            attacker.Attack(reciever);

            sb.AppendLine(String.Format
               (SuccessMessages.AttackCharacter, attackerName, recieverName, attacker.AbilityPoints,
               recieverName, reciever.Health, reciever.BaseHealth, reciever.Armor, reciever.BaseArmor));

            if (!reciever.IsAlive)
            {
                sb.AppendLine(String.Format(SuccessMessages.AttackKillsCharacter, reciever.Name));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!this.characterRepo.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healerName);
            }
            if (!this.characterRepo.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), healingReceiverName);
            }

            if (this.characterRepo.FirstOrDefault(x => x.Name == healerName).GetType().Name != "Priest")
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest healer = (Priest)this.characterRepo.FirstOrDefault(x => x.Name == healerName);
            Character reciever = this.characterRepo.FirstOrDefault(x => x.Name == healingReceiverName);

            healer.Heal(reciever);

            sb.AppendLine(String.Format
             (SuccessMessages.HealCharacter, healer.Name, reciever.Name, healer.AbilityPoints, reciever.Name, reciever.Health));

            return sb.ToString().TrimEnd();
        }
    }
}
