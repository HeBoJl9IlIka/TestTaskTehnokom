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

    public void Init(IDataKeeper<int> levelsKeeper, IDataKeeper<Config.ItemType[]> itemsKeeper)
    {
        _levelsKeeper = levelsKeeper;
        _itemsKeeper = itemsKeeper;
        enabled = true;
    }

    private void Awake()
    {
        _shopFactory = GetComponent<ShopFactory>();
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
