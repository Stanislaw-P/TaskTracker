# TaskTracker

ТЗ: [Тестовое_задание_для_собеседования.docx](https://github.com/user-attachments/files/26871227/_._._.docx)

> Управление задачами через REST API с хранением данных в PostgreSQL.

## 📋 Требования
 
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) — для локальной разработки и применения миграций
- [Docker](https://www.docker.com/) и Docker Compose — для запуска приложения и БД в контейнерах
- (опционально) [EF Core CLI tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) — `dotnet tool install --global dotnet-ef`
## 📥 Клонирование репозитория
 
```bash
git clone https://github.com/Stanislaw-P/TaskTracker.git
cd TaskTracker
```
 
## ⚙️ Настройка переменных окружения
 
В корне репозитория создай файл `.env` (на основе `.env.example`, если он есть) со следующими переменными:
 
```env
DB_USER=postgres
DB_PASSWORD=your_strong_password
```
 
Эти значения подставляются в `docker-compose.yml` для контейнера `postgres` и для строки подключения веб-приложения (`ConnectionStrings__DefaultConnection`).
 
> ⚠️ Файл `.env` не должен попадать в репозиторий — убедись, что он добавлен в `.gitignore`.
 
## 🐳 Запуск через Docker Compose (рекомендуемый способ)

1. Собрать образы и запустить контейнеры:
```bash
docker compose up -d --build
```
 
2. Будут запущены два контейнера:
   - `task_tracker_web_api` — API на ASP.NET Core, доступен на `http://localhost:8080`
   - `postgres` — база данных PostgreSQL, доступна на `localhost:5432`
  
## 💻 Запуск без Docker (локальная разработка)
 
1. Поднять только базу данных в Docker:
```bash
docker compose up -d postgres
```
 
2. Указать строку подключения в `TaskTracker/appsettings.Development.json` или через user-secrets:
```bash
cd TaskTracker
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=task-tracker;Username=<DB_USER>;Password=<DB_PASSWORD>"
```

3. Запустить приложение:
```bash
dotnet run
```
 
## 🛑 Остановка и очистка
 
Остановить контейнеры:
 
```bash
docker compose down
```
 
Остановить контейнеры и удалить данные БД (volume):
 
```bash
docker compose down -v
```
 
 
