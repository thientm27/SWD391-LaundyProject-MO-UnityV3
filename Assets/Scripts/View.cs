using System;
using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private GameObject popupLogin;
    // ERROR
    [SerializeField] private GameObject popupError;
    [SerializeField] private TextMeshProUGUI errorTitle;
    [SerializeField] private TextMeshProUGUI errorDescription;
    // MESSAGE
    [SerializeField] private GameObject popupMessage;
    [SerializeField] private TextMeshProUGUI messageTitle;
    [SerializeField] private TextMeshProUGUI messageDescription;
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
}

public enum PopupName
{
    None,
    Error,
    Login,
    Message
}