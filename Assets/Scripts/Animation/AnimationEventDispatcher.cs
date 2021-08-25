using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventDispatcher : MonoBehaviour
{
    public UnityEvent OnKeyFrameEventDispatched;

    public void Dispatch()
    {
        OnKeyFrameEventDispatched.Invoke();
    }
}
