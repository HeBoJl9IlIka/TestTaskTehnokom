using Company.TestTask.Model;
using Company.TestTask.Presenter;
using UnityEngine;

namespace Company.TestTask.Factory
{
    public class ButtonsOpenLevelFactory : MonoBehaviour
    {
        [SerializeField] private ButtonOpenLevelPresenter[] _buttonsOpenLevelPresenters;

        public ButtonOpenLevel[] Create()
        {
            ButtonOpenLevel[] buttonsOpenLevel = new ButtonOpenLevel[_buttonsOpenLevelPresenters.Length];

            for (int i = 0; i < _buttonsOpenLevelPresenters.Length; i++)
            {
                buttonsOpenLevel[i] = new ButtonOpenLevel(Config.FirstLevelNumber + i);
                _buttonsOpenLevelPresenters[i].Init(buttonsOpenLevel[i]);
            }

            return buttonsOpenLevel;
        }
    }
}
