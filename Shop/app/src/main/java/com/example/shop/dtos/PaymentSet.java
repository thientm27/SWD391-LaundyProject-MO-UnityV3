package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

public class PaymentSet {
    @SerializedName("orderId")
    private String orderId;

    @SerializedName("amount")
    private double amount;

    @SerializedName("paymentMethod")
    private String paymentMethod;

    @SerializedName("status")
    private String status;

    public PaymentSet(String orderId, double amount, String paymentMethod, String status) {
        this.orderId = orderId;
        this.amount = amount;
        this.paymentMethod = paymentMethod;
        this.status = status;
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
