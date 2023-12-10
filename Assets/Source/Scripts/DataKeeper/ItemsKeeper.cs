using System;
using System.Collections.Generic;
using UnityEngine;

namespace Company.TestTask.Model
{
    public class ItemsKeeper : IDataKeeper<Config.ItemType[]>
    {
        Config.ItemType[] IDataKeeper<Config.ItemType[]>.Load()
        {
            List<Config.ItemType> items = new List<Config.ItemType>();

            foreach (Config.ItemType itemType in Enum.GetValues(typeof(Config.ItemType)))
            {
                if (PlayerPrefs.HasKey(itemType.ToString()))
                    items.Add((Config.ItemType)PlayerPrefs.GetInt(itemType.ToString()));
            }

            return items.ToArray();
        }

        public void Save(Config.ItemType[] itemsTypes)
        {
            foreach (var itemType in itemsTypes)
            {
                if (itemType != Config.ItemType.Ticket)
                    PlayerPrefs.SetInt(itemType.ToString(), (int)itemType);
            }
        }
    }
}
