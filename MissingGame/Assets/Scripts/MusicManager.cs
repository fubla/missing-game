using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter musicEmitter;
    public static MusicManager Instance { get; private set; }

    public GameObject player;

    public float playerXpos;

    private float musicInfluence;
    private string _currentScene;

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
        _currentScene = scene.name;

        switch (_currentScene)
        {
            case "Level1":
                musicEmitter.Play();
                break;
            case "Level2":
                soundEmitter.SetParameter("HorizontalControl", 1);
                _horizontalControl = true;
                musicInfluence = 50f;
                break;
            case "Level3":
                _horizontalControl = false;
                soundEmitter.SetParameter("HorizontalControl", 0);
                break;
            case "Level4":
                _horizontalControl = true;
                soundEmitter.SetParameter("HorizontalControl", 1);
                musicInfluence = 0;
                break;
            case "LevelHome":
                _horizontalControl = false;
                soundEmitter.SetParameter("InHome", 1);
                break;
            case "EndScreen":
                soundEmitter.SetParameter("MusicEnd", 1);
                break;

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
        
        soundEmitter.SetParameter("PlayerPos", playerXpos + musicInfluence);
    }
}
