using System;

namespace Company.TestTask.Model
{
    public class DailyReward
    {
        private readonly IDataKeeper<DateTime> _dateKeeper;
        private readonly IDataKeeper<int> _amountDaysKeeper;
        private readonly Reward[] _rewards;
        private DateTime _currentDate;
        private DateTime _firstDate;
        private DateTime _lastDate;
        private DateTime _zeroDate;

        public int DayNumber => GetNumberReward() + 1;
        public int AmountDays => _amountDaysKeeper.Load();
        public int MaxAmountDays => _rewards.Length;

        public event Action<Reward> Awarded;

        public DailyReward(IDataKeeper<DateTime> dataKeeper, IDataKeeper<int> amountDaysKeeper, Reward[] rewards)
        {
            _dateKeeper = dataKeeper;
            _amountDaysKeeper = amountDaysKeeper;
            _rewards = rewards;
            _currentDate = DateTime.Now;
        }

        public void Enable()
        {
            try
            {
                _lastDate = _dateKeeper.Load();
                UnblockReward();
            }
            catch (ArgumentOutOfRangeException)
            {
                _firstDate = DateTime.Now;
                _dateKeeper.Save(_firstDate);
                UnblockReward();
            }

            foreach (Reward reward in _rewards)
                reward.Getted += OnGetted;
        }

        public void Disable()
        {
            foreach (Reward reward in _rewards)
                reward.Getted -= OnGetted;
        }

        private void UnblockReward()
        {
            if (_currentDate.Day > _lastDate.Day)
            {
                foreach (var reward in _rewards)
                    reward.Unblock(GetNumberReward() + 1);

                _dateKeeper.Save(_currentDate);
                _lastDate = _currentDate;
            }
        }

        private int GetNumberReward()
        {
            if (_lastDate == _zeroDate)
                return 0;

            int rewardNumber = _currentDate.Day - _firstDate.Day;

            if (rewardNumber > _rewards.Length - 1)
            {
                _firstDate = _currentDate;
                return 0;
            }

            return rewardNumber;
        }

        private void OnGetted(Reward reward)
        {
            Awarded?.Invoke(reward);
            _amountDaysKeeper.Save(_rewards.Length);
        }
    }
}
