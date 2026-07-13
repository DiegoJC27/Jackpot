using System.Collections;
using UnityEngine;

public class Rueda : MonoBehaviour
{
    public int ruedaSize = 4;
    public Ranura[] ranuras;
    public int ranuraSelected;
    public bool bloqueado {  get; private set; }

    public IEnumerator SpinFor(float timeToSpin)
    {
        float elapsedTime = 0;
        int newRanura = 0;
        while(timeToSpin > elapsedTime)
        {
            newRanura++;
            if (newRanura % ruedaSize == 0 && newRanura != 0)
                newRanura = 0;
            yield return new WaitForSeconds(0.15f);
            elapsedTime += 0.15f;
        }
    }

    public  void SetBlocked(bool block)
    {
        bloqueado = block;
        Debug.Log("Se ha setado a: " + block);
    }
}
