using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class CharacterSpawner : MonoBehaviour {
    public GameObject blankCharacterPrefab;

    GameObject SpawnCharacter() {
        GameObject newCharacter = (GameObject)Instantiate( blankCharacterPrefab, Vector3.zero, Quaternion.identity );

        Array values = Enum.GetValues( typeof(Needs) );
        int firstParameter = Random.Range( 0, values.Length - 1 );

        int secondParameter = Random.Range( 0, values.Length - 1 );
        while ( secondParameter == firstParameter ) {
            secondParameter = Random.Range( 0, values.Length - 1 );
        }

        int thirdParameter = Random.Range( 0, values.Length - 1 );
        while ( thirdParameter == firstParameter || thirdParameter == secondParameter ) {
            thirdParameter = Random.Range( 0, values.Length - 1 ); 
        }

        AddDesire( firstParameter, newCharacter );
        AddDesire( secondParameter, newCharacter );
        AddDesire( thirdParameter, newCharacter );

        return newCharacter;
    }

    void AddDesire( int index, GameObject character ) {
        Array needs = Enum.GetValues( typeof(Needs) );
        Desire newDesire = character.AddComponent<Desire>();

        newDesire.varName = needs.GetValue( index ).ToString();
        newDesire.level = 20;
        newDesire.dropRate = 1;
    }

    void Update() {
        if ( Input.GetKeyDown( KeyCode.S ) ) {
            SpawnCharacter();
        }
    }
}
