using UnityEngine;


namespace JP.Mytrix.Gameplay
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera camera;

        private float trauma;
        private float shake;

        public void AddTrauma(float value)
        {
            trauma = Mathf.Min(1.0f, trauma + value);
        }

        private Vector3 cameraPosition;
        private Vector3 shakePosition;

        private Quaternion cameraRotation;
        private Vector3 shakeRotation;
        
        public float maxOffset = 1f;

        private float noiseTime;
        

        private void Awake()
        {
            cameraPosition = camera.transform.position;
            cameraRotation = camera.transform.localRotation;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.U))
                AddTrauma(0.3f);
            
            shake = trauma * trauma * trauma;

            shakePosition.x = maxOffset * shake * GetNoise(0);
            shakePosition.y = maxOffset * shake * GetNoise(1);
            shakePosition.z = maxOffset * shake * GetNoise(2);

            camera.transform.position = cameraPosition + shakePosition;
            camera.transform.localRotation = cameraRotation;

            trauma = Mathf.Max(0.0f, trauma - (Time.deltaTime * (1 / 2f)));
        }

        private float GetNoise(float offset)
        {
            noiseTime += Time.deltaTime *4 ;

            return (Mathf.PerlinNoise(noiseTime, offset) * 2) - 1f;
        }
    }
}
