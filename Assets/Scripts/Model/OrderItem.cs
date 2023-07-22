using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Model
{
    public class OrderItem : MonoBehaviour
    {
        private string id;
        private UnityAction<int> _onClickView;
        public UnityAction<string, int> _onClickSubmit;
        [SerializeField] private TextMeshProUGUI typeTxt;
        [SerializeField] private TextMeshProUGUI nameTxt;
        [SerializeField] private TextMeshProUGUI buildingTxt;
        [SerializeField] private TextMeshProUGUI priceTxt;
        [SerializeField] private Button thisBtn;
        [SerializeField] private TextMeshProUGUI btnLable;
        private int money;

        public void InitItem(int index, string id, UnityAction<string, int> onClickSubmit,
            string name, string building, string price, bool isDone)
        {
            typeTxt.text = "Order: " + index;
            nameTxt.text = "Customer: " + name;
    
            Debug.Log("TMT: " + name);
            buildingTxt.text = "Building: " + building;
            if (string.IsNullOrEmpty(price))
            {
                priceTxt.text = "N/A";
                money = 0;
            }
            else
            {
                priceTxt.text = "Price: " + price + ".000 VND";
                money = int.Parse(price);
            }

            this.id = id;
            _onClickSubmit = onClickSubmit;
            if (isDone)
            {
                thisBtn.interactable = false;
                btnLable.text = "Done";
            }

            // monney = int.Parse("monney");
        }

        public void UpdateStatus(bool isDone)
        {
            if (isDone)
            {
                thisBtn.interactable = false;
                btnLable.text = "Done";
            }
        }
        // public void OnClickView()
        // {
        //     _onClickSubmit?.Invoke(id, money);
        // }

        public void OnClickSubmit()
        {
            _onClickSubmit?.Invoke(id, money);
            thisBtn.interactable = false;
            btnLable.text = "Done";
        }
    }
}