using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private Transform centerBackground;
    
    // Update is called once per frame
    void Update()
    {
        centerBackground.position = new Vector2(transform.position.x + 5f, centerBackground.position.y);
    }
}
