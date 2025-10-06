using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rb;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed);
    }
}
