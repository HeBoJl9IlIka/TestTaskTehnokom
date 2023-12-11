using Company.TestTask.Model;
using UnityEngine;

namespace Company.TestTask.Presenter
{
    public class DailyRewardPresenter : MonoBehaviour
    {
        [SerializeField] private Transform _sliderContainer;
        [SerializeField] private Transform[] _rewardsContainers;
        [SerializeField] private GameObject _container;

        private DailyReward _dailyReward;

        public Transform SliderContainer => _sliderContainer;
        public Transform[] RewardsContainers => _rewardsContainers;

        public void Init(DailyReward dailyReward)
        {
            _dailyReward = dailyReward;
            enabled = true;
        }

        private void OnEnable()
        {
            _dailyReward.Awarded += OnAwarded;
            _dailyReward.Showing += OnShowing;
        }

        private void OnDisable()
        {
            _dailyReward.Awarded -= OnAwarded;
            _dailyReward.Showing -= OnShowing;
        }

        private void OnAwarded(Reward reward)
        {
            Invoke(nameof(Hide), Config.DelayShowingReward);
        }

        private void OnShowing()
        {
            _container.SetActive(true);
        }

        private void Hide() => _container.SetActive(false);
    }
}
