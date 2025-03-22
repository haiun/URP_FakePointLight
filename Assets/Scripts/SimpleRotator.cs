using UnityEngine;

public class SimpleRotator : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationAxis = Vector3.up;
    
    [SerializeField]
    private float rotationSpeed = 30f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis, Time.deltaTime * rotationSpeed);
    }
}
