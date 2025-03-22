using UnityEngine;

public class SelfShadowController : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    
    [SerializeField]
    private bool ShadowActive = false;

    private const string ToggleName = "Active Self Shadow";
    private readonly int _prop = Shader.PropertyToID("_Set_SystemShadowsToBase");
    
    private void Start()
    {
        var value = ShadowActive ? 1f : 0f;
        foreach (var material in materials)
        {
            material.SetFloat(_prop, value);
        }

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
    }
    /*
    private void OnGUI()
    {
        ShadowActive = GUI.Toggle(new Rect(0,0,100,20), ShadowActive, ToggleName);
        var value = ShadowActive ? 1f : 0f;
        foreach (var material in materials)
        {
            material.SetFloat(_prop, value);
        }
    }
    */
}
