using System.Collections;
using NUnit.Framework;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Speed of movement in units per second
    public bool hasPowerup = false;
    Rigidbody rb;
    GameObject focalPoint;
    private float powerupStrength = 15.0f;
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
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
        }
    }
    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody enemyrb = GetComponent<Rigidbody>();
        Vector3 AwayfromPlayer = (collision.gameObject.transform.position - transform.position);
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Debug.Log("Collier With" + collision.gameObject.name + " with powerup set to " + hasPowerup);
            enemyrb.AddForce(AwayfromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
