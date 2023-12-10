using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    private bool visible;

    private FMOD.Studio.Bus masterBus;

    private FMOD.Studio.EventInstance pauseSnap;

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ToggleShowHide()
    {
        visible = !visible;
        pauseMenu.SetActive(visible);

        if (!pauseSnap.isValid())
            pauseSnap = FMODUnity.RuntimeManager.CreateInstance("{4c3a25a8-eb96-4764-b5bf-3ff05a75d3dc}");
        
        if (visible)
            pauseSnap.start();
        else
            pauseSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleShowHide();
        }
    }

    public void ReturnToMainMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ToggleShowHide();
            return;
        }
        
        masterBus = FMODUnity.RuntimeManager.GetBus("{061d697e-6410-465e-903b-acfe9058811d}");
        masterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        visible = false;
        pauseMenu.SetActive(visible);
        pauseSnap.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene(0);
    }
}
