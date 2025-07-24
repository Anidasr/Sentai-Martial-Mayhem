using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Addition : MonoBehaviour
{
    public static Addition Instance;

    [SerializeField]
    private TextMeshProUGUI textValue;
    [SerializeField]
    private Image CD_layer;
    [SerializeField]
    private float current, max;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        textValue.text = current.ToString("N2");
    }

    private void Update()
    {
        current -= Time.deltaTime;
        textValue.text = current.ToString("N2");

        if(current <= 0)
        {
            Destroy(gameObject);
        }
    }

}
