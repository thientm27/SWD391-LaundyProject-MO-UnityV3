package com.example.shop;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Context;
import android.os.Bundle;
import android.util.Log;

import com.example.shop.Repositories.UnitOfWork;
import com.example.shop.Services.OrderService;
import com.example.shop.dtos.Order;
import com.example.shop.dtos.OrderResponse;
import com.example.shop.dtos.Payment;
import com.example.shop.dtos.Store;
import com.example.shop.dtos.StoreRequestBody;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {
    private RecyclerView recyclerView;

    List<Order> listOrder=new ArrayList<>();

    OrderAdapter orderAdapter;

    OrderService orderService;
    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        recyclerView = findViewById(R.id.recyclerView);
        orderService= UnitOfWork.getOrderService();
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
        getOrder();

         // Replace this with the actual list of orders
        // Initialize the adapter and set it to the RecyclerView

    }

    public void getOrder() {
        List<String> storeIds = Arrays.asList("42520508-68ce-4d3a-b8e6-273a6fdf4077");
        StoreRequestBody requestBody = new StoreRequestBody(storeIds);

        // Call the API to get the list of orders

        Call<OrderResponse> call = orderService.getOrdersByStoreId(requestBody);
        Context context = this;
        call.enqueue(new Callback<OrderResponse>() {
            @Override
            public void onResponse(Call<OrderResponse> call, Response<OrderResponse> response) {
                if (response.isSuccessful()) {
                    OrderResponse order = response.body();
                    if (order != null && order.getItems()!=null) {
                        // Process the list of orders here
                        listOrder = order.getItems();
                        orderAdapter = new OrderAdapter(listOrder,context);
                        recyclerView.setAdapter(orderAdapter);
                        orderAdapter.notifyDataSetChanged();
                    } else {
                        // Handle the case when the response body is null
                    }
                } else {
                    // Handle the case when the API call was not successful
                    Log.e("OrderService", "Error: " + response.message());
                }
            }

            @Override
            public void onFailure(Call<OrderResponse> call, Throwable t) {
                // Handle API call failure here
                Log.e("OrderService", "Error: " + t.getMessage());
            }
        });
    }


}