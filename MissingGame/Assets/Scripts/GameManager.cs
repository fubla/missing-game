using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerFantasy;
    public GameObject playerFantasySword;
    public GameObject playerReal;

    public Transform playerStart;
    public GameObject startPlayerObject;
    private GameObject currentPlayerObject;

    private GameObject oldPlayerObject;
    private Transform oldPlayerTransform;

    private bool canAttack;
    
    void Start()
    {
        currentPlayerObject = Instantiate(startPlayerObject, playerStart.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // mode: 0 - Fantasy, 1 - Fantasy with sword, 2 - Real
    public void ActivatePlayerMode(int mode)
    {
        switch (mode)
        {
            case 0:
                oldPlayerTransform = currentPlayerObject.transform;
                Destroy(currentPlayerObject);
                currentPlayerObject = Instantiate(playerFantasy, oldPlayerTransform.position, Quaternion.identity);
                break;
            case 1:
                oldPlayerTransform = currentPlayerObject.transform;
                Destroy(currentPlayerObject);
                currentPlayerObject = Instantiate(playerFantasySword, oldPlayerTransform.position, Quaternion.identity);
                canAttack = true;
                break;
            case 2:
                oldPlayerTransform = currentPlayerObject.transform;
                Destroy(currentPlayerObject);
                currentPlayerObject = Instantiate(playerReal, oldPlayerTransform.position, Quaternion.identity);
                canAttack = true;
                break;
        }
    }

    public bool CanPlayerCanAttack()
    {
        return canAttack;
    }

    public GameObject GetCurrentPlayer()
    {
        return currentPlayerObject;
    }
}
