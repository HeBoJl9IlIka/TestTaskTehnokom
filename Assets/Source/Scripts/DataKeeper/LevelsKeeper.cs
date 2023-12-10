using UnityEngine;

namespace Company.TestTask.Model
{
    public class LevelsKeeper : IDataKeeper<int>
    {
        public int Load()
        {
            return PlayerPrefs.GetInt(Config.CurrentLevel);
        }

        public void Save(int currentLevel)
        {
            PlayerPrefs.SetInt(Config.CurrentLevel, currentLevel);
        }
    }
}
