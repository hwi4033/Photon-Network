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
        // 1. nickName�� inputField�� �Է��� ���� �����Ѵ�.
        nickName = inputField.text;

        // 2. PhotonNetwork.NickName�� nickName ���� �־��ش�.
        PhotonNetwork.NickName = nickName;

        // 3. NickName�� �����Ѵ�.
        PlayerPrefs.SetString("NickName", PhotonNetwork.NickName);

        // 4. ��Ȱ��ȭ�Ѵ�.
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