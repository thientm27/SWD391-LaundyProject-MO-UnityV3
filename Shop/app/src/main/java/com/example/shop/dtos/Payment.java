package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

public class Payment {
    @SerializedName("paymentId")
    private String paymentId;

    @SerializedName("orderId")
    private String orderId;

    @SerializedName("amount")
    private Double amount;

    @SerializedName("paymentMethod")
    private String paymentMethod;

    @SerializedName("status")
    private String status;

    public Payment(String paymentId, String orderId, double amount, String paymentMethod, String status) {
        this.paymentId = paymentId;
        this.orderId = orderId;
        this.amount = amount;
        this.paymentMethod = paymentMethod;
        this.status = status;
    }


    public String getPaymentId() {
        return paymentId;
    }

    public void setPaymentId(String paymentId) {
        this.paymentId = paymentId;
    }

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public double getAmount() {
        return amount;
    }

    public void setAmount(double amount) {
        this.amount = amount;
    }

    public String getPaymentMethod() {
        return paymentMethod;
    }

    public void setPaymentMethod(String paymentMethod) {
        this.paymentMethod = paymentMethod;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
