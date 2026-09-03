using UnityEngine;

public class PlayerManager : CharacterManager
{
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
