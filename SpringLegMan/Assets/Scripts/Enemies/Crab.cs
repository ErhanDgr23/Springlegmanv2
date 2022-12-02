using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Crab : MonoBehaviour
{

    public Transform crab;
    private Animator anim;
    [SerializeField] private Transform targetPos;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Crab");
            crab.DOMoveX(targetPos.position.x, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }

    }
}
