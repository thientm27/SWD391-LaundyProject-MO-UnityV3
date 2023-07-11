using System;
using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private GameObject popupLogin;
    [SerializeField] private GameObject popupError;
    [SerializeField] private TextMeshProUGUI errorTitle;
    [SerializeField] private TextMeshProUGUI errorDescription;

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
        }
    }

    public void ShowError(string title, string description)
    {
        errorTitle.text = title;
        errorDescription.text = description;
        popupError.SetActive(true);
    }
}

public enum PopupName
{
    None,
    Error,
    Login
}