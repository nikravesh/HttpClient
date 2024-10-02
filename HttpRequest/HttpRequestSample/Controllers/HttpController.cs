using HttpSample.Models;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace HttpRequestSample.Controllers;

[Route("api/[controller]")]
[ApiController]

public class HttpController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        using HttpClient httpClient = new();
        httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        string result = await httpClient.GetStringAsync("/posts");

        List<JsonModel> jsonObject = JsonConvert.DeserializeObject<List<JsonModel>>(result);
        return Ok(jsonObject);
    }
}
