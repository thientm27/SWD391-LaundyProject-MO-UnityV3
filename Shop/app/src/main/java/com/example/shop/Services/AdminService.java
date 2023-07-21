package com.example.shop.Services;


import com.example.shop.dtos.Admin;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface AdminService {
    String PATH = "Admin";

    @POST(PATH+"/Login")
    Call<Admin> login(@Body Admin admin);

}
