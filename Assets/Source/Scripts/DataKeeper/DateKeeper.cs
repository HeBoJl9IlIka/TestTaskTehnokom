using System;
using UnityEngine;

namespace Company.TestTask.Model
{
    public class DateKeeper : IDataKeeper<DateTime>
    {
        public DateTime Load()
        {
            int day = PlayerPrefs.GetInt(Config.DateKeeperDay);
            int month = PlayerPrefs.GetInt(Config.DateKeeperMonth);
            int year = PlayerPrefs.GetInt(Config.DateKeeperYear);

            return new DateTime(year, month, day);
        }

        public void Save(DateTime dateTime)
        {
            int year = dateTime.Year;
            int month = dateTime.Month;
            int day = dateTime.Day;

            PlayerPrefs.SetInt(Config.DateKeeperYear, year);
            PlayerPrefs.SetInt(Config.DateKeeperMonth, month);
            PlayerPrefs.SetInt(Config.DateKeeperDay, day);
        }
    }
}
