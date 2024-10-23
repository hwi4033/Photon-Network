using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown dropDown;
    [SerializeField] Canvas lobbyCanvas;
    [SerializeField] GameObject nickNamePanel;

    private void Awake()
    {
        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

        if (string.IsNullOrEmpty(PlayerPrefs.GetString("NickName")))
        {
            nickNamePanel.SetActive(true);
        }

        if (PhotonNetwork.IsConnected)
        {
            lobbyCanvas.gameObject.SetActive(false);
        }
    }

    public void Connect()
    {
        // 서버에 접속하는 함수
        PhotonNetwork.ConnectUsingSettings();

        lobbyCanvas.gameObject.SetActive(false);
    }

    public override void OnJoinedLobby()
    {
        if (lobbyCanvas.gameObject.activeSelf)
        {
            lobbyCanvas.gameObject.SetActive(true);
        }
    }

    public override void OnConnectedToMaster()
    {
        // JoinLobby : 특정 로비를 생성하여 진입하는 함수
        PhotonNetwork.JoinLobby
        (
            new TypedLobby
            (
                // 드롭다운 서버별로 나누는 코드
                dropDown.options[dropDown.value].text,
                LobbyType.Default
            )

        );
    }
}