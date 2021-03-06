using UnityEngine;

[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class FractalMaster : MonoBehaviour {

    public ComputeShader fractalShader;

    public int currentMandelbulb; 
    public int currentGeneration;

    [Range (1, 20)]
    public float fractalPower = 10;
    public float darkness = 70;

    [Header ("Colour mixing")]
    [Range (0, 1)] public float blackAndWhite;
    [Range (0, 1)] public float redA;
    [Range (0, 1)] public float greenA;
    [Range (0, 1)] public float blueA = 1;
    [Range (0, 1)] public float redB = 1;
    [Range (0, 1)] public float greenB;
    [Range (0, 1)] public float blueB;

    RenderTexture target;
    Camera cam;
    Light directionalLight;

    [Header ("Animation Settings")]
    public float powerIncreaseSpeed = 0.2f;

    void Start() {
        Application.targetFrameRate = 60;
        currentGeneration = 0;
        currentMandelbulb = 0;
    }

    public void setBlueA(float newValue) {
        blueA = newValue;
    }
    public void setRedA(float newValue)
    {
        redA = newValue;
    }
    public void setGreenA(float newValue)
    {
        greenA = newValue;
    }
    public void setBlueB(float newValue)
    {
        blueB = newValue;
    }
    public void setRedB(float newValue)
    {
        redB = newValue;
    }
    public void setGreenB(float newValue)
    {
        greenB = newValue;
    }
    public void setFractalPower(float newValue)
    {
        fractalPower = newValue;
    }

    public void setDarkness(float newValue)
    {
        darkness = newValue;
    }

    public void setAnimationSpeed(float newSpeed)
    {
        powerIncreaseSpeed = newSpeed;
    }

    public void setSaturation(float newValue)
    {
        blackAndWhite = 1-newValue;
    }

    void Init () {
        cam = Camera.current;
        directionalLight = FindObjectOfType<Light> ();
    }

    // Animate properties
    void Update () {
        if (Application.isPlaying) {
            fractalPower += powerIncreaseSpeed * Time.deltaTime;
        }
    }

   

    void OnRenderImage (RenderTexture source, RenderTexture destination) {
        Init ();
        InitRenderTexture ();
        SetParameters ();

        int threadGroupsX = Mathf.CeilToInt (cam.pixelWidth / 8.0f);
        int threadGroupsY = Mathf.CeilToInt (cam.pixelHeight / 8.0f);
        fractalShader.Dispatch (0, threadGroupsX, threadGroupsY, 1);

        Graphics.Blit (target, destination);
    }

    void SetParameters () {
        fractalShader.SetTexture (0, "Destination", target);
        fractalShader.SetFloat ("power", Mathf.Max (fractalPower, 1.01f));
        fractalShader.SetFloat ("darkness", darkness);
        fractalShader.SetFloat ("blackAndWhite", blackAndWhite);
        fractalShader.SetVector ("colourAMix", new Vector3 (redA, greenA, blueA));
        fractalShader.SetVector ("colourBMix", new Vector3 (redB, greenB, blueB));

        fractalShader.SetMatrix ("_CameraToWorld", cam.cameraToWorldMatrix);
        fractalShader.SetMatrix ("_CameraInverseProjection", cam.projectionMatrix.inverse);
        fractalShader.SetVector ("_LightDirection", directionalLight.transform.forward);

    }

    void InitRenderTexture () {
        if (target == null || target.width != cam.pixelWidth || target.height != cam.pixelHeight) {
            if (target != null) {
                target.Release ();
            }
            target = new RenderTexture (cam.pixelWidth, cam.pixelHeight, 0, RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
            target.enableRandomWrite = true;
            target.Create ();
        }
    }

    public void setGenParams(FractalParams fP)
    {
        this.blackAndWhite = fP.blackAndWhite;
        this.blueA = fP.blueA;
        this.blueB= fP.blueB;
        this.redA = fP.redA;
        this.redB= fP.redB;
        this.greenA= fP.greenA;
        this.greenB= fP.greenB;
        this.fractalPower= fP.fractalPower;
        this.darkness = fP.darkness;
    }

    public void increaseCurrentMandelbulbIdx()
    {
        currentMandelbulb++;
    }
    public void resetCurrentMandelbulbIdx()
    {
        currentMandelbulb = 0;
    }

    public void increaseCurrentGenerationIdx()
    {
        currentGeneration++;
    }
}