# Pokedex

This is a web app where you can manage your pokemons, you can get, add, update, delete pokemons and their region or their types.

### Technologies

- ASP.NET
- SQL Server

<br/>

### Start manage your pokemons

You have to change the connectionString in the appsettings.json:

```
 "ConnectionStrings": {
    "defaultConnection": "Server=your_server; Database=your_database; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True"
  },

```

You can download the project and run the following command in the Nuget Package Manager console:
```
Update-Database
```
<br/>

### Make your own migrations

If you change the models structure or Context settings in your code, you can run the following command in the Nuget Package Manager console to update the database:

```
Add-Migration "my migration"
Update-Database
```

You can add your regions and types of pokemons.

<br/>

## Web App Screenshot Preview
<hr>

#### Pokemons page

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/bd179bce-5148-4693-99ca-ee4e8d133825)

#### Editing pokemons

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/59107922-6e4b-461c-8b47-db98e1ad632e)

#### Types of pokemons

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/7d26a04e-f6c5-4647-b7ce-0661ae1ef9d7)

#### Regions

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/7e92d8b0-38d8-4d9f-aea4-4c5314675163)
