using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public Material newMaterial;
    public Material originalMaterial;
    public XRSocketInteractor socketInteractor; // Reference to the socket interactor
    public SceneTransitionManager sceneTransitionManager;

    private bool isPressed = false;
    private GameObject presser;

    void Start()
    {
        Renderer buttonRenderer = button.GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            originalMaterial = buttonRenderer.material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.001f, -0.003f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = newMaterial;
            }

            presser = other.gameObject;
            isPressed = true;

            CheckCartridgeAndChangeScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.013f, -0.016f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = originalMaterial;
            }
            isPressed = false;
        }
    }

    private void CheckCartridgeAndChangeScene()
    {
        // Assuming each cartridge has a CartridgeScript with a sceneName variable
        CartridgeScript1 cartridge = socketInteractor.selectTarget?.GetComponent<CartridgeScript1>();

        if (cartridge != null)
        {
            string sceneName = cartridge.sceneName;
            sceneTransitionManager.GoToSceneAsync(int.Parse(sceneName)); // Change this line
            Debug.Log(sceneName);
        }
    }
}
