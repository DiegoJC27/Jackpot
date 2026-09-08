using UnityEngine;

public class PlayerManager : CharacterManager
{
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetMTM(MaquinaTragamonedas _mtm)
    {
        this.mtm = _mtm;
    }

    public void DoesDestroy()
    {
        Destroy(this.gameObject);
    }
}
