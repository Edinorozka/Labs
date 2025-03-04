package com.example.messanger.data;

import android.content.Context;
import android.content.SharedPreferences;

import androidx.security.crypto.EncryptedSharedPreferences;
import androidx.security.crypto.MasterKey;

import java.io.IOException;
import java.security.GeneralSecurityException;

public class Data {
    private static final String PREFS_FILENAME = "encrypted_prefs";

    private static EncryptedSharedPreferences preferences;

    public static EncryptedSharedPreferences getPreferences() {
        return preferences;
    }

    public static void getEncryptedSharedPreferences(Context context){
        try {
            preferences = (EncryptedSharedPreferences) EncryptedSharedPreferences.create(
                    context,
                    PREFS_FILENAME,
                    new MasterKey.Builder(context).setKeyScheme(MasterKey.KeyScheme.AES256_GCM).build(),
                    EncryptedSharedPreferences.PrefKeyEncryptionScheme.AES256_SIV,
                    EncryptedSharedPreferences.PrefValueEncryptionScheme.AES256_GCM);
        } catch (GeneralSecurityException | IOException e) {
            throw new RuntimeException(e);
        }
    }

    public static void saveData(String key, String value){
        SharedPreferences.Editor editor = preferences.edit();
        editor.putString(key, value);
        editor.apply();
    }

    public static String getData(String key){
        return preferences.getString(key, null);
    }
}
