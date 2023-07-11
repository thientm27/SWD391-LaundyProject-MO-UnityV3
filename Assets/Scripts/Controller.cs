using System;
using BaseHttp.Core;
using LaudryAPI;
using LaundryAPI.Api;
using LaundryAPI.ResponseModels;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private APIServices _apiServices;
    [SerializeField] private View view;
    [SerializeField] private InputField loginEmail;
    [SerializeField] private InputField loginPassword;

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("GET ALL BATCH");
            _apiServices.GetAllBatch();
        }
    }

    #region Button Event

    public void OnClickLogin()
    {
        if (string.IsNullOrEmpty(loginEmail.text) || string.IsNullOrEmpty(loginPassword.text))
        {
            view.ShowError("Error", "Email or password cannot be empty");
        }
        else
        {
            _apiServices.Login(loginEmail.text, loginPassword.text);
        }
    }

    public void OnClickCloseError()
    {
        view.CloseAnPopup(PopupName.Error);
    }

    #endregion

    #region API Callback

    private void OnGetAllBatches(AllBatchResponse response)
    {
    }

    private void OnLogin(LoginResponse response)
    {
        Debug.Log("Login thanh cong");
    }

    private void OnGetAllBatchesError()
    {
        Debug.Log("ERROR");
    }

    private void OnLoginFail()
    {
        Debug.Log("ERROR");
    }

    #endregion


    private void OnEnable()
    {
        _apiServices.onGetAllBatches = OnGetAllBatches;
        _apiServices.onLogin = OnLogin;
        _apiServices.onGetAllBatchesFail = OnGetAllBatchesError;
        _apiServices.onLoginFail = OnLoginFail;
    }

    private void OnDisable()
    {
        _apiServices.onGetAllBatches = null;
        _apiServices.onLoginFail = null;
        _apiServices.onGetAllBatchesFail = null;
        _apiServices.onLogin = null;
    }
}