using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Chat;
using UnityEngine.UI;
using System.Net.Sockets;

public class DialogManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform parentTransform;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputField.ActivateInputField();

            if (inputField.text.Length <= 0)
            {
                return;
            }

            // inputField�� �ִ� �ؽ�Ʈ�� �����´�.
            string talk = photonView.Owner.NickName + " : " + inputField.text;

            // RPCTarget.All : ���� �뿡 �ִ� ��� Ŭ���̾�Ʈ���� Talk �Լ��� �����϶�� ����� �Ѵ�.
            photonView.RPC("Talk", RpcTarget.All, talk);
        }
    }

    [PunRPC]
    public void Talk(string message)
    {
        // Prefab�� �ϳ� ������ ���� text ���� �����Ѵ�.
        GameObject talk = Instantiate(Resources.Load<GameObject>("String"));

        talk.GetComponent<Text>().text = message;

        // ��ũ�� �� - content�� �ڽ����� ����Ѵ�.
        talk.transform.SetParent(parentTransform);

        // ä���� �Է��� �Ŀ��� �̾ �Է��� �� �ֵ��� �����Ѵ�.
        inputField.ActivateInputField();

        // inputField�� �ؽ�Ʈ�� �ʱ�ȭ�Ѵ�.
        inputField.text = "";
    }
}