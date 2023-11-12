using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSecretLadder : MonoBehaviour
{
    public GameObject ladder;
    public BoxCollider2D thisCollider;
    
    public void EnableLadder()
    {
        thisCollider.enabled = true;
        var children = ladder.GetComponentsInChildren<SpriteRenderer>();
        foreach (var child in children)
        {
            child.enabled = true;
        }
    }
}
