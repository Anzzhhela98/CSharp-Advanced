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
        private List<Character> characters;
        private List<Item> items;
        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Character character = null;

            string typeOfCharacter = args[0];
            string nameOfCharacter = args[1];

            //Character character = characterType switch
            //{
            //    "Warrior" => new Warrior(name),
            //    "Priest" => new Priest(name),
            //    _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType))
            //};

            if (typeOfCharacter == "Warrior")
            {
                character = new Warrior(nameOfCharacter);
            }
            else if (typeOfCharacter == "Priest")
            {
                character = new Priest(nameOfCharacter);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, typeOfCharacter));
            }

            this.characters.Add(character);
            return String.Format(SuccessMessages.JoinParty, nameOfCharacter);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemName switch
            {
                nameof(FirePotion) => new FirePotion(),
                nameof(HealthPotion) => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName))
            };

            this.items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string givenName = args[0];
            var character = this.characters.FirstOrDefault(x => x.Name == givenName);

            if (character == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, givenName));
            }
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var pickedItem = this.items.Last();
            character.Bag.AddItem(pickedItem);

            return String.Format(SuccessMessages.PickUpItem, givenName, pickedItem.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string givenName = args[0];
            string givenItem = args[1];

            if (!this.characters.Any(x => x.Name == givenName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, givenName));
            }

            Character character = this.characters.FirstOrDefault(x => x.Name == givenName);
            Item item = character.Bag.GetItem(givenName);

            character.UseItem(item);

            return String.Format(SuccessMessages.UsedItem, givenName, givenItem);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {

                sb.AppendLine(character.ToString());

            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Warrior attacker = (Warrior)this.characters.Where(c => c.GetType().Name == nameof(Warrior)).FirstOrDefault(c => c.Name == attackerName);
            Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (!attacker.IsAlive)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AttackFail, attacker));
            }

            if (!receiver.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
            attacker.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                sb.AppendLine(String.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName  = args[0];
            string healingReceiverName  = args[1];

            Priest healer = (Priest)this.characters.Where(c => c.GetType().Name == nameof(Priest)).FirstOrDefault(c => c.Name == healerName );
            Character receiver = this.characters.FirstOrDefault(x => x.Name == healingReceiverName );

            if (healer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (!healer.IsAlive)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            healer.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

        }
    }
}
