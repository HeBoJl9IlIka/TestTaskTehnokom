using System.Linq;

namespace Company.TestTask.Model
{
    public class Shop
    {
        private readonly IDataKeeper<int> _levelsKeeper;
        private readonly IDataKeeper<Config.ItemType[]> _itemsKeeper;
        private readonly ShopItem[] _shopItems;
        private int _currentLevel;

        public Shop(ShopItem[] shopItems, IDataKeeper<int> levelsKeeper, IDataKeeper<Config.ItemType[]> itemsKeeper)
        {
            _shopItems = shopItems;
            _levelsKeeper = levelsKeeper;
            _currentLevel = _levelsKeeper.Load();
            _itemsKeeper = itemsKeeper;
        }

        public void Enable()
        {
            BlockItem();
            UnblockItem();
            ShowBuyedItem();

            foreach (var shopItem in _shopItems)
                shopItem.Buying += OnBuying;
        }

        public void Disable()
        {
            foreach (var shopItem in _shopItems)
                shopItem.Buying -= OnBuying;
        }

        private void BlockItem()
        {
            foreach (var item in _shopItems)
            {
                if (item.TargetLevel > _currentLevel)
                    item.Block();
            }
        }

        private void UnblockItem()
        {
            foreach (var item in _shopItems)
            {
                if (item.TargetLevel < _currentLevel)
                    item.Unblock();
            }
        }

        private void ShowBuyedItem()
        {
            Config.ItemType[] itemsTypes = _itemsKeeper.Load();

            foreach (var shopItem in _shopItems)
            {
                Config.ItemType itemType = itemsTypes.FirstOrDefault(itemType => itemType == shopItem.Type);

                if (shopItem.Type == itemType)
                {
                    shopItem.ShowBuyed();
                }
            }
        }

        private void OnBuying(ShopItem shopItem)
        {
            Config.ItemType[] items = new Config.ItemType[1];
            items[0] = shopItem.Type;
            shopItem.ShowBuyed();
            _itemsKeeper.Save(items);
        }
    }
}
