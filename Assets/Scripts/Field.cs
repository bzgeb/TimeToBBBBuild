using UnityEngine;
using System.Collections;

public class Field
{
    public static int[,] data;

    public static void Init( int width, int height ) {
        data = new int[width, height];
        for ( int i = 0; i < width; ++i ) {
            for ( int j = 0; j < height; ++j ) {
                data[i, j] = -1;
            }
        }
    }
}
