using UnityEngine;
using System.Collections;

public class SetAnimationSpeed : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    void Start() {
        animation["Walk"].speed = speed;
    }
}
