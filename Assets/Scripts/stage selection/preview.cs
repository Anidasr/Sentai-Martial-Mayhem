using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject previewObject; // Objek preview yang ingin ditampilkan

    private void Start()
    {
        // Awalnya, pastikan previewObject tidak aktif
        previewObject.SetActive(false);
    }

    // Saat pointer masuk ke atas tombol
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Aktifkan objek preview
        previewObject.SetActive(true);
    }

    // Saat pointer keluar dari tombol
    public void OnPointerExit(PointerEventData eventData)
    {
        // Nonaktifkan objek preview kembali
        previewObject.SetActive(false);
    }
}
