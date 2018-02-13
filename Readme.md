# REST

- Clona detta projekt
- Öppna upp projektet i VS och kör det (Start without debugging).

Så där, nu har du ett C# web api körandes på din dator :tada: Låt oss nu testa det
- Se till att du har [Insomnia](https://insomnia.rest/) eller [Postman](https://www.getpostman.com/) installerat på din dator. Om du vill använda [curl](https://curl.haxx.se/) så är det också helt okej.
- Börja med att göra ett GET anrop mot `http://localhost:58956/books`.
Om allt fungerar som det ska så kommer du få tillbaka följande data:

```json
[
    {
        "author": 1,
        "title": "Snabba Cash",
        "intro": "Ett besök i Stockholms undre värld...",
        "id": 1
    }
]
```
- Gör nu ett POST anrop mot samma url: `http://localhost:58956/books` för att skapa en ny bok och inkludera följande data i HTTP bodyn:

```json
{
    "author": 1,
    "title": "Alldrig fucka upp",
    "intro": "Uppföljaren til succén...",
    "id": 2
}
```
- Hämta nu ut en specifik identitet genom att göra ett GET anrop till ex. denna url: `http://localhost:58956/books/2`
- Du ser nu att det är ett stavfel i introt till boken :scream: så du bestämmer dig att uppdatera posten med en PUT (om du rättade till stavfelet innan du postade, testa att uppdatera texten till något annat):

```json
{
    "author": 1,
    "title": "Alldrig fucka upp",
    "intro": "Uppföljaren till succén...",
    "id": 2
}
```
- Du kommer på att du inte alls tycker om bok nr 2 så du tar bort den genom DELETE
- Som du säkert redan har lagt märke till så har alla böcker hittills haft en property som heter `author` och som har värdet 1. Detta är en referens (id) till en författare identitet. Tyärr så finns inte någon endpoint för att hämta ut författare :/ Så för tillfället kan man inte ta reda på vad författaren med id 1 heter. Det är nu din uppgift att lösa detta. Skapa en ny controller som heter AuthorController som innehåller REST verben: GET, POST, PUT, DELETE. Ta hjälp av `AuthorRepository`. Du kan få mycket inspiration från `BooksController` men gör inte dig själv en björntjänst och kopiera allt utan sätt dig in i koden och förstå vad de olika verben gör.


---

När man ska integrera frontend med backend så är det väldigt tråkigt att behöva gå till källkoden för att se hur api:et är utformat. Därför ska vi lägga till lite dokumentation till rest-api:et. Eftersom det är tråkigt att skriva dokumentation själv, och den snabbt blir utdaterad så ska vi använda oss av [Swagger](https://swagger.io/) och [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) för att generera den. 

För lite 

- Lägg till NuGet-paketet `Swashbuckle.AspNetCore` till projektet
- Lägg till följande snippet i metoden `ConfigureServices` i filen `Startup.cs`

```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IBookRepository, BookRepository>();
    services.AddSingleton<IAuthorRepository, AuthorRepository>();
    services.AddMvc();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
    });
}
```

- Lägg till följande snippet i metoden `Configure` i filen `Startup.cs`

```cs
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

            app.UseMvc();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
```

- Surfa in på `/swagger/` och njut av din vackra API-dokumentation

- Färdig? Gött! :punch: 
- Antingen kan du bygga en frontend för ditt api, eller gå tillbaka till någon tidigare labb.
