using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

public class MoveOnBeat : RAIN.Action.Action
{
    public MoveOnBeat() {
        actionName = "MoveOnBeat";
    }

    public override RAIN.Action.Action.ActionResult Start( RAIN.Core.Agent agent, float deltaTime ) {
        Debug.Log( "Start" );
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Execute( RAIN.Core.Agent agent, float deltaTime ) {
        Debug.Log( "Execute" );
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }

    public override RAIN.Action.Action.ActionResult Stop( RAIN.Core.Agent agent, float deltaTime ) {
        Debug.Log( "Stop" );
        return RAIN.Action.Action.ActionResult.SUCCESS;
    }
}