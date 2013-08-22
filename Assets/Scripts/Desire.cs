using UnityEngine;
using System.Collections;
using RAIN.Core;

public class Desire : MonoBehaviour {
    public string varName;
    public float level;
    public float dropRate;

    RAINAgent ai;

	// Use this for initialization
	void Start () {
        ai = GetComponent<RAINAgent>();
        if ( ai != null ) {
            ai.Agent.actionContext.SetContextItem<float>( varName, level );
        }
	}

    void Update() {
        level -= dropRate * Time.deltaTime;

        if ( ai != null ) {
            ai.Agent.actionContext.SetContextItem<float>( varName, level );
        }
    }
}
