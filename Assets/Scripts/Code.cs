using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Code : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;
    public string enteredCode;
    public string generatedCode;
    public UnityEvent onDoorOpen;

    private void Awake()
    {
        generatedCode = Random.Range(1111, 9999).ToString();
    }

    private void Update()
    {
        textComponent.text = enteredCode;
    }
}
