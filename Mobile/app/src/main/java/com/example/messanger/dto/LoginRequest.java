package com.example.messanger.dto;

public class LoginRequest {
    private final String login;
    private final String password;

    public String getLogin() {
        return login;
    }

    public String getPassword() {
        return password;
    }

    public LoginRequest(String login, String password) {
        this.login = login;
        this.password = password;
    }
}
