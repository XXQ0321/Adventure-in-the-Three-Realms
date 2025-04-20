using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    // �����ٶȺ���ת�Ĳ���
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    // ���Ƶ���������
    private float moveForwardBackward;
    private float moveUpDown;
    private float rotateLeftRight;

    void Update()
    {
        // ��ȡ����
        moveForwardBackward = Input.GetAxis("Vertical"); // ǰ���ƶ���W/S �� ���¼�ͷ��
        moveUpDown = 0f; // ���������ƶ�

        // ʹ�� Q �� E �����������ƶ�
        if (Input.GetKey(KeyCode.Q))
        {
            moveUpDown = -1f; // �����ƶ�
        }
        if (Input.GetKey(KeyCode.E))
        {
            moveUpDown = 1f; // �����ƶ�
        }

        rotateLeftRight = Input.GetAxis("Horizontal"); // ������ת��A/D �� ���Ҽ�ͷ��

        // ǰ�������ƶ�
        Vector3 moveDirection = transform.forward * moveForwardBackward + transform.up * moveUpDown;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // ������ת
        transform.Rotate(Vector3.up * rotateLeftRight * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameManager>().AddGoin();//ui��������1
        }
        if (other.gameObject.tag == "Fish")
        {
         //   Destroy(other.gameObject);
            FindObjectOfType<GameManager>().SubGoin();//ui��������1
        }
    }
}
