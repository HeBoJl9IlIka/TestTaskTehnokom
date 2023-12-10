using Company.TestTask.Model;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Company.TestTask.Presenter
{
    public class ShopCellPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _amount;
        [SerializeField] private TMP_Text _targetLevel;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _currencyIcon;
        [SerializeField] private Config.CurrencyType _currency;
        [SerializeField] private Image _icon;
        [SerializeField] private GameObject _buyed;
        [SerializeField] private GameObject _block;
        [SerializeField] private Button _buyingButton;

        private ShopItem _shopItem;

        public void Init(ShopItem shopItem)
        {
            _shopItem = shopItem;
            enabled = true;
            SetData();
        }

        private void OnEnable()
        {
            _shopItem.Blocked += OnBlocked;
            _shopItem.Unlocked += OnUnlocked;
            _shopItem.Buyed += OnBuyed;
            _buyingButton.onClick.AddListener(OnBuying);

            if (_shopItem.IsBlocked)
                OnBlocked();
            else
                OnUnlocked();

            if (_shopItem.IsBuyed)
                OnBuyed();
        }

        private void OnDisable()
        {
            _shopItem.Blocked -= OnBlocked;
            _shopItem.Unlocked -= OnUnlocked;
            _shopItem.Buyed -= OnBuyed;
            _buyingButton.onClick.RemoveListener(OnBuying);
        }

        private void SetData()
        {
            string currency = "";

            if (_currency == Config.CurrencyType.Dollars)
                currency = "$";

            _title.text = _shopItem.Title;
            _price.text = _shopItem.Price.ToString() + currency;
            _icon.sprite = _shopItem.Icon;

            if (_amount != null)
                _amount.text = "x" + _shopItem.Amount.ToString();

            if (_targetLevel != null)
                _targetLevel.text = "LV. " + _shopItem.TargetLevel.ToString();
        }

        private void OnBlocked()
        {
            if (_block == null)
                return;

            _block.SetActive(true);
            _icon.gameObject.SetActive(false);
        }

        private void OnUnlocked()
        {
            if (_block == null)
                return;

            _block.SetActive(false);
            _icon.gameObject.SetActive(true);
        }

        private void OnBuying()
        {
            if (_shopItem.IsBlocked)
                return;

            if (_shopItem.IsBuyed)
                return;

            _shopItem.Buy();
        }

        private void OnBuyed()
        {
            if (_buyed == null)
                return;

            _buyed.SetActive(true);
            _price.gameObject.SetActive(false);

            if (_currencyIcon != null)
                _currencyIcon.gameObject.SetActive(false);
        }
    }
}
