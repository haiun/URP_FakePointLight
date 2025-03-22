using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis, Time.deltaTime * 30f);
    }
}
