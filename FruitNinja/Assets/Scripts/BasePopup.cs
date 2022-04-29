using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    public virtual void Open()
    {
        //gameObject.SetActive(true);
        if (!IsActive())
        {
            this.gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENED);
        }
        else
        {
            Debug.LogError(this + ".Open() - trying to open a popup that is active!");
        }
    }

    public virtual void Close()
    {
        //gameObject.SetActive(false);

        if (IsActive())
        {
            this.gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
        else
        {
            Debug.LogError(this + ".Close() - trying to close a popup that is inactive!");
        }
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
