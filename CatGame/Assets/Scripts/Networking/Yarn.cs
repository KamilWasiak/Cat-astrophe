using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yarn : MonoBehaviour
{
    public int ownerId;
    public MeshRenderer yarnModel;
    private Vector3 fromPos = new Vector3(-10000.0f, -10000.0f, -10000.0f);
    private Vector3 toPos = new Vector3(-10000.0f, -10000.0f, -10000.0f);
    private float lastTime;

    private Vector3 basePosition;

    public void Initialize(int _ownerId, Vector3 _yarnPosition)
    {
        ownerId = _ownerId;
        yarnModel.enabled = true;
        fromPos = _yarnPosition;
        toPos = _yarnPosition;

        basePosition = transform.position;
    }

    public void ItemPickedup(int _itemId, int _playerId)
    {
        Debug.Log($"Item nr {_itemId} picked up by {_playerId}");
    }

    public void SetPosition(Vector3 _position)
    {
        fromPos = toPos;
        toPos = _position;
        lastTime = Time.time;
    }
    private void Update()
    {
        this.transform.position = Vector3.Lerp(fromPos, toPos, (Time.time - lastTime) / (1.0f / 30));
    }
}
