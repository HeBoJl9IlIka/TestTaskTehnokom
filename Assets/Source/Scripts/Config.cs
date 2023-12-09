namespace Company.TestTask.Model
{
    public static class Config
    {
        public enum ItemType
        {
            Ticket,
            Ball
        }

        // DateKeeper
        public const string DateKeeperDay = "Day";
        public const string DateKeeperMonth = "Month";
        public const string DateKeeperYear = "Year";
        public const string AmountDays = "AmountDays";
        public const string MaxAmountDays = "MaxAmountDays";
        // DailyReward
        public const string RewardDay = "Day";
        public const string RewardX = "X";
        public const float SliderDuration = 1f;
        public const float DelayShowingReward = 2f;
        public const float DelayHideReward = DelayShowingReward + 2f;
    }
}
