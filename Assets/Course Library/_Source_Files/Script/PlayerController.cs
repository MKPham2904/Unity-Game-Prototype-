using NUnit.Framework;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Speed of movement in units per second
    public bool hasPowerup = false;
    Rigidbody rb;
    GameObject focalPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * verticalInput * speed);
    }
    void OTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
        }
    }
    void OCollisionEnter(Collision collision)
    {
        if (other.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Collier With" + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
