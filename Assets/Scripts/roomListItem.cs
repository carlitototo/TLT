using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using TMPro;
public class roomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public RoomInfo info;

    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = info.Name;
    }

    public void onClick()
    {
        Launcher.Instance.joinRoom(info);
    }
}
