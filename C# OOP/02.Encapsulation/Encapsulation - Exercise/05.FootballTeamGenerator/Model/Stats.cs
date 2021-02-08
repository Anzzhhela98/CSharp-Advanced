using System;
namespace _05.FootballTeamGenerator.Model
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        private int Endurance
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InavlidRaiting,
                        nameof(this.Endurance), Common.Validator.MIN_VALUE_OF_STATS, Common.Validator.MAX_VALUE_OF_STATS));
                }
                this.endurance = value;
            }
        }
        private int Sprint
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InavlidRaiting,
                        nameof(this.Sprint), Common.Validator.MIN_VALUE_OF_STATS, Common.Validator.MAX_VALUE_OF_STATS));
                }
                this.sprint = value;
            }
        }
        private int Dribble
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InavlidRaiting, nameof(this.Dribble),
                         Common.Validator.MIN_VALUE_OF_STATS, Common.Validator.MAX_VALUE_OF_STATS));
                }
                this.dribble = value;
            }
        }
        private int Passing
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InavlidRaiting,
                        nameof(this.Passing), Common.Validator.MIN_VALUE_OF_STATS, Common.Validator.MAX_VALUE_OF_STATS));
                }
                this.passing = value;
            }
        }
        private int Shooting
        {
            set
            {
                if (!IsValid(value))
                {
                    throw new ArgumentException(String.Format(Common.Validator.InavlidRaiting,
                        nameof(this.Shooting), Common.Validator.MIN_VALUE_OF_STATS, Common.Validator.MAX_VALUE_OF_STATS));
                }
                this.shooting = value;
            }
        }
        private bool IsValid(int value) => value >= Common.Validator.MIN_VALUE_OF_STATS && value <= Common.Validator.MAX_VALUE_OF_STATS;

        public double Average()
        {
            double average =
                (this.endurance + this.dribble + this.shooting + this.passing + this.sprint) / 5.00;

            return average;
        }
    }
}
