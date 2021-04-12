using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    private Vector3 fromPos = Vector3.zero;
    private Vector3 toPos = Vector3.zero;
    private float lastTime;

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
    }

    public void SetPosition(Vector3 position)
    {
        fromPos = toPos;
        toPos = position;
        lastTime = Time.time;
    }
    private void Start()
    {
        this.transform.position = Vector3.Lerp(fromPos, toPos, (Time.time - lastTime) / (1.0f / 30));
    }
    private void Update()
    {
        this.transform.position = Vector3.Lerp(fromPos, toPos, (Time.time - lastTime) / (1.0f /30));
    }
}
