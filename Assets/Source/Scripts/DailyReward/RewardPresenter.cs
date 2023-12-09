using Company.TestTask.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Company.TestTask.Presenter
{
    public class RewardPresenter : MonoBehaviour
    {
        [SerializeField] private Config.ItemType _itemType;
        [SerializeField] private int _amount;
        [SerializeField] private int _dayNumber;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private TMP_Text _dayNumberText;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private Button _gettingRewardButton;

        private Reward _reward;

        public Item Item => new Item(_itemType);
        public int Amount => _amount;
        public int DayNumber => _dayNumber;

        public void Init(Reward reward)
        {
            _reward = reward;
            enabled = true;
        }

        private void Awake()
        {
            _dayNumberText.text = Config.RewardDay + _dayNumber.ToString();
            _icon.sprite = _sprite;
            _amountText.text = Config.RewardX +  _amount.ToString();
            _gettingRewardButton.interactable = false;
        }

        private void OnEnable()
        {
            _gettingRewardButton.onClick.AddListener(OnGettedReward);

            if (_reward.IsGetted == false)
                _gettingRewardButton.interactable = _reward.IsUnblocked;
        }

        private void OnDisable()
        {
            _gettingRewardButton.onClick.RemoveListener(OnGettedReward);
        }

        private void OnGettedReward()
        {
            _reward.GetReward();
            _gettingRewardButton.interactable = false;
        }
    }
}
