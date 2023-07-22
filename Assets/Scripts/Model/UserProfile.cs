using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserProfile : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fullName;
    [SerializeField] private TextMeshProUGUI email;
    [SerializeField] private TextMeshProUGUI phoneNumber;

    public void InitUserInformation(string fullNamePr, string emailPr, string phoneNumberPr)
    {
        fullName.text = fullNamePr;
        email.text = emailPr;
        phoneNumber.text = phoneNumberPr;
    }
}