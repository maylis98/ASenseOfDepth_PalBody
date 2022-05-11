using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterOrder : MonoBehaviour
{
    public void ARSceneEnd(bool endMemory)
    {
        EventManager.TriggerEvent("CloseMemory", endMemory);
    }

    public void SendInputdata(bool moveButtonIsPressed)
    {
        EventManager.TriggerEvent("PlayerInput", moveButtonIsPressed);
    }
    public void SendBackwards(bool backwardButtonIsPressed)
    {
        EventManager.TriggerEvent("PlayerBack", backwardButtonIsPressed);
    }

}

