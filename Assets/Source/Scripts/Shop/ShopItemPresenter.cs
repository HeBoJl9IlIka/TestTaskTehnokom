using Company.TestTask.Model;
using UnityEngine;

namespace Company.TestTask.Presenter
{
    public class ShopItemPresenter : MonoBehaviour
    {
        [SerializeField] private string _title;
        [SerializeField] private Config.ItemType _type;
        [SerializeField] private Config.CurrencyType _currency;
        [SerializeField] private Sprite _icon;
        [Header("In what quantity is it sold?")]
        [SerializeField] private bool _isOne;
        [SerializeField] private int _amount;
        [Header("To unlock you need to complete the level?")]
        [SerializeField] private bool _isBlock;
        [SerializeField] private int _targetLevel;
        [SerializeField] private float _price;

        public string Title => _title;
        public Config.ItemType Type => _type;
        public Config.CurrencyType Currency => _currency;
        public Sprite Icon => _icon;
        public bool IsOne => _isOne;
        public int Amount => _amount;
        public bool IsBlock => _isBlock;
        public int TargetLevel => _targetLevel;
        public float Price => _price;
    }
}
