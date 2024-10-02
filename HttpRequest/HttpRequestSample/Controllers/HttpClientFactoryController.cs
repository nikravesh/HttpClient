using HttpSample.Models;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Text.Json;

namespace HttpRequestSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HttpClientFactoryController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientFactoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        using HttpClient httpClient = _httpClientFactory.CreateClient();
        httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        string result = await httpClient.GetStringAsync("/posts");

        List<JsonModel> jsonObject = JsonConvert.DeserializeObject<List<JsonModel>>(result);
        return Ok(jsonObject);
    }
}
