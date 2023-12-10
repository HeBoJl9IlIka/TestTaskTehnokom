using UnityEngine;

namespace Company.TestTask.Model
{
    public class AmountDaysKeeper : IDataKeeper<int>
    {
        public int Load()
        {
            if (PlayerPrefs.GetInt(Config.MaxAmountDays) == PlayerPrefs.GetInt(Config.AmountDays))
                return 0;

            return PlayerPrefs.GetInt(Config.AmountDays);
        }

        public void Save(int maxDays)
        {
            PlayerPrefs.SetInt(Config.MaxAmountDays, maxDays);

            int amountDays = PlayerPrefs.GetInt(Config.AmountDays);
            PlayerPrefs.SetInt(Config.AmountDays, ++amountDays);
        }
    }
}
