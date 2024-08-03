// AppHost 자체 설정
var builder = DistributedApplication.CreateBuilder(args);

// cache 추가
var cache = builder.AddRedis("cache");

var config = builder.Configuration;

// ApiApp의 설정을 AppHost에서 전달
var apiapp = builder.AddProject<Projects.AspireYouTubeSummariser_ApiApp>("apiapp")
                    .WithExternalHttpEndpoints()
                    .WithEnvironment("OpenAI__Endpoint", config["OpenAI:Endpoint"])
                    .WithEnvironment("OpenAI__ApiKey", config["OpenAI:ApiKey"])
                    .WithEnvironment("OpenAI__DeploymentName", config["OpenAI:DeploymentName"]);

// cache, apiapp을 참조하는 webapp 추가
builder.AddProject<Projects.AspireYouTubeSummariser_WebApp>("webapp")
       .WithExternalHttpEndpoints()
       .WithReference(cache)
       .WithReference(apiapp);

// 설정이 완료된 다음에 런해야한다 ~!
builder.Build().Run();