using TMPro;
using UnityEngine;

namespace SystemApp
{
    public class View : MonoBehaviour
    {
        [Header("Avoid Banner")]
        [SerializeField] private Canvas canvasTotal;

        [SerializeField] private RectTransform[] canvas;
        [SerializeField] private GameObject popupLogin;

        // ERROR
        [SerializeField] private GameObject popupError;
        [SerializeField] private TextMeshProUGUI errorTitle;

        [SerializeField] private TextMeshProUGUI errorDescription;

        // MESSAGE
        [SerializeField] private GameObject popupMessage;
        [SerializeField] private TextMeshProUGUI messageTitle;

        [SerializeField] private TextMeshProUGUI messageDescription;

        // MAIN
        [SerializeField] private TextMeshProUGUI walletUserTxt;
        [SerializeField] private TextMeshProUGUI userNameTxt;
        [SerializeField] private GameObject batchToday;
        [SerializeField] private GameObject myOrder;

        public void SwitchTab(int index)
        {
            batchToday.SetActive(false);
            myOrder.SetActive(false);
            switch (index)
            {
                case 0:
                {
                    batchToday.SetActive(true);
                    break;
                }
                case 1:
                {
                    myOrder.SetActive(true);
                    break;
                }
            }
        }

        public void InitMainPage(string wallet, string userName)
        {
            walletUserTxt.text = wallet + ".000 VND";
            userNameTxt.text = userName;
        }

        public void UpdateWalletDisplay(string wallet)
        {
            walletUserTxt.text = wallet + ".000 VND";
        }

        public void CloseAnPopup(PopupName popupName)
        {
            switch (popupName)
            {
                case PopupName.None:
                    break;
                case PopupName.Error:
                    popupError.SetActive(false);
                    break;
                case PopupName.Login:
                    popupLogin.SetActive(false);
                    break;
                case PopupName.Message:
                    popupMessage.SetActive(false);
                    break;
            }
        }

        public void ShowAnPopup(PopupName popupName)
        {
            switch (popupName)
            {
                case PopupName.None:
                    break;
                case PopupName.Error:
                    popupError.SetActive(true);
                    break;
                case PopupName.Login:
                    popupLogin.SetActive(true);
                    break;
                case PopupName.Message:
                    popupMessage.SetActive(true);
                    break;
            }
        }

        public void ShowError(string title, string description)
        {
            errorTitle.text = title;
            errorDescription.text = description;
            popupError.SetActive(true);
        }

        public void ShowMessage(string title, string description)
        {
            messageTitle.text = title;
            messageDescription.text = description;
            popupMessage.SetActive(true);
        }

        public Rect SafeArea()
        {
            Rect safeArea = Screen.safeArea;
            Rect[] cutouts = Cutouts();

            if (safeArea.y == 0)
            {
                float posY = safeArea.height;
                foreach (Rect rect in cutouts)
                {
                    if (posY > rect.y)
                    {
                        posY = rect.y;
                    }
                }

                safeArea.y = Screen.height - posY;
            }

            return safeArea;
        }

        public Rect[] Cutouts()
        {
            return Screen.cutouts;
        }

        public void AvoidCutout()
        {
            var safeArea = SafeArea();
            var cutouts = Cutouts();
            // view.AvoidCutout(DisplayService.SafeArea(), DisplayService.Cutouts());
            if (safeArea.y == 0)
            {
                float posY = safeArea.height;
                foreach (Rect rect in cutouts)
                {
                    if (posY > rect.y)
                    {
                        posY = rect.y;
                    }
                }

                safeArea.y = Screen.height - posY;
            }

            foreach (var item in canvas)
            {
                item.offsetMax = new Vector2(item.offsetMax.x, -safeArea.y);
            }
        }
    }

    public enum PopupName
    {
        None,
        Error,
        Login,
        Message
    }
}