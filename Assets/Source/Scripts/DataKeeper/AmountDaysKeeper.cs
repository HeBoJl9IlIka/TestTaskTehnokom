using UnityEngine;

namespace Company.TestTask.Model
{
    public class AmountDaysKeeper : IDataKeeper<int>
    {
        public int LoadDate()
        {
            if (PlayerPrefs.GetInt(Config.MaxAmountDays) == PlayerPrefs.GetInt(Config.AmountDays))
                return 0;

            return PlayerPrefs.GetInt(Config.AmountDays);
        }

        public void SaveDate(int maxDays)
        {
            PlayerPrefs.SetInt(Config.MaxAmountDays, maxDays);

            int amountDays = PlayerPrefs.GetInt(Config.AmountDays);
            PlayerPrefs.SetInt(Config.AmountDays, ++amountDays);
        }
    }
}
