# The Bank Api

The API consists of two endpoints ``GET v1/balance``, and ``POST v1/event``.

| Verb | Path       | Describe                          |
|------|------------|-----------------------------------|
| Post | v1/reset   | Reset state before starting tests |
| Get  | v1/balance | Get balance from account          |
| Post | v1/event   | Account Management Events         |

If you would like to run this API, please, visit the address below:

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

## Note
This is not a Rest or RestFull api, basically it'a remote procudere call API.

## How to Run

Access the root direcotry of BankApi project: 
```cmd
cd ~\source\repos\BankApi\BankApi
```

Execute the dotnet run command:

```cmd
~\source\repos\BankApi\BankApi>
$ dotnet run

info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: ~\source\repos\BankApi\BankApi
```

If you would like to run this API, please, visit the address below:

``https://localhost:5001/index.html``


## How to Run
Run the command below in the root directory:

```cmd
dotnet run
```
## Run inside Docker

Access the root direcotry of project: 
```cmd
cd ~\source\repos\BankApi
```

Build the image:

```cmd
~\source\repos\BankApi\>
$ docker build -t bank-api .

info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: ~\source\repos\BankApi\BankApi
```

Run the command bellow for start the application:

```cmd
~\source\repos\BankApi\>
$ docker run -dp 5001:80 bank-api
```

In this case, the application wil run inside docker on port *80* but in host envoriment will run on port *5001*

## How to Test

Access the root direcotry of project: 
```cmd
cd ~\source\repos\BankApi
```

Run the command below in the root directory:

```cmd
dotnet test
...
Iniciando execução de teste, espere...
1 arquivos de teste no total corresponderam ao padrão especificado.

Aprovado!  - Com falha:     0, Aprovado:    15, Ignorado:     0, Total:    15, Duração: 153 ms - TestBankApi.dll (netcoreapp3.1)

```

## Requirements

.NET Core 3.1 LTS

Visual Studio or Visual Code

Docker
