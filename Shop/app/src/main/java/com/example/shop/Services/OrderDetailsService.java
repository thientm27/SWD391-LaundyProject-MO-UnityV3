package com.example.shop.Services;

import com.example.shop.dtos.OrderDetailsS;
import com.example.shop.dtos.PaymentSet;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.PUT;
import retrofit2.http.Path;

public interface OrderDetailsService {
    String PATH = "OrderDetail";

    @PUT(PATH+"/Update/{id}")
    Call<Void> updateKg(@Path("id") Object id, @Body OrderDetailsS orderS);

}
