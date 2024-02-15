using System;
using Patterns.Adapter;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Strategy
{
    public class ConsumerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var dataStore = GetDataStore();
            var consumer = new Consumer(dataStore);
            consumer.SaveData();
            consumer.LoadData();
        }

        private IDataStore GetDataStore()
        {
            var isEven = Random.Range(0, 99) % 2 == 0;
            if (isEven)
            {
                return new PlayerPrefsDataStoreAdapter();
            }
            return new FileDataStoreAdapter();
        }
    }
}