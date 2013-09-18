using UnityEngine;
using System.Collections;

public class PunchTower : MonoBehaviour
{
    void Punch() {
        iTween.PunchRotation( gameObject, new Vector3( 10f, 0, 0 ), 1f );
    }
}
