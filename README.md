# MaxBotNET - библиотека для создания ботов в мессенджере MAX для .NET

Библиотека **MaxBot** предоставляет простой и типизированный HTTP-клиент для работы с [Max Bot Platform API](https://max.ru) на .NET.

> ⚠️ **Важно**: SDK находится в **активной разработке**. API может меняться, некоторые функции (например, загрузка видео и аудио) пока не реализованы.

---

## Установка

На данный момент SDK распространяется в виде исходного кода. Добавьте файлы проекта в своё решение вручную или подключите как ссылку на проект (`ProjectReference`).

В будущем планируется публикация в NuGet.

---

## Использование

Пример простейшего бота, который на полученное сообщение отправляет ответ с клавиатурой. При нажатии на кнопку на этой клавиатуре отправляет её Payload и изображения пользователю в ответ

```csharp
// Создаём клиент бота с указанным токеном авторизации.
// Токен выдаётся при регистрации бота в платформе MaxBot.
MaxBotClient bot = new MaxBotClient(token);

// Бесконечный цикл для постоянного опроса входящих обновлений (long polling).
while (true)
{
    // Получаем пакет обновлений от сервера.
    // Метод GetUpdates() возвращает объект, содержащий список событий (сообщений, нажатий кнопок и т.д.),
    // произошедших с момента последнего вызова.
    var updates = await bot.GetUpdates();
    Console.WriteLine("test");
    // Обрабатываем каждое обновление по отдельности.
    foreach (var update in updates.Updates)
    {
        // --- Обработка нового входящего сообщения ---
        if (update.MessageCreated is not null)
        {
            // Извлекаем данные нового сообщения.
            var message = update.MessageCreated.Message;

            // Создаём клавиатуру с inline-кнопками.
            var buttons = new InlineKeyboardPayload();

            // Первая строка кнопок.
            buttons.CreateRow();
            // Добавляем две кнопки
            buttons.AddButton(new CallbackButton("Testing negative", "payload_negative", CallbackButtonIntent.Negative));
            buttons.AddButton(new CallbackButton("Testing positive", "payload_positive", CallbackButtonIntent.Positive));

            // Вторая строка кнопок.
            buttons.CreateRow();
            // Кнопка без указания Intent использует стиль по умолчанию.
            buttons.AddButton(new CallbackButton("Testing default", "payload_default"));

            // Отправляем ответное сообщение пользователю с прикреплённой клавиатурой.
            // userId берётся из информации об отправителе исходного сообщения.
            await bot.SendMessage(
                userId: message.Sender.UserId,
                text: "Test",
                attachments: [Attachment.CreateButtons(buttons)]
            );
        }

        // --- Обработка нажатия на callback-кнопку ---
        if (update.MessageCallback is not null)
        {
            // Извлекаем данные о нажатой кнопке (включая payload — полезную нагрузку).
            var callback = update.MessageCallback.Callback;
            
            //Путь к изображению
            string filePath = "/home/user/image.png";
            // Отправляем пользователю echo-сообщение с содержимым payload,
            // чтобы продемонстрировать, что обработка callback работает.
            // Прикремляем два изображения: одно, которое было загруженно с устройства, и второе по url
            await bot.SendMessage(
                userId: callback.User.UserId,
                text: callback.Payload,  // Например: "payload_negative"
                attachments: [
                    Attachment.CreatePhoto(token: await bot.Upload(filePath, UploadType.Image)),
                    Attachment.CreatePhoto(url: "https://example.org/image.png"),
                ]
            );
        }
    }
}
```

---

## Основные возможности

- Отправка текстовых сообщений
- Загрузка файлов (изображения, документы и др.)
- Получение информации о боте
- Работа с обновлениями (polling)
- Управление вебхук-подписками

---

## Ограничения

Библиотека находится в активной разработке, функции добавляются постепенно 

---

## Лицензия

MIT. См. файл `LICENSE` в репозитории.
