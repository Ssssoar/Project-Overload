using UnityEngine;
using System.Collections.Generic;

public class SCR_CableManager : MonoBehaviour{
    [Header("Prefabs")]
    [SerializeField] SCR_Cable cable;

    [Header("References")]
    [SerializeField] Transform connectFrom;

    [Header("Variables")]
    Dictionary<Transform,SCR_Cable> activeConnections = new Dictionary<Transform,SCR_Cable>();

    public void ConnectTo(Transform connectTarget){
        SCR_Cable USELESS;
        if (activeConnections.TryGetValue(connectTarget, out USELESS)) return; //if there is an active charge from chargeSource, ignore.
        SCR_Cable newCable = Instantiate(cable,transform);
        activeConnections.Add(connectTarget, newCable);
        newCable.connectFrom = transform;
        newCable.connectTo = connectTarget;
    }

    public void DisconnectFrom(Transform connectTarget){
        SCR_Cable toDestroy;
        if (!activeConnections.TryGetValue(connectTarget, out toDestroy)) return;
        Destroy(toDestroy.gameObject);
        activeConnections.Remove(connectTarget);
    }
}
