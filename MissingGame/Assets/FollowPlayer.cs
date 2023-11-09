using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera vCam;
    
    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!vCam.Follow)
        {
            player = FindObjectOfType<GameManager>().GetCurrentPlayer();
            vCam.Follow = player.transform;
            vCam.Follow = player.transform;
        }
        
    }
}
