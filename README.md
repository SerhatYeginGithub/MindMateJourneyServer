# MindMateJourney

## Proje Tanımı
MindMateJourney, kullanıcılara ruhsal destek sağlamak amacıyla geliştirilmiş bir platformdur. Bu proje, kitap önerileri, meditasyon önerileri ve film önerileri gibi çeşitli kategorilerde içerik sunarak kullanıcıların kendilerini iyi hissetmelerine yardımcı olur. Ayrıca, yapay zeka (AI) entegrasyonu sayesinde kullanıcılar AI ile sohbet ederek kişiselleştirilmiş öneriler alabilirler.

## Klasör Yapısı
```
MindMateJourney/
│
├── src/
│   ├── Core/
│   │   ├── MindMateJourney.Application/
│   │   ├── MindMateJourney.Domain/
│   │   └── Services/
│   ├── External/
│   │   ├── MindMateJourney.Infrastructure/
│   │   ├── MindMateJourney.Persistance/
│   │   └── MindMateJourney.Presentation/
│   └── MindMateJourney.WebApi/
│       ├── Controllers/
│       ├── Middleware/
│       ├── OptionsSetup/
│       ├── Program.cs
│       └── appsettings.json
└── ...
```


## Kullanılan Teknolojiler
- ASP.NET Core Web API
- Katmanlı Mimari (Core, Infrastructure, Application, Presentation)
- Entity Framework Core
- JWT Authentication
- Swagger / OpenAPI
- MemoryCache
- Identity
- Yapay Zeka (AI) Entegrasyonu


## Mimari
MindMateJourney, Clean Architecture prensiplerine uygun olarak geliştirilmiştir. Bu mimari, uygulamanın katmanlarını ve bağımlılıklarını daha iyi yönetmeyi sağlar. Proje Domain, Infrastructure, Application, Persitance ve Presentation  katmanlarından oluşmaktadır. 