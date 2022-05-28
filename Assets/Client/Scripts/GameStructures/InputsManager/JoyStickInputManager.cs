
using UnityEngine;

public class JoyStickInputManager : IInputManager
{
    private Joystick _joyStick;

    public JoyStickInputManager(Joystick joyStick)
    {
        _joyStick = joyStick;
    }

    public Vector3 MoveVector
    {
        get
        {
            return new Vector3(_joyStick.Horizontal, 0, _joyStick.Vertical).normalized;
        }
    }

    public float MoveFloat
    {
        get
        {
            return Mathf.Abs(MoveVector.x) + Mathf.Abs(MoveVector.z);
        }
    }

}
