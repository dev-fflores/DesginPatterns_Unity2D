using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class Consumer
    {
        private readonly IDataStore _dataStoreAdapter;

        public Consumer(IDataStore dataStoreAdapter)
        {
            _dataStoreAdapter = dataStoreAdapter;
        }
        
        public void SaveData()
        {
            var data = new Data("Hello", 456);
            _dataStoreAdapter.SetData(data, "Data1");
        }
        
        public void LoadData()
        {
            var data = _dataStoreAdapter.GetData<Data>("Data1");
            Debug.Log(data.dato_01);
            Debug.Log(data.dato_02);
        }
    }
}