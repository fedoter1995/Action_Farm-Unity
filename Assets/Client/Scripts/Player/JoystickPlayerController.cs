using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "PlayerController/JoystickPlayerController")]
public class JoystickPlayerController : PlayerController
{
    [SerializeField] private JoystickCanvas joystickCanvasPrefab;
    
    private Joystick joystick;
    private Button button;

    public override void InitInputs()
    {
        var canvas = Instantiate(joystickCanvasPrefab);
        joystick = canvas.GetComponentInChildren<Joystick>();
        button = canvas.GetComponentInChildren<Button>();
        button.onClick.AddListener(Attack);
        _userInput = new JoyStickInputManager(joystick);
    }
    public override void Move(float speed, Transform transform)
    {
        transform.Translate(_userInput.MoveVector * Time.fixedDeltaTime * speed, Space.World);

        if (_userInput.MoveVector != Vector3.zero)
        {
            transform.forward = _userInput.MoveVector;
        }
    }

}
