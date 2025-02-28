// See https://aka.ms/new-console-template for more information

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;

// Semantic kernel initialization
var kernel = Kernel
    .CreateBuilder()
    .AddOpenAIChatCompletion(
        // modelId: "llama-3.2-3b-instruct",
        modelId: "phi-3.1-mini-128k-instruct",
        apiKey: null,
        endpoint: new Uri("http://localhost:1234/v1")
        )
    .Build();

// var prompt = "Write a short poem about cats";
var prompt = "Rewrite the input as something that would be said by a cat {{$input}}";

var function = kernel.CreateFunctionFromPrompt(prompt, new OpenAIPromptExecutionSettings
{
    TopP = 0.5,
    MaxTokens = 1000
});
var response = await kernel.InvokeAsync(function, new() 
{
    ["input"] = "Tell david that I'm going to finish the business plan by the end of the week."
});

Console.WriteLine(response);