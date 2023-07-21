package com.example.shop.Repositories;




import android.content.Context;
import android.content.SharedPreferences;

import okhttp3.OkHttpClient;
import okhttp3.Request;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class APIClient {
    private static Retrofit retrofit;
    private static Context context; // Add a static variable for the Context

    // Set the context from SignInActivity
    public static void setContext(Context context) {
        APIClient.context = context.getApplicationContext();
    }

    private static String deployUrl ="https://flaundry.somee.com/api/v1/";

    public  static Retrofit getClient(){
        if(retrofit== null) {
            retrofit = new Retrofit.Builder().baseUrl(deployUrl)
                    .addConverterFactory(GsonConverterFactory.create()).build();
        }
        return retrofit;
    }

    private static OkHttpClient getOkHttpClient() {
        return new OkHttpClient.Builder()
                .addInterceptor(chain -> {
                    // Retrieve the JWT token from SharedPreferences
                    SharedPreferences preferences = context.getSharedPreferences("MyPrefs", Context.MODE_PRIVATE);
                    String token = preferences.getString("LoginAdmin", null);

                    // Add the Authorization header with the JWT token to the request
                    if (token != null) {
                        Request original = chain.request();
                        Request.Builder requestBuilder = original.newBuilder()
                                .header("Authorization", token);
                        Request request = requestBuilder.build();
                        return chain.proceed(request);
                    }
                    return chain.proceed(chain.request());
                })
                .build();
    }

    public static void addAuthorizationHeader(String token) {
        OkHttpClient okHttpClient = getOkHttpClient();
        OkHttpClient.Builder builder = okHttpClient.newBuilder()
                .addInterceptor(chain -> {
                    Request original = chain.request();
                    Request.Builder requestBuilder = original.newBuilder()
                            .header("Authorization", token);
                    Request request = requestBuilder.build();
                    return chain.proceed(request);
                });
        retrofit = retrofit.newBuilder().client(builder.build()).build();
    }
}
