using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform submarine; // 潜艇的Transform
    public Vector3 offset = new Vector3(0, 5, -10); // 摄像机与潜艇的相对位置
    public float rotationSpeed = 5f; // 控制摄像机旋转的速度

    void Update()
    {
        // 摄像机跟随潜艇
        transform.position = submarine.position + offset;

        // 摄像机始终朝向潜艇
        transform.LookAt(submarine);

        //// 可选：摄像机旋转（如果想让摄像机绕潜艇旋转）
        //float horizontalInput = Input.GetAxis("Horizontal"); // 左右旋转
        //float verticalInput = Input.GetAxis("Vertical"); // 上下旋转

        //// 控制摄像机的旋转
        //if (horizontalInput != 0 || verticalInput != 0)
        //{
        //    Vector3 direction = submarine.position - transform.position;
        //    Quaternion rotation = Quaternion.LookRotation(direction);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //}
    }
}
