using System;

namespace Company.TestTask.Model
{
    public class ButtonOpenLevel
    {
        public int LevelNumber { get; private set; }
        public bool IsBlocked { get; private set; }

        public event Action<int> Opening;
        public event Action Blocked;

        public ButtonOpenLevel(int levelNumber)
        {
            LevelNumber = levelNumber;
        }

        public void Open() => Opening?.Invoke(LevelNumber);

        public void Block(int currentLevel)
        {
            if (LevelNumber > currentLevel)
            {
                IsBlocked = true;
                Blocked?.Invoke();
            }
        }

        public void Unblock(int currentLevel)
        {
            if (LevelNumber <= currentLevel)
                IsBlocked = false;
        }
    }
}
