/*using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    bool isTouchingWall = false;
    bool isWalking = false;
    bool isJumping = false;
    bool canJump = true;
    bool canControl = false; // 新添加的变量

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool keydn = Input.anyKey;

        if (!keydn)
        {
            anim.SetBool("mov", false);
            anim.SetBool("jump", false);
        }

        if (!Input.GetKey(KeyCode.W) && !canJump)
        {
            canJump = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && canJump && canControl) // 添加了canControl条件
        {
            anim.SetBool("jump", true);
            JumpCharacter(); // 跳躍
        }

        if (Input.GetKey(KeyCode.A) && canControl) // 添加了canControl条件
        {
            anim.SetBool("mov", true);
            MoveCharacter(-1f); // 向左移動
            FlipCharacter(true); // 水平翻轉
        }

        if (Input.GetKey(KeyCode.D) && canControl) // 添加了canControl条件
        {
            anim.SetBool("mov", true);
            MoveCharacter(1f); // 向右移動
            FlipCharacter(false); // 恢復水平方向
        }
    }

    void MoveCharacter(float direction)
    {
        Vector2 targetVelocity = new Vector2(direction * 3f, rb.velocity.y);
        rb.velocity = targetVelocity;
        isWalking = true;
    }

    void JumpCharacter()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 16f);
            canJump = false;
            isJumping = true;
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit = Physics.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }

    void FlipCharacter(bool flip)
    {
        if (flip)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}有多餘的程式*/
/*
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;  // 角色的剛體
    Animator anim; // 角色的動畫控制器

    bool canControl = true; // 是否可以控制角色

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 獲取剛體組件
        anim = GetComponent<Animator>(); // 獲取動畫控制器組件
    }

    void Update()
    {
        bool keydn = Input.anyKey; // 檢查是否有按鍵被按下

        if (!keydn)
        {
            anim.SetBool("mov", false); // 如果沒有按鍵被按下，設置動畫狀態為不移動
        }

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) && canControl)
        {
            anim.SetBool("mov", true); // 如果A鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.left; // 向左移動角色
        }

        if (Input.GetKey(KeyCode.D) && canControl)
        {
            anim.SetBool("mov", true); // 如果D鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.right; // 向右移動角色
        }

        if (Input.GetKey(KeyCode.W) && canControl)
        {
            anim.SetBool("mov", true); // 如果W鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.forward; // 向前移動角色
        }

        if (Input.GetKey(KeyCode.S) && canControl)
        {
            anim.SetBool("mov", true); // 如果S鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.back; // 向後移動角色
        }

        if (moveDirection != Vector3.zero)
        {
            MoveCharacter(moveDirection); // 根據方向移動角色
            RotateCharacter(moveDirection); // 根據方向旋轉角色
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        Vector3 targetVelocity = direction * 3f; // 設置目標速度
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z); // 應用目標速度到剛體
    }

    void RotateCharacter(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // 根據方向計算目標旋轉
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime); // 平滑旋轉角色
    }
}慣性移動問題*/
/*
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;  // 角色的剛體
    Animator anim; // 角色的動畫控制器

    bool canControl = true; // 是否可以控制角色

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 獲取剛體組件
        anim = GetComponent<Animator>(); // 獲取動畫控制器組件
    }

    void Update()
    {
        bool keydn = Input.anyKey; // 檢查是否有按鍵被按下

        if (!keydn)
        {
            anim.SetBool("mov", false); // 如果沒有按鍵被按下，設置動畫狀態為不移動
            rb.velocity = Vector3.zero; // 停止角色的移動
        }

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) && canControl)
        {
            anim.SetBool("mov", true); // 如果A鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.left; // 向左移動角色
        }

        if (Input.GetKey(KeyCode.D) && canControl)
        {
            anim.SetBool("mov", true); // 如果D鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.right; // 向右移動角色
        }

        if (Input.GetKey(KeyCode.W) && canControl)
        {
            anim.SetBool("mov", true); // 如果W鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.forward; // 向前移動角色
        }

        if (Input.GetKey(KeyCode.S) && canControl)
        {
            anim.SetBool("mov", true); // 如果S鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.back; // 向後移動角色
        }

        if (moveDirection != Vector3.zero)
        {
            MoveCharacter(moveDirection); // 根據方向移動角色
            RotateCharacter(moveDirection); // 根據方向旋轉角色
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        Vector3 targetVelocity = direction * 3f; // 設置目標速度
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z); // 應用目標速度到剛體
    }

    void RotateCharacter(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // 根據方向計算目標旋轉
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime); // 平滑旋轉角色
    }
}少跳躍*/
/*
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb; // 角色的剛體
    Animator anim; // 角色的動畫控制器

    bool canControl = true; // 是否可以控制角色
    bool canJump = true; // 是否可以跳躍

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 獲取剛體組件
        anim = GetComponent<Animator>(); // 獲取動畫控制器組件
    }

    void Update()
    {
        bool keydn = Input.anyKey; // 檢查是否有按鍵被按下

        if (!keydn)
        {
            anim.SetBool("mov", false); // 如果沒有按鍵被按下，設置動畫狀態為不移動
            anim.SetBool("jump", false); // 如果沒有按鍵被按下，設置動畫狀態為不移動
            rb.velocity = new Vector3(0, rb.velocity.y, 0); // 停止角色的移動
        }

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) && canControl)
        {
            anim.SetBool("mov", true); // 如果A鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.left; // 向左移動角色
        }

        if (Input.GetKey(KeyCode.D) && canControl)
        {
            anim.SetBool("mov", true); // 如果D鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.right; // 向右移動角色
        }

        if (Input.GetKey(KeyCode.W) && canControl)
        {
            anim.SetBool("mov", true); // 如果W鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.forward; // 向前移動角色
        }

        if (Input.GetKey(KeyCode.S) && canControl)
        {
            anim.SetBool("mov", true); // 如果S鍵被按下並且可以控制，設置動畫狀態為移動
            moveDirection = Vector3.back; // 向後移動角色
        }

        if (moveDirection != Vector3.zero)
        {
            MoveCharacter(moveDirection); // 根據方向移動角色
            RotateCharacter(moveDirection); // 根據方向旋轉角色
        }

        if (Input.GetKeyDown(KeyCode.Space) && canControl && canJump)
        {
            anim.SetTrigger("jump"); // 設置動畫狀態為跳躍
            JumpCharacter(); // 使角色跳躍
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        Vector3 targetVelocity = direction * 3f; // 設置目標速度
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z); // 應用目標速度到剛體
    }

    void RotateCharacter(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // 根據方向計算目標旋轉
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime); // 平滑旋轉角色
    }

    void JumpCharacter()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 7f, rb.velocity.z); // 设置跳跃速度
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
        return Physics.Raycast(transform.position, Vector3.down, 0.1f); // 使用射線檢測是否著地
    }
    
}*//*99
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb; // 角色的刚体
    Animator anim; // 角色的动画控制器

    bool canControl = true; // 是否可以控制角色
    bool canJump = true; // 是否可以跳跃

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取刚体组件
        anim = GetComponent<Animator>(); // 获取动画控制器组件
    }

    void Update()
    {
        bool keyDown = Input.anyKey; // 检查是否有按键被按下

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) && canControl)
        {
            moveDirection = Vector3.left; // 向左移动角色
        }

        if (Input.GetKey(KeyCode.D) && canControl)
        {
            moveDirection = Vector3.right; // 向右移动角色
        }

        if (Input.GetKey(KeyCode.W) && canControl)
        {
            moveDirection = Vector3.forward; // 向前移动角色
        }

        if (Input.GetKey(KeyCode.S) && canControl)
        {
            moveDirection = Vector3.back; // 向后移动角色
        }

        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("mov", true); // 设置动画状态为移动
            MoveCharacter(moveDirection); // 根据方向移动角色
            RotateCharacter(moveDirection); // 根据方向旋转角色
        }
        else
        {
            anim.SetBool("mov", false); // 如果没有移动方向，设置动画状态为不移动

            if (IsGrounded())
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0); // 如果角色在地面上，停止水平移动
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canControl && canJump)
        {
            anim.SetTrigger("jump"); // 设置动画状态为跳跃
            JumpCharacter(); // 触发角色跳跃
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        Vector3 targetVelocity = direction * 3f; // 设置目标速度
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z); // 应用目标速度到刚体
    }

    void RotateCharacter(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // 根据方向计算目标旋转
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime); // 平滑旋转角色
    }

    void JumpCharacter()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 6f, rb.velocity.z); // 设置跳跃速度
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
        return Physics.Raycast(transform.position, Vector3.down, 0.1f); // 使用射线检测是否着地
    }

    void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("jump", false); // 当接触地面时，设置动画状态为不跳跃
            canControl = true; // 当接触地面时，启用控制
        }
    }
}


   /* void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canControl = false; // 当离开地面时，禁用控制
        }
    }*//*99

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb; // 角色的刚体
    Animator anim; // 角色的动画控制器

    bool canControl = true; // 是否可以控制角色
    bool canJump = true; // 是否可以跳跃

    public float moveSpeed = 3f; // 角色移动速度

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取刚体组件
        anim = GetComponent<Animator>(); // 获取动画控制器组件
    }

    void Update()
    {
        // 获取输入轴
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (moveDirection != Vector3.zero && canControl)
        {
            anim.SetBool("mov", true); // 设置动画状态为移动
            MoveCharacter(moveDirection); // 根据方向移动角色
            RotateCharacter(moveDirection); // 根据方向旋转角色
        }
        else
        {
            anim.SetBool("mov", false); // 如果没有移动方向，设置动画状态为不移动

            if (IsGrounded())
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0); // 如果角色在地面上，停止水平移动
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && canControl && canJump)
        {
            anim.SetTrigger("jump"); // 设置动画状态为跳跃
            JumpCharacter(); // 触发角色跳跃
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        Vector3 targetVelocity = direction * moveSpeed; // 设置目标速度
        rb.velocity = new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.z); // 应用目标速度到刚体
    }

    void RotateCharacter(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up); // 根据方向计算目标旋转
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime); // 平滑旋转角色
    }

    void JumpCharacter()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 6f, rb.velocity.z); // 设置跳跃速度
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
        return Physics.Raycast(transform.position, Vector3.down, 0.1f); // 使用射线检测是否着地
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("jump", false); // 当接触地面时，设置动画状态为不跳跃
            canControl = true; // 当接触地面时，启用控制
        }
    }
}*//*99
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // 角色的刚体
    private Animator anim; // 角色的动画控制器

    private bool canControl = true; // 是否可以控制角色
    private bool canJump = true; // 是否可以跳跃

    public float moveSpeed = 3f; // 角色移动速度
    public float jumpForce = 6f; // 跳跃力量
    public float mouseSensitivity = 100f; // 鼠标灵敏度
    public Transform cameraTransform; // 摄像机的 Transform

    private float xRotation = 0f; // 摄像机的垂直旋转角度

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取刚体组件
        anim = GetComponent<Animator>(); // 获取动画控制器组件
        Cursor.lockState = CursorLockMode.Locked; // 锁定鼠标光标
        Cursor.visible = false; // 隐藏鼠标光标
    }

    void Update()
    {
        HandleMouseLook(); // 处理鼠标视角控制
        HandleMovement(); // 处理角色移动

        if (Input.GetKeyDown(KeyCode.Space) && canControl && canJump)
        {
            anim.SetTrigger("jump"); // 设置动画状态为跳跃
            JumpCharacter(); // 触发角色跳跃
        }
    }

    void HandleMouseLook()
    {
        // 获取鼠标输入
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 旋转摄像机的 x 轴 (上下视角)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 限制上下视角的旋转角度
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 旋转玩家角色的 y 轴 (左右视角)
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        // 获取输入轴
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = (cameraTransform.right * horizontal + cameraTransform.forward * vertical).normalized;
        moveDirection.y = 0; // 防止角色因摄像机倾斜而产生垂直移动

        if (moveDirection != Vector3.zero && canControl)
        {
            anim.SetBool("mov", true); // 设置动画状态为移动
            MoveCharacter(moveDirection); // 根据方向移动角色
        }
        else
        {
            anim.SetBool("mov", false); // 如果没有移动方向，设置动画状态为不移动

            if (IsGrounded())
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0); // 如果角色在地面上，停止水平移动
            }
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
        return Physics.Raycast(transform.position, Vector3.down, 0.1f); // 使用射线检测是否着地
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("jump", false); // 当接触地面时，设置动画状态为不跳跃
            canControl = true; // 当接触地面时，启用控制
        }
    }
}*/





/*
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // 角色的刚体
    private Animator anim; // 角色的动画控制器

    private bool canControl = true; // 是否可以控制角色
    private bool canJump = true; // 是否可以跳跃

    public float moveSpeed = 3f; // 角色移动速度
    public float jumpForce = 6f; // 跳跃力量
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

        if (Input.GetKeyDown(KeyCode.Space) && canControl && canJump)
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

        if (moveDirection != Vector3.zero && canControl)
        {
            anim.SetBool("mov", true); // 设置动画状态为移动
            MoveCharacter(moveDirection); // 根据方向移动角色
        }
        else
        {
            anim.SetBool("mov", false); // 如果没有移动方向，设置动画状态为不移动

            if (IsGrounded())
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0); // 如果角色在地面上，停止水平移动
            }
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
        return Physics.Raycast(transform.position, Vector3.down, 0.1f); // 使用射线检测是否着地
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("jump", false); // 当接触地面时，设置动画状态为不跳跃
            canControl = true; // 当接触地面时，启用控制
        }
    }
}
*/
//優化//
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
