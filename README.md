# CompanyUser
Simple server with user and company entities

В приложении должно быть две сущности:
      User – список пользователей (Id, UserName)
      Company – список компаний, к которой принадлежит пользователь.
В одной компании может быть несколько пользователей.
Пользователи и компании должны храниться в базе данных
Приложение должно обладать следующей функциональностью:

  Создавать новые компании   http://localhost:123/Home/CreateCompany?companyName=Ромашка
  Создавать новых пользователей (причем пользователи не могут быть не привязаны к
  компании)                   http://localhost:123/Home/CreateUser?companyName=Ромашка&companyName=Ромашка
  Редактировать имена пользователей   http://localhost:123/Home/CreateUser?userName=Иванов&newUserName=Петров
  Редактировать название компании     http://localhost:123/Home/EditCompany?CompanyName=Ромашка&newCompanyName=Васильки
  Получать список компаний в виде json/xml через браузер    http://localhost:123/Home/GetCompanies
  Получать список пользователей в виде json/xml через браузер http://localhost:123/Home/GetUsers

Примеры:
Создание компании – http://localhost:123/Home/CreateCompany?companyName=Ромашка
Создание Пользователя – http://localhost:123/Home/CreateUser?userName=Иванов&companyName=Ромашка
Получение пользователя http://localhost:123/Home/GetUserJson?userName=Иванов
Ответ:
{
"Company": {
"Id": 1,
"Name": "Ромашка"
},
"Id": 1,
"UserName": "Иванов"
}
Получение пользователя http://localhost:123/Home/GetCompany?companyName=Ромашка
Ответ:
{
"Id": 1,
"Name": "Ромашка"
}
Редактирование компании – http://localhost:123/Home/EditCompany?CompanyName=Ромашка&newCompanyName=Васильки
Редактирование Пользователя – http://localhost:123/Home/CreateUser?userName=Иванов&newUserName=Петров
При повторном запросе http://localhost:123/Home/GetUser?userName=Иванов , должны получить пустоту:
{}
А если http://localhost:12/Home/GetUser?userName=Петров
Ответ:
{
"Company": {
"Id": 1,
"Name": "Васильки"
},
"Id": 1,
"UserName": "Петров"
}
