package com.example.messanger.ui.fragments.auth;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.navigation.NavController;
import androidx.navigation.NavOptions;
import androidx.navigation.Navigation;

import android.text.Editable;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;

import com.example.messanger.MainActivity;
import com.example.messanger.R;
import com.example.messanger.api.Client;
import com.example.messanger.api.RestApiMethods;
import com.example.messanger.data.Data;
import com.example.messanger.databinding.FragmentLoginBinding;
import com.example.messanger.databinding.FragmentRegBinding;
import com.example.messanger.dto.ReqRequest;
import com.example.messanger.dto.TokenResponse;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class RegFragment extends Fragment {
    private FragmentRegBinding binding;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentRegBinding.inflate(inflater, container, false);

        binding.regButton.setOnClickListener(v -> {
            Editable enterLogin = binding.editLogin.getText();
            Editable enterName = binding.editName.getText();
            Editable enterPass = binding.editPassword.getText();
            if (enterLogin.length() > 0 && enterPass.length() > 0 && enterName.length() > 0){
                RestApiMethods apiMethods = Client.getClient().create(RestApiMethods.class);
                ReqRequest request = new ReqRequest(enterLogin.toString(), enterName.toString(), enterPass.toString());
                Call<TokenResponse> call = apiMethods.req(request);
                call.enqueue(new Callback<>() {
                    @Override
                    public void onResponse(Call<TokenResponse> call, Response<TokenResponse> response) {
                        Data.saveData("token", response.body().getToken());
                        MainActivity.setLogin(true);
                        MainActivity activity = (MainActivity) getActivity();
                        activity.findViewById(R.id.nav_view).setVisibility(View.VISIBLE);
                        NavController navController = Navigation.findNavController(requireActivity(), R.id.nav_host_fragment_activity_main);
                        navController.navigate(R.id.navigation_chats);
                    }

                    @Override
                    public void onFailure(Call<TokenResponse> call, Throwable throwable) {
                        binding.textView7.setText(R.string.login_failed);
                        binding.textView7.setVisibility(View.VISIBLE);
                    }
                });
            } else {
                binding.textView7.setText(R.string.noEnter);
                binding.textView7.setVisibility(View.VISIBLE);
            }
        });

        View root = binding.getRoot();
        return root;
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }
}