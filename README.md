# The Bank Api

The API consists of two endpoints ``GET v1/balance``, and ``POST v1/event``.

| Verb | Path       | Describe                          |
|------|------------|-----------------------------------|
| Post | v1/reset   | Reset state before starting tests |
| Get  | v1/balance | Get balance from account          |
| Post | v1/event   | Account Management Events         |

For more details about contract, please, visit the documentation below:

``https://localhost:5001/index.html``

## Durability

Durability is not a requirement, so we aren't use database or persistence mechanism.

In this case the data will be stored in memory, only for get a way to store data and allow to realize some test through the api.

## Requirements

.NET Core 3.1 LTS

Visual Studio or Visual Code

Docker
