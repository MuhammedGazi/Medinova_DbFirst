<div align="center">

  <img src="https://via.placeholder.com/1200x400/20B2AA/ffffff?text=MEDINOVA+AI+HOSPITAL+SYSTEM" alt="Medinova Banner" width="100%" />

  <br />
  <br />

  # 🏥 Medinova - Yapay Zeka Destekli Hastane Yönetim Sistemi

  **Geleneksel Hastane Otomasyonunu, Modern Yapay Zeka Teknolojileriyle Buluşturan Karar Destek Sistemi.**

  <a href="https://github.com/muhammedgazi/medinova_dbfirst">
    <img src="https://img.shields.io/badge/Maintained%3F-yes-green.svg?style=for-the-badge" alt="Maintained">
  </a>
  <a href="#">
    <img src="https://img.shields.io/badge/.NET-4.8-512BD4?style=for-the-badge&logo=.net" alt=".NET Framework">
  </a>
  <a href="#">
    <img src="https://img.shields.io/badge/ML.NET-Prediction-blue?style=for-the-badge&logo=dotnet" alt="ML.NET">
  </a>
  <a href="#">
    <img src="https://img.shields.io/badge/AI-Google%20Gemini-orange?style=for-the-badge&logo=google" alt="Gemini AI">
  </a>
  <a href="#">
    <img src="https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge" alt="License">
  </a>

</div>

---

## 🚀 Proje Hakkında

**Medinova**, sadece hastaların kayıtlarını tutan bir sistem değildir; hastanenin operasyonel verimliliğini artırmak için **Geleceği Tahmin Eden** akıllı bir platformdur. 

ASP.NET MVC mimarisi üzerine kurulu bu proje, **Entity Framework (DbFirst)** ile sağlam bir veri yönetimi sunarken, **Microsoft ML.NET** kütüphaneleri ile geçmiş verilerden öğrenerek gelecek hasta yoğunluğunu tahmin eder. Ayrıca **Google Gemini AI** entegrasyonu ile yöneticilere akıllı asistanlık yapar.

## ✨ Öne Çıkan Özellikler

### 🧠 1. Yapay Zeka & Makine Öğrenimi (AI Core)
Projenin kalbinde yer alan `ForecastController` ve `GeminiService` sayesinde:
* **📈 Zaman Serisi Tahmini (SSA):** Geçmiş randevu verilerini analiz ederek, gelecek aylarda hangi poliklinikte (Kardiyoloji, Dahiliye vb.) yoğunluk olacağını öngörür.
* **⏱️ Saatlik Talep Tahmini (Regression):** `FastTree` algoritması kullanılarak, günün hangi saatlerinde hasta akışının artacağı tahmin edilir.
* **🚦 Akıllı Uyarı Sistemi:** Yoğunluk tahminlerine göre "Düşük", "Normal", "Yüksek" şeklinde dinamik uyarılar üretir ve personel planlaması önerisi sunar (Örn: "Saat 14:00'te 2 Ek Doktor Gerekli").
* **🤖 Gemini AI Asistanı:** Sistem içi verileri yorumlayabilen üretken yapay zeka desteği.

### 🏛️ 2. Mimari ve Yapı
* **Multi-Area System:** * 🛡️ **Admin Paneli:** Tam yetkili yönetim, istatistikler ve tahmin raporları.
    * 👨‍⚕️ **Doktor Paneli:** Randevu yönetimi ve hasta takibi.
    * 👤 **Kullanıcı (Hasta) Paneli:** Randevu alma ve profil işlemleri.
* **DTO (Data Transfer Objects):** Güvenli ve optimize veri taşıma modelleri.
* .Net 4.8 Kullanıldı

### 🎨 3. Modern Arayüz
* **Responsive Dashboard:** Bootstrap tabanlı, mobil uyumlu yönetim panelleri.
* **Görselleştirme:** Chart.js ve ZingChart ile zenginleştirilmiş interaktif grafikler.
* **KPI Kartları:** Anlık durum özetleri.

---

## 🛠️ Kullanılan Teknolojiler

<div align="center">

| Backend | Frontend | Veri & AI | Araçlar |
| :---: | :---: | :---: | :---: |
| <img src="https://skillicons.dev/icons?i=cs,dotnet" width="50"/> | <img src="https://skillicons.dev/icons?i=html,css,bootstrap,js,jquery" width="50"/> | <img src="https://img.shields.io/badge/MSSQL-CC2927?style=flat&logo=microsoft-sql-server&logoColor=white" height="40"/> | <img src="https://skillicons.dev/icons?i=visualstudio,git,github" width="50"/> |
| **ASP.NET MVC 5** | **AdminPluto Template** | **ML.NET (Time Series)** | **NuGet** |
| **Entity Framework 6** | **Chart.js** | **Google Gemini API** | **Postman** |

</div>

---

## 📸 Ekran Görüntüleri

### 📊 Yapay Zeka Destekli Dashboard
*Makine öğrenimi modellerinin ürettiği tahmin grafikleri ve personel önerileri.*
<div align="center">
  <img src="https://via.placeholder.com/800x450/eeeeee/000000?text=Dashboard+ve+Tahmin+Ekrani" alt="Dashboard" width="800" />
</div>

### 📅 Randevu Yönetimi
*Admin ve Doktorlar için sürükle-bırak destekli takvim yönetimi.*
<div align="center">
  <img src="https://via.placeholder.com/800x450/eeeeee/000000?text=Randevu+Yonetimi" alt="Appointments" width="800" />
</div>

---

## ⚙️ Kurulum ve Çalıştırma

Projeyi yerel makinenizde çalıştırmak için aşağıdaki adımları izleyin:

<details>
<summary>📦 Adım 1: Projeyi Klonlayın</summary>

```bash
git clone [https://github.com/muhammedgazi/medinova_dbfirst.git](https://github.com/muhammedgazi/medinova_dbfirst.git)
cd medinova_dbfirst
