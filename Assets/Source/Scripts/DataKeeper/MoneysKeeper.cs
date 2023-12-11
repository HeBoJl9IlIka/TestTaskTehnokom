using UnityEngine;

namespace Company.TestTask.Model
{
    public class MoneysKeeper : IDataKeeper<int>
    {
        public int Load()
        {
            return PlayerPrefs.GetInt(Config.AmountMoneys);
        }

        public void Save(int value)
        {
            PlayerPrefs.SetInt(Config.AmountMoneys, value);
        }
    }
}
