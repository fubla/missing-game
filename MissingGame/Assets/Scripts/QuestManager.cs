using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Animator questScrollAnimator;

    public void OpenQuest()
    {
        questScrollAnimator.SetBool("IsOpen", true);
    }

    public void CloseQuest()
    {
        questScrollAnimator.SetBool("IsOpen", false);
    }
    
}
