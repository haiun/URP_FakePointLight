# URP_FakePointLight


<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-003.png?raw=true"/>

이 프로젝트는 Unity 엔진에서 3D NPR(Non-Photo Realistic) 렌더링 시 활용할 수 있는 유사 광원 효과에 대해 안내합니다.<br>
이 유사 광원 효과는 섬광, 폭발, 머즐 이펙트의 표현에 적합하다고 생각합니다.<br>

* 주요 리소스 경로
  * 확인용 씬 : Assets/FakePointLight_Comp.unity
  * 점광원 : Assets/FakePointLight/ShaderGraph/FakePointLight.shadergraph
  * 점광원(툰버전) : Assets/FakePointLight/ShaderGraph/FakePointToonLight.shadergraph

<br>
<br>

### 광원에 대한 각 오브젝트들 표현 차이 문제

셸 셰이딩 기반 캐릭터들이 등장하는 게임을 만들다 보면, 한 광원에 대해 각각 다르게 반응하는 상황에 대해 고민한 경험이 있습니다.<br>
URP 기본 셰이더나 에셋스토어에서 구입한 에셋을 혼용하면, 메인 광원에 대해 각 리소스의 벨런스를 조정하며 화면 구성을 진행했습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-005.png?raw=true"/>

이때, 추가 광원으로 연출을 시도 한다면 조정해둔 벨런스가 망가지면 추가적인 조정이 필요할 수 있습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-001.png?raw=true"/>
광원에 너무 민감하게 반응하거나 반응하지 않는 등, 벨런스를 유지하는 것이 쉽지 않습니다.<br>
<br>
<br>

### DepthNormalPrepass의 활성화

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-006.png?raw=true"/>

Renderer Feature에 대해 조사하던 중, PostEffect를 간편하게 구현할 수 있도록 제공되는 FullScreenPassRenderFeature에서 포워드 렌더링 파이프라인에서도 ScreenNormal을 생성하는 기능을 발견했습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-007.png?raw=true"/>


사용 중인 FullScreenPassRenderFeature가 있다면 해당 옵션을 추가하면 되고, 없다면 이 프로젝트에 포함된 RequireDepthNormalPrepassRendererFeature를 UniversalRendererData에 추가하면 DepthNormalPrepass가 활성화됩니다.<br>
ScreenDepth와 ScreenNormal에 대한 정보가 있다면, 포워드 및 포워드+ 파이프 라인에서도 디퍼드 라이팅 연산을 구현할 수 있습니다.<br>

<br>
<br>

### 큐브메쉬로 계산 영역 검출하기

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-009.png?raw=true"/>

볼록한 모양의 메쉬를 RenderFace를 Back으로 설정하고, DepthTest를 GEqual로 설정하여 렌더링 효과를 구현하면, 화면의 일부 영역만 연산하여 효율성을 높일 수 있습니다.<br>
또한, Transform의 LightRange가 연동됨으로써 일반 광원에 비해 연출 작업이 더 수월해집니다.<br>

<br>
<br>

### 결과

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/result1.gif?raw=true"/>

개별 오브젝트가 아닌 광원 단위로 후처리를 통해 균일한 광원 효과를 구현하였습니다.<br>

<br>
<br>

### 응용 : 툰라이팅

애니메이션에서 표현되는 강력한 광원은 빛이 닿는 각도와 거리 기준으로 최대 밝기로 표현되며, 블룸 효과와 결합되어 강력함을 강조하는 연출을 쉽게 볼 수 있습니다.<br>

<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/GurrenLagannEp1.gif?raw=true"/>
<img src="https://raw.githubusercontent.com/haiun/URP_FakePointLight/refs/heads/main/ReadmeImage/eva_railgun.webp"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/simon.png?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/FrierenEp9.gif?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/K-008.png?raw=true"/>

<br>
<br>
위 연출과 비슷한 느낌을 주기 위해 배치해 보았습니다.<br>


<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/resultex1.gif?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/resultex2.gif?raw=true"/>
<img src="https://github.com/haiun/URP_FakePointLight/blob/main/ReadmeImage/resultex3.gif?raw=true"/>
