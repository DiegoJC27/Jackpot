using UnityEngine;

public class MenuScript : MonoBehaviour
{
    void Start()
    {
        if (PlayerManager.instance != null)
        {
            PlayerManager.instance.DoesDestroy();
        }
    }
}
