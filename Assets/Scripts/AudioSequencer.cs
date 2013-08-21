using UnityEngine;
using System.Collections;

public class AudioSequencer : MonoBehaviour {
    public float bpm;
	// Use this for initialization
	void Start () {
        InvokeRepeating( "Tick", 60.0f / bpm, 60.0f / bpm );
	}

    void Tick() {
        EventManager.Push( "OnTick" );
    }
}
