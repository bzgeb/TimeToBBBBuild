using UnityEngine;
using System.Collections;

public class SoundOnSpecificTick : ISoundOnTick
{
    public AudioClip clip;
    public int playOnTick;
    public ParticleSystem particleOnTick;
    public string messageOnTick;
    public int pitchIndex;

    void OnEnable() {
        EventManager.Register( "OnTick", OnTick );
    }

    void OnDisable() {
        EventManager.Deregister( "OnTick", OnTick );
    }

    void OnTick( params object[] args ) {
        int tick = (int)args[0];
        if ( tick == playOnTick ) {
            Debug.Log( string.Format( "Specific Tick {0}!", tick ) );
            audio.clip = clip;
            audio.pitch = Pitch.pitches[pitchIndex];
            audio.Play();

            if ( particleOnTick != null ) {
                particleOnTick.Play();
            }

            if ( messageOnTick != null && messageOnTick != "" ) {
                SendMessage( messageOnTick, SendMessageOptions.DontRequireReceiver );
            }
        }
    }
}
