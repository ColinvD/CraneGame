using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode _forwardButton = KeyCode.W;
    [SerializeField] private KeyCode _backwardButton = KeyCode.S;
    [SerializeField] private KeyCode _leftButton = KeyCode.A;
    [SerializeField] private KeyCode _rightButton = KeyCode.D;
    [SerializeField] private KeyCode _upButton = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downButton = KeyCode.DownArrow;
    [SerializeField] private KeyCode _dropButton = KeyCode.Space;

    public KeyCode ForwardButton
    {
        get { return _forwardButton; }
    }
    
    public KeyCode BackwardButton
    {
        get { return _backwardButton; }
    }
    
    public KeyCode LeftButton
    {
        get { return _leftButton; }
    }
    
    public KeyCode RightButton
    {
        get { return _rightButton; }
    }
    
    public KeyCode UpButton
    {
        get { return _upButton; }
    }
    
    public KeyCode DownButton
    {
        get { return _downButton; }
    }
    
    public KeyCode DropButton
    {
        get { return _dropButton; }
    }
}
