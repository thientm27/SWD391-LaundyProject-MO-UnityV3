package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

public class ObjectFinish {
    @SerializedName("message")
    private String message;

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public ObjectFinish(String message) {
        this.message = message;
    }
}
