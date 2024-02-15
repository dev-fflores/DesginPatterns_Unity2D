using System;

namespace Patterns.Adapter
{
    [Serializable]
    public class Data
    {
        public string dato_01;
        public int dato_02;

        public Data(string dato01, int dato02)
        {
            dato_01 = dato01;
            dato_02 = dato02;
        }
    }
}