using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void OpenPanel()
    {
        panel.SetActive(true);
    }
}
