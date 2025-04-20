using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    // 控制速度和旋转的参数
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    // 控制的轴向输入
    private float moveForwardBackward;
    private float moveUpDown;
    private float rotateLeftRight;

    void Update()
    {
        // 获取输入
        moveForwardBackward = Input.GetAxis("Vertical"); // 前后移动（W/S 或 上下箭头）
        moveUpDown = 0f; // 重置上下移动

        // 使用 Q 和 E 键控制上下移动
        if (Input.GetKey(KeyCode.Q))
        {
            moveUpDown = -1f; // 向下移动
        }
        if (Input.GetKey(KeyCode.E))
        {
            moveUpDown = 1f; // 向上移动
        }

        rotateLeftRight = Input.GetAxis("Horizontal"); // 左右旋转（A/D 或 左右箭头）

        // 前后上下移动
        Vector3 moveDirection = transform.forward * moveForwardBackward + transform.up * moveUpDown;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // 左右旋转
        transform.Rotate(Vector3.up * rotateLeftRight * rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameManager>().AddGoin();//ui数量增加1
        }
        if (other.gameObject.tag == "Fish")
        {
         //   Destroy(other.gameObject);
            FindObjectOfType<GameManager>().SubGoin();//ui数量增加1
        }
    }
}
