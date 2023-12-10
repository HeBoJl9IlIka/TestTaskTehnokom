using Company.TestTask.Model;
using Company.TestTask.Presenter;
using System.Collections.Generic;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class ShopFactory : MonoBehaviour
    {
        [SerializeField] private ShopPresenter _template;
        [SerializeField] private ShopSectionFactory[] _shopSectionsFactories;

        public Shop Create(IDataKeeper<int> levelsKeeper, IDataKeeper<Config.ItemType[]> itemsKeeper)
        {
            float lastSectionHeight = 0;
            List<ShopItem> shopItems = new List<ShopItem>();
            ShopPresenter shopPresenter = Instantiate(_template);

            foreach(var shopSection in _shopSectionsFactories)
            {
                ShopItem[] newShopItems = shopSection.Create(shopPresenter.CellsContainer, lastSectionHeight);
                lastSectionHeight += shopSection.Height;

                foreach(var shopItem in newShopItems)
                    shopItems.Add(shopItem);
            }

            Shop shop = new Shop(shopItems.ToArray(), levelsKeeper, itemsKeeper);
            shopPresenter.Init(shop, lastSectionHeight);

            return shop;
        }
    }
}
