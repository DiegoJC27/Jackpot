using UnityEngine;

public abstract class MTMTButton : MonoBehaviour
{
    public abstract void OnClick();

    public virtual void OnHover()
    {
        Debug.Log("Hovering over button");
    }
    public virtual void OnHoverExit()
    {
        Debug.Log("Stopped hovering over button");
    }

    protected void OnMouseDown()
    {
        Debug.Log("Mouse down on button");
        OnClick();
    }
}
