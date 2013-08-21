using UnityEngine;
using System.Collections;

public class SoundOnTick : MonoBehaviour
{
    void OnEnable() {
        EventManager.Register( "OnTick", OnTick );
    }

    void OnDisable() {
        EventManager.Deregister( "OnTick", OnTick );
    }

    void OnTick( params object[] args ) {
        Debug.Log( "Tick!" );
    }
}
