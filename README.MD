# CodeFirstRelation

Bu proje, Entity Framework Core kullanarak Code First yaklaşımı ile ilişkisel bir veritabanı oluşturmayı ve yönetmeyi amaçlamaktadır.

## Proje Yapısı

## Kurulum

1. Bu projeyi klonlayın:
    ```sh
    git clone https://github.com/kullaniciadi/CodeFirstRelation.git
    cd CodeFirstRelation
    ```

2. Gerekli NuGet paketlerini yükleyin:
    ```sh
    dotnet restore
    ```

3. Veritabanı bağlantı dizesini `appsettings.json` dosyasında güncelleyin:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5433;Database=PatikaFirstDb2;Username=postgres;Password=123456;"
      }
    }
    ```

4. Veritabanını oluşturun ve gerekli migrasyonları uygulayın:
    ```sh
    dotnet ef database update
    ```

5. Projeyi çalıştırın:
    ```sh
    dotnet run
    ```

## Kullanım

### Kullanıcılar

- Kullanıcıları listelemek için:
    ```http
    GET /api/User
    ```

### Postlar

- Yeni bir post oluşturmak için:
    ```http
    POST /api/Post
    ```

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin veya bir issue açın.

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.