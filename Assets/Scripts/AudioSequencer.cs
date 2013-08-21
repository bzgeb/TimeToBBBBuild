using UnityEngine;
using System.Collections;

public class AudioSequencer : MonoBehaviour
{
    public int tickMod;
    public float bpm;

    int currentTick;
    // Use this for initialization
    void Start() {
        InvokeRepeating( "Tick", 60.0f / bpm, 60.0f / bpm );
    }

    void Tick() {
        currentTick = (currentTick + 1) % tickMod;
        EventManager.Push( "OnTick", currentTick );
    }
}
