using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Plankton : MonoBehaviour {

    public Transform plankton;
    private Animator anim;
    [SerializeField] private Transform targetPos1, targetPos2;
    [SerializeField] private Transform raytr;
    public bool dur, yurubasla = true, ters = false;
    DrawLine drawlinesc;

    void Start()
    {
        drawlinesc = GameObject.FindGameObjectWithTag("drawline").GetComponent<DrawLine>();
        targetPos1.transform.SetParent(null);
        targetPos2.transform.SetParent(null);
        anim = GetComponent<Animator>();
        hareketloop();
    }

    // Update is called once per frame
    void Update()
    {
        if (drawlinesc.oyunbasladi)
        {
            if (yurubasla)
            {
                if (!ters)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos1.position, 1f * Time.deltaTime);

                    if (transform.position.x >= targetPos1.position.x)
                        ters = true;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos2.position, 1f * Time.deltaTime);

                    if (transform.position.x <= targetPos2.position.x)
                        ters = false;
                }
            }

            if (Physics.Raycast(raytr.transform.position, raytr.transform.forward, out RaycastHit hit, 7f))
            {
                if (hit.collider.gameObject == null)
                {
                    hareketloop();
                }

                if (hit.collider.tag == "Player" && !dur)
                {
                    hareketloopkir();
                    anim.SetBool("attack", true);
                    yurubasla = false;
                    dur = true;
                }
            }
        }     
    }

    public void objeat()
    {

    }

    public void animdurdur()
    {
        anim.SetBool("attack", false);
        hareketloop();
        dur = false;
    }

    public void hareketloopkir()
    {
        yurubasla = false;
    }

    public void hareketloop()
    {
        yurubasla = true;
    }
}
