using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Unity.RenderStreaming.Samples
{
    class WebBrowserInputSample : MonoBehaviour
    {
        [SerializeField] RenderStreaming renderStreaming;
        [SerializeField] private Button setUpButton;
        [SerializeField] private Button hangUpButton;
        [SerializeField] Dropdown dropdownCamera;
        [SerializeField] Transform[] cameras;
        [SerializeField] CopyTransform copyTransform;
        [SerializeField] SingleConnection singleConnection;

        [SerializeField] string connectionId;

        private void Awake()
        {
            setUpButton.onClick.AddListener(SetUp);
            hangUpButton.onClick.AddListener(HangUp);

            setUpButton.interactable = true;
            hangUpButton.interactable = false;
        }

        // Start is called before the first frame update
        void Start()
        {
            dropdownCamera.onValueChanged.AddListener(OnChangeCamera);

            if (renderStreaming.runOnAwake)
                return;
            renderStreaming.Run(
                hardwareEncoder: RenderStreamingSettings.EnableHWCodec,
                signaling: RenderStreamingSettings.Signaling);
        }

        private void SetUp()
        {
            setUpButton.interactable = false;
            hangUpButton.interactable = true;

            singleConnection.CreateConnection(connectionId);
        }

        private void HangUp()
        {
            setUpButton.interactable = true;
            hangUpButton.interactable = false;

            singleConnection.DeleteConnection(connectionId);
        }

        void OnChangeCamera(int value)
        {
            copyTransform.SetOrigin(cameras[value]);
        }
    }
}
