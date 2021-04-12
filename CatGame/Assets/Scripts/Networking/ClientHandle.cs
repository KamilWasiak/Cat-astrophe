using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Net;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from the server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {

        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        if (GameManager.players.TryGetValue(_id, out PlayerManager _player))
        {
            GameManager.players[_id].GetComponent<PlayerManager>().SetPosition(_position);
        }
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();

        if (GameManager.players.TryGetValue(_id, out PlayerManager _player))
        {
            _player.transform.rotation = _rotation;
        }
    }

    public static void CreateItem(Packet _packet)
    {
        int _itemId = _packet.ReadInt();
        Vector3 _itemPosition = _packet.ReadVector3();

        GameManager.instance.CreateItem(_itemId, _itemPosition);
    }

    public static void ItemPickedup(Packet _packet)
    {
        int _itemId = _packet.ReadInt();
        int _playerId = _packet.ReadInt();

        GameManager.items[_itemId].ItemPickedup(_itemId, _playerId);
    }

    public static void UpdateItemPosition(Packet _packet)
    {
        int _itemId = _packet.ReadInt();
        Vector3 _itemPosition = _packet.ReadVector3();
        Quaternion _itemRotation = _packet.ReadQuaternion();

        if (GameManager.items.TryGetValue(_itemId, out MoveItem _item))
        {
            GameManager.items[_itemId].SetPosition(_itemPosition);
            _item.transform.rotation = _itemRotation;
        }
    }

    public static void WinCondition(Packet _packet)
    {
        int _pos = _packet.ReadInt();
        string _username = _packet.ReadString();

        SceneManager.LoadScene("EndScene");
    }

    public static void CreateYarn(Packet _packet)
    {
        int _itemId = _packet.ReadInt();
        Vector3 _itemPosition = _packet.ReadVector3();

        GameManager.instance.CreateYarn(_itemId, _itemPosition);
    }

    public static void UpdateYarnPosition(Packet _packet)
    {
        int _ownerId = _packet.ReadInt();
        Vector3 _yarnPosition = _packet.ReadVector3();
        Quaternion _yarnRotation = _packet.ReadQuaternion();

        if (GameManager.yarns.TryGetValue(_ownerId, out Yarn _yarn))
        {
            GameManager.yarns[_ownerId].SetPosition(_yarnPosition);
            _yarn.transform.rotation = _yarnRotation;
        }
    }
}
