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
        // 룸 삭제

        // 룸 업데이트

        // 룸 생성
        InstantiateRoom();
    }

    public void InstantiateRoom()
    {
        foreach(RoomInfo roomInfo in dictionary.Values)
        {
            // 1. Room 오브젝트를 생성한다.
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            // 2. Room 오브젝트의 위치 값을 설정한다.
            room.transform.SetParent(contentTransform);

            // 3. Room 오브젝트 안에 있는 Text 속성을 설정한다.
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