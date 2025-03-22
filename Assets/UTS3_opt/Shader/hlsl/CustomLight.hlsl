void CustomLight_File_float(out float3 Color)
{
#ifdef SHADERGRAPH_PREVIEW
    Color = float3(1,1,1);
#else
    Light  light = GetMainLight();
    Color = light.color;
#endif
}

void CustomLight_Shadow_float(float3 WorldPos, out float ShadowAtten)
{

#ifdef SHADERGRAPH_PREVIEW
    ShadowAtten = 1.0f;
#else
    /*
    #if defined(_MAIN_LIGHT_SHADOWS_SCREEN) && !defined(_SURFACE_TYPE_TRANSPARENT)
        half4 clipPos = TransformWorldToHClip(WorldPos);
        half4 shadowCoord = ComputeScreenPos(clipPos);
    #else
        half4 shadowCoord = TransformWorldToShadowCoord(WorldPos);
    #endif
    */
    /*  
    #if !defined(_MAIN_LIGHT_SHADOWS) || defined(_RECEIVE_SHADOWS_OFF)
        ShadowAtten = 1.0f;
    #endif

    #if SHADOWS_SCREEN
        ShadowAtten = SampleScreenSpaceShadowmap(shadowCoord);
    #else
        ShadowSamplingData shadowSamplingData = GetMainLightShadowSamplingData();
        half shadowStrength = GetMainLightShadowStrength();
        ShadowAtten = SampleShadowmap(shadowCoord, TEXTURE2D_ARGS(_MainLightShadowmapTexture, sampler_MainLightShadowmapTexture), shadowSamplingData, shadowStrength, false);
    #endif
    #endif */

    half cascadeIndex = ComputeCascadeIndex(WorldPos);
    half4 shadowCoord = mul(_MainLightWorldToShadow[cascadeIndex], float4(WorldPos, 1.0));
    
    ShadowSamplingData shadowSamplingData = GetMainLightShadowSamplingData();
    half4 shadowParams = GetMainLightShadowParams();
    ShadowAtten = SampleShadowmap(TEXTURE2D_ARGS(_MainLightShadowmapTexture, sampler_MainLightShadowmapTexture), shadowCoord, shadowSamplingData, shadowParams, false);
#endif

    
#if !defined (UTS_USE_RAYTRACING_SHADOW)
    ShadowAtten *= 2.0f;
    ShadowAtten = saturate(ShadowAtten);
#endif
}