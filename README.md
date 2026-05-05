# Product Catalog App
🇬🇧 English | 🇵🇱 [Polska wersja](README_PL.md)




A simple full-stack product catalog application built with \*\*.NET 5+ Web API\*\* and \*\*Angular (standalone + Material UI)\*\*.



The project demonstrates modern architecture patterns such as \*\*CQRS\*\*, \*\*DTO separation\*\*, and \*\*FluentValidation\*\*, along with a reactive frontend using \*\*RxJS and Angular Material\*\*.



---



# 🇬🇧 Project Description (EN)



## Features



This application allows:

- viewing product list
- adding new products
- deleting products
- automatic refresh after changes
- frontend and backend validation



---



## Backend Architecture (.NET)

The backend is built using:

- CQRS pattern (Command / Query Separation)
- FluentValidation
- DTO (Data Transfer Objects)
- In-memory repository
- REST API



### Structure:
- Controllers
- Application (Commands / Queries / Handlers)
- Models
- DTOs
- Validators
- Repositories



---



## Validation

Validation is handled using FluentValidation:

- Product Code → required
- Product Name → required
- Price → must be ≥ 0



---



## Frontend (Angular)

Frontend is built with:

- Angular Standalone Components
- Angular Material UI
- RxJS (reactive programming)
- async pipe
- template-driven forms



### Features:

- product creation form
- Material data table
- delete product functionality
- automatic data refresh



---



## UI

- Angular Material design system
- centered layout
- responsive table
- action icons (delete)



---



## API



### GET /api/products

Returns list of products



### POST /api/products

Creates a new product



### DELETE /api/products/{id}

Deletes a product



---



## Technologies



### Backend:

- NET 5+
- ASP.NET Core Web API
- FluentValidation



### Frontend:

- Angular 17+
- Angular Material
- RxJS
- TypeScript



---



## How to run



### Backend:

```bash

dotnet run```

Default:
https://localhost:7172



### Frontend:

```bash

npm install```

ng serve

Defualt:
http://localhost:4200



---



## Architecture Highlights

This project demonstrates:

* CQRS separation of concerns
* Clean API design with DTOs
* Independent validation layer
* Reactive frontend architecture
* Full-stack communication between Angular and .NET



---





