package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class OrderResponse {
    @SerializedName("totalItemsCount")
    private int totalItemsCount;

    @SerializedName("pageSize")
    private int pageSize;

    @SerializedName("totalPagesCount")
    private int totalPagesCount;

    @SerializedName("pageIndex")
    private int pageIndex;

    @SerializedName("next")
    private boolean next;

    @SerializedName("previous")
    private boolean previous;

    @SerializedName("items")
    private List<Order> items;

    public OrderResponse(int totalItemsCount, int pageSize, int totalPagesCount, int pageIndex, boolean next, boolean previous, List<Order> items) {
        this.totalItemsCount = totalItemsCount;
        this.pageSize = pageSize;
        this.totalPagesCount = totalPagesCount;
        this.pageIndex = pageIndex;
        this.next = next;
        this.previous = previous;
        this.items = items;
    }

    public int getTotalItemsCount() {
        return totalItemsCount;
    }

    public void setTotalItemsCount(int totalItemsCount) {
        this.totalItemsCount = totalItemsCount;
    }

    public int getPageSize() {
        return pageSize;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }

    public int getTotalPagesCount() {
        return totalPagesCount;
    }

    public void setTotalPagesCount(int totalPagesCount) {
        this.totalPagesCount = totalPagesCount;
    }

    public int getPageIndex() {
        return pageIndex;
    }

    public void setPageIndex(int pageIndex) {
        this.pageIndex = pageIndex;
    }

    public boolean isNext() {
        return next;
    }

    public void setNext(boolean next) {
        this.next = next;
    }

    public boolean isPrevious() {
        return previous;
    }

    public void setPrevious(boolean previous) {
        this.previous = previous;
    }

    public List<Order> getItems() {
        return items;
    }

    public void setItems(List<Order> items) {
        this.items = items;
    }
}
