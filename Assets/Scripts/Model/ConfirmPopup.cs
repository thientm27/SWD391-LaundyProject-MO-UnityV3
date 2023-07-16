using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class ConfirmPopup : MonoBehaviour
    {
        [SerializeField] private string des;
         private UnityAction _onClickYes;

         public void InitPopup( UnityAction onClickYes)
         {
             _onClickYes = onClickYes;
         }
        public void OnClickClose()
        {
            gameObject.SetActive(false);
        }
        public void OnClickYes()
        {
            _onClickYes?.Invoke();
        }
    }
}