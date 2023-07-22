package com.example.shop.Services;

import com.example.shop.dtos.ObjectFinish;
import com.example.shop.dtos.Order;
import com.example.shop.dtos.OrderResponse;
import com.example.shop.dtos.Store;
import com.example.shop.dtos.StoreRequestBody;

import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface OrderService {
    String PATH = "Order";

    @POST(PATH+"/GetListWithFilter/0/10")
    Call<OrderResponse> getOrdersByStoreId(@Body StoreRequestBody store);
    @GET(PATH+"/FinishOrder/{entityId}")
    Call<ObjectFinish> finishOrder(@Path("entityId") Object entityId);
}
