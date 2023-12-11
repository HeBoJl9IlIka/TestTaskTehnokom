using Company.TestTask.Model;
using Company.TestTask.Presenter;
using System;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class ShopCellsFactory : MonoBehaviour
    {
        [SerializeField] private ShopCellPresenter _templateCell;
        [SerializeField] private ShopItemPresenter[] _shopItemsPresenters;

        private float _lastCellHeight;

        private float CellHeight => GetCellHeight();
        public float Height { get; private set; }

        public ShopItem[] Create(Transform container)
        {
            ShopItem[] shopItems = new ShopItem[_shopItemsPresenters.Length];

            for (int i = 0; i < _shopItemsPresenters.Length; i++)
            {
                shopItems[i] = new ShopItem(_shopItemsPresenters[i]);
                ShopCellPresenter shopCellPresenter = Instantiate(_templateCell, container);
                shopCellPresenter.Init(shopItems[i]);
                SetPosition(shopCellPresenter);
            }

            Height = Config.SpaceBetweenTitle + CellHeight * _shopItemsPresenters.Length + Config.SpaceBetweenCells * _shopItemsPresenters.Length;

            return shopItems;
        }

        private void SetPosition(ShopCellPresenter shopCellPresenter)
        {
            if (shopCellPresenter.TryGetComponent(out RectTransform rectTransform) == false)
                throw new ArgumentNullException(nameof(rectTransform));

            if (_lastCellHeight == 0)
                _lastCellHeight += Config.SpaceBetweenTitle + CellHeight / 2;
            else
                _lastCellHeight += Config.SpaceBetweenCells + CellHeight;

            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -_lastCellHeight);
        }

        private float GetCellHeight()
        {
            if (_templateCell.TryGetComponent(out RectTransform rectTransform) == false)
                throw new ArgumentNullException(nameof(rectTransform));

            return rectTransform.sizeDelta.y;
        }
    }
}
