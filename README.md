####fullstackprojectthienlam


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
