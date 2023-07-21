package com.example.shop.dtos;

import com.google.gson.annotations.SerializedName;

public class Building {
    @SerializedName("buildingId")
    private String buildingId;

    @SerializedName("name")
    private String name;

    @SerializedName("address")
    private String address;
    public Building(String buildingId, String name, String address) {
        this.buildingId = buildingId;
        this.name = name;
        this.address = address;
    }

    public String getBuildingId() {
        return buildingId;
    }

    public void setBuildingId(String buildingId) {
        this.buildingId = buildingId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }
}
