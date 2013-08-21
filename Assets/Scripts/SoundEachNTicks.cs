using UnityEngine;
using System.Collections;

public class SoundEachNTicks : ISoundOnTick
{
    public int playEachNTicks;
    void OnEnable() {
        EventManager.Register( "OnTick", OnTick );
    }

    void OnDisable() {
        EventManager.Deregister( "OnTick", OnTick );
    }

    void OnTick( params object[] args ) {
        int tick = (int)args[0];
        if ( tick % playEachNTicks == 0 ) {
            Debug.Log( string.Format( "Tick {0}!", tick ) );
        }
    }
}
