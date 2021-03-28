﻿using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {

        private const double DefaultHealth = 100;
        private const double DefaultArmor = 50;
        private const double DefaultAbilityPoints = 40;
        public Warrior(string name)
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Satchel())
        {

        }

        public void Attack(Character character)
        {
            if (character.Name == Name)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
            }

            if (!character.IsAlive || !this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead); //?
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
