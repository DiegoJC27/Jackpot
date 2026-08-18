using System.Collections;
using UnityEngine;

public class Rueda : MonoBehaviour
{
    public int ruedaSize = 4;
    public Ranura[] ranuras;
    public Ranura ranuraSelected { get; private set; }
    public int ranuraIndex;
    public bool bloqueado = false;
    public MaquinaTragamonedas MTM;
    public GameObject bloqueoIndicator;

    private void Start()
    {
        foreach(Ranura ranura in ranuras)
        {
            ranura.SetMiRueda(this);
        }
    }
    public IEnumerator SpinFor(float timeToSpin)
    {
        float elapsedTime = 0;
        ranuraIndex = Random.Range(0,ruedaSize);
        while (timeToSpin > elapsedTime)
        {
            ranuras[ranuraIndex].gameObject.SetActive(false);
            ranuraIndex++;
            if (ranuraIndex % ruedaSize == 0 && ranuraIndex != 0)
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
        bloqueado = !bloqueado;
        bloqueoIndicator.SetActive(bloqueado);
    }
    public  void SetBlocked(bool block)
    {
        bloqueado = block;
        bloqueoIndicator.SetActive(block);
    }
}
