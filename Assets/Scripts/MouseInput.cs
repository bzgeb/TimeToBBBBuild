﻿using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour
{
    GameObject planeCollider;
    public Object wall;
    void Awake() {
        planeCollider = new GameObject( "PlaneCollider" );
        BoxCollider box = planeCollider.AddComponent<BoxCollider>();
        box.transform.position = Vector3.zero;
        box.transform.rotation = Quaternion.identity;
        box.size = new Vector3( 1000, 0f, 1000 );
        planeCollider.layer = LayerMask.NameToLayer( "GroundLayer" );
        planeCollider.hideFlags = HideFlags.HideInHierarchy;
    }

    void Update() {
        if ( Input.GetMouseButtonDown( 0 ) ) {
            Vector3 gridPoint;
            if ( GetMousePositionOnGrid( out gridPoint ) ) {
                Debug.Log( "Click: " + gridPoint );
                Instantiate( wall, gridPoint, Quaternion.identity );
            }
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
}