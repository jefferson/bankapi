# The Bank Api

The API consists of two endpoints ``GET /balance``, and ``POST /event``.

| Verb | path    | Describe                          |
|------|---------|-----------------------------------|
| Post | reset   | Reset state before starting tests |
| Get  | balance | Get balance from account          |
| Post | event   | Account Management Events         |

For more details about contract, please, visit the documentation below:

``http://localhost:3333/swagger/index.html``

## Durability

Durability is not a requirement, so we aren't use database or persistence mechanism.

In this case the data will be stored in memory, only for get a way to store data and allow to realize some test through the api.

## Requirements

.NET Core 3.1 LTS

Visual Studio or Visual Code

Docker
