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
                oldPlayerObject = currentPlayerObject;
                currentPlayerObject = Instantiate(playerFantasy, currentPlayerObject.transform);
                Destroy(oldPlayerObject);
                break;
            case 1:
                oldPlayerObject = currentPlayerObject;
                currentPlayerObject = Instantiate(playerFantasySword, currentPlayerObject.transform);
                Destroy(oldPlayerObject);
                canAttack = true;
                break;
            case 2:
                oldPlayerObject = currentPlayerObject;
                currentPlayerObject = Instantiate(playerReal, currentPlayerObject.transform);
                Destroy(oldPlayerObject);
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
