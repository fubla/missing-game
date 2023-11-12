using Cinemachine;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera vCam;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (!vCam.Follow)
        {
            player = gameManager.GetCurrentPlayer();
            vCam.Follow = player.transform;
        }
    }
}
