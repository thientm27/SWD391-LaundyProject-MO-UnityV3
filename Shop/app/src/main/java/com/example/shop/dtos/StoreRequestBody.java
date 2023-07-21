package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class StoreRequestBody {
    @SerializedName("storeId")
    private List<String> storeIds;

    public StoreRequestBody(List<String> storeIds) {
        this.storeIds = storeIds;
    }
}
