using UnityEngine;
using System.Collections;

public class ShakeTower : MonoBehaviour
{
    void Shake() {
        iTween.ShakeScale( gameObject, new Vector3( 0.5f, 0.5f, 0.5f ), 0.8f );
    }
}
