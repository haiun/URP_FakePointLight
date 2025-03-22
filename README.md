# URP_FakePointLight


<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-003.png?raw=true"/>

이 프로젝트는 Unity엔진에서 3D NPR(Non-Photo Realistic)렌더링 시 활용 할 수 있는 유사광원효과에 대해 안내합니다.<br>

섬광, 폭발, 머즐이펙트의 표현에 적합하다고 생각합니다.<br>

* 주요 리소스 경로
  * 확인용 씬 : Assets/FakePointLight_Comp.unity
  * 점광원 : Assets/FakePointLight/ShaderGraph/FakePointLight.shadergraph
  * 점광원(툰버전) : Assets/FakePointLight/ShaderGraph/FakePointToonLight.shadergraph

<br>
<br>

### 광원에 대한 각 오브젝트들 표현 차이 문제

셸 셰이딩 기반 캐릭터들이 등장하는 게임을 만들다 보면 한 광원에 대해 각각 다르게 반응하는 경우로 고민한 경험이 있습니다.<br>
URP기본 셰이더나 에셋스토어에서 산 에셋을 혼용한다면 메인광원에 대해 각각 리소스의 벨런스를 조정하며 화면구성을 진행 했습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-005.png?raw=true"/>

이때, 추가 광원으로 연출을 시도 한다면 조정해둔 벨런스가 망가지면서 고민이 생길 수 있습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-001.png?raw=true"/>
광원에 너무 민감하게 반응하거나, 반응하지 않는 등 벨런스유지가 쉽지 않습니다.<br>
<br>
<br>

### DepthNormalPrepass의 활성화

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-006.png?raw=true"/>

Renderer Feature에 대해 조사하던 중 PostEffect를 간편하게 구현 할 수 있도록 제공되는 FullScreenPassRenderFeature에서 포워드렌더링파이프라인에서도 ScreenNormal을 만들 수 있는 기능을 발견했습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-007.png?raw=true"/>


사용중인 FullScreenPassRenderFeature가 있다면 해당옵션을 추가하면되고, 없다면 이 프로젝트에 포함되어있는 RequireDepthNormalPrepassRendererFeature를 UniversalRendererData 추가하면 DepthNormalPrepass가 활성화 됩니다.<br>
ScreenDepth, ScreenNormal에 대한 정보가 있다면, 포워드, 포워드+파이프라인에서도 디퍼드 라이팅연산을 구현할 수 있습니다.<br>

<br>
<br>

### 큐브메쉬로 계산 영역 검출하기

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-009.png?raw=true"/>

볼록한 모양의 메쉬를 RenderFace를 Back, DepthTest를 GEqual로 렌더링 하면서 효과를 구현할 경우 화면 전체를 연산영역을 줄일 수 있습니다.
그리고, Transfrom의 LightRange가 연동되면서 일반 광원에 비해 비교적 연출작업이 용이합니다.

<br>
<br>

### 결과

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/result1.gif?raw=true"/>

개별 오브젝트가 아닌 광원단위의 후처리로 균일한 광원효과를 표현하였습니다.

<br>
<br>

### 응용 : 툰라이팅

애니메이션에서 표현되는 강력한 광원은 빛이 닫는 각도와 거리라면, 최대 밝기로 표현되면서 블룸효과와 합쳐져서 강력함을 표현하는 연출을 쉽게 볼 수 있습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/GurrenLagannEp1.gif?raw=true"/>
<img src="https://raw.githubusercontent.com/haiun/URP_FakePointLight/refs/heads/main/ReadmeImage/eva_railgun.webp"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/simon.png?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/FrierenEp9.gif?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-008.png?raw=true"/>

<br>
<br>
비슷한 느낌이 나도록 배치해보았습니다.<br>


<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/resultex1.gif?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/resultex2.gif?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/resultex3.gif?raw=true"/>
