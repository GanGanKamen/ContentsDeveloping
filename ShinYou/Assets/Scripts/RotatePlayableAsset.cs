using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class RotatePlayableAsset : PlayableAsset
{
    public ExposedReference<GameObject> gameObject;
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        RotateBehaviour behaviour = new RotateBehaviour();
        behaviour.targetObj = gameObject.Resolve(graph.GetResolver());
        ScriptPlayable<RotateBehaviour> playable = ScriptPlayable<RotateBehaviour>.Create(graph, behaviour);
        return playable;
    }
}
