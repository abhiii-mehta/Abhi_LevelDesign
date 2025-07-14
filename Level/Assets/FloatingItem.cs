using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FloatingItem : MonoBehaviour
{
    public float floatStrength = 0.5f;       // How far it moves up and down
    public float floatSpeed = 2f;            // How fast it floats
    public float rotationSpeed = 45f;        // Degrees per second

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        // Make sure collider is trigger
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    void Update()
    {
        // Floating up and down
        float newY = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = startPos + new Vector3(0, newY, 0);

        // Rotate around Y-axis in place
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // TODO: Add pickup logic here (sound, inventory, etc.)
            Debug.Log("Picked up: " + gameObject.name);

            // Destroy the pickup
            Destroy(gameObject);
        }
    }
}
