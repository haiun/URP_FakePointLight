using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RequireDepthNormalPrepassRendererFeature : ScriptableRendererFeature
{
    public ScriptableRenderPassInput requirements = ScriptableRenderPassInput.None;

    private EmptyRenderPass m_FullScreenPass;

    public override void Create()
    {
        m_FullScreenPass = new EmptyRenderPass(name);
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (renderingData.cameraData.cameraType == CameraType.Preview
            || renderingData.cameraData.cameraType == CameraType.Reflection
            || UniversalRenderer.IsOffscreenDepthTexture(ref renderingData.cameraData))
            return;

        m_FullScreenPass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
        m_FullScreenPass.ConfigureInput(requirements);
        
        m_FullScreenPass.requiresIntermediateTexture = false;
        
        renderer.EnqueuePass(m_FullScreenPass);
    }

    protected override void Dispose(bool disposing)
    {
        m_FullScreenPass.Dispose();
    }

    internal class EmptyRenderPass : ScriptableRenderPass
    {
        public EmptyRenderPass(string passName)
        {
            profilingSampler = new ProfilingSampler(passName);
        }

        public void Dispose()
        {
            
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            using (new ProfilingScope(profilingSampler))
            {
                
            }
        }
    }
}
