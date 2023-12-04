# Уведомительная система микросервисов

Система отправки уведомлений, построенная на микросервисной архитектуре.

## Пререквизиты

Для запуска вам необходим [Docker](https://www.docker.com/) и [docker-compose](https://docs.docker.com/compose/).

## Сервисы

### Сервис API

Сервис API доступен внешне. Используйте следующий конечный пункт для отправки POST-запроса для уведомлений по электронной почте:

```http
http://127.0.0.1:5000/api/v1/notification/send_email
```

Включите следующие параметры:

```json
{
  "toEmail": "email@example.com",
  "toFio": "Имя",
  "event": "register"
}
```

### Сервис Worker

Сервис Worker доступен внутри сети контейнеров Docker. Здесь реализованы методы отправки уведомлений.

### Сервис Setting Agent

Сервис Setting Agent отвечает за предоставление настроек другим сервисам.

### RabbitMQ

RabbitMQ обеспечивает обмен сообщениями между сервисами API и Worker.

## Файлы настроек

Директория `setting files` содержит файлы JSON с настройками для других сервисов. Такой подход гарантирует, что чувствительные данные, такие как учетные данные электронной почты, не хранятся нигде в кодовой базе. Заполните этот файл непосредственно на сервере, где он будет использоваться.

## Использование

1. Клонируйте репозиторий.
2. Запустите Docker и docker-compose.
3. Получите доступ к внешнему сервису API для отправки уведомлений.
4. Используйте RabbitMQ для обмена сообщениями между сервисами API и Worker.

## Вклад

Pull-запросы приветствуются. При необходимости внесения значительных изменений предварительно создайте проблему для обсуждения.

## Лицензия

Этот проект лицензирован в соответствии с [MIT License](LICENSE).

---

# Notification Microservices System

A notification system built on a microservices architecture.

## Prerequisites

To run this system, you need [Docker](https://www.docker.com/) and [docker-compose](https://docs.docker.com/compose/).

## Services

### API Service

The API service is accessible externally. Use the following endpoint to send a POST request for email notifications:

```http
http://127.0.0.1:5000/api/v1/notification/send_email
```

Include the following parameters:

```json
{
  "toEmail": "email@example.com",
  "toFio": "Name",
  "event": "register"
}
```

### Worker Service

The worker service is accessible within the Docker container network. It handles the implementation of notification sending methods.

### Setting Agent Service

The setting agent service is responsible for providing settings to other services.

### RabbitMQ

RabbitMQ facilitates message exchange between the API and worker services.

## Setting Files

The `setting files` directory contains JSON files with settings for other services. This approach ensures that sensitive data, such as email account credentials, is not stored anywhere in the codebase. Populate this file directly on the server where it will be used.

## Usage

1. Clone the repository.
2. Run Docker and docker-compose.
3. Access the API service externally to send notifications.
4. Utilize RabbitMQ for communication between the API and worker services.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

This project is licensed under the [MIT License](LICENSE).
