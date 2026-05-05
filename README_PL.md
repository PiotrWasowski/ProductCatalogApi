# Product Catalog App
🇵🇱 Polski | 🇬🇧 [English version](README.md)


Prosta, pełnozakresowa aplikacja katalogu produktów zbudowana z wykorzystaniem \*\*.NET 5+ Web API\*\* i \*\*Angular (samodzielny + Material UI)\*\*.

Projekt demonstruje nowoczesne wzorce architektoniczne, takie jak \*\*CQRS\*\*, \*\*separacja DTO\*\* i \*\*FluentValidation\*\*, a także reaktywny frontend wykorzystujący \*\*RxJS i Angular Material\*\*.


---



# 🇵🇱 Opis projektu (PL)



## Funkcjonalności



Aplikacja umożliwia:



- wyświetlanie listy produktów

- dodawanie nowego produktu

- usuwanie produktu

- automatyczne odświeżanie listy po zmianach

- walidację danych po stronie backendu i frontendu



---



## Architektura backendu (.NET)



Projekt backendu został zbudowany w oparciu o:



- CQRS (Command / Query Separation)

- FluentValidation

- DTO (Data Transfer Objects)

- Repozytorium w pamięci (In-Memory Repository)

- REST API



### Struktura:



- Controllers

- Application (Commands / Queries / Handlers)

- Models

- DTOs

- Validators

- Repositories



---



## Walidacja



Walidacja realizowana jest przy użyciu \*\*FluentValidation\*\*:



- Kod produktu → wymagany

- Nazwa produktu → wymagana

- Cena → nie może być mniejsza niż 0



---



## Frontend (Angular)



Frontend został zbudowany przy użyciu:



- Angular Standalone Components

- Angular Material UI

- RxJS (reactive programming)

- async pipe

- template-driven forms



### Funkcje:



- formularz dodawania produktu

- tabela produktów (Material Table)

- usuwanie produktów

- automatyczne odświeżanie danych



---



## UI



- Angular Material design

- centralny layout

- responsywna tabela

- ikony akcji (delete)



---



## API



### GET /api/products

Zwraca listę produktów



### POST /api/products

Dodaje nowy produkt



### DELETE /api/products/{id}

Usuwa produkt



---



## Technologie



### Backend:

- .NET 5+

- ASP.NET Core Web API

- FluentValidation



### Frontend:

- Angular 17+

- Angular Material

- RxJS

- TypeScript



---



## Uruchomienie projektu



### Backend:

```bash
dotnet run
```

Domyślnie:
https://localhost:7172



### Frontend:

```bash
npm install
ng serve
```

Domyślnie:
http://localhost:4200



---



## Wnioski architektoniczne

Projekt pokazuje:

* separację logiki biznesowej (CQRS)
* czystą strukturę API (DTO)
* walidację niezależną od modelu
* reaktywny frontend (RxJS)
* komunikację frontend - backend



---





