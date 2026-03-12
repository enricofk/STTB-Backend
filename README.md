# STTB Backend API 🚀

Selamat datang di repository Backend untuk sistem informasi kampus STTB. Project ini dibangun menggunakan **ASP.NET Core (.NET 10)** dan **PostgreSQL**.

---

## Tech Stack
* **Framework:** ASP.NET Core Web API 10.0
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core
* **Security:** * JWT (JSON Web Token) Authentication
    * BCrypt.Net untuk Password Hashing
* **Documentation:** Swagger / OpenAPI

---

##  Cara Setup di Lokal

Agar project ini bisa berjalan di laptopmu, ikuti langkah-langkah berikut:

### 1. Clone Repository
```bash
git clone [https://github.com/USERNAME_KAMU/STTB-Backend.git](https://github.com/USERNAME_KAMU/STTB-Backend.git)
```

### 2. Konfigurasi Database
Buka file appsettings.json dan sesuaikan ConnectionStrings dengan kredensial PostgreSQL lokal kamu:
```
JSON
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost; Database=sttb_db; Username=postgres; Password=ISI_PASSWORD_DATABASE"
}
```
### 3. Update Database (Migration)
Buka Package Manager Console di Visual Studio, lalu jalankan perintah berikut untuk membuat tabel secara otomatis:
```
PowerShell
Update-Database
```
### 4. Jalankan Project
Tekan F5 atau klik tombol Play di Visual Studio. Swagger UI akan otomatis terbuka di browser.

## 🔐 Cara Testing API (Security JWT)
Beberapa endpoint seperti POST, PUT, dan DELETE sudah dilindungi oleh sistem keamanan JWT. Untuk mencobanya di Swagger:

Registrasi/Login: Gunakan endpoint /api/Auth/login untuk mendapatkan token.
Ambil Token: Copy string panjang yang muncul di bagian "token".
Authorize: Klik tombol Authorize (ikon gembok) di pojok kanan atas Swagger.
Input: Ketik Bearer [spasi] TOKEN_KAMU.

Contoh: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...

Test: Klik Authorize dan sekarang kita bisa mengakses endpoint yang terkunci.


## 📂 Struktur Database
Project ini mencakup manajemen data untuk:

- Berita & Kategori Berita
- Kegiatan & Event Kampus
- Informasi Akademik (Dosen, Mata Kuliah, Program Studi)
- Pendaftaran Mahasiswa Baru (Admissions)
- Fasilitas, FAQ, dan Dokumen Unduhan
- Manajemen User (Admin)


