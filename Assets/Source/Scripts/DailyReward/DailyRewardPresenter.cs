using Company.TestTask.Model;
using UnityEngine;

namespace Company.TestTask.Presenter
{
    public class DailyRewardPresenter : MonoBehaviour
    {
        [SerializeField] private Transform _sliderContainer;
        [SerializeField] private Transform[] _rewardsContainers;

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
        }

        private void OnDisable()
        {
            _dailyReward.Awarded -= OnAwarded;
        }

        private void OnAwarded(Reward reward)
        {
            Invoke(nameof(Hide), Config.DelayShowingReward);
        }

        private void Hide() => gameObject.SetActive(false);
    }
}
