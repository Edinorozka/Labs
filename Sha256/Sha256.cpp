#include <iostream>
#include <string>
#include <bitset>
#include <vector>
#include <algorithm>
#include <iterator>

#include <cstdlib>
#include <ctime>

using namespace std;

const int N = 256;

uint32_t h0 = 0x6a09e667;
uint32_t h1 = 0xbb67ae85;
uint32_t h2 = 0x3c6ef372;
uint32_t h3 = 0xa54ff53a;
uint32_t h4 = 0x510e527f;
uint32_t h5 = 0x9b05688c;
uint32_t h6 = 0x1f83d9ab;
uint32_t h7 = 0x5be0cd19;

const uint32_t ks[] = {
        0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5, 0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
        0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3, 0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
        0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc, 0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
        0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7, 0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
        0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13, 0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
        0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3, 0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
        0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5, 0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
        0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208, 0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
};

uint32_t rightrotate(uint32_t value, unsigned int count) {
    return (value >> count) | (value << (32 - count));
}

uint32_t rightshift(uint32_t value, unsigned int count) {
    return value >> count;
}

void sha256(uint32_t* result, string text) {
    int index = 1;
    vector<bitset<8>> textBins;
    for (char ch : text) {
        textBins.push_back(bitset<8>(ch));
    }
    int size = textBins.size();

    while ((textBins.size() * 8 + 8) % 512 != 0) {
        textBins.push_back(bitset<8>(0));
    }
    textBins.push_back(bitset<8>(size));

    for (int i = 0; i < textBins.size(); i++)
    {
        cout << textBins[i] << " ";
        if (index == 8) {
            index = 1;
            cout << endl;
        }
        else {
            index++;
        }
    }
    cout << endl;

    vector<bitset<32>> text32Bins;
    for (size_t i = 0; i < textBins.size(); i += 4) {
        bitset<32> combined;

        combined = textBins[i].to_ulong() << 24 |
            textBins[i + 1].to_ulong() << 16 |
            textBins[i + 2].to_ulong() << 8 |
            textBins[i + 3].to_ulong();

        text32Bins.push_back(combined);
    }

    for (int i = 0; i < 48; i++)
    {
        text32Bins.push_back(bitset<32>(0));
    }

    // для изменнеия нулевых индексов
    vector<uint32_t> text32;
    for (int i = 16; i < 64; ++i) {
        uint32_t s0 = rightrotate(text32Bins[i - 15].to_ullong(), 7) ^ rightrotate(text32Bins[i - 15].to_ullong(), 18) ^ (text32Bins[i - 15].to_ullong() >> 3);
        uint32_t s1 = rightrotate(text32Bins[i - 2].to_ullong(), 17) ^ rightshift(text32Bins[i - 2].to_ullong(), 19) ^ (text32Bins[i - 2].to_ullong() >> 10);
        text32Bins[i] = text32Bins[i - 16].to_ullong() + s0 + text32Bins[i - 7].to_ullong() + s1;
    }

    uint32_t a = h0;
    uint32_t b = h1;
    uint32_t c = h2;
    uint32_t d = h3;
    uint32_t e = h4;
    uint32_t f = h5;
    uint32_t g = h6;
    uint32_t h = h7;

    //цикл сжатия
    for (int i = 0; i < 64; ++i) {
        uint32_t S1 = rightrotate(e, 6) ^ rightrotate(e, 11) ^ rightrotate(e, 25);
        uint32_t ch = (e & f) ^ ((~e) & g);
        uint32_t temp1 = h + S1 + ch + ks[i] + text32Bins[i].to_ullong();
        uint32_t S0 = rightrotate(a, 2) ^ rightrotate(a, 13) ^ rightrotate(a, 22);
        uint32_t maj = (a & b) ^ (a & c) ^ (b & c);
        uint32_t temp2 = S0 + maj;

        h = g;
        g = f;
        f = e;
        e = d + temp1;
        d = c;
        c = b;
        b = a;
        a = temp1 + temp2;
    }

    //модификация хеша
    h0 = h0 + a;
    h1 = h1 + b;
    h2 = h2 + c;
    h3 = h3 + d;
    h4 = h4 + e;
    h5 = h5 + f;
    h6 = h6 + g;
    h7 = h7 + h;

    
    for (int i = 0; i < 8; i++)
    {
        switch (i) {
        case 0: result[i] = h0; break;
        case 1: result[i] = h1; break;
        case 2: result[i] = h2; break;
        case 3: result[i] = h3; break;
        case 4: result[i] = h4; break;
        case 5: result[i] = h5; break;
        case 6: result[i] = h6; break;
        case 7: result[i] = h7; break;
        }

        cout << hex << static_cast<int>(result[i]);
    }
}

// Функция для вычисления модульной инверсии
long long mod_inverse(long long a, long long m) {
    long long m0 = m, t, q;
    long long x0 = 0, x1 = 1;
    if (m == 1) return 0;
    while (a > 1) {
        q = a / m;
        t = m;
        m = a % m, a = t;
        t = x0;
        x0 = x1 - q * x0;
        x1 = t;
    }
    if (x1 < 0) x1 += m0;
    return x1;
}

int main()
{
    setlocale(LC_ALL, "Russian");
    string text;
    cout << "Введите строку\n";
    cin >> text;
    cout << text << endl;

    if (text.size() > 30) {
        cout << "Длинна слова слишком большая" << endl;
    }
    uint32_t result[8];

    sha256(result, text);

    long long p = 23;
    long long q = 11;
    long long g = 4;

    srand(time(0));
    long long x = 0 + rand() % (q - 0 + 1);
    long long y = pow(g, x);
    y = y % p;

    long long k = 0 + rand() % (q - 0 + 1);

    cout << dec << endl << "x = " << x << endl;
    cout << "y = " << y << endl;
    cout << "k = " << k << endl;

    long long r = pow(g, k);
    r = (r % p) % q;

    cout << "r = " << r << endl;

    /*string he = to_string(result[0]) + to_string(result[1]) + to_string(result[2]) + to_string(result[3]) + to_string(result[4]) + to_string(result[5]) + to_string(result[6]) + to_string(result[7]);
    long long H = stoll(he);*/
    
    long long H = result[0] + result[1] + result[2] + result[3] + result[4] + result[5] + result[6] + result[7];

    long double s = H + x * r;
    double nk = mod_inverse(k, q);
    s = fmod((long long)(nk * s), q);

    cout << "Цифровая подпись = " << r << " " << s << endl;

    if (r > 0 && r < q && s > 0 && s < q) {
        long long w = mod_inverse(s, q);
        long long u1 = (H * w) % q;
        long long u2 = (r * w) % q;
        long long u = (long long)(pow(g, u1) * pow(y, u2)) % p % q;

        cout << "w = " << w << endl;
        cout << "u1 = " << u1 << endl;
        cout << "u2 = " << u2 << endl;
        cout << "u = " << u << endl;

        if (u == r) {
            cout << "Подпись верна" << endl;
        }
        else {
            cout << "Подпись не верна" << endl;
        }
    }
    else {
        cout << "переменные r и/или s не удовлетворяют условиям алгоритма" << endl;
    }

}
