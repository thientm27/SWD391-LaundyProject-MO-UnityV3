using System;
using System.Text.RegularExpressions;
using LaudryAPI;
using LaundryAPI.ResponseModels;
using Model;
using TMPro;
using UnityEngine;


public class Controller : MonoBehaviour
{
    private APIServices _apiServices;
    [SerializeField] private View view;
    [SerializeField] private TMP_InputField loginEmail;
    [SerializeField] private TMP_InputField loginPassword;
    [SerializeField] private BatchDisplay batchDisplay;
    [SerializeField] private FooterTab[] footerTabs;

    private BatchTodayResponse batchToday;
    private string userId;

    //38245ee0-d03e-4cdb-9be1-40597f6b41b8 
    private void Awake()
    {
        _apiServices = new APIServices();
    }

    void Start()
    {
        view.ShowAnPopup(PopupName.Login);
        batchDisplay.onClickRegister = OnClickRegisterToBatch;
        foreach (var oFooterTab in footerTabs)
        {
            oFooterTab.onClick = OnClickFooterTab;
        }

        OnClickFooterTab(footerTabs[0]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Debug.Log("Test API");
            // _apiServices.GetBatchToday();
            // _apiServices.RegisterToBatch("c1a1dea7-0b3b-4470-bcc1-2aa7470a6f45");
            // _apiServices.GetAllBatchOfDriver("38245ee0-d03e-4cdb-9be1-40597f6b41b8");
            _apiServices.GetOrderInBatch("9d35343b-d0d3-4ab9-b72b-939160cfcfba");
        }
    }

    public bool ValidateEmail(string email)
    {
        // Regular expression pattern for email validation
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        // Use Regex.IsMatch() to check if the email matches the pattern
        bool isValid = Regex.IsMatch(email, pattern);

        return isValid;
    }

    #region Button Event

    private void OnClickFooterTab(FooterTab itemClick)
    {
        var index = 0;
        foreach (var item in footerTabs)
        {
            item.SetActive(false);
        }
        foreach (var item in footerTabs)
        {
            if (item == itemClick)
            {
                item.SetActive(true);
                break;
            }
            index++;
        }
        
        // do stm
        view.SwitchTab(index);
    }

    private void OnClickRegisterToBatch(int index)
    {
        Debug.Log("Register");
        Debug.Log(batchToday.items[index].batchId);
        _apiServices.RegisterToBatch(batchToday.items[index].batchId);
    }

    public void OnClickLogin()
    {
        if (string.IsNullOrEmpty(loginEmail.text) || string.IsNullOrEmpty(loginPassword.text))
        {
            view.ShowError("Error", "Email or password cannot be empty");
        }
        else if (!ValidateEmail(loginEmail.text))
        {
            view.ShowError("Error", "Email not valid");
        }
        else
        {
            try
            {
                _apiServices.Login(loginEmail.text, loginPassword.text);
            }
            catch (Exception e)
            {
                OnLoginFail();
                throw;
            }
        }
    }

    #endregion

    #region API Callback

    private void OnGetUserInformation(UserInformation response)
    {
        view.InitMainPage(response.wallet.ToString(), response.fullName.ToString());
    }

    private void OnGetUserInformationFail()
    {
    }

    private void OnGetBatchOfDriver(BatchOfDriverResponse response)
    {
        Debug.Log(response.totalItemsCount);
    }

    private void OnGetBatchOfDriverFail()
    {
        Debug.Log("Fail");
    }

    private void OnGetBatchToday(BatchTodayResponse response)
    {
        batchToday = response;
        batchDisplay.InitListOfBatchDisplay(response.items, userId);
    }

    private void OnGetBatchTodayFail()
    {
        Debug.Log("fail");
    }

    private void OnGetRegisterToBatch(RegisterToBatchResponse response)
    {
        view.ShowMessage("Message", response.message);
        // reload batch
        _apiServices.GetBatchToday();
    }

    private void OnGetRegisterToBatchFail()
    {
        view.ShowError("Error unknown", "Register fail");
    }

    private void OnGetAllBatches(AllBatchResponse response)
    {
    }

    private void OnLogin(LoginResponse response)
    {
        userId = response.userId;
        view.CloseAnPopup(PopupName.Login);
        _apiServices.GetUserInformation(userId);
        _apiServices.GetBatchToday();
    }

    private void OnGetAllBatchesError()
    {
        Debug.Log("ERROR");
    }

    private void OnLoginFail()
    {
        Debug.Log("ERROR");
    }

    public void OnClickCloseError()
    {
        view.CloseAnPopup(PopupName.Error);
    }

    public void OnClickCloseMessage()
    {
        view.CloseAnPopup(PopupName.Message);
    }

    #endregion


    private void OnEnable()
    {
        _apiServices.onGetAllBatches = OnGetAllBatches;
        _apiServices.onGetAllBatchesFail = OnGetAllBatchesError;
        // LOGIN
        _apiServices.onLogin = OnLogin;
        _apiServices.onLoginFail = OnLoginFail;
        // Register to batch
        _apiServices.onPostRegisterToBatch = OnGetRegisterToBatch;
        _apiServices.onPostRegisterToBatchFail = OnGetRegisterToBatchFail;
        // Get batch today
        _apiServices.onPostBatchToday = OnGetBatchToday;
        _apiServices.onPostBatchTodayFail = OnGetBatchTodayFail;
        // Get batch of driver
        _apiServices.onGetBatchOfDriver = OnGetBatchOfDriver;
        _apiServices.onGetBatchOfDriverFail = OnGetBatchOfDriverFail;
        // Get user infor
        _apiServices.onGetUserInformation = OnGetUserInformation;
        _apiServices.onGetUserInformationFail = OnGetUserInformationFail;
    }

    private void OnDisable()
    {
        _apiServices.onGetAllBatches = null;
        _apiServices.onLoginFail = null;
        _apiServices.onGetAllBatchesFail = null;
        _apiServices.onLogin = null;
        // Register to batch
        _apiServices.onPostRegisterToBatch = null;
        _apiServices.onPostRegisterToBatchFail = null;
        // Get batch today
        _apiServices.onPostBatchToday = null;
        _apiServices.onPostBatchTodayFail = null;
        // Get batch of driver
        _apiServices.onGetBatchOfDriver = null;
        _apiServices.onGetBatchOfDriverFail = null;
        // Get user infor
        _apiServices.onGetUserInformation = null;
        _apiServices.onGetUserInformationFail = null;
    }
}