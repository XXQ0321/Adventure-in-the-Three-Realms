using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform submarine; // Ǳͧ��Transform
    public Vector3 offset = new Vector3(0, 5, -10); // �������Ǳͧ�����λ��
    public float rotationSpeed = 5f; // �����������ת���ٶ�

    void Update()
    {
        // ���������Ǳͧ
        transform.position = submarine.position + offset;

        // �����ʼ�ճ���Ǳͧ
        transform.LookAt(submarine);

        //// ��ѡ���������ת����������������Ǳͧ��ת��
        //float horizontalInput = Input.GetAxis("Horizontal"); // ������ת
        //float verticalInput = Input.GetAxis("Vertical"); // ������ת

        //// �������������ת
        //if (horizontalInput != 0 || verticalInput != 0)
        //{
        //    Vector3 direction = submarine.position - transform.position;
        //    Quaternion rotation = Quaternion.LookRotation(direction);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //}
    }
}
