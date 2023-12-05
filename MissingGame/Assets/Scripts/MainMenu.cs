using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(InitFMODAsync());
    }

    [BankRef] [SerializeField] private string masterBankRef;
    [BankRef] [SerializeField] private string masterStrBankRef;
    [SerializeField] private GameObject loadText;

    private IEnumerator InitFMODAsync()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
        
        RuntimeManager.LoadBank(masterBankRef, true);
        RuntimeManager.LoadBank(masterStrBankRef, true);

        RuntimeManager.CoreSystem.mixerSuspend();
        RuntimeManager.CoreSystem.mixerResume();
        
        loadText.SetActive(true);
        while (!RuntimeManager.HaveAllBanksLoaded)
        {
            yield return null;
        }

        while (RuntimeManager.AnySampleDataLoading())
        {
            yield return null;
        }
        
        loadText.SetActive(false);

        async.allowSceneActivation = true;

        while (!async.isDone)
        {
            yield return null;
        }

    }
}
