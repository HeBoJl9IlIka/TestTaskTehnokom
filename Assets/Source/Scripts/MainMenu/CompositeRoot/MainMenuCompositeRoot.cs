using Company.TestTask.Model;
using UnityEngine;

public class MainMenuCompositeRoot : MonoBehaviour
{
    [SerializeField] private ShopCompositeRoot _shopCompositeRoot;
    [SerializeField] private LevelsMenuCompositeRoot _levelsMenuCompositeRoot;

    private IDataKeeper<int> _levelsKeeper;
    private IDataKeeper<Config.ItemType[]> _itemsKeeper;

    private void Awake()
    {
        _levelsKeeper = new LevelsKeeper();
        _itemsKeeper = new ItemsKeeper();

        _shopCompositeRoot.Init(_levelsKeeper, _itemsKeeper);
        _levelsMenuCompositeRoot.Init(_levelsKeeper);
    }
}
