using TMPro;
using UnityEngine;

public class Code : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    public string enteredCode;
    public string generatedCode;

    private void Start()
    {
        generatedCode = Random.Range(1111, 9999).ToString();
    }

    private void Update()
    {
        textComponent.text = enteredCode;
    }
}
