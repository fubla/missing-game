using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    public GameObject player;

    public float playerXpos;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneChange;
        }
    }

    private void OnSceneChange(Scene scene, LoadSceneMode mode)
    {
        player = null;
        StartCoroutine(WaitABitToAssignPlayer());
    }

    private IEnumerator WaitABitToAssignPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(!player)
            return;

        playerXpos = player.transform.position.x;
    }
}
