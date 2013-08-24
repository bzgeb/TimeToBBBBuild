using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Towers : MonoBehaviour
{
    int previouslySelectedIndex;
    public List<GameObject> towers;

    GameObject GetNextTower() {
        previouslySelectedIndex = (previouslySelectedIndex + 1) % towers.Count;
        return towers[previouslySelectedIndex];
    }

    GameObject GetPreviousTower() {
        previouslySelectedIndex = previouslySelectedIndex - 1;
        if ( previouslySelectedIndex < 0 ) {
            previouslySelectedIndex = towers.Count - 1;
        }
        return towers[previouslySelectedIndex];
    }

    void Awake() {
        previouslySelectedIndex = 0;
    }

    void Start() {
        EventManager.Register( "RequestNextTower", RequestNextTower );
        EventManager.Register( "RequestPreviousTower", RequestPreviousTower );
    }

    void RequestNextTower( params object[] args ) {
        GameObject nextTower = GetNextTower();
        EventManager.Push( "SendNextTower", nextTower );
    }

    void RequestPreviousTower( params object[] args ) {
        GameObject previousTower = GetPreviousTower();
        EventManager.Push( "SendPreviousTower", previousTower );
    }
}
