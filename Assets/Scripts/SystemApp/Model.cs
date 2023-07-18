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
                    return fakeDataCustomerA[Random.Range(0, fakeDataBuilding.Count - 1)] + fakeDataCustomerB[Random.Range(0, fakeDataBuilding.Count - 1)] + fakeDataCustomerC[Random.Range(0, fakeDataBuilding.Count - 1)];
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