namespace Company.TestTask.Model
{
    public static class Config
    {
        public enum ItemType
        {
            Ticket,
            Skin1,
            Skin2,
            Location1,
            Location2,
            Location3
        }

        public enum CurrencyType
        {
            Ticket,
            Dollars
        }

        // DateKeeper
        public const string DateKeeperDay = "Day";
        public const string DateKeeperMonth = "Month";
        public const string DateKeeperYear = "Year";
        public const string AmountDays = "AmountDays";
        public const string MaxAmountDays = "MaxAmountDays";
        public const string CurrentLevel = "CurrentLevel";
        public const string AmountMoneys = "AmountMoneys";
        // DailyReward
        public const string RewardDay = "Day";
        public const string RewardX = "X";
        public const float SliderDuration = 1;
        public const float DelayShowingReward = 2;
        public const float DelayHideReward = DelayShowingReward + 2;
        // Shop
        public const float SpaceBetweenCells = 40;
        public const float SpaceBetweenTitle = 70;
        // LevelsMenu
        public const int FirstLevelNumber = 1;
    }
}
