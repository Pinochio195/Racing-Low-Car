using UnityEngine;

namespace EVP
{

    public class VehicleStandardInput : MonoBehaviour
    {
        public VehicleController target;


        public enum ThrottleAndBrakeInput { SingleAxis, SeparateAxes };
        public ThrottleAndBrakeInput throttleAndBrakeInput = ThrottleAndBrakeInput.SingleAxis;
        public bool handbrakeOverridesThrottle = false;

        [Space(5)]
        public string steerAxis = "Horizontal";
        public string throttleAndBrakeAxis = "Vertical";
        public string handbrakeAxis = "Jump";
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
        }


        void FixedUpdate()
        {
            if (target == null) return;

            // Read the user input

            float steerInput = Mathf.Clamp(Input.GetAxis(steerAxis), -1.0f, 1.0f);
            float handbrakeInput = Mathf.Clamp01(Input.GetAxis(handbrakeAxis));

            float forwardInput = 0.0f;
            float reverseInput = 0.0f;


            forwardInput = Mathf.Clamp01(Input.GetAxis(throttleAndBrakeAxis));
            reverseInput = Mathf.Clamp01(-Input.GetAxis(throttleAndBrakeAxis));
            //Debug.Log(forwardInput);

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


            // Override throttle if specified

            if (handbrakeOverridesThrottle)
            {
                throttleInput *= 1.0f - handbrakeInput;
            }

            // Apply input to vehicle

            target.steerInput = steerInput;
            target.throttleInput = throttleInput;
            target.brakeInput = brakeInput;
            target.handbrakeInput = handbrakeInput;

            // Do a vehicle reset

            if (m_doReset)
            {
                target.ResetVehicle();
                m_doReset = false;
            }
        }

    }
}