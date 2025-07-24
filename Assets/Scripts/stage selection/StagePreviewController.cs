using UnityEngine;
using UnityEngine.UI;

public class StagePreviewController : MonoBehaviour
{
    public GameObject preview2;
    public GameObject preview3;

    private void Start()
    {
        HidePreviews(); // Sembunyikan pratinjau awalnya saat permainan dimulai
    }

    public void ShowPreview2()
    {
        preview2.SetActive(true);
    }

    public void ShowPreview3()
    {
        preview3.SetActive(true);
    }

    public void HidePreviews()
    {
        preview2.SetActive(false);
        preview3.SetActive(false);
    }
}
