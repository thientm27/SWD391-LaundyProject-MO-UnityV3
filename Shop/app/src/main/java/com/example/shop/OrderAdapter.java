package com.example.shop;

import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.recyclerview.widget.RecyclerView;

import com.example.shop.Repositories.UnitOfWork;
import com.example.shop.Services.OrderDetailsService;
import com.example.shop.Services.OrderService;
import com.example.shop.Services.PaymentService;
import com.example.shop.dtos.Customer;
import com.example.shop.dtos.ObjectFinish;
import com.example.shop.dtos.Order;
import com.example.shop.dtos.OrderDetails;
import com.example.shop.dtos.OrderDetailsS;
import com.example.shop.dtos.OrderResponse;
import com.example.shop.dtos.Payment;
import com.example.shop.dtos.PaymentSet;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class OrderAdapter extends RecyclerView.Adapter<OrderAdapter.OrderViewHolder> {

    private Context context;
    OrderService orderService;
    PaymentService paymentService;
    OrderDetailsService orderDetailsService;

    Order order;
    Payment pay;

    public List<Order> orderList;
    public List<Payment> payments;
    public List<OrderDetails> orderDetails;
    OrderDetails orderS;
    private PaymentSet paymentSet;
    private OrderDetailsS orderSet;

    public OrderAdapter(List<Order> orderList, Context context) {
        this.context = context;
        this.orderList = orderList;
    }

    @NonNull
    @Override
    public OrderViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_order, parent, false);
        return new OrderViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(@NonNull OrderViewHolder holder, int position) {
        order = orderList.get(position);
        payments = order.getPayments();
        Customer customer = order.getCustomer();
        orderDetails=order.getOrderDetails();
        holder.setPayments(payments);
        holder.setOrderDetails(orderDetails);
        holder.setOrderList(orderList);
        // Bind data to the views
        holder.txtAmount.setText("Amount: " + getOrderTotalAmount(payments)/payments.size());
        holder.txtStatus.setText("Status: " + order.getStatus());
        holder.txtNote.setText("Note: " + order.getNote());
        // Replace "customerName" with the actual field name in your Order class representing the customer name
        holder.txtCustomerName.setText("Customer Name: " + customer.getFullName());
        holder.txtKg.setText("Kg: " + getOrderTotalWeight(orderDetails));
        holder.btnSubMit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                order=holder.getOrderList().get(position);
                orderService = UnitOfWork.getOrderService();
                Call<ObjectFinish> call = orderService.finishOrder(order.getOrderId());
                call.enqueue(new Callback<ObjectFinish>() {
                    @Override
                    public void onResponse(Call<ObjectFinish> call, Response<ObjectFinish> response) {
                        ((MainActivity) context).getOrder();
                    }

                    @Override
                    public void onFailure(Call<ObjectFinish> call, Throwable t) {
                        // Handle API call failure here
                        Log.e("OrderService", "Error: " + t.getMessage());
                    }
                });

            }
        });

        holder.btnAddPrice.setOnClickListener(new View.OnClickListener() {
            private EditText editPrice;
            private AlertDialog alertDialog;


            @Override
            public void onClick(View view) {
                AlertDialog.Builder builder = new AlertDialog.Builder(context);
                alertDialog = builder
                        .setView(R.layout.dialog_add_price)
                        .setNegativeButton("No", null)
                        .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialogInterface, int i) {
                                Double price;
                                try {
                                    editPrice = alertDialog.findViewById(R.id.editPrice);
                                    price = Double.parseDouble(editPrice.getText().toString());
                                } catch (Exception e) {

                                    return;
                                }
                                payments = holder.getPayments();
                                for (Payment pay : payments) {
                                    pay.setAmount(price);
                                }
                                order.setPayments(payments);
                                for (Payment pay : payments) {
                                    String id = pay.getOrderId();
                                    paymentSet = new PaymentSet(id, pay.getAmount(), pay.getPaymentMethod(), pay.getStatus());
                                    paymentService = UnitOfWork.getPaymentService();
                                    Call<Void> call = paymentService.updatePayment(pay.getPaymentId(), paymentSet);
                                    call.enqueue(new Callback<Void>() {
                                        @Override
                                        public void onResponse(Call<Void> call, Response<Void> response) {
                                            ((MainActivity) context).getOrder();
                                        }

                                        @Override
                                        public void onFailure(Call<Void> call, Throwable t) {
                                            // Handle API call failure here
                                            Log.e("OrderService", "Error: " + t.getMessage());
                                        }
                                    });
                                }
                            }
                        }).create();
                alertDialog.show();
            }
        });
        holder.btnAddKG.setOnClickListener(new View.OnClickListener() {
            private EditText editKg;
            private AlertDialog alertDialog;
            private EditText editId;


            @Override
            public void onClick(View view) {
                AlertDialog.Builder builder = new AlertDialog.Builder(context);
                alertDialog = builder
                        .setView(R.layout.dialog_add_kg)
                        .setNegativeButton("No", null)
                        .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialogInterface, int i) {
                                Double kg;
                                String id;
                                try {
                                    editId=alertDialog.findViewById(R.id.editId);
                                    editKg = alertDialog.findViewById(R.id.editKg);
                                    id=editId.getText().toString();
                                    kg = Double.parseDouble(editKg.getText().toString());
                                } catch (Exception e) {

                                    return;
                                }
                                orderDetails = holder.getOrderDetails();
                                for (OrderDetails o : orderDetails) {
                                    o.setWeight(kg);
                                }
                                order.setOrderDetails(orderDetails);
                                for (OrderDetails o : orderDetails) {
                                    String idAll=o.getOrderDetailId();
                                    String status=o.getStatus();
                                    orderSet = new OrderDetailsS(idAll,o.getWeight(),status);
                                    orderDetailsService = UnitOfWork.getOrderDetailsService();
                                    Call<Void> call = orderDetailsService.updateKg(o.getOrderDetailId(),orderSet);
                                    call.enqueue(new Callback<Void>() {
                                        @Override
                                        public void onResponse(Call<Void> call, Response<Void> response) {
                                            ((MainActivity) context).getOrder();
                                        }

                                        @Override
                                        public void onFailure(Call<Void> call, Throwable t) {
                                            // Handle API call failure here
                                            Log.e("OrderService", "Error: " + t.getMessage());
                                        }
                                    });
                                }
                            }
                        }).create();
                alertDialog.show();
            }
        });
    }

    @Override
    public int getItemCount() {
        return orderList.size();
    }

    public static class OrderViewHolder extends RecyclerView.ViewHolder {
        TextView txtAmount;
        TextView txtStatus;
        TextView txtNote;
        TextView txtCustomerName;

        Button btnSubMit;

        Button btnAddPrice;

        List<Payment> payments;
        TextView txtKg;
        Button btnAddKG;
        List<OrderDetails> orderDetails;

        List<Order> orderList;

        public OrderViewHolder(@NonNull View itemView) {
            super(itemView);
            txtAmount = itemView.findViewById(R.id.txtAmount);
            txtStatus = itemView.findViewById(R.id.txtStatus);
            txtNote = itemView.findViewById(R.id.txtNote);
            txtCustomerName = itemView.findViewById(R.id.txtCustomerName);
            btnSubMit = itemView.findViewById(R.id.btnSubmit);
            btnAddPrice = itemView.findViewById(R.id.btnAddPrice);
            txtKg=itemView.findViewById(R.id.txtKg);
            btnAddKG=itemView.findViewById(R.id.btnAddKG);
        }

        public List<Payment> getPayments() {
            return payments;
        }

        public void setPayments(List<Payment> payments) {
            this.payments = payments;
        }

        public List<OrderDetails> getOrderDetails() {
            return orderDetails;
        }

        public void setOrderDetails(List<OrderDetails> orderDetails) {
            this.orderDetails = orderDetails;
        }

        public List<Order> getOrderList() {
            return orderList;
        }

        public void setOrderList(List<Order> orderList) {
            this.orderList = orderList;
        }
    }

    private double getOrderTotalAmount(List<Payment> payments) {
        int totalAmount = 0;
        for (Payment payment : payments) {
            totalAmount += payment.getAmount();
        }
        return totalAmount;
    }
    private double getOrderTotalWeight(List<OrderDetails> orderDetails) {
        int totalWeight = 0;
        for (OrderDetails orderD : orderDetails) {
            totalWeight += orderD.getWeight();
        }
        return totalWeight;
    }

}
