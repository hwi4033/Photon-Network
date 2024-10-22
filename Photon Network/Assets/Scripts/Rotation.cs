using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float mouseX;
    [SerializeField] float mouseY;
    [SerializeField] float speed = 200.0f;

    public void InputRotateY()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime;
    }

    public void RotateY(Rigidbody rigidBody)
    {
        rigidBody.transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

    public void RotateX()
    {
        // mouseY�� ���콺�� �Է��� ���� �����Ѵ�.
        mouseY += Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime;

        // mouseY�� ���� -65 ~ 65 ������ ������ �����Ѵ�.
        // mouseY <- Mathf.Clamp(�����ϰ��� �ϴ� ��, �ּҰ�, �ִ밪)
        mouseY = Mathf.Clamp(mouseY, -65, 65);

        transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}