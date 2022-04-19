using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterOrder : MonoBehaviour
{
    public void ARSceneEnd(bool endMemory)
    {
        Debug.Log("the AR scene is finished");
        EventManager.TriggerEvent("CloseMemory", endMemory);
    }

    public void SendInputdata(bool moveButtonIsPressed)
    {
        EventManager.TriggerEvent("PlayerInput", moveButtonIsPressed);
    }

    public void StartGameTimeline(bool gameIsStarted)
    {
        Debug.Log("game timeline is started");
        EventManager.TriggerEvent("StartGame", gameIsStarted);
    }

}

