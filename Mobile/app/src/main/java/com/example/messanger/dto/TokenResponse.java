package com.example.messanger.dto;

public class TokenResponse {
    private final String token;

    public String getToken() {
        return token;
    }

    public TokenResponse(String token) {
        this.token = token;
    }
}
