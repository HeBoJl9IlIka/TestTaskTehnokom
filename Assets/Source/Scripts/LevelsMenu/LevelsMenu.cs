using UnityEngine;
using UnityEngine.SceneManagement;

namespace Company.TestTask.Model
{
    public class LevelsMenu
    {
        private IDataKeeper<int> _levelsKeeper;
        private ButtonOpenLevel[] _buttonsOpenLevel;
        private int _currentLevel;

        public LevelsMenu(IDataKeeper<int> levelsKeeper, ButtonOpenLevel[] buttonsOpenLevel)
        {
            _levelsKeeper = levelsKeeper;
            _buttonsOpenLevel = buttonsOpenLevel;
            _currentLevel = _levelsKeeper.Load();

            if (_currentLevel == 0)
            {
                _levelsKeeper.Save(Config.FirstLevelNumber);
                _currentLevel = _levelsKeeper.Load();
            }
        }

        public void Enable()
        {
            BlockLevels();

            foreach (var button in _buttonsOpenLevel)
                button.Opening += OnOpening;
        }

        public void Disable()
        {
            foreach (var button in _buttonsOpenLevel)
                button.Opening -= OnOpening;
        }

        private void OnOpening(int targetLevel)
        {
            if (targetLevel <= _currentLevel)
                SceneManager.LoadScene(targetLevel);
        }

        private void BlockLevels()
        {
            foreach (var button in _buttonsOpenLevel)
                button.Block(_currentLevel);
        }
    }
}
