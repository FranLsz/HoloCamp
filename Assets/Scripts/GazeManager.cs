using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeManager : MonoBehaviour
{

    public static GazeManager Instance { get; private set; }
    public GameObject FocusedObject { get; private set; }
    private GestureRecognizer _gestureRecognizer;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        _gestureRecognizer = new GestureRecognizer();
        _gestureRecognizer.TappedEvent += (source, tapCount, hitInfo) =>
        {
            if (FocusedObject != null)
                FocusedObject.SendMessage("OnSelect");
        };
        _gestureRecognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        var oldFocusedObject = FocusedObject;

        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        FocusedObject = Physics.Raycast(headPosition, gazeDirection, out hitInfo) ? hitInfo.collider.gameObject : null;

        if (oldFocusedObject != FocusedObject)
        {
            _gestureRecognizer.CancelGestures();
            _gestureRecognizer.StartCapturingGestures();
        }
    }
}
