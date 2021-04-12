using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
    public int itemId;
    public MeshRenderer itemModel;
    private Vector3 fromPos = new Vector3(-10000.0f, -10000.0f, -10000.0f);
    private Vector3 toPos = new Vector3(-10000.0f, -10000.0f, -10000.0f);
    private float lastTime;

    private Vector3 basePosition;

    public void Initialize(int _itemId, Vector3 _itemPosition)
    {
        itemId = _itemId;
        itemModel.enabled = true;
        fromPos = _itemPosition;
        toPos = _itemPosition;

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
