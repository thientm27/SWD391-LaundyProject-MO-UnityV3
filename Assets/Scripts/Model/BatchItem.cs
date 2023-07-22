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

        public void InitItem(string type, string timeSpan, int driver, int indexOfBatch,
            UnityAction<int> onClickRegister)
        {
            _indexOfBatch = indexOfBatch;
            
            switch (type)
            {
                case "Return":
                    typeTxt.text = "Batch Type: " +  "<color=green>" + type + "</color>";
                    break;
                case "Pickup":
                    typeTxt.text = "Batch Type: " +  "<color=blue>" + type + "</color>";
                    break;
                default:
                    typeTxt.text = "Batch Type: " +  type;
                    break;
            }

            
           
            statusTxt.text = "Time span: " + timeSpan;
            if (driver == 0)
            {
                driveTxt.text = "Driver: " + "None";
                button.interactable = true;
            }
            else if (driver == -1)
            {
                driveTxt.text = "Driver: " + "<color=red>Other driver</color>";
                button.interactable = false;
            }
            else
            {
                driveTxt.text = "Driver: " + "<color=blue>You</color>";
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