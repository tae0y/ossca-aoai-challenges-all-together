var builder = DistributedApplication.CreateBuilder(args);

// 이 구문을 추가해서 레디스 캐시 사용
var cache = builder.AddRedis("cache");

// 추가
var config = builder.Configuration;

// 수정 : ApiApp의 설정을 AppHost에서 가져다준다
var apiapp = builder.AddProject<Projects.AspireYouTubeSummariser_ApiApp>("apiapp")
                    .WithEnvironment("OpenAI__Endpoint", config["OpenAI:Endpoint"])
                    .WithEnvironment("OpenAI__ApiKey", config["OpenAI:ApiKey"])
                    .WithEnvironment("OpenAI__DeploymentName", config["OpenAI:DeploymentName"]);

// 이 구문을 추가해서 레디스를 포함해 앱빌드
builder.AddProject<Projects.AspireYouTubeSummariser_WebApp>("webapp")
       // 추가 👇
       .WithExternalHttpEndpoints()
       // 추가 👆
       .WithReference(cache)
       .WithReference(apiapp);
   
// 설정이 완료된 다음에 런해야한다 ~!
builder.Build().Run();