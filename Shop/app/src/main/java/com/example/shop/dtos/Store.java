package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Store {
    @SerializedName("storeId")
    private String storeId;
    @SerializedName("storeName")
    private String storeName;
    @SerializedName("storeAddress")
    private String storeAddress;

    public Store(String storeId, String storeName, String storeAddress) {
        this.storeId = storeId;
        this.storeName = storeName;
        this.storeAddress = storeAddress;
    }

    public String getStoreId() {
        return storeId;
    }

    public void setStoreId(String storeId) {
        this.storeId = storeId;
    }

    public String getStoreName() {
        return storeName;
    }

    public void setStoreName(String storeName) {
        this.storeName = storeName;
    }

    public String getStoreAddress() {
        return storeAddress;
    }

    public void setStoreAddress(String storeAddress) {
        this.storeAddress = storeAddress;
    }
}
