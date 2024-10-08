using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tm;
    private int currentBullets = 0;
    private int maxBullets = 0;

    private void Start()
    {
        tm.text = "" + currentBullets.ToString() + "/" + maxBullets.ToString();
    }

    public void SetMaxBullets(int numBullets)
    {
        maxBullets = numBullets;
        tm.text = currentBullets.ToString() + "/" + maxBullets.ToString();
    }

    public void SetCurrentBullets(int numBullets)
    {
        currentBullets = numBullets;
        tm.text = currentBullets.ToString() + "/" + maxBullets.ToString();
    }
}
