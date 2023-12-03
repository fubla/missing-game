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

    public FMODUnity.StudioEventEmitter soundEmitter;

    private bool _horizontalControl;

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

        if (scene.name == "Level2")
        {
            soundEmitter.SetParameter("HorizontalControl", 1);
            _horizontalControl = true;
        }

        if (scene.name == "LevelHome")
        {
            _horizontalControl = false;
            soundEmitter.SetParameter("InHome", 1);
        }

        if (scene.name == "EndScreen")
        {
            soundEmitter.SetParameter("MusicEnd", 1);
        }
    }

    private IEnumerator WaitABitToAssignPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(!player || !_horizontalControl)
            return;
        
        playerXpos = player.transform.position.x;
        
        soundEmitter.SetParameter("PlayerPos", playerXpos);
    }
}
