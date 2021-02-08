namespace _05.FootballTeamGenerator.Common
{
    public static class Validator
    {
        public const int MIN_VALUE_OF_STATS = 0;
        public const int MAX_VALUE_OF_STATS = 100;

        public static string InavlidRaiting =
            "{0} should be between {1} and {2}.";

        public static string INVALID_NAME =
            "A {0} should not be empty.";

        public static string INVALID_PLAYER_NAME =
             "Player {1} is not in {2} team.";

        public static string INVALID_TEAM_NAME =
            "Team {0} does not exist.";

    }
}
