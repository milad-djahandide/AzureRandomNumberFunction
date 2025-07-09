using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker.Http;
using System.Text.Json;

namespace RandomNumberFunction;

public class GenerateRandomNumber
{
    private readonly ILogger<GenerateRandomNumber> _logger;

    public GenerateRandomNumber(ILogger<GenerateRandomNumber> logger)
    {
        _logger = logger;
    }

    [Function("GenerateRandomNumber")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var rng = new Random();
        var number = rng.Next(1, 100);

        return new OkObjectResult(new { number });
    }
}
