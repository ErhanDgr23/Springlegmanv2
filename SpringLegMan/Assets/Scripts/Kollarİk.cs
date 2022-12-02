using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kollarİk : MonoBehaviour {

    [SerializeField] float speedkol;
    [SerializeField] Transform lefthand, righthand, head;
    [SerializeField] Transform lefthandmax, lefthandmin, righthandmax, righthandmin, headmin, headmax;
    [SerializeField] Rigidbody rb;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (rb.velocity.y < 0f)
        {
            righthand.position = Vector3.Lerp(righthand.position, righthandmin.position, speedkol * Time.deltaTime);
            lefthand.position = Vector3.Lerp(lefthand.position, lefthandmin.position, speedkol * Time.deltaTime);
            head.position = Vector3.Lerp(head.position, headmin.position, speedkol * Time.deltaTime);
        }
        else
        {
            righthand.position = Vector3.Lerp(righthand.transform.position, righthandmax.position, speedkol * Time.deltaTime);
            lefthand.position = Vector3.Lerp(lefthand.transform.position, lefthandmax.position, speedkol * Time.deltaTime);
            head.position = Vector3.Lerp(head.position, headmax.position, speedkol * Time.deltaTime);
        }
    }

    void OnAnimatorIK()
    {
        if (anim)
        {
            if (righthand != null)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.RightHand, righthand.position);
            }

            if (lefthand != null)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, lefthand.position);
            }

            if (head != null)
            {
                anim.SetLookAtWeight(1f, 1f, 1f, 1f, 1f);
                anim.SetLookAtPosition(head.position);
            }
        }
    }
}
