using UnityEngine;

public class onon : MonoBehaviour
{
    public GameObject ontargetCamera; // 修改为 GameObject 类型
    public GameObject offtargetCamera; // 修改为 GameObject 类型

    private void OnMouseDown()
    {
        // 關閉指定的 GameObject
        if (offtargetCamera != null)
        {
            offtargetCamera.SetActive(false); // 修改为小写开头的变量名，并直接调用SetActive
        }

        // 打开指定的 GameObject
        if (ontargetCamera != null)
        {
            ontargetCamera.SetActive(true); // 修改为小写开头的变量名，并直接调用SetActive
        }
    }
}