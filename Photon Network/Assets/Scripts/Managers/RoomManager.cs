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
    private Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

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
        GameObject temporaryRoom;

        foreach(RoomInfo room in roomList)
        {
            // ���� ������ ���
            if (room.RemovedFromList == true)
            {
                dictionary.TryGetValue(room.Name, out temporaryRoom);

                Destroy(temporaryRoom);

                dictionary.Remove(room.Name);
            }
            // ���� ������ ����Ǵ� ���
            else
            {
                // ���� ó�� �����Ǵ� ���
                if (dictionary.ContainsKey(room.Name) == false)
                {
                    GameObject roomObject = Instantiate(Resources.Load<GameObject>("Room"), contentTransform);

                    roomObject.GetComponent<Information>().SetData(room.Name, room.PlayerCount, room.MaxPlayers);

                    dictionary.Add(room.Name, roomObject);
                }
                // ���� ������ ����Ǵ� ���
                else
                {
                    dictionary.TryGetValue(room.Name, out temporaryRoom);

                    temporaryRoom.GetComponent<Information>().SetData(room.Name, room.PlayerCount, room.MaxPlayers);
                }
            }
        }
    }
}