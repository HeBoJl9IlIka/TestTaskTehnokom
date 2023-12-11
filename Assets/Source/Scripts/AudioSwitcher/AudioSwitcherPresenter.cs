using UnityEngine;
using UnityEngine.UI;

namespace Company.TestTask.Presenter
{
    public class AudioSwitcherPresenter : MonoBehaviour
    {
        [SerializeField] private Button _buttonOnAudio;
        [SerializeField] private Button _buttonOffAudio;

        private void OnEnable()
        {
            _buttonOnAudio.onClick.AddListener(OnAudio);
            _buttonOffAudio.onClick.AddListener(OffAudio);
        }

        private void OnDisable()
        {
            _buttonOnAudio.onClick.RemoveListener(OnAudio);
            _buttonOffAudio.onClick.RemoveListener(OffAudio);
        }

        private void OnAudio()
        {
            AudioListener.pause = false;
        }

        private void OffAudio()
        {
            AudioListener.pause = true;
        }
    }
}
