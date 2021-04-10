using System;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.Health = health;
            this.BaseHealth = health;
            this.Armor = armor;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }
        public double Health
        {
            get { return this.health; }
            set
            {
                if (value > 0)
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; private set; }
        public double Armor
        {
            get { return this.armor; }
            private set
            {
                if (value >0)
                {
                    this.armor = value;
                }
            }
        }

        public double AbilityPoints { get; private set; }
        public IBag Bag { get; private set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            if (this.Armor < hitPoints)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;

                if (this.Health >= hitPoints)
                {
                    this.Health -= hitPoints;
                }
                else
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
            }
            else
            {
                this.armor -= hitPoints;
            }
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}