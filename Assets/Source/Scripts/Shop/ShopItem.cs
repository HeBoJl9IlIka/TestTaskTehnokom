using Company.TestTask.Presenter;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Company.TestTask.Model
{
    public class ShopItem
    {
        public string Title { get; private set; }
        public Config.ItemType Type { get; private set; }
        public Config.CurrencyType Currency { get; private set; }
        public Sprite Icon { get; private set; }
        public bool IsOne { get; private set; }
        public int Amount { get; private set; }
        public bool IsBlock { get; private set; }
        public int TargetLevel { get; private set; }
        public float Price { get; private set; }

        public bool IsBlocked { get; private set; }
        public bool IsBuyed { get; private set; }

        public event Action Blocked;
        public event Action Unlocked;
        public event Action<ShopItem> Buying;
        public event Action Buyed;

        public ShopItem(ShopItemPresenter shopItemPresenter)
        {
            Title = shopItemPresenter.Title;
            Type = shopItemPresenter.Type;
            Currency = shopItemPresenter.Currency;
            Icon = shopItemPresenter.Icon;
            IsOne = shopItemPresenter.IsOne;
            Amount = shopItemPresenter.Amount;
            IsBlock = shopItemPresenter.IsBlock;
            TargetLevel = shopItemPresenter.TargetLevel;
            Price = shopItemPresenter.Price;
        }

        public void Block()
        {
            IsBlocked = true;
            Blocked?.Invoke();
        }

        public void Unblock()
        {
            IsBlocked = false;
            Unlocked?.Invoke();
        }

        public void Buy()
        {
            Buying?.Invoke(this);
        }

        public void ShowBuyed()
        {
            IsBuyed = true;
            Buyed?.Invoke();
        }
    }
}
