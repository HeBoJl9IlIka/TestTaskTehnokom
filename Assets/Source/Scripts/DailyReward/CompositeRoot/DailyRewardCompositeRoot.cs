using Company.TestTask.Factory;
using Company.TestTask.Model;
using Company.TestTask.Presenter;
using System;
using UnityEngine;

namespace Company.TestTask.CompositeRoot
{
    [RequireComponent(typeof(RewardFactory))]
    [RequireComponent(typeof(SliderFactory))]
    [RequireComponent(typeof(RewardGiverFactory))]
    [RequireComponent(typeof(DailyRewardFactory))]
    public class DailyRewardCompositeRoot : MonoBehaviour
    {
        private DailyReward _dailyReward;
        private IDataKeeper<DateTime> _dateKeeper;
        private IDataKeeper<int> _amountDaysKeeper;
        private RewardFactory _rewardFactory;
        private SliderFactory _sliderFactory;
        private RewardGiverFactory _rewardGiverFactory;
        private DailyRewardFactory  _dailyRewardFactory;
        private DailyRewardPresenter  _dailyRewardPresenter;

        private void Awake()
        {
            _rewardFactory = GetComponent<RewardFactory>();
            _sliderFactory = GetComponent<SliderFactory>();
            _rewardGiverFactory = GetComponent<RewardGiverFactory>();
            _dailyRewardFactory = GetComponent<DailyRewardFactory>();
            _dateKeeper = new DateKeeper();
            _amountDaysKeeper = new AmountDaysKeeper();
            _dailyRewardPresenter = _dailyRewardFactory.Create();
            _dailyReward = new DailyReward(_dateKeeper, _amountDaysKeeper, _rewardFactory.Create(_dailyRewardPresenter.RewardsContainers));
            _dailyRewardPresenter.Init(_dailyReward);
            _sliderFactory.Create(_dailyReward, _dailyRewardPresenter.SliderContainer);
            _rewardGiverFactory.Create(_dailyReward);
        }

        private void OnEnable()
        {
            _dailyReward.Enable();
        }

        private void OnDisable()
        {
            _dailyReward.Disable();
        }
    }
}
