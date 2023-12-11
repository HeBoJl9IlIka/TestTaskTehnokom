using Company.TestTask.Model;
using TMPro;
using UnityEngine;

namespace Company.TestTask.Presenter
{
    public class WalletPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _value;

        private Wallet _model;

        public void Init(Wallet model)
        {
            _model = model;
            _value.text = _model.Value.ToString();
            enabled = true;
        }

        private void OnEnable()
        {
            _model.Changed += OnChanged;
        }

        private void OnDisable()
        {
            _model.Changed -= OnChanged;
        }

        private void OnChanged(int value)
        {
            _value.text = value.ToString();
        }
    }
}
