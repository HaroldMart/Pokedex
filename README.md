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
    "defaultConnection": "Server=your_server; Database=your_database; Trusted_Connection=True; 
    TrustServerCertificate=True; MultipleActiveResultSets=True"
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

#### Pokemons page

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/2ff19c49-07ff-44f4-826b-cf4c70e86bf8)

#### Editing pokemons

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/7090cd43-9c35-40d8-8208-000df62a75dd)

#### Types of pokemons

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/22d5f3ae-7b82-42ba-a610-cade8226abbc)

#### Regions

![image](https://github.com/HaroldMart/Pokedex/assets/93040571/7e92d8b0-38d8-4d9f-aea4-4c5314675163)
