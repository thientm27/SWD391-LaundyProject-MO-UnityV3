package com.example.shop.dtos;

import java.util.List;

public class Order {
    private String orderId;
    private Building building;
    private Store store;
    private String note;
    private String status;
    private int numberOfPackage;

    private Customer customer;
    private List<OrderDetails> orderDetails;
    private List<Payment> payments;

    public Order(String orderId, Building building, Store store, String note, String status, int numberOfPackage, Customer customer, List<OrderDetails> orderDetails, List<Payment> payments) {
        this.orderId = orderId;
        this.building = building;
        this.store = store;
        this.note = note;
        this.status = status;
        this.numberOfPackage = numberOfPackage;
        this.customer = customer;
        this.orderDetails = orderDetails;
        this.payments = payments;
    }

    public List<OrderDetails> getOrderDetails() {
        return orderDetails;
    }

    public void setOrderDetails(List<OrderDetails> orderDetails) {
        this.orderDetails = orderDetails;
    }

    public Customer getCustomer() {
        return customer;
    }

    public void setCustomer(Customer customer) {
        this.customer = customer;
    }

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public Building getBuilding() {
        return building;
    }

    public void setBuilding(Building building) {
        this.building = building;
    }

    public Store getStore() {
        return store;
    }

    public void setStore(Store store) {
        this.store = store;
    }

    public String getNote() {
        return note;
    }

    public void setNote(String note) {
        this.note = note;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public int getNumberOfPackage() {
        return numberOfPackage;
    }

    public void setNumberOfPackage(int numberOfPackage) {
        this.numberOfPackage = numberOfPackage;
    }

    public List<Payment> getPayments() {
        return payments;
    }

    public void setPayments(List<Payment> payments) {
        this.payments = payments;
    }
}
