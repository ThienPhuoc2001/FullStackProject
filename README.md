####fullstackprojectthienlam

[//]: # (1&#41; Set up folder structure + make git repository with git init and make a gitignore file with dotnet new gitignore &#40;optionally also gitignore the file appsettings.json&#41; &#40;Done&#41;)

[//]: # ()
[//]: # (2&#41; Create client app in "client" directory with npm create vite &#40;Done&#41;)

[//]: # ()
[//]: # (3&#41; Create server directory with c# projects Api &#40;web&#41;, Tests &#40;xunit3&#41; and DataAccess &#40;classlib&#41; &#40;Done&#41; )

[//]: # (4&#41; Add relevant Nuget packages to each project, adjust .Net project versions, and add references Tests -> Api -> DataAccess)

[//]: # (5&#41; Provision a database at Postgres Neon and connect to it using Rider's Database Tool)

[//]: # (6&#41; Build tables in the database and perform scaffolding from DataAccess project [Also see Monday, week 37 in Programming II for scaffolding steps])

[//]: # (7&#41; Add AppOptions)

[//]: # ()
[//]: # (&#40;optionally add  Dependency injection for your DbContext to test the app options or simply trigger the DataAnnotations validations for your AppOptions properties. In my solution I did dependency injection for DbContext a few steps later&#41;)

[//]: # ()
[//]: # ([Also see Systems Development II.Testing week 37, exercise 3 for Options Pattern implementation steps])

[//]: # (8&#41; Add Dependency injection + Middleware for controllers & Swagger/OpenAPI. Then add NSwag.CodeGeneration.Typescript  [Also see Systems Development II.Testing week 37, exercise 2 for NSwag Typescript generation steps])

[//]: # (9&#41; Configure CORS in Program.cs with builder.Services.AddCors&#40;&#41;; and app.UseCors&#40;config => config.AllowAnyHeader&#40;&#41;.AllowAnyMethod&#40;&#41;.AllowAnyOrigin&#40;&#41;.SetIsOriginAllowed&#40;x => true&#41;&#41;;)

[//]: # (10&#41; Add service classes & controller classes + Dependency injection for these)

11) Create Response DTOs (and optionally define service + controller methods with signatures but empty implementation / throw new NotImplementedException(); )

You can also define constructors at this point, but I just did it in a later commit: https://github.com/uldahlalex/ProjectSolution/commit/a80d587fc9ddf12c5cb5d0b056644af4a02912a0

12) Create Dockerfile in your server directory (https://github.com/uldahlalex/todo/blob/master/server/Dockerfile (adjust path to your API project if necessary)) + fly launch to configure deployment

13) Adjust Program.cs to feature a ConfigureServices(IServiceCollection services) method (which you can call in your tests/Setup.cs file)

14) In your tests/Setup.cs, replace DbContext instance with a TestContainer instance https://github.com/uldahlalex/testcontainersdemointernational/blob/master/tests/Startup.cs

15) In your React app, set up Routing with React Router 7 data mode

16) Add jotai + jotai-devtools for global state management.

(If you want to add atoms right away, I recommend adding a few controller methods with the DTOs as response type such that you can use the models from the generated TS client file).

17) Add UI library (like DaisyUI)

18) Configure development base URL & production base URL with Vite & instantiate Typescript HTTP client from generated code like this: https://github.com/uldahlalex/todo/blob/master/client/src/baseUrl.ts

19) Add Dockerfile to client directory like this https://github.com/uldahlalex/todo/blob/master/client/Dockerfile +  fly launch --dockerfile=./Dockerfile to configure deployment

At this point all configuration / setup / installations / boilerplate are pretty much done.

Each feature from this point can be implemented like this:

Build the UI element (button / input field, etc)
Build the state container + events for the UI elements
Figure out what data you need to send/retrieve from backend and make RequestDto and optionally response DTO from this
Build the Controller method
Build the Service method
Write a unit test for it
Re-run the API to generate the new Typescript code to use in React
Use the Typescript method to call your API from React
Make state change/feedback depending on success/failure
