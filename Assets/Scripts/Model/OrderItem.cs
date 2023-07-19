using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class OrderItem : MonoBehaviour
    {
        private int _indexOfOrder;
        private UnityAction<int> _onClickView;
        public UnityAction<int> _onClickSubmit;
        [SerializeField] private TextMeshProUGUI typeTxt;
        [SerializeField] private TextMeshProUGUI nameTxt;
        [SerializeField] private TextMeshProUGUI buildingTxt;
        [SerializeField] private TextMeshProUGUI priceTxt;

        public void InitItem(int index, UnityAction<int> onClickView, UnityAction<int> onClickSubmit,
            string name, string building, string price
        )
        {
            typeTxt.text = "Order: " + index;
            nameTxt.text = "Customer: " + name;
            Debug.Log("TMT: " + name);
            buildingTxt.text = "Building: " + building;
            priceTxt.text = "Price: " + price;
            _indexOfOrder = index;
            // _onClickView = onClickView;
            _onClickSubmit = onClickSubmit;
        }

        public void OnClickView()
        {
            _onClickSubmit?.Invoke(_indexOfOrder);
        }

        public void OnClickSubmit()
        {
            _onClickSubmit?.Invoke(_indexOfOrder);
        }
    }
}