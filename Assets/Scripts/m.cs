using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float mouseSensitivity = 100.0f; // 滑鼠靈敏度
    public Transform playerBody; // 玩家角色的 Transform

    private float xRotation = 0.0f;

    void Start()
    {
        // 隱藏並鎖定滑鼠遊標
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 取得滑鼠輸入
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 旋轉攝影機的 x 軸 (上下視角)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); // 限制上下視角的旋轉角度
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        // 旋轉玩家角色的 y 軸 (左右視角)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}

