# Unity-AsyncTask
Async task for Unity in C#

 1. Create a new object: `AsyncTask asyncTask = gameObject.AddComponent<AsyncTask>();`
 1. Set your URL: `SetUrl`
 1. *(Optional)* Add query parameters: `AddQueryParams`
 1. *(Optional)* Set the code you want to run before sending WWW request: `Before`
 1. *(Optional)* Set the code to do with the progress: `Progress`
 1. *(Optional)* Set your callback: `After`
 1. Start the task: `Start`
