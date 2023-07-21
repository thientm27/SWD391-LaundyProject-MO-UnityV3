package com.example.shop.dtos;

import java.io.IOException;

import okhttp3.Interceptor;
import okhttp3.Request;
import okhttp3.Response;

public class Admin  {

    private String email;
    private String password;
    private String jwt;
    private String refreshToken;

    public Admin() {
        super();
    }

    public Admin(String email, String password) {
        this.email = email;
        this.password = password;
    }

    public Admin(String email, String password, String jwt, String refreshToken) {
        this.email = email;
        this.password = password;
        this.jwt = jwt;
        this.refreshToken = refreshToken;
    }

    public String getUsername() {
        return email;
    }

    public void setUsername(String username) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getJwt() {
        return jwt;
    }

    public void setJwt(String jwt) {
        this.jwt = jwt;
    }

    public String getRefreshToken() {
        return refreshToken;
    }

    public void setRefreshToken(String refreshToken) {
        this.refreshToken = refreshToken;
    }

}
