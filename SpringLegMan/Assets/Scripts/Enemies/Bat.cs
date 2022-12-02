using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bat : MonoBehaviour
{
    public Transform bat;
    public Ease ease;
    [SerializeField] private Transform targetPos;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Bat");
            bat.DOMoveY(targetPos.position.y, 3f).SetLoops(-1, LoopType.Yoyo).SetEase(ease);
        }
    }
}
