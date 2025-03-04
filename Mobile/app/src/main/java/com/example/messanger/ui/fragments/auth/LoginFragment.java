package com.example.messanger.ui.fragments.auth;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;

import android.text.Editable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.messanger.MainActivity;
import com.example.messanger.R;
import com.example.messanger.api.Client;
import com.example.messanger.api.RestApiMethods;
import com.example.messanger.data.Data;
import com.example.messanger.databinding.FragmentLoginBinding;
import com.example.messanger.dto.LoginRequest;
import com.example.messanger.dto.TokenResponse;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginFragment extends Fragment {

    private FragmentLoginBinding binding;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentLoginBinding.inflate(inflater, container, false);
        View root = binding.getRoot();

        binding.buttonLogin.setOnClickListener(v -> {
            Editable enterLogin = binding.enterLogin.getText();
            Editable enterPass = binding.enterPassword.getText();
            if (enterLogin.length() > 0 && enterPass.length() > 0){
                RestApiMethods apiMethods = Client.getClient().create(RestApiMethods.class);
                LoginRequest request = new LoginRequest(enterLogin.toString(), enterPass.toString());
                Call<TokenResponse> call = apiMethods.login(request);
                call.enqueue(new Callback<>() {
                    @Override
                    public void onResponse(Call<TokenResponse> call, Response<TokenResponse> response) {
                        if (response.isSuccessful()) {
                            Data.saveData("token", response.body().getToken());
                            MainActivity.setLogin(true);
                            MainActivity activity = (MainActivity) getActivity();
                            activity.findViewById(R.id.nav_view).setVisibility(View.VISIBLE);
                            NavController navController = Navigation.findNavController(requireActivity(), R.id.nav_host_fragment_activity_main);
                            navController.navigate(R.id.navigation_chats);
                        }
                    }

                    @Override
                    public void onFailure(Call<TokenResponse> call, Throwable throwable) {
                        binding.textView5.setText(R.string.login_failed);
                        binding.textView5.setVisibility(View.VISIBLE);
                    }
                });

            } else {
                binding.textView5.setText(R.string.noEnter);
                binding.textView5.setVisibility(View.VISIBLE);
            }

        });

        ((AppCompatActivity)getActivity()).getSupportActionBar().setDisplayHomeAsUpEnabled(false);
        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}