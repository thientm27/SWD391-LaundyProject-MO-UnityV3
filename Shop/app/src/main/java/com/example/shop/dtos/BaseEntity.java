package com.example.shop.dtos;

import java.io.Serializable;

public class BaseEntity implements Serializable {


    private int id;

    public BaseEntity() {
    }

    public BaseEntity(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}
