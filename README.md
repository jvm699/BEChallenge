# BEChallenge
Back end challenge

API REST CRUD for a single entity User composed of the following fields:

User
--------------
Id (int)
Name (string)
Birth date (datetime)
Active (bool)

Know-how
API presentation in swagger

GET /api/User
* This action will return the list of all saved users. Press in the button Try it out and then in execute, at the bottom it'll list the users

POST /api/User
* Action to create a new user. Validation: can't create a user with the same name or id. Press in the button Try it out and then complete the json model and press in execute.

PUT /api/User{id}
* Action to edit parameter Active of an existing user. Press in the button Try it out and then complete the user id and the field active. If you do not fill in the active field it will be set to false

DELETE /api/User{id}
* Action to delete user. Press in the button Try it out and then enter the user Id to be deleted.

Can be viewed in json format at: https://localhost:7014/swagger/v1/swagger.json

POST MAN
Access to the same methods presented by swagger

Request URL:

GET: https://localhost:7014/api/User

POST: https://localhost:7014/api/User

PUT: https://localhost:7014/api/User/{id}

DELETE https://localhost:7014/api/User/{id}