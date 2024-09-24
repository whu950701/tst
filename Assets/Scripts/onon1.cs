

using UnityEngine;

public class onon1 : MonoBehaviour
{
    public GameObject onTargetObject;  // 使用更规范的变量命名
    public GameObject offTargetObject; // 使用更规范的变量命名

    private void Update()
    {
        // 在 Update 中检测 Escape 键是否按下
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (offTargetObject != null)
            {
                offTargetObject.SetActive(false); // 关闭指定的 GameObject
            }
        }
    }

    private void OnMouseDown()
    {
        // 打开指定的 GameObject
        if (onTargetObject != null)
        {
            onTargetObject.SetActive(true); // 打开对象
        }
    }
}
