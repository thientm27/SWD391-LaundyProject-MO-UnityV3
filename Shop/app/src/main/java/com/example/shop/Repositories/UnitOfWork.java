package com.example.shop.Repositories;


import com.example.shop.Services.AdminService;
import com.example.shop.Services.OrderDetailsService;
import com.example.shop.Services.OrderService;
import com.example.shop.Services.PaymentService;

public class UnitOfWork {
    // Repositories
    public  static AdminService getAdminService(){
        return APIClient.getClient().create(AdminService.class);
    }
    public static OrderService getOrderService() {
        return APIClient.getClient().create(OrderService.class);
    }
    public static PaymentService getPaymentService() {
        return APIClient.getClient().create(PaymentService.class);
    }
    public static OrderDetailsService getOrderDetailsService() {
        return APIClient.getClient().create(OrderDetailsService.class);
    }

}
