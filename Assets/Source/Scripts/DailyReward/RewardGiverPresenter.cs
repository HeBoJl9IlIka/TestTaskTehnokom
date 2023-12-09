using Company.TestTask.Model;
using TMPro;
using UnityEngine;

namespace Company.TestTask.Presenter
{
    public class RewardGiverPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private TMP_Text _dayNumber;
        [SerializeField] private TMP_Text _amountReward;

        private DailyReward _dailyReward;

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
            _dayNumber.text = Config.RewardDay + " " + reward.DayNumber.ToString();
            _amountReward.text = Config.RewardX + reward.Amount.ToString();
            Invoke(nameof(ShowReward), Config.DelayShowingReward);
            Invoke(nameof(Hide), Config.DelayHideReward);
        }

        private void ShowReward() => _container.SetActive(true);

        private void Hide() => _container.SetActive(false);
    }
}
