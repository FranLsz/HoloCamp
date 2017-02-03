using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    // Use this for initialization
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            transform.position = hitInfo.point;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);

            _meshRenderer.enabled = true;
        }
        else
            _meshRenderer.enabled = false;
    }
}
