using UnityEngine;

namespace EVP
{

    public class VehicleStandardInput : MonoBehaviour
    {
        public VehicleController target;
        public UpSpeed targetButtonUpSpeed;


        public enum ThrottleAndBrakeInput { SingleAxis, SeparateAxes };
        public ThrottleAndBrakeInput throttleAndBrakeInput = ThrottleAndBrakeInput.SingleAxis;
        public bool handbrakeOverridesThrottle = false;

        [Space(5)]
        public string steerAxis = "Horizontal";
        public string throttleAndBrakeAxis = "Vertical";
        public KeyCode resetVehicleKey = KeyCode.Return;

        bool m_doReset = false;

        void OnEnable()
        {
            // Cache vehicle

            if (target == null)
                target = GetComponent<VehicleController>();
        }


        void OnDisable()
        {
            if (target != null)
            {
                target.steerInput = 0.0f;
                target.throttleInput = 0.0f;
                target.brakeInput = 0.0f;
                target.handbrakeInput = 0.0f;
            }
        }


        void Update()
        {
            if (target == null) return;

            if (Input.GetKeyDown(resetVehicleKey)) m_doReset = true;
            //GameManager.Instance._directionCar.isBosst = Input.GetKey(KeyCode.LeftShift); // Kiểm tra phím U trong hàm Update()
        }


        void FixedUpdate()
        {
            if (target == null) return;

            // Read the user input

            //float steerInput = Mathf.Clamp(Input.GetAxis(steerAxis), -1.0f, 1.0f);
            float steerInput = Mathf.Clamp(GameManager.Instance._directionCar._speedVertical_Horizontal, -1.0f, 1.0f);
            float forwardInput = 0.0f;
            float reverseInput = 0.0f;


            //forwardInput = Mathf.Clamp01(Input.GetAxis(throttleAndBrakeAxis));
            //reverseInput = Mathf.Clamp01(-Input.GetAxis(throttleAndBrakeAxis));
            forwardInput = Mathf.Clamp01(UiController.Instance._uiManager._speedVertical_UP._speedCar);
            reverseInput = Mathf.Clamp01(-UiController.Instance._uiManager._speedVertical_DOWN._speedCar);
            // Translate forward/reverse to vehicle input

            float throttleInput = 0.0f;
            float brakeInput = 0.0f;


            float minSpeed = 0.1f;
            float minInput = 0.1f;

            if (target.speed > minSpeed)
            {
                throttleInput = forwardInput;
                brakeInput = reverseInput;
            }
            else
            {
                if (reverseInput > minInput)
                {
                    throttleInput = -reverseInput;
                    brakeInput = 0.0f;
                }
                else if (forwardInput > minInput)
                {
                    if (target.speed < -minSpeed)
                    {
                        throttleInput = 0.0f;
                        brakeInput = forwardInput;
                    }
                    else
                    {
                        throttleInput = forwardInput;
                        brakeInput = 0;
                    }
                }
            }

            // Apply input to vehicle

            target.steerInput = steerInput;
            target.throttleInput = throttleInput;
            if (GameManager.Instance._directionCar.isBosst) // Sử dụng biến m_uKeyPressed để kiểm tra phím U trong FixedUpdate()
            {
                target.maxSpeedForward = 600;//tăng target tốc độ
                target.maxDriveForce = 50000000000;//giảm thời gian tăng tốc cho car
                target.upSpeed = .000001f;//tăng giới hạn tốc độ cho car
                Debug.Log(target.maxSpeedForward);
            }
            else if(!GameManager.Instance._directionCar.isBosst && (target.maxSpeedForward != 60||target.upSpeed != .001f||target.maxDriveForce != 5000))
            {
                target.maxSpeedForward = 60;
                target.upSpeed = .001f;
                target.maxDriveForce = 5000;
            }
            
            target.brakeInput = brakeInput;

            // Do a vehicle reset

            if (m_doReset)
            {
                target.ResetVehicle();
                m_doReset = false;
            }
        }

    }
}