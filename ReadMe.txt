Rest-сервис на Core WebAPI.
1. Реализован CRUD по модели пользователя:
{
    Iin: "012345678910",
    FirstName: "Иван",
    LastName: "Иванов",
    BirthDate: "2019-05-16"
}
2. Есть методы для создания, обновления, получения списка пользователей и удаления
3. Валидация полей по типу содержимого (буквы в ИИН и'#$123' в ФИО не проходят). Валидация реализована через FluentValidation.
4. Слой работы с данными в папке Data - класс DataContext.
5. При работе с классами используются инъекции зависимости.
6. Сервис написан Swagger'ом.
7. Реализован механизм получения токенов и авторизации.
8. Неавторизованные запросы возвращают ошибку 401.
9. В проекте также внедерена версионность.