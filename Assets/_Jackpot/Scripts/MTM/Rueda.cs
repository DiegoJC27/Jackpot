using System.Collections;
using UnityEngine;

public class Rueda : MonoBehaviour
{
    public Ranura[] ranuras;
    public Ranura ranuraSelected { get; private set; }
    public int ranuraIndex;
    public bool bloqueado = false;
    public MaquinaTragamonedas MTM;
    public GameObject lockIndicator;

    public bool Locked => locked;
    public bool locked = false;

    private void Start()
    {
        foreach(Ranura ranura in ranuras)
        {
            ranura.InitializeRanura(this);
        }
    }
    public IEnumerator SpinFor(float timeToSpin)
    {
        float elapsedTime = 0;
        ranuraIndex = Random.Range(0,ranuras.Length);
        while (timeToSpin > elapsedTime)
        {
            ranuras[ranuraIndex].gameObject.SetActive(false);
            ranuraIndex++;
            if (ranuraIndex % ranuras.Length == 0 && ranuraIndex != 0)
                ranuraIndex = 0;
            ranuras[ranuraIndex].gameObject.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            elapsedTime += 0.15f;
        }
        ranuraSelected = ranuras[ranuraIndex];
        MTM.OnStopSpinning();
    }

    public  void ToggleBlocked()
    {
        if(Locked) return;
        bloqueado = !bloqueado;
        lockIndicator.SetActive(bloqueado);
    }
    public  void SetBlocked(bool block)
    {
        if(Locked) return;
        bloqueado = block;
        lockIndicator.SetActive(bloqueado);

    }
    public void Unlock() { 
        locked = false; 
        lockIndicator.SetActive(locked);
    }
    public void Lock() { 
        locked = true; 
        lockIndicator.SetActive(locked);
    }
}
