using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    private Vector3 offSet;
    private void Awake()
    {
        offSet = player.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position - offSet;
    }
}
