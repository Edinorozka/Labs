package com.example.messanger.ui.fragments.auth;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.viewpager2.adapter.FragmentStateAdapter;

public class AuthAdapter extends FragmentStateAdapter {
    public AuthAdapter(@NonNull Fragment fragment) {
        super(fragment);
    }

    @NonNull
    @Override
    public Fragment createFragment(int position) {
        if (position == 0)
            return new LoginFragment();
        else
            return new RegFragment();
    }

    @Override
    public int getItemCount() {
        return 2;
    }
}
