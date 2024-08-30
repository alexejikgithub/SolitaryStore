using UnityEngine;

public class Good : MonoBehaviour
{
    [SerializeField] private GoodType _goodType;

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}