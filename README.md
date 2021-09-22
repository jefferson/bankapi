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

## Command Design Pattern

As an options to handler events on the BankApi we are going to use **``Command Design Pattern``**.

The ``Command`` desing pattern encapsulates a request as an object, thereby letting you parameterize
clients with different requests, queues or logs requests, and support undoable operations.



- The ``Command`` declares an interface for executing an operation.
- The ``ConcretCommand`` defines a binding between a Receiver object and an action, implements Execute by invoking the corresponding operation(s) on Receiver.
- The ``Client`` creates a ConcretCommand object and sets its receiver.
- The ``Invoker`` asks the command to carry ou the request.
- The ``Receiver`` knows how to perform the operations associated with carrying out the request.


## Requirements

.NET Core 3.1 LTS

Visual Studio or Visual Code

Docker
