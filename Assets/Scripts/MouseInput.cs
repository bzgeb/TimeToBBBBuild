﻿using UnityEngine;
using System.Collections;
using RainComponent = RAIN.Core.RAINComponent;

public class MouseInput : MonoBehaviour
{
    GameObject hoverObject;
    GameObject planeCollider;
    public Material hoverMaterial;
    public GameObject wall;
    int towerIndex;
    void Awake() {
        planeCollider = new GameObject( "PlaneCollider" );
        BoxCollider box = planeCollider.AddComponent<BoxCollider>();
        box.transform.position = Vector3.zero;
        box.transform.rotation = Quaternion.identity;
        box.size = new Vector3( 1000, 0f, 1000 );
        planeCollider.layer = LayerMask.NameToLayer( "GroundLayer" );
        planeCollider.hideFlags = HideFlags.HideInHierarchy;

        if ( wall != null ) {
            SetHoverObject( wall, 0 );
        }
    }

    void OnEnable() {
        EventManager.Register( "SendNextTower", SetHoverObject );
        EventManager.Register( "SendPreviousTower", SetHoverObject );
    }

    void OnDisable() {
        EventManager.Register( "SendNextTower", SetHoverObject );
        EventManager.Register( "SendPreviousTower", SetHoverObject );
    }

    void Update() {
        Vector3 gridPoint;

        if ( hoverObject != null && GetMousePositionOnGrid( out gridPoint ) ) {
            hoverObject.transform.position = gridPoint;
        }

        if ( hoverObject != null && Input.GetMouseButtonDown( 0 ) && Camera.main.pixelRect.Contains( Input.mousePosition ) ) {
            Debug.Log( "Click: " + gridPoint );
            PlaceObject( wall, gridPoint, wall.transform.rotation, towerIndex );
        }

        if ( Input.GetAxis( "Mouse ScrollWheel" ) > 0 ) {
            EventManager.Push( "RequestNextTower" );
        }

        if ( Input.GetAxis( "Mouse ScrollWheel" ) < 0 ) {
            EventManager.Push( "RequestPreviousTower" );
        }
    }

    bool GetMousePositionOnGrid( out Vector3 gridPoint ) {
        Ray inputRay = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit hit;
        LayerMask layerMask = 1 << LayerMask.NameToLayer( "GroundLayer" );

        if ( Physics.Raycast( inputRay, out hit, 1000f, layerMask ) ) {
            gridPoint = hit.point;
            gridPoint.x = Mathf.Round( gridPoint.x );
            gridPoint.y = Mathf.Round( gridPoint.y );
            gridPoint.z = Mathf.Round( gridPoint.z );
            return true;
        }

        gridPoint = Vector3.zero;
        return false;
    }

    void SetHoverObject( params object[] args ) {
        wall = (GameObject)args[0];
        towerIndex = (int)args[1];

        if ( hoverObject != null ) {
            Destroy( hoverObject );
        }

        Vector3 gridPoint;
        Vector3 startPosition = Vector3.zero;
        if ( GetMousePositionOnGrid( out gridPoint ) ) {
            startPosition = gridPoint;
        }

        hoverObject = (GameObject)Instantiate( wall, startPosition, wall.transform.rotation );
        hoverObject.hideFlags = HideFlags.HideInHierarchy;
        hoverObject.GetComponent<MeshRenderer>().material = hoverMaterial;



        // Disable all the sound scripts
        ISoundOnTick[] soundScripts = hoverObject.GetComponents<ISoundOnTick>();
        foreach ( ISoundOnTick script in soundScripts ) {
            script.enabled = false;
        }

        RainComponent[] rainComponents = hoverObject.GetComponents<RainComponent>();
        foreach ( RainComponent rainComponent in rainComponents ) {
            Destroy( rainComponent );
        }
    }

    void PlaceObject( GameObject obj, Vector3 gridPosition, Quaternion rotation, int objIndex ) {
        int x = (int)gridPosition.x;
        int y = (int)gridPosition.z;
        Debug.Log( "X: " + x + " Y: " + y ); 
        if ( Field.data[x, y] == -1 ) {
            Field.data[x, y] = objIndex;
            Instantiate( obj, gridPosition, rotation );
        }
    }
}
