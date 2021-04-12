using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public static Dictionary<int, MoveItem> items = new Dictionary<int, MoveItem>();
    public static Dictionary<int, Yarn> yarns = new Dictionary<int, Yarn>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject itemPrefab;
    public GameObject yarnPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destorying instance");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public void CreateItem(int _itemId, Vector3 _itemPosition)
    {
        GameObject _item = Instantiate(itemPrefab, _itemPosition, itemPrefab.transform.rotation);

        _item.GetComponent<MoveItem>().Initialize(_itemId, _itemPosition);
        items.Add(_itemId, _item.GetComponent<MoveItem>());
       
    }
    public void CreateYarn(int _yarnId, Vector3 _yarnPosition)
    {
        Debug.Log(_yarnPosition);
        GameObject _yarn = Instantiate(yarnPrefab, _yarnPosition, itemPrefab.transform.rotation);
        Debug.Log(_yarn);

        _yarn.GetComponent<Yarn>().Initialize(_yarnId, _yarnPosition);
        yarns.Add(_yarnId, _yarn.GetComponent<Yarn>());

    }
}
