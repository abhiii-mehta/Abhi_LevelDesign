using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatStrength = 0.5f;       // How far it moves up and down
    public float floatSpeed = 2f;            // How fast it floats
    public float rotationSpeed = 45f;        // Degrees per second

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Floating up and down
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = startPos + new Vector3(0, newY, 0);

        // Rotating around Y axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
