using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Model
{
    public class BatchItem : MonoBehaviour
    {
        private int _indexOfBatch;
        private UnityAction<int> _onClickRegister;
        [SerializeField] private TextMeshProUGUI typeTxt;
        [SerializeField] private TextMeshProUGUI statusTxt;
        [SerializeField] private TextMeshProUGUI driveTxt;
        [SerializeField] private Button button;

        public void InitItem(string type, string status, int driver, int indexOfBatch,
            UnityAction<int> onClickRegister)
        {
            _indexOfBatch = indexOfBatch;
            typeTxt.text = "Batch Type: " + type;
            statusTxt.text = "Batch status: " + status;
            if (driver == 0)
            {
                driveTxt.text = "Driver: " + "None";
                button.interactable = true;
            }
            else if (driver == -1)
            {
                driveTxt.text = "Driver: " + "Other driver";
                button.interactable = false;
            }
            else
            {
                driveTxt.text = "Driver: " + "You";
                button.interactable = false;
            }

            _onClickRegister = onClickRegister;
        }

        public void OnClickRegister()
        {
            _onClickRegister?.Invoke(_indexOfBatch);
        }
    }
}