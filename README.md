Part4:

Teknik Özellikler:Uygulama ASPNET Core5 ve MSSQL kullanılarak gerçekleştirilmiştir. Mimari olarak Loose coupling sağlaması nedeniyle Clean architecture
implementasyonu olan Onion architecture tercih edilmiştir. 

Core dosyası altında yer alan Domain projesinde veritabanı tabloları için entityler oluşturulmuştur. Application uygulamasında ise DTO ve Interfaceler yer almaktadır. 
Infrastructure dosyası altında yer alan Persistence uygulamasında metodlar için repository dosyası oluşturulmuş, kullanılacak enum ve context sınıfları tanımlanmış, 
StartUp belgesine kaydedilecek servisler için bir extension sınıfı oluşturulmuştur. WebAPI dosyası altında ise API projesi yer almaktadır.


Sistemde Cutomer, Book ve Purchase tabloları yer almaktadır.Code-First anlayışına göre veri tabanı oluşturulmaktadır.Book ve Purchase tabloları arasında Many-to Many 
ilişkisi olduğu için entity sınıfları ile context sınıfı, PurchaseBook tablosu oluşturulcak şekilde ayarlanmıştır. Ayrıca söz konusu tabloya quantity alanı da eklenmiştir. 
Veri tabanı şeması github repositorye eklenmiştir.


Uygulamanın test edilebilmesi CustomerID ile BookID ve quantity verileri ile istek gönderilmelidir. Sistem tarafından Cutomer classification değeri tablodan okunur. 
Eğer employee ise herhangi en yüksek discount değerine sahip olduğu için bu değer dikkate alınır. Değil ise customerın son 30 günlük alış-verişleri toplamına göre discount 
miktarı hesaplanıp istek gönderilen alış-veriş toplam tutarına uygulanır. Sonuçlar Purchase ve PurchaseBook tablolarına işlenir. Response olarak fiyat bilgileri getirilir.


