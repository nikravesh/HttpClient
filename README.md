# HttpClient VS IHttpClientFactory
I want to talk about HttpClient and IHttpClientFactory, and their difference.

## HttpClient
HttpClient is a functionality in .Net that sends HTTP requests.
HttpClient has a big problem when the application sends a lot of HTTP requests or the application has a lot of concurrent users, HttpClient opens a port for each request, and we don't have a lot of ports, we have approximately 65,000 ports. of course, HttpClient implemented IDisposable and we can dispose of it, but OS (depends on OS, I describe Windows behavior) after disposing of HttpClient takes ports to 'TimeWait'status and after 240 seconds release that. so when we have many concurrent users or requests, our ports are finished and we don't have any port for another request and our request waits until release the port.

## IHttpClientFactory
To solve the HttpClient problem .Net released IHttpClientFactory, the interface works like a pipeline and orchestrates requests. IHttpClientFactory creates a pool of HttpClientHandler and it holds the HttpClientHandler instance on the pool and assigns to request to send. It doesn't dispose of the HttpClientFactory for roughly 2 minutes if the application doesn't have any request dispose of that.

## IHttpClientFactory diagram
![Build Cart Api](https://github.com/nikravesh/HttpClient/blob/main/HttpRequest/SolutionItems/IHttpClientFactory.png)

### If you want to read and learn deeply
https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory


