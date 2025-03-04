package com.example.messanger.dto;

public class ReqRequest {
    private String login;
    private String name;
    private String password;

    public ReqRequest(String login, String name, String password) {
        this.login = login;
        this.name = name;
        this.password = password;
    }

    public String getLogin() {
        return login;
    }

    public String getName() {
        return name;
    }

    public String getPassword() {
        return password;
    }
}
