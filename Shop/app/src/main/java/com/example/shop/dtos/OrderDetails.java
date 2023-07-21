package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

public class OrderDetails {
    @SerializedName("orderDetailId")
    private String orderDetailId;
    @SerializedName("serviceId")
    private String serviceId;
    @SerializedName("weight")
    private double weight;
    @SerializedName("status")
    private String status;

    public OrderDetails(String orderDetailId, String serviceId, double weight, String status) {
        this.orderDetailId = orderDetailId;
        this.serviceId = serviceId;
        this.weight = weight;
        this.status = status;
    }

    public String getOrderDetailId() {
        return orderDetailId;
    }

    public void setOrderDetailId(String orderDetailId) {
        this.orderDetailId = orderDetailId;
    }

    public String getServiceId() {
        return serviceId;
    }

    public void setServiceId(String serviceId) {
        this.serviceId = serviceId;
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
