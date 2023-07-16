using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class OrderItem : MonoBehaviour
    {
        private int _indexOfOrder;
        private UnityAction<int> _onClickView;
        private UnityAction<int> _onClickSubmit;
        [SerializeField] private TextMeshProUGUI typeTxt;

        public void InitItem(int index, UnityAction<int> onClickView, UnityAction<int> onClickSubmit)
        {
            typeTxt.text = "Order: " + index;
            _indexOfOrder = index;
            _onClickView = onClickView;
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