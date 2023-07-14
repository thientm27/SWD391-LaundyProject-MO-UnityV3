using System;
using System.Text.RegularExpressions;
using LaudryAPI;
using LaundryAPI.ResponseModels;
using TMPro;
using UnityEngine;


public class Controller : MonoBehaviour
{
    private APIServices _apiServices;
    [SerializeField] private View view;
    [SerializeField] private TMP_InputField loginEmail;
    [SerializeField] private TMP_InputField loginPassword;

    private void Awake()
    {
        _apiServices = new APIServices();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Debug.Log("Test API");
            _apiServices.GetBatchToday();
            // _apiServices.RegisterToBatch("c1a1dea7-0b3b-4470-bcc1-2aa7470a6f45");
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
    private void OnGetBatchToday(BatchTodayResponse response)
    {
        Debug.Log(response.totalItemsCount);
    }
    private void OnGetBatchTodayFail()
    {
        Debug.Log("fail");
    }

    private void OnGetRegisterToBatch(RegisterToBatchResponse response)
    {
        Debug.Log(response.message);
    }
    private void OnGetRegisterToBatchFail()
    {
        Debug.Log("fail");
    }

    private void OnGetAllBatches(AllBatchResponse response)
    {
    }

    private void OnLogin(LoginResponse response)
    {
        view.ShowMessage("Login successfully", "Welcome " + response.userId);
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
        _apiServices.onLogin = OnLogin;
        _apiServices.onGetAllBatchesFail = OnGetAllBatchesError;
        _apiServices.onLoginFail = OnLoginFail;
        _apiServices.onPostRegisterToBatch = OnGetRegisterToBatch;
        _apiServices.onPostRegisterToBatchFail = OnGetRegisterToBatchFail;
        _apiServices.onPostBatchToday = OnGetBatchToday;
        _apiServices.onPostBatchTodayFail = OnGetBatchTodayFail;
    }

    private void OnDisable()
    {
        _apiServices.onGetAllBatches = null;
        _apiServices.onLoginFail = null;
        _apiServices.onGetAllBatchesFail = null;
        _apiServices.onLogin = null;
        _apiServices.onPostRegisterToBatch = null;
        _apiServices.onPostRegisterToBatchFail = null;
        _apiServices.onPostBatchToday = null;
        _apiServices.onPostBatchTodayFail = null;
    }
}