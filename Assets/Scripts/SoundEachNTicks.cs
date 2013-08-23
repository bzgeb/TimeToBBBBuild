﻿using UnityEngine;
using System.Collections;

public class SoundEachNTicks : ISoundOnTick
{
    public AudioClip clip;
    public int playEachNTicks;
    public ParticleSystem particleOnTick;
    public string messageOnTick;
    void OnEnable() {
        EventManager.Register( "OnTick", OnTick );
    }

    void OnDisable() {
        EventManager.Deregister( "OnTick", OnTick );
    }

    void OnTick( params object[] args ) {
        int tick = (int)args[0];
        if ( tick % playEachNTicks == 0 ) {
            Debug.Log( string.Format( "Each N Ticks {0}!", tick ) );
            audio.PlayOneShot( clip );

            if ( particleOnTick != null ) {
                particleOnTick.Play();
            }

            if ( messageOnTick != null && messageOnTick != "" ) {
                SendMessage( messageOnTick, SendMessageOptions.DontRequireReceiver );
            }
        }
    }
}
