package com.example.messanger.dto;

public class UserResponse {
    private final String id;
    private final String name;

    public UserResponse(String id, String name) {
        this.id = id;
        this.name = name;
    }

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }
}
