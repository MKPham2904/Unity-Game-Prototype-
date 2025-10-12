using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetrb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetrb = GetComponent<Rigidbody>();
        targetrb.AddForce(RandomForce(), ForceMode.Impulse);
        targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-10, 10);
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-4, 4), -6, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
