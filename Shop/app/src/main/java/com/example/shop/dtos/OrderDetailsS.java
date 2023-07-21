package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

public class OrderDetailsS {
    @SerializedName("orderDetailId")
    private String orderDetailId;
    @SerializedName("weight")
    private double weight;
    @SerializedName("status")
    private String status;

    public OrderDetailsS(String orderDetailId, double weight, String status) {
        this.orderDetailId = orderDetailId;
        this.weight = weight;
        this.status = status;
    }

    public String getOrderDetailId() {
        return orderDetailId;
    }

    public void setOrderDetailId(String orderDetailId) {
        this.orderDetailId = orderDetailId;
    }

    public double getWeight() {
        return weight;
    }

    public void setWeight(double weight) {
        this.weight = weight;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
