package com.example.shop.Services;

import com.example.shop.dtos.PaymentSet;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface PaymentService {
    String PATH = "Payment";

    @PUT(PATH+"/Update/{id}")
    Call<Void> updatePayment(@Path("id") Object id,@Body PaymentSet paymentSet);
    @POST(PATH+"/Add")
    Call<Void> addPayment(@Body PaymentSet paymentSet);
}
