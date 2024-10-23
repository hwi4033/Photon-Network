using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] Button button;
    [SerializeField] InputField inputField;

    [SerializeField] string nickName;

    public void SetName()
    {
        // 1. nickName에 inputField로 입력한 값을 저장한다.
        nickName = inputField.text;

        // 2. PhotonNetwork.NickName에 nickName 값을 넣어준다.
        PhotonNetwork.NickName = nickName;

        // 3. NickName을 저장한다.
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        // 4. 비활성화한다.
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length <= 0)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}