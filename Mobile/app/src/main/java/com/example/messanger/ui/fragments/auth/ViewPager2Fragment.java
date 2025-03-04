package com.example.messanger.ui.fragments.auth;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.messanger.R;
import com.example.messanger.databinding.FragmentViewPager2Binding;
import com.google.android.material.tabs.TabLayoutMediator;

public class ViewPager2Fragment extends Fragment {

    private FragmentViewPager2Binding binding;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentViewPager2Binding.inflate(inflater, container, false);
        View root = binding.getRoot();

        binding.logRegViewPager.setAdapter(new AuthAdapter(this));
        binding.logRegViewPager.setCurrentItem(0);

        new TabLayoutMediator(binding.tabLayout,
                binding.logRegViewPager,
                ((tab, position) -> {
                    switch (position){
                        case 0:
                            tab.setText(R.string.loginTitle);
                            break;
                        case 1:
                            tab.setText(R.string.reqTitle);
                    }
                })).attach();

        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}