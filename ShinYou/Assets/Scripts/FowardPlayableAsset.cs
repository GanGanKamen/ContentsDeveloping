using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class FowardPlayableAsset : PlayableAsset
{
    public ExposedReference<GameObject> gameObject;
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        FowardBehaviour behaviour = new FowardBehaviour();
        behaviour.targetObj = gameObject.Resolve(graph.GetResolver());
        ScriptPlayable<FowardBehaviour> playable = ScriptPlayable<FowardBehaviour>.Create(graph, behaviour);
        return playable;
    }
}
