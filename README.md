🧪 C# .NET Unit Testing & TDD Pratik Deposu
Bu depo, modern .NET uygulamalarında yazılım kalitesini artırmak, hataları erken aşamada yakalamak ve sürdürülebilir kod mimarileri kurmak amacıyla geliştirilmiş Unit Test (Birim Testi) çalışmalarımı içermektedir.

Geliştirmeler, Udemy üzerinden alınan kapsamlı bir Unit Test eğitimi müfredatı takip edilerek, temel kavramlardan gerçek dünya senaryolarına doğru aşama aşama ilerlenerek yapılmıştır.

🛠️ Kullanılan Teknolojiler ve Araçlar
Platform / Dil: .NET, C#

Test Framework: xUnit

Assertion Kütüphanesi: FluentAssertions

Mocking (Taklit) Aracı: NSubstitute

📚 İçerik ve Öğrenme Çıktıları
Bu depo altındaki projeler ve test senaryoları şu ana başlıkları kapsamaktadır:

1. Temel Kavramlar (Fundamentals)
AAA Pattern (Arrange, Act, Assert): Testlerin standart ve okunabilir bir yapıda yazılması.

xUnit Yaşam Döngüsü: Test Execution Model (Test çalıştırma modeli) ve Test Context yönetimi.

Veri Odaklı Testler: [Theory] ve [InlineData] kullanılarak parametreli test senaryolarının (Parameterized Tests) oluşturulması.

İsimlendirme Standartları: Anlaşılır ve dökümantasyon niteliği taşıyan test metod isimlendirmeleri.

2. Test Teknikleri (Techniques & FluentAssertions)
FluentAssertions kütüphanesi kullanılarak yazılmış, okunabilirliği yüksek doğrulama senaryoları:

String, Number (Sayısal), Date (Tarih) ve Object (Nesne) testleri.

Koleksiyon (Collection) testleri.

Exception (Hata) Testleri: Beklenen hataların (ThrowAsync vb.) doğru fırlatıldığının doğrulanması.

Görünürlük (Private/Internal method) test yaklaşımları.

3. İleri Seviye Konseptler (Mocking)
NSubstitute Kullanımı: Dış bağımlılıkların (veritabanı, API, servisler vb.) izole edilerek test edilecek birimin (SUT) tek başına test edilmesi.

Davranış doğrulama (Received()) ve dönüş değerlerini taklit etme (Returns()).

4. Gerçek Dünya Projesi (Real World)
Çok katmanlı mimaride yazılmış bir API projesi üzerinde test senaryoları.

Service Katmanı Testleri: UserService gibi iş mantığı (business logic) içeren sınıfların test edilmesi.

Controller Katmanı Testleri: API uç noktalarının (UsersController) istek ve yanıt döngülerinin test edilmesi.
