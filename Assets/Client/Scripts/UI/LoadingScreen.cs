using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Image _progressBar;


    public void UpdateProgressBar(float value)
    {
        _progressBar.fillAmount = value;
    }
}
