package com.example.messanger.api;

import com.example.messanger.dto.LoginRequest;
import com.example.messanger.dto.ReqRequest;
import com.example.messanger.dto.TokenResponse;
import com.example.messanger.dto.UserResponse;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.POST;

public interface RestApiMethods {
    @POST("/auth/login")
    Call<TokenResponse> login(@Body LoginRequest request);

    @POST("/auth/logout")
    Call<Void> logout();

    @POST("/auth/register")
    Call<TokenResponse> req(@Body ReqRequest request);

    @GET("/users/user")
    Call<UserResponse> getUser(@Body String userId);
}
