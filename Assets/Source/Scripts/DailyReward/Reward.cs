using System;

namespace Company.TestTask.Model
{
    public class Reward
    {

        public Item Item { get; private set; }
        public int Amount { get; private set; }
        public int DayNumber { get; private set; }
        public bool IsUnblocked { get; private set; }
        public bool IsGetted { get; private set; }

        public event Action<Reward> Getted;

        public Reward(Item item, int amount, int dayNumber)
        {
            Item = item;
            Amount = amount;
            DayNumber = dayNumber;
        }

        public void GetReward()
        {
            IsGetted = true;
            Getted?.Invoke(this);
        }

        public void Unblock(int currentDate)
        {
            IsUnblocked = DayNumber == currentDate;
        }
    }
}
