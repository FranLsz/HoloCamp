using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public void OnSelect()
    {
        var newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<MeshRenderer>().material.color = newColor;
    }
}