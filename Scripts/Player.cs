using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed; // 角色移动速度
    public float runSpeed; // 角色跑步速度
    public float cameraRotSpeed; // 摄像机旋转速度
    public float jumpForce; // 跳跃力
    public Transform cameraParentTr; // 摄像机父级
    public Transform playerBodyTr; // 角色身体
    public Transform rayFrom; // 射线起点
    public Transform rayTo; // 射线终点
    public LayerMask groundLayer; // 地面层
    public Vector2 cameraRotRangeX; // 摄像机旋转范围

    private Rigidbody _rigidbody; // 刚体
    private Animator _animator; // 动画控制器
    private Vector3 _inputMoveValue; // 移动输入
    private Vector3 _inputMouseValue; // 鼠标输入
    private bool _isRun; // 是否跑步
    private bool _isGround; // 是否在地面
    private Vector3 _startPos; // 起始位置

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); // 获取刚体
        _animator = GetComponentInChildren<Animator>(); // 获取动画控制器
        _startPos = transform.position; // 记录起始位置
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraRot();

        // 如果角色超出范围，则回到起始位置
        if (transform.position.y < -30)
        {
            transform.position = _startPos;
        }
    }

    private void Move()
    {
        // 获取移动输入
        _inputMoveValue.x = Input.GetAxis("Horizontal");
        _inputMoveValue.z = Input.GetAxis("Vertical");
        // 获取跑步输入
        _isRun = Input.GetKey(KeyCode.LeftShift);

        // 设置角色朝向移动方向
        if (_inputMoveValue.magnitude > 0)
        {
            _inputMoveValue.Normalize();
            _inputMoveValue = Quaternion.Euler(0, cameraParentTr.eulerAngles.y, 0) * _inputMoveValue;
            playerBodyTr.forward = _inputMoveValue;
        }
        
        // 移动角色
        _rigidbody.MovePosition(_rigidbody.position + _inputMoveValue * ( _isRun ? runSpeed : moveSpeed) * Time.fixedDeltaTime);
        
        // 设置动画参数
        _animator.SetBool("Move", _inputMoveValue.magnitude > 0);
        _animator.SetBool("Run", _isRun);
    }

    // 摄像机旋转
    private void CameraRot()
    {
        // 获取鼠标输入
        _inputMouseValue.x = -Input.GetAxis("Mouse Y");
        _inputMouseValue.y = Input.GetAxis("Mouse X");

        // 限制摄像机X轴旋转角度
        Vector3 angle = cameraParentTr.eulerAngles;
        angle += _inputMouseValue * cameraRotSpeed * Time.deltaTime;

        if (angle.x > 180)
        {
            angle.x -= 360;
            angle.x = Mathf.Clamp(angle.x, cameraRotRangeX.x, cameraRotRangeX.y);
        }

        angle.z = 0;
        // 设置摄像机旋转角度
        cameraParentTr.eulerAngles = angle;
    }

    // 跳跃
    private void Jump()
    {
        // 射线检测判断是否在地面
        _isGround = Physics.Linecast(rayFrom.position, rayTo.position, groundLayer);

        // 跳跃
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
        }
        
        // 设置动画参数
        _animator.SetBool("Jump", !_isGround);
    }
}
