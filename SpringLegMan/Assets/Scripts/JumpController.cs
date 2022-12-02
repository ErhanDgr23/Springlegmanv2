using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Line"))
        {

            Debug.Log("Girdi");
            //rb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
            Vector3 jumpDir = other.gameObject.transform.up;
            //rb.AddForce(jumpDir * speed * Time.deltaTime, ForceMode.Impulse);
            rb.velocity = jumpDir * speed * Time.deltaTime;
            Destroy(other.transform.parent.gameObject);
        }
    }
}
