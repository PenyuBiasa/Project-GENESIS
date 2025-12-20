using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform followPlayer;
    public float distanceFromPlayer;
    public List<Vector2> followPlayerPositions = new List<Vector2>();
    public float allowableSampleDistance;
    public float sampleTimeDifference;
    float sampleTime;
    public float followSpeed;
    public float removeDistance;
    private Animator animator;
    private const string _horizontal = "horizontal";
    private const string _vertical = "vertical";

    void Start()
    {
        animator = GetComponent<Animator>();
        sampleTime = Time.time;
        followPlayerPositions.Add(followPlayer.position);
    }


    // void Update()
    // {
    //     if (Time.time > sampleTime)
    //     {
    //         sampleTime = Time.time + sampleTimeDifference;

    //         if (Vector2.Distance(followPlayer.position, followPlayerPositions[followPlayerPositions.Count - 1]) > allowableSampleDistance)
    //         {
    //             followPlayerPositions.Add(followPlayer.position);
    //         }
    //     }

    //     if (Vector2.Distance(transform.position,followPlayer.position) > distanceFromPlayer)
    //     {
    //         transform.position = Vector2.MoveTowards(transform.position, followPlayer.position, Time.deltaTime *followSpeed);
    //         if (Vector2.Distance(transform.position, followPlayerPositions[0]) < removeDistance)
    //         {
    //             if (followPlayerPositions.Count > 1)
    //             {
    //                 followPlayerPositions.RemoveAt(0);
    //             }
    //         }
    //     }
    // }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, followPlayer.position);

        if (distance > distanceFromPlayer)
        {
            Vector2 direction = (followPlayer.position - transform.position).normalized;

            transform.position = Vector2.MoveTowards(
                transform.position,
                followPlayer.position,
                followSpeed * Time.deltaTime
            );

            // Kirim arah ke Animator
            animator.SetFloat(_horizontal, direction.x);
            animator.SetFloat(_vertical, direction.y);

            // lastDirection = direction;
        }
        else
        {
            // Idle → tetap menghadap arah terakhir
            animator.SetFloat("horizontal", 0);
            animator.SetFloat("vertical", 0);
        }
    }

}
