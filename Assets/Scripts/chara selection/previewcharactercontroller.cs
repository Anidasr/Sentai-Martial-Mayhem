using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class previewcharactercontroller : MonoBehaviour
{
    public GameObject preview1;
    public GameObject preview2;
    public GameObject preview3;
    public GameObject preview4;
    public GameObject previewability1;
    public GameObject previewability2;
    public GameObject previewability3;
    public GameObject previewability4;


    private void Start()
    {
        HidePreviews(); // Sembunyikan pratinjau awalnya saat permainan dimulai
    }
    public void ShowPreview1()
    {
        preview1.SetActive(true);
        previewability1.SetActive(true);
        preview4.SetActive(false);
        previewability4.SetActive(false);
    }
    public void ShowPreview2()
    {
        preview2.SetActive(true);
        previewability2.SetActive(true);
        preview4.SetActive(false);
        previewability4.SetActive(false);
    }

    public void ShowPreview3()
    {
        preview3.SetActive(true);
        previewability3.SetActive(true);
        preview4.SetActive(false);
        previewability4.SetActive(false);
    }

    public void HidePreviews()
    {
        preview1.SetActive(false);
        preview2.SetActive(false);
        preview3.SetActive(false);
        previewability1.SetActive(false);
        previewability2.SetActive(false);
        previewability3.SetActive(false);
        preview4.SetActive(true);
        previewability4.SetActive(true);
}
}
