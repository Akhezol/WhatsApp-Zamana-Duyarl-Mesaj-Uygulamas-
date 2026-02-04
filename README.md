# WhatsApp Zamana Duyarlı Mesaj Uygulaması

Bu proje, **Windows için WhatsApp Desktop uygulamasını** kullanarak,
belirlenen bir saatte otomatik olarak mesaj göndermeyi sağlayan
**C# Console tabanlı bir otomasyon uygulamasıdır**.

⚠️ Uygulama çalıştırıldıktan ve mesaj zamanlandıktan sonra,
mesaj gönderilene kadar **mouse ve klavye ile herhangi bir işlem yapılmamalıdır**.

Bu uygulama, Windows UI otomasyonu (klavye odaklama) kullandığı için,
kullanıcı etkileşimi odak kaybına neden olabilir ve
mesajın yanlış pencereye yazılmasına veya gönderilememesine yol açabilir.

> ⚠️ Proje, resmi WhatsApp API kullanmaz.  
> Windows UI otomasyonu (klavye odaklama) mantığıyla çalışır.

---

## 🚀 Özellikler

- ⏰ Belirli bir saat için mesaj zamanlama
- 👤 Mesaj gönderilecek kişi adını konsoldan alma
- 💬 Gönderilecek mesajı konsoldan alma
- 🖥️ WhatsApp Desktop (Windows Store sürümü) desteği
- 🎯 Otomatik pencere odaklama (focus fix)
- 🧩 Kolay geliştirilebilir yapı

---

## 🛠️ Gereksinimler

- Windows 10 / 11
- WhatsApp Desktop (Microsoft Store sürümü)
- .NET (Console App)

---

## ▶️ Kullanım

Uygulamayı çalıştırdığınızda sizden sırasıyla:

```text
Mesaj gönderim saati (HH:mm)
Mesaj gönderilecek kişi adı
Gönderilecek mesaj
