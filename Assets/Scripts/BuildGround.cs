﻿using UnityEngine;
using System.Collections;

public class BuildGround : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject[] tiles;
    // Use this for initialization
    void Start() {
        for ( int i = 0; i < width; ++i ) {
            for ( int j = 0; j < height; ++j ) {
                int x = i - (int)(width / 2);
                int z = j - (int)(height / 2);

                GameObject tile = GetRandomTile();
                GameObject newTile = (GameObject)Instantiate( tile, new Vector3( x, 0, z ), Quaternion.AngleAxis( Random.Range( 0, 3 ) * 90, Vector3.up ) * Quaternion.AngleAxis( -90, new Vector3( 1, 0, 0 ) ) );
                newTile.hideFlags = HideFlags.HideInHierarchy;
            }
        }
    }

    GameObject GetRandomTile() {
        return tiles[Random.Range( 0, tiles.Length - 1 )];
    }
}
