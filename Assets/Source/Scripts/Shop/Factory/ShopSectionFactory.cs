using Company.TestTask.Model;
using Company.TestTask.Presenter;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class ShopSectionFactory : MonoBehaviour
    {
        [SerializeField] private string _title;
        [SerializeField] private ShopSectionPresenter _template;
        [SerializeField] private ShopCellsFactory _shopCellsFactory;

        public float Height { get; private set; }

        public ShopItem[] Create(Transform container, float positionVertical)
        {
            ShopSectionPresenter newShopSection = Instantiate(_template, container);
            ShopItem[] shopItems = _shopCellsFactory.Create(newShopSection.transform);
            Height = _shopCellsFactory.Height;

            if (newShopSection.TryGetComponent(out RectTransform rectTransform))
            {
                float positionVartical = rectTransform.sizeDelta.y / 2 + positionVertical;
                rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -positionVartical);
            }

            newShopSection.Init(_title);

            return shopItems;
        }
    }
}
