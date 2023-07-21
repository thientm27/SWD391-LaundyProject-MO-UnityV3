package com.example.shop;
import static android.content.ContentValues.TAG;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.example.shop.Repositories.APIClient;
import com.example.shop.Repositories.UnitOfWork;
import com.example.shop.Services.AdminService;
import com.example.shop.databinding.ActivitySignInBinding;


import com.example.shop.dtos.Admin;
import com.google.gson.Gson;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.converter.gson.GsonConverterFactory;

public class SignInActivity extends AppCompatActivity {
    private static final String REQUIRE = "Required";

    ArrayList<Admin>  listAdmin;
    AdminService adminService;
    private ActivitySignInBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //call service
        adminService = UnitOfWork.getAdminService();
        APIClient.setContext(this);

        binding = ActivitySignInBinding.inflate(getLayoutInflater());

        setContentView(binding.getRoot());

        setListeners();
    }


    private void setListeners() {
        binding.btnLogin.setOnClickListener(view -> {
            signIn();
        });
    }

    private boolean checkInput() {
        // Username
        if (binding.etUsername.getText().toString().trim().isEmpty()) {
            showToast("Invalid Username");
            return false;
        }
        // Password
        if (binding.etPassword.getText().toString().trim().isEmpty()) {
            showToast("Invalid Password");
            return false;
        }
        // VaLid
        return true;
    }
    private void signIn() {
        Admin admin = new Admin(binding.etUsername.getText().toString().trim(),binding.etPassword.getText().toString().trim());
        if(checkInput()==false){
            return;
        }
        Call<Admin> call= adminService.login(admin);
        call.enqueue(new Callback<Admin>() {
            @Override
            public void onResponse(Call<Admin> call, Response<Admin> response) {
                if(!response.isSuccessful()){
                    return;
                } else{
                       Admin admin = response.body();
                       if(admin.getJwt()!=null){
                           // Convert the loginAccount object to a string using Gson
                           Gson gson = new Gson();
                           String LoginAdminJson = gson.toJson(admin);
                            // Save the loginAccount string to SharedPreferences
                           SharedPreferences preferences = getSharedPreferences("MyPrefs", MODE_PRIVATE);
                           SharedPreferences.Editor editor = preferences.edit();
                           editor.putString("LoginAdmin", admin.getJwt());
                           editor.apply();

                           // Add the JWT token to the headers of your Retrofit requests
                           String token = "Bearer " + admin.getJwt();
                           APIClient.addAuthorizationHeader(token);
                           Intent intent = new Intent(SignInActivity.this,MainActivity.class);
                           startActivity(intent);
                       }
                }
            }

            @Override
            public void onFailure(Call<Admin> call, Throwable t) {
                String errorMessage = "Load fail: " + t.getMessage();
                Toast.makeText(SignInActivity.this, errorMessage, Toast.LENGTH_LONG).show();
                Log.e("API Error", errorMessage);
            }
        });
    }

    private void showToast(String message) {
        Toast.makeText(getApplicationContext(), message, Toast.LENGTH_SHORT).show();
    }

}