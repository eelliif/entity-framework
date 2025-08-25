# entity-framework
Bu depo, C# ile geliştirilmiş basit bir Ürün, Müşteri ve Sipariş Yönetimi uygulamasıdır. Uygulama, temel CRUD (Create, Read, Update, Delete) operasyonlarını gerçekleştirmektedir.

Özellikler
Ürün Yönetimi: Yeni ürün ekleme, mevcut ürünleri silme ve güncelleme.
Müşteri Yönetimi: Müşteri bilgilerini görüntüleme, ekleme ve düzenleme.
Sipariş Yönetimi: Müşteri ve ürün ID'lerine göre yeni sipariş oluşturma ve mevcut siparişleri listeleme/sorgulama.
Veritabanı Entegrasyonu: Entity Framework ile veritabanı işlemlerini kolayca yönetme.
Kullanılan Teknolojiler
Programlama Dili: C#
Platform: Windows Forms (.NET Framework)
Veritabanı: SQL Server
ORM: Entity Framework

Kurulum ve Çalıştırma
Bu depoyu yerel makinenize klonlayın:
Bash
git clone https://github.com/KullaniciAdiniz/DepoAdiniz.git
Visual Studio'yu açın ve çözüm dosyasını (ProjeAdiniz.sln) açın.
Veritabanı Bilgileri İçin Önemli Not
Veritabanı bağlantı ayarları App.config dosyasında bulunmaktadır. Lütfen bu dosyayı açarak kendi SQL Server bilgilerinize göre (server=, database=, user id=, password=) güncelleyiniz.
Çözümü derleyin (Build Solution).
Uygulamayı çalıştırın (F5 tuşuna basın).
Ekran Görüntüleri
Ana Menü: [Ana menü tasarımının ekran görüntüsü]
Ürün Yönetim Formu: [Ürün formu tasarımının ekran görüntüsü]
Sipariş Yönetim Formu: [Sipariş formu tasarımının ekran görüntüsü]

Katkıda Bulunma
Eğer bu projeye katkıda bulunmak isterseniz, lütfen bir Pull Request (PR) gönderin.

Lisans
Bu proje MIT License altında lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasına bakınız.
