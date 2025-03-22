# URP_FakePointLight


<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-003.png?raw=true"/>

이 프로젝트는 Unity엔진에서 3D NPR(Non-Photo Realistic)렌더링 시 활용 할 수 있는 유사광원효과에 대해 안내합니다.<br>

섬광, 폭발, 머즐이펙트의 표현에 적합하다고 생각합니다.
<br>
<br>

### 추가 광원에 표현다양성 문제

셸 셰이딩 기반 캐릭터들이 등장하는 게임을 만들다 보면 한 광원에 대해 각각 다르게 반응하는 경우로 고민한 경험이 있을겁니다.<br>
URP기본 셰이더나 에셋스토어에서 산 에셋을 혼용한다면 메인광원에 대해 각각 리소스의 벨런스를 조정하며 화면구성을 진행 했을겁니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-005.png?raw=true"/>

이때, 추가 광원으로 연출을 시도 한다면 조정해둔 벨런스가 망가지면서 고민이 생길 수 있습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-001.png?raw=true"/>
<br>
<br>

### DepthNormalPrepass의 발견

Renderer Feature에 대해 조사하던 중 PostEffect를 간편하게 구현 할 수 있도록 제공되는 FullScreenPassRenderFeature에서 Forward에서도 ScreenNormal을 만들 수 있는 기능을 발견했습니다.<br>

ScreenColor, ScreenDepth, ScreenNormal에 대한 정보가 있다면, 디퍼드렌더링에서의 라이팅연산의 제료가 모두 있기 때문에 큐브매시 기반으로 포인트라이트를 구현해봤습니다.

<br>
<br>

### 접근



<br>
<br>

### 결과

<br>
<br>

### 응용

<img src="https://raw.githubusercontent.com/haiun/URP_FakePointLight/refs/heads/main/ReadmeImage/eva_railgun.webp"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/simon.png?raw=true"/>
