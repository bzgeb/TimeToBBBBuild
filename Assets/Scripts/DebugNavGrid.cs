using UnityEngine;
using System.Collections;
using RAIN.Path;

public class DebugNavGrid : MonoBehaviour
{
    RAINPathManager pathManager;
    // Use this for initialization
    void Start() {
        pathManager = GetComponent<RAINPathManager>();
        NavGridMultiRegionGraph graph = (NavGridMultiRegionGraph)RAINPathManager.LoadNavigationGridGraphFromFile( "NavGrid" );
        pathManager.gridPathGraph = graph;
        pathManager.ReInit();
        //NavGridMultiRegionGraph graph = pathManager.gridPathGraph;

        //PathNode node = graph.Node( 0 );
        //node.RemoveAllEdgesFrom( node.NodeIndex );
        //node.RemoveAllEdgesTo( node.NodeIndex );
        //Debug.Log( "Size: " + graph.Size );

        //for ( int i = 0; i < graph.Size; ++i ) {
        //    PathNode node = graph.Node( i );
        //    node.RemoveAllEdgesTo( node.NodeIndex );
        //    node.RemoveAllEdgesFrom( node.NodeIndex );
        //}

        //NavGridArray gridArray = graph.navGridArray;

        //foreach ( NavGridRegion region in gridArray.regions ) {
        //    Debug.Log( "Numcells: " + region.NumCells );
        //}
    }

}
