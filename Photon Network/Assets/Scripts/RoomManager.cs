using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using PlayFab.PfEditor.EditorModels;

public class RoomManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField roomTitleInputField;
    [SerializeField] InputField roomCapacityInputField;

    [SerializeField] Transform contentTransform;
    private Dictionary<string, RoomInfo> dictionary = new Dictionary<string, RoomInfo>();

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }

    public void OnCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = byte.Parse(roomCapacityInputField.text);

        roomOptions.IsOpen = true;
        
        roomOptions.IsVisible = true;

        PhotonNetwork.CreateRoom(roomTitleInputField.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // �� ����

        // �� ������Ʈ

        // �� ����
        InstantiateRoom();
    }

    public void InstantiateRoom()
    {
        foreach(RoomInfo roomInfo in dictionary.Values)
        {
            // 1. Room ������Ʈ�� �����Ѵ�.
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            // 2. Room ������Ʈ�� ��ġ ���� �����Ѵ�.
            room.transform.SetParent(contentTransform);

            // 3. Room ������Ʈ �ȿ� �ִ� Text �Ӽ��� �����Ѵ�.
            room.GetComponent<Information>().SetData
            (
                roomInfo.Name,
                roomInfo.PlayerCount,
                roomInfo.MaxPlayers
            );           
        }
    }

    public void UpdateRoom()
    {

    }

    public void RemoveRoom()
    {

    }
}