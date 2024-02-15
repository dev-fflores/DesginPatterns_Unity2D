using System;
using UnityEngine;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private IDataStore _dataStoreAdapter;
        private void Awake()
        {
            _dataStoreAdapter = new PlayerPrefsDataStoreAdapter();
            
            var data = new Data("dato01", 123);
            _dataStoreAdapter.SetData(data, "Data1");
        }

        private void Start()
        {
            var data = _dataStoreAdapter.GetData<Data>("Data1");
            Debug.Log(data.dato_01);
            Debug.Log(data.dato_02);
        }
    }
}