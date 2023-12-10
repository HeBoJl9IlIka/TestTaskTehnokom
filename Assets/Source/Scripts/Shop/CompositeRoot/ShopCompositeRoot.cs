using Company.TestTask.Factory;
using Company.TestTask.Model;
using UnityEngine;

[RequireComponent(typeof(ShopFactory))]
public class ShopCompositeRoot : MonoBehaviour
{
    private IDataKeeper<int> _levelsKeeper;
    private IDataKeeper<Config.ItemType[]> _itemsKeeper;
    private Shop _shop;
    private ShopFactory _shopFactory;

    private void Awake()
    {
        _shopFactory = GetComponent<ShopFactory>();
        _levelsKeeper = new LevelsKeeper();
        _itemsKeeper = new ItemsKeeper();
        _shop = _shopFactory.Create(_levelsKeeper, _itemsKeeper);
    }

    private void OnEnable()
    {
        _shop.Enable();
    }

    private void OnDisable()
    {
        _shop.Disable();
    }
}
