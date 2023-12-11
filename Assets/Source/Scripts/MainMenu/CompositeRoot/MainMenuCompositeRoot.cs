using Company.TestTask.Model;
using Company.TestTask.Presenter;
using UnityEngine;

public class MainMenuCompositeRoot : MonoBehaviour
{
    [SerializeField] private ShopCompositeRoot _shopCompositeRoot;
    [SerializeField] private LevelsMenuCompositeRoot _levelsMenuCompositeRoot;
    [SerializeField] private DailyRewardCompositeRoot _dailyRewardCompositeRoot;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private MenuTransition _shopTransition;
    [SerializeField] private WalletPresenter _walletPresenter;

    private IDataKeeper<int> _levelsKeeper;
    private IDataKeeper<Config.ItemType[]> _itemsKeeper;
    private IDataKeeper<int> _moneysKeeper;
    private Wallet _wallet;

    private void Awake()
    {
        _levelsKeeper = new LevelsKeeper();
        _itemsKeeper = new ItemsKeeper();
        _moneysKeeper = new MoneysKeeper();
        _wallet = new Wallet(_moneysKeeper);

        _shopCompositeRoot.Init(_levelsKeeper, _itemsKeeper);
        _levelsMenuCompositeRoot.Init(_levelsKeeper);
        _shopTransition.Init(_mainMenu, _shopCompositeRoot.ShopPresenter.gameObject);
        _walletPresenter.Init(_wallet);
    }

    private void Start()
    {
        _dailyRewardCompositeRoot.Init(_wallet);
        _wallet.Enable();
    }


    private void OnDisable()
    {
        _wallet.Disable();
    }
}
