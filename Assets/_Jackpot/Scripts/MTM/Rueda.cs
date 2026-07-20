using System.Collections;
using UnityEngine;

public class Rueda : MonoBehaviour
{
    public int ruedaSize = 4;
    public Ranura[] ranuras;
    public int ranuraSelected;
    public bool bloqueado = false;
    public MaquinaTragamonedas MTM;
    public IEnumerator SpinFor(float timeToSpin)
    {
        float elapsedTime = 0;
        int newRanura = Random.Range(0,ruedaSize);
        Debug.Log("Random = " + newRanura);
        while (timeToSpin > elapsedTime)
        {
            ranuras[newRanura].gameObject.SetActive(false);
            newRanura++;
            if (newRanura % ruedaSize == 0 && newRanura != 0)
                newRanura = 0;
            ranuras[newRanura].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            elapsedTime += 0.15f;
        }
        MTM.OnStopSpinning();
    }

    public  void SetBlocked()
    {
        bloqueado = !bloqueado;
        Debug.Log("Se ha setado a: " + bloqueado);
    }
    public  void SetBlocked(bool block)
    {
        bloqueado = block;
        Debug.Log("Se ha setado a: " + bloqueado);
    }
}
