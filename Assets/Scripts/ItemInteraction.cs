/*using UnityEngine;
using System.Collections;

public class ItemInteraction : MonoBehaviour
{
    public BlurBackground blurBackground;  // 背景模糊腳本引用
    public Transform inspectPosition;  // 物品檢查位置
    public float resizeScale = 0.7f;  // 縮小比例
    public float moveDuration = 1.0f;  // 移動和縮小持續時間
    public float rotationSpeed = 200.0f;  // 旋轉速度
    public Camera mainCamera;  // 直接引用你的攝影機對象
    public MonoBehaviour playerMovementScript;  // 玩家移動腳本引用
    public Animator playerAnimator;  // 玩家動畫控制器引用
    public Rigidbody playerRigidbody;  // 玩家Rigidbody引用

    private GameObject currentItem;  // 目前檢查的物品
    private Vector3 originalPosition;  // 物品的原始位置
    private Quaternion originalRotation;  // 物品的原始旋轉
    private Vector3 originalScale;  // 物品的原始大小
    private bool isInspecting = false;  // 是否在檢查模式中

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isInspecting)
        {
            if (mainCamera != null)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.CompareTag("InteractiveItem"))
                    {
                        StartCoroutine(StartInspecting(hit.transform.gameObject));
                    }
                }
            }
            else
            {
                Debug.LogError("Main camera reference is not set.");
            }
        }

        if (isInspecting && Input.GetMouseButton(2))
        {
            RotateItem();
        }

        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            StopInspecting();
        }
    }

    IEnumerator StartInspecting(GameObject item)
    {
        blurBackground.EnableBlur();
        currentItem = item;
        originalPosition = currentItem.transform.position;
        originalRotation = currentItem.transform.rotation;
        originalScale = currentItem.transform.localScale;

        Vector3 targetPosition = inspectPosition.position;
        Vector3 targetScale = originalScale * resizeScale;

        // 停用攝影機控制腳本和玩家移動腳本
        var cameraController = mainCamera.GetComponent<MonoBehaviour>();
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
        if (playerMovementScript != null)
        {
            // 停止玩家的移動和動畫
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
          
            playerMovementScript.enabled = false;
        }
        if (playerAnimator != null)
        {
            playerAnimator.enabled = false;  // 禁用玩家動畫
        }

        // 平滑移動和縮小物品
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            currentItem.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            currentItem.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentItem.transform.position = targetPosition;
        currentItem.transform.localScale = targetScale;

        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        isInspecting = true;
    }

    void StopInspecting()
    {
        blurBackground.DisableBlur();
        if (currentItem != null)
        {
            Rigidbody rb = currentItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            currentItem.transform.position = originalPosition;
            currentItem.transform.rotation = originalRotation;
            currentItem.transform.localScale = originalScale;
            currentItem = null;
        }
        isInspecting = false;
        
        //重新啟用攝影機控制腳本和玩家移動腳本
        var cameraController = mainCamera.GetComponent<MonoBehaviour>();
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }
        if (playerAnimator != null)
        {
            playerAnimator.enabled = true;  // 重新啟用玩家動畫
        }
    }

    void RotateItem()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        currentItem.transform.Rotate(Vector3.up, -horizontal, Space.World);
        currentItem.transform.Rotate(Vector3.right, vertical, Space.World);
    }
}*/


/*
using UnityEngine;
using System.Collections;

public class ItemInteraction : MonoBehaviour
{
    public Transform inspectPosition;  // 物品檢查位置
    public float resizeScale = 0.7f;  // 縮小比例
    public float moveDuration = 1.0f;  // 移動和縮小持續時間
    public float rotationSpeed = 200.0f;  // 旋轉速度
    public Camera mainCamera;  // 直接引用你的攝影機對象
    public MonoBehaviour playerMovementScript;  // 玩家移動腳本引用
    public Animator playerAnimator;  // 玩家動畫控制器引用
    public Rigidbody playerRigidbody;  // 玩家Rigidbody引用

    private GameObject currentItem;  // 目前檢查的物品
    private Vector3 originalPosition;  // 物品的原始位置
    private Quaternion originalRotation;  // 物品的原始旋轉
    private Vector3 originalScale;  // 物品的原始大小
    private bool isInspecting = false;  // 是否在檢查模式中

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isInspecting)
        {
            if (mainCamera != null)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.CompareTag("InteractiveItem"))
                    {
                        StartCoroutine(StartInspecting(hit.transform.gameObject));
                    }
                }
            }
            else
            {
                Debug.LogError("Main camera reference is not set.");
            }
        }

        if (isInspecting && Input.GetMouseButton(2))
        {
            RotateItem();
        }

        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            StopInspecting();
        }
    }

    IEnumerator StartInspecting(GameObject item)
    {
        currentItem = item;
        originalPosition = currentItem.transform.position;
        originalRotation = currentItem.transform.rotation;
        originalScale = currentItem.transform.localScale;

        Vector3 targetPosition = inspectPosition.position;
        Vector3 targetScale = originalScale * resizeScale;

        // 停用攝影機控制腳本和玩家移動腳本
        var cameraController = mainCamera.GetComponent<MonoBehaviour>();
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
        if (playerMovementScript != null)
        {
            // 停止玩家的移動和動畫
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
          
            playerMovementScript.enabled = false;
        }
        if (playerAnimator != null)
        {
            playerAnimator.enabled = false;  // 禁用玩家動畫
        }

        // 平滑移動和縮小物品
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            currentItem.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            currentItem.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        currentItem.transform.position = targetPosition;
        currentItem.transform.localScale = targetScale;

        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        isInspecting = true;
    }

    void StopInspecting()
    {
        if (currentItem != null)
        {
            Rigidbody rb = currentItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            currentItem.transform.position = originalPosition;
            currentItem.transform.rotation = originalRotation;
            currentItem.transform.localScale = originalScale;
            currentItem = null;
        }
        isInspecting = false;
        
        //重新啟用攝影機控制腳本和玩家移動腳本
        var cameraController = mainCamera.GetComponent<MonoBehaviour>();
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }
        if (playerAnimator != null)
        {
            playerAnimator.enabled = true;  // 重新啟用玩家動畫
        }
    }

    void RotateItem()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        currentItem.transform.Rotate(Vector3.up, -horizontal, Space.World);
        currentItem.transform.Rotate(Vector3.right, vertical, Space.World);
    }
}*/

using UnityEngine;
using System.Collections;

public class ItemInteraction : MonoBehaviour
{
    public Transform inspectPosition;  // 物品检查位置
    public float resizeScale = 0.7f;  // 缩小比例
    public float moveDuration = 1.0f;  // 移动和缩小持续时间
    public float rotationSpeed = 200.0f;  // 旋转速度
    public Camera mainCamera;  // 直接引用你的摄像机对象
    public MonoBehaviour playerMovementScript;  // 玩家移动脚本引用
    public Animator playerAnimator;  // 玩家动画控制器引用
    public Rigidbody playerRigidbody;  // 玩家Rigidbody引用

    private GameObject currentItem;  // 当前检查的物品
    private Vector3 originalPosition;  // 物品的原始位置
    private Quaternion originalRotation;  // 物品的原始旋转
    private Vector3 originalScale;  // 物品的原始大小
    private bool isInspecting = false;  // 是否在检查模式中

    void Update()
    {
        // 鼠标左键点击进行检查
        if (Input.GetMouseButtonDown(0) && !isInspecting)
        {
            PerformRaycast();
        }

        // 允许在检查模式中旋转物品
        if (isInspecting && Input.GetMouseButton(2))
        {
            RotateItem();
        }

        // 按下Escape退出检查模式
        if (isInspecting && Input.GetKeyDown(KeyCode.Escape))
        {
            StopInspecting();
        }
    }

    // 射线检测交互物品
    void PerformRaycast()
    {
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("InteractiveItem"))
                {
                    StartCoroutine(StartInspecting(hit.transform.gameObject));
                }
            }
        }
        else
        {
            Debug.LogError("Main camera reference is not set.");
        }
    }

    // 开始检查物品的协程
    IEnumerator StartInspecting(GameObject item)
    {
        currentItem = item;
        SaveOriginalTransform();

        Vector3 targetPosition = inspectPosition.position;
        Vector3 targetScale = originalScale * resizeScale;

        DisablePlayerControls();

        // 平滑移动和缩放物品
        float elapsedTime = 0;
        while (elapsedTime < moveDuration)
        {
            currentItem.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / moveDuration);
            currentItem.transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 确保物体最终位置和缩放精确设置到目标值
        currentItem.transform.position = targetPosition;
        currentItem.transform.localScale = targetScale;

        currentItem.GetComponent<Rigidbody>().isKinematic = true;
        isInspecting = true;
    }

    // 停止检查物品，恢复状态
    void StopInspecting()
    {
        if (currentItem != null)
        {
            Rigidbody rb = currentItem.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }

            // 恢复原始位置、旋转和缩放
            RestoreOriginalTransform();
            currentItem = null;
        }
        isInspecting = false;

        EnablePlayerControls();
    }

    // 保存原始变换信息
    void SaveOriginalTransform()
    {
        originalPosition = currentItem.transform.position;
        originalRotation = currentItem.transform.rotation;
        originalScale = currentItem.transform.localScale;
    }

    // 恢复物体到原始变换
    void RestoreOriginalTransform()
    {
        currentItem.transform.position = originalPosition;
        currentItem.transform.rotation = originalRotation;
        currentItem.transform.localScale = originalScale;
    }

    // 禁用玩家控制
    void DisablePlayerControls()
    {
        var cameraController = mainCamera.GetComponent<MonoBehaviour>();
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }

        if (playerMovementScript != null)
        {
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
            playerMovementScript.enabled = false;
        }

        if (playerAnimator != null)
        {
            playerAnimator.enabled = false;  // 禁用玩家动画
        }
    }

    // 启用玩家控制
    void EnablePlayerControls()
    {
        var cameraController = mainCamera.GetComponent<MonoBehaviour>();
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }

        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }

        if (playerAnimator != null)
        {
            playerAnimator.enabled = true;  // 重新启用玩家动画
        }
    }

    // 旋转物品
    void RotateItem()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        currentItem.transform.Rotate(Vector3.up, -horizontal, Space.World);
        currentItem.transform.Rotate(Vector3.right, vertical, Space.World);
    }
}

