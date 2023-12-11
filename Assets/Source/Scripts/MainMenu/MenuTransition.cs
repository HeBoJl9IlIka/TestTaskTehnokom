using UnityEngine;
using UnityEngine.UI;

namespace Company.TestTask.Presenter
{
    [RequireComponent(typeof(Button))]
    public class MenuTransition : MonoBehaviour
    {
        [SerializeField] private GameObject _parent;
        [SerializeField] private GameObject _link;
        [SerializeField] private bool _isDisablingParent;

        private Button _button;

        public void Init(GameObject parent, GameObject link)
        {
            _parent = parent;
            _link = link;
            enabled = true;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Transit);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Transit);
        }

        private void Transit()
        {
            if (_isDisablingParent)
                _parent.SetActive(false);

            _link.SetActive(true);
        }
    }
}
