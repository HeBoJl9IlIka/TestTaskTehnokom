using System;

namespace Company.TestTask.Model
{
    public class Wallet
    {
        private IDataKeeper<int> _moneysKeeper;
        private DailyReward _dailyReward;

        public int Value { get; private set; }

        public event Action<int> Changed;

        public Wallet(IDataKeeper<int> moneysKeeper)
        {
            _moneysKeeper = moneysKeeper;
            Value = _moneysKeeper.Load();
            Changed?.Invoke(Value);
        }

        public void Init(DailyReward dailyReward)
        {
            _dailyReward = dailyReward;
        }

        public void Enable()
        {
            _dailyReward.Awarded += OnAwarded;
        }

        public void Disable()
        {
            _dailyReward.Awarded -= OnAwarded;
        }

        public void Add(int value)
        {
            Value += value;
            _moneysKeeper.Save(Value);
            Changed?.Invoke(Value);
        }

        public bool TryBuy(int value)
        {
            if (Value >= value)
            {
                Value -= value;
                _moneysKeeper.Save(Value);
                Changed?.Invoke(Value);
                return true;
            }

            return false;
        }

        private void OnAwarded(Reward reward)
        {
            Value += reward.Amount;
            _moneysKeeper.Save(Value);
            Changed?.Invoke(Value);
        }
    }
}
