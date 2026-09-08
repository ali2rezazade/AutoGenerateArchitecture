# 🚀 .NET Architecture Generator (Visual Studio Extension)

[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?logo=visualstudio&logoColor=white)](https://visualstudio.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![Platform](https://img.shields.io/badge/.NET-Core%20%7C%208%20%7C%209-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)

**⚡ .NET Architecture Generator** is a productivity extension for Visual Studio designed to instantly generate clean folder structures and boilerplate files for **10 popular modern software architectures** in your .NET projects.

---

## 🌟 Key Features

- 📁 **Two-Phase Generation**: Creates complete directory trees first, then injects clean base boilerplate files.
- 🧩 **Namespace Agnostic**: Injected boilerplate files come without hardcoded namespaces to seamlessly adapt to your project structure.
- 🎯 **10 Popular Architectures**: Supports Clean Architecture, Vertical Slice, DDD, CQRS, Hexagonal, and more.
- ⚡ **Lightweight & Fast**: Simple WPF dialog integrated right into Solution Explorer.
- 🛠 **Zero Dependencies**: Pure VSIX implementation without heavy external dependencies.

---

## 🏗 Supported Architectures

| # | Architecture | Description |
|---|---|---|
| 1 | **Clean Architecture** | Full separation of Domain, Application, Infrastructure, and Presentation layers. |
| 2 | **Vertical Slice** | Feature-driven structure grouping Commands, Queries, and Handlers together. |
| 3 | **Hexagonal (Ports & Adapters)** | Isolates core domain logic from external concerns via Primary and Secondary ports. |
| 4 | **Onion Architecture** | Concentric layered design where dependencies strictly point toward the domain core. |
| 5 | **CQRS** | Segregates Command execution from Query operations with dedicated DTOs and Handlers. |
| 6 | **Domain-Driven Design (DDD)** | Rich domain modeling with Aggregates, Value Objects, Domain Events, and Repositories. |
| 7 | **Modular Monolith** | Independent business modules with dedicated contracts and shared `BuildingBlocks`. |
| 8 | **Microservices (Template)** | Service structure with integration events, controllers, and sample Proto definitions. |
| 9 | **N-Tier (Traditional Layered)** | Classic 3-tier layering: Data Access Layer (DAL), Business Logic (BLL), and Presentation. |
| 10 | **Event-Driven Architecture (EDA)** | Asynchronous decoupled architecture featuring Event definitions, Producers, and Consumers. |

---

## 📥 How to Install

### Option A: From Visual Studio Marketplace
1. Open Visual Studio 2022.
2. Go to **Extensions** > **Manage Extensions**.
3. Search for `.NET Architecture Scaffolder`.
4. Click **Download** and restart Visual Studio.

### Option B: Manual Installation (.VSIX)
1. Download the latest `.vsix` file from the [Releases](https://github.com/your-username/ArchitectureScaffolder/releases) section.
2. Double-click the `.vsix` installer.
3. Follow the wizard to complete the installation for Visual Studio 2022.

---

## 🚀 How to Use

1. Open your project in Visual Studio.
2. In **Solution Explorer**, right-click on the target **Project**.
3. Click on **`Apply Architecture...`**.
4. Select your desired architecture pattern from the dialog list.
5. Click **تولید ساختار و فایل‌ها (Generate)**.
6. Your project folders and initial base boilerplate files are ready!

---

## 📂 Example Generated Structure (Clean Architecture)
```text
MyProject/
├── Domain/
│   ├── Common/BaseEntity.cs
│   ├── Entities/
│   ├── Enums/
│   └── Exceptions/
├── Application/
│   ├── Common/
│   │   ├── Interfaces/IApplicationDbContext.cs
│   │   ├── Models/Result.cs
│   │   └── Behaviors/
│   ├── Features/
│   └── Services/
├── Infrastructure/
│   ├── Persistence/
│   │   ├── Contexts/
│   │   └── Repositories/GenericRepository.cs
│   └── Services/
└── Presentation/
├── Controllers/
└── Middlewares/
