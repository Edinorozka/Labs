package com.example.messanger.ui.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.messanger.MainActivity;
import com.example.messanger.R;
import com.example.messanger.api.Client;
import com.example.messanger.api.RestApiMethods;
import com.example.messanger.data.Data;
import com.example.messanger.databinding.FragmentSettingsBinding;
import com.example.messanger.dto.TokenResponse;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SettingsFragment extends Fragment {
    private FragmentSettingsBinding binding;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        binding = FragmentSettingsBinding.inflate(inflater, container, false);
        View root = binding.getRoot();

        binding.UserNameView.setText(Data.getData("token"));

        binding.logoutButton.setOnClickListener(v -> {
            RestApiMethods apiMethods = Client.getClient().create(RestApiMethods.class);
            Call<Void> call = apiMethods.logout();
            call.enqueue(new Callback<Void>() {
                @Override
                public void onResponse(Call<Void> call, Response<Void> response) {
                    MainActivity.setLogin(false);
                    NavController navController = Navigation.findNavController(requireActivity(), R.id.nav_host_fragment_activity_main);
                    navController.navigate(R.id.viewPager2Fragment);
                }

                @Override
                public void onFailure(Call<Void> call, Throwable throwable) {

                }
            });

        });

        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}