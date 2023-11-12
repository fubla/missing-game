using System.Collections;
using UnityEngine;

public class QuestManager : DialogueManager
{
    #region Singleton

    public new static QuestManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of DialogueManager found!");
            return;
        }
        instance = this;
    }

    #endregion
    
}
