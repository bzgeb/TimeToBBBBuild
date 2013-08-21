using UnityEngine;
using System.Collections;

public class SoundOnSpecificTick : ISoundOnTick
{
    public int playOnTick;
    void OnEnable() {
        EventManager.Register( "OnTick", OnTick );
    }

    void OnDisable() {
        EventManager.Deregister( "OnTick", OnTick );
    }

    void OnTick( params object[] args ) {
        int tick = (int)args[0];
        Debug.Log( string.Format( "Tick {0}!", tick ) );
    }
}
