using Company.TestTask.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Company.TestTask.Presenter
{
    [RequireComponent(typeof(Button))]
    public class ButtonOpenLevelPresenter : MonoBehaviour
    {
        [SerializeField] private Image _block;
        [SerializeField] private TMP_Text _number;

        private ButtonOpenLevel _model;
        private Button _button;

        public void Init(ButtonOpenLevel model)
        {
            _model = model;
            _number.text = _model.LevelNumber.ToString();
            enabled = true;
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _model.Blocked += OnBlocked;
            _button.onClick.AddListener(OnOpenedLevel);

            if (_model.IsBlocked)
                OnBlocked();
            else
                Unblock();
        }

        private void OnDisable()
        {
            _model.Blocked -= OnBlocked;
            _button.onClick.RemoveListener(OnOpenedLevel);
        }

        private void OnOpenedLevel() => _model.Open();

        private void OnBlocked()
        {
            _block.gameObject.SetActive(true);
            _number.gameObject.SetActive(false);
        }

        private void Unblock()
        {
            _block.gameObject.SetActive(false);
            _number.gameObject.SetActive(true);
        }
    }
}
