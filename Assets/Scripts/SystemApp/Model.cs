using System.Collections.Generic;
using UnityEngine;

namespace SystemApp
{
    public class Model : MonoBehaviour
    {
        [SerializeField] private List<string> fakeDataBuilding;
        [SerializeField] private List<string> fakeDataCustomerA;
        [SerializeField] private List<string> fakeDataCustomerB;
        [SerializeField] private List<string> fakeDataCustomerC;

        public string GetRandomData(FakeDataType fakeDataType)
        {
            switch (fakeDataType)
            {
                case FakeDataType.Building:
                    return fakeDataBuilding[Random.Range(0, fakeDataBuilding.Count)];
                case FakeDataType.Money:
                    return Random.Range(10, 500) + ".000 VND";
                case FakeDataType.Customer:
                    var tmp = fakeDataCustomerA[Random.Range(0, fakeDataCustomerA.Count - 1)] + " " +
                              fakeDataCustomerB[Random.Range(0, fakeDataCustomerB.Count - 1)] + " " +
                              fakeDataCustomerC[Random.Range(0, fakeDataCustomerC.Count - 1)];
                    Debug.Log("TMT: " + tmp);
                    return tmp;
            }

            return "";
        }
    }

    public enum FakeDataType
    {
        Building,
        Money,
        Customer
    }
}