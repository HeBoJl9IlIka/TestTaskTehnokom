using Company.TestTask.Model;
using UnityEngine;

namespace Company.TestTask.Presenter
{
    public class ShopPresenter : MonoBehaviour
    {
        [SerializeField] private Transform _cellsContainer;
        [SerializeField] private RectTransform _targetPoint;

        private Shop _shop;

        public Transform CellsContainer => _cellsContainer;
        public Vector2 Position => _targetPoint.anchoredPosition;
        public float PositionHorizontal => _targetPoint.position.x;

        public void Init(Shop shop, float height)
        {
            _shop = shop;

            if (_cellsContainer.TryGetComponent(out RectTransform rectTransform))
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);

            enabled = true;
        }

        private void Awake()
        {
            gameObject.SetActive(false);
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
}
