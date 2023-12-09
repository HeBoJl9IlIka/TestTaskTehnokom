using Company.TestTask.Model;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Company.TestTask.Presenter
{
    [RequireComponent(typeof(Slider))]
    public class DaysProgressBarPresenter : MonoBehaviour
    {
        private DailyReward _dailyReward;
        private Slider _slider;

        public void Init(DailyReward dailyReward)
        {
            _dailyReward = dailyReward;
            enabled = true;
        }

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _slider.maxValue = _dailyReward.MaxAmountDays;
            _slider.value = _dailyReward.AmountDays;
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
            int value = (int)_slider.value;
            _slider.DOValue(++value, Config.SliderDuration);
        }
    }
}
