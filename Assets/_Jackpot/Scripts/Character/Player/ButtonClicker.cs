using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClicker : MonoBehaviour
{
    //Madres de Debug
    Vector3 hitPos;
    float rad = 0.2f;
    void Update()
    {
        if (InputSystem.actions.FindAction("Click").triggered)
        {
            hitPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Collider2D[] cols = Physics2D.OverlapCircleAll(hitPos, rad);
            foreach (Collider2D col in cols) { 
                if (col.gameObject.TryGetComponent<IMTMTButton>(out var button))
                {
                    button.OnClick();
                }   
            }
        }
    }
}
