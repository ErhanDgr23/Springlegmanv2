using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] GameObject coinNumPrefab;
    public Rigidbody rb;
   // public float speed;
    // private bool isJumping => rb.velocity.y > 0.01f;
    public CoinsManager coinsManager;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject spring;
    void Start()
    {

    }

    void Update()
    {

    }
   /* public void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.gameObject.CompareTag("Shield"))
        {
            shield.SetActive(true);
            this.gameObject.tag = "Untagged";
            Destroy(other.gameObject);
            StartCoroutine(slowAfteraWhileCoroutine());
        }
        if (other.gameObject.CompareTag("Spring"))
        {
            Destroy(other.gameObject);
            speed = 400;
            spring.SetActive(true);
            StartCoroutine(SpringTime());
        }
           }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {

            coinsManager.AddCoins(other.transform.position, 7);

            Destroy(other.gameObject);

            //Show (+7) number
            Destroy(Instantiate(coinNumPrefab, other.transform.position, Quaternion.identity), 1f);
        }
        if (other.gameObject.CompareTag("Hole"))
        {
            this.gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }
    }

    private IEnumerator slowAfteraWhileCoroutine()
    {
        yield return new WaitForSeconds(5f);
        //playerController.runningSpeed = playerController.runningSpeed - 3f;
        this.gameObject.tag = "Player";
        shield.SetActive(false);
    }

    private IEnumerator SpringTime()
    {
        yield return new WaitForSeconds(5f);
       // speed = 200;
        spring.SetActive(false);
    }

}
