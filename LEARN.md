# LEARN
학습한 내용을 정리합니다

- 프로젝트 경로를 바꾸고 솔루션파일에서 프로젝트를, 각 프로젝트에서 다른 프로젝트를 인식하지 못함
  - 루트 디렉토리에서 솔루션 새로 생성하고 각 프로젝트를 추가 `dotnet sln MySolution.sln add backend/AppHost/AppHost.csproj`
  - 각 프로젝트 csproj파일에서 상대경로 수정 `..\..\front\{생략}`

- `dotnet build`는 솔루션 단위로 가능한데, `dotnet run`은 프로젝트 단위로 가능

- `AppHost`는 어디에 위치해야하는가?
  - AppHost 역할은?
  - Azure 배포할때 front/backend를 분리해서 배포하는가?
  - 일단 합쳐서해보자

- 빌드는 성공했지만 로직을 처리하지 못한다~
```
System.UriFormatException: Invalid URI: The format of the URI could not be determined.
```

- 깃헙에 openai 키값 커밋을 안해뒀더니 이제 여기서 null 오류가 난다! 보통 다른 사람들은 어떻게 하지? 

- `azd`
```shell
#Azure 배포설정
AZURE_ENV_NAME="tae0y"
azd init -e $AZURE_ENV_NAME

#깃헙 시크릿 설정
gh secret set AZURE_OPENAI_ENDPOINT --body "{{ Azure OpenAI Proxy Service Endpoint }}" --repo {{ GITHUB_ID }}/aspire-app-dev-in-a-day-ko
gh secret set AZURE_OPENAI_API_KEY --body "{{ Azure OpenAI Proxy Service Access Code }}" --repo {{ GITHUB_ID }}/aspire-app-dev-in-a-day-ko
gh secret set AZURE_OPENAI_DEPLOYMENT_NAME --body "{{ Azure OpenAI Proxy Service Deployment Name }}" --repo {{ GITHUB_ID }}/aspire-app-dev-in-a-day-ko

#깃헙-애저 파이프라인 설정
azd pipeline config

#배포
git push
```

