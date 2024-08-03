# MEMO
- 요구사항정의, 할일관리를 위한 메모

## 수행계획
- [V] 디렉토리 구조변경하고 로컬빌드
  - [V] 솔루션, 프로젝트파일 의존성 변경
- [V] gitignore 확인
- [V] 커밋/푸시할 경우 깃헙액션
- [V] 깃헙액션을 통해 Azure 배포
- [ ] 수정사항 반영 << 🔥 여기에요!!



## 요구사항정의
  
### 요청 - 기능
- [ ] .Net Aspire를 사용해 프론트/백엔드API 앱을 개발하고 Azure Container Apps 서비스에 배포

- 프론트
  - [V] frontend 디렉토리 아래 blazor로 개발
  - [V] 홈페이지에서 youtube url 링크 입력후 지정한 언어에 따른 요약결과 표시화면
  - [V] 화면UI는 자유롭게 구성하되 질문입력, 결과표시
    - [ ] 프롬프트가 원하는대로 동작하진 않음, 어떻게 고쳐야할까..
  - [V] 화면UI는 다음 요소를 반드시 포함하여야함
    - `<input id="youtube-link" />`
    - `<select id="video-language-code"></select>`
    - `<select id="summary-language-code"></select>`
    - `<button id="summary">Summary</button>`
    - `<textarea id="result"></textarea>`
  - [V] Summary 버튼을 클릭하면 백엔드 API앱의 /summarize 엔드포인트 호출하여 결과를 화면에 표시
  - [V] 외부에서 접근할 수 있도록 Url 오픈

- 백엔드
  - [ ] backend 디렉토리 아래 ASP.NET Core Web API로 개발
  - [ ] `/weather-focast` 엔드포인트 구현
  - [ ] 외부에서 접근할 수 있도록 Url 오픈
    - [ ] AppHost
    - [V] API
      - [ ] 동작을 안함
      - [ ] `/`로 접속하면 `/swagger`로 리다이렉션

요청/응답 예시
```shell
# 요청
curl -X GET \
    -H "Content-Type: application/json" \
    https://my-backend-api.koreacentral.azurecontainerapps.io/weatherforecast
  
# 응답
[{
        "date": "2024-07-24",
        "temperatureC": -9,
        "summary": "Balmy",
        "temperatureF": 16
    },
    {
        "date": "2024-07-25",
        "temperatureC": 41,
        "summary": "Sweltering",
        "temperatureF": 105
    },
    {
        "date": "2024-07-26",
        "temperatureC": 46,
        "summary": "Sweltering",
        "temperatureF": 114
    },
    {
        "date": "2024-07-27",
        "temperatureC": 48,
        "summary": "Cool",
        "temperatureF": 118
    },
    {
        "date": "2024-07-28",
        "temperatureC": 7,
        "summary": "Freezing",
        "temperatureF": 44
    }
]
```

- Azure Bicep, Github Actions를 활용해 빌드/배포자동화
  - [V] 본인 Github 계정에 레포생성/커밋
  - [V] 코드 커밋/푸시 이벤트 발생하면 Github Actions 수행
  - [V] Azure Bicep을 이용해서 인프라 생성하고 .Net Aspire 앱을 배포
  - [V] Auzre 배포 리소스 그룹은 `rg-tae0y`
  
- [ ] 산출물은 `https://aka.ms/aoai-proxy.net`으로 제출
  
  
### 추가 - 기능
- [ ] 시멘틱 커널로 프롬프트를 정제해볼까?
- [ ] 유튜브 링크를 좀더 쉽게 가져올 수는 없나?
- [V] 유튜브 자막 추출 못하거나 너무 길때 출력하는 오류메시지 처리?
- [ ] 단위테스트를 추가해볼까?  
- [ ] 배포 워크플로우를 로컬>Azure를 막고, dev환경을 추가해볼까?

### 추가 - 비기능
- [ ] apphost는 어디에 둬야 편할까? 