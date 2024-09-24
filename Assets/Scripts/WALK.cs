using UnityEngine;

public class WALK : MonoBehaviour
{
    private Rigidbody rb; // 角色的剛體
    private Animator anim; // 角色的動畫控制器

    private bool canJump = true; // 是否可以跳躍

    public float moveSpeed = 3f; // 角色移動速度
    public float jumpForce = 6f; // 跳躍力量
    public Transform cameraTransform; // 摄像机的 Transform

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取刚体组件
        anim = GetComponent<Animator>(); // 获取动画控制器组件
        Cursor.lockState = CursorLockMode.Locked; // 锁定鼠标光标
        Cursor.visible = false; // 隐藏鼠标光标
    }

    void Update()
    {
        HandleMovement(); // 处理角色移动

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            anim.SetTrigger("jump"); // 设置动画状态为跳跃
            JumpCharacter(); // 触发角色跳跃
        }
    }

    void HandleMovement()
    {
        // 获取输入轴
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 基于角色的方向获取移动方向
        Vector3 moveDirection = (transform.right * horizontal + transform.forward * vertical).normalized;
        moveDirection.y = 0; // 防止角色因摄像机倾斜而产生垂直移动

        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("mov", true); // 设置动画状态为移动
            MoveCharacter(moveDirection); // 根据方向移动角色
        }
        else
        {
            anim.SetBool("mov", false); // 如果没有移动方向，设置动画状态为不移动
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        Vector3 targetVelocity = direction * moveSpeed; // 设置目标速度
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z); // 应用目标速度到刚体
    }

    void JumpCharacter()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); // 设置跳跃速度
            canJump = false; // 禁止再次跳跃直到落地
            Invoke("EnableJump", 0.3f); // 在0.3秒后允许再次跳跃
        }
    }

    void EnableJump()
    {
        canJump = true; // 允许再次跳跃
    }

    bool IsGrounded()
    {
        // 使用射线检测是否着地
        return Physics.Raycast(transform.position, Vector3.down, 0.1f + 0.1f); // 增加0.1f的容错范围
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("jump", false); // 当接触地面时，设置动画状态为不跳跃
        }
    }
}