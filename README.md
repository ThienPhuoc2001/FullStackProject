####fullstackprojectthienlam

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
