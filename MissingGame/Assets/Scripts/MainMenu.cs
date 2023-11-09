using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        InitFMOD();
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
    
    [BankRef] [SerializeField] private string masterBankRef;
    [SerializeField] private GameObject loadText;
    
    public void InitFMOD()
    {
        RuntimeManager.LoadBank(masterBankRef, false);
        StartCoroutine(WaitForFMODLoading());
    }

    private IEnumerator WaitForFMODLoading()
    {
        loadText.SetActive(true);
        while (!RuntimeManager.HaveAllBanksLoaded)
        {
            yield return null;
        }
        loadText.SetActive(false);
        
        LoadFirstScene();
    }
}
