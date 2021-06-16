using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.IO;
using TMPro;
using Random = UnityEngine.Random;

public class Launcher : MonoBehaviourPunCallbacks
{

    public static Launcher Instance;
    [SerializeField] private TMP_InputField roomNameInputField;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private TMP_Text roomNametext;
    [SerializeField] private Transform roomListContent;
    [SerializeField] private Transform playerListContent;
    [SerializeField] private GameObject roomListItemPrefab;
    [SerializeField] private GameObject playerListItemPrefab;
    [SerializeField] private GameObject StartGameButton;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        menuManager.Instance.OpenMenu("title");
        Debug.Log("joined lobby");
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000).ToString("0000");
        
    }

    public void CreateRoom()
    {
        Debug.Log("room created");
        Debug.Log(roomNameInputField.text);
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        menuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        menuManager.Instance.OpenMenu("room");
        roomNametext.text = PhotonNetwork.CurrentRoom.Name;

        foreach (Transform player in playerListContent)
        {
            Destroy(player.gameObject);
        }
        
        foreach (var player in PhotonNetwork.PlayerList)
        {
            Instantiate(playerListItemPrefab,playerListContent).GetComponent<playerListItem>().SetUp(player);
        }
        
        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room creation failed :" + message;
        menuManager.Instance.OpenMenu("error");
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }

    public void leaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        menuManager.Instance.OpenMenu("loading");
    }

    public void joinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        menuManager.Instance.OpenMenu("loading");

    }
    public override void OnLeftRoom()
    {
        menuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }
        foreach (var room in roomList)
        {
            if (room.RemovedFromList)
            {
                continue;
            }
            Instantiate(roomListItemPrefab,roomListContent).GetComponent<roomListItem>().SetUp(room);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab,playerListContent).GetComponent<playerListItem>().SetUp(newPlayer);
    }
}
