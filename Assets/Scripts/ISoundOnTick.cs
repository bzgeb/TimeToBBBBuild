using UnityEngine;
using System.Collections;

// ISoundOnTick is a fake interface so that I can use GetComponent() to grab any SoundOnTick scripts
public class ISoundOnTick : MonoBehaviour
{
    void OnTick( params object[] args ) { }
}
