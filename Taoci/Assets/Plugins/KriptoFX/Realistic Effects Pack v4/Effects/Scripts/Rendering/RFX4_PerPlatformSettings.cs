using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class RFX4_PerPlatformSettings : MonoBehaviour
{
    public bool DisableOnMobiles;
    public bool RenderMobileDistortion;
    [Range(0.1f, 1)] public float ParticleBudgetForMobiles = 0.5f;
    // Use this for initialization
    private bool isMobile;

    void Start()
    {


    }

    void Awake()
    {
        isMobile = IsMobilePlatform();
        if (isMobile)
        {
            if (DisableOnMobiles) gameObject.SetActive(false);
            else
            {
                ChangeParticlesBudget(ParticleBudgetForMobiles);
            }
        }
    }

    void OnEnable()
    {
        var cam = Camera.main;

        if (cam == null) return;
        if (RenderMobileDistortion && !DisableOnMobiles && isMobile)
        {
#if !KRIPTO_FX_LWRP_RENDERING && !KRIPTO_FX_HDRP_RENDERING
            var mobileDistortion = cam.GetComponent<RFX4_MobileDistortion>();
            if (mobileDistortion == null) cam.gameObject.AddComponent<RFX4_MobileDistortion>();
#endif
        }

        LWRP_Rendering();
    }

    void Update()
    {
        LWRP_Rendering();
    }

    void LWRP_Rendering()
    {
#if KRIPTO_FX_LWRP_RENDERING
        var cam = Camera.main;
        var mobileLwrpDistortion = cam.GetComponent<RFX4_RenderTransparentDistortion>();
        if (mobileLwrpDistortion == null) mobileLwrpDistortion = cam.gameObject.AddComponent<RFX4_RenderTransparentDistortion>();
        mobileLwrpDistortion.IsActive = true;
#endif
    }

    void OnDisable()
    {
        var cam = Camera.main;
        if (cam == null) return;
        if (RenderMobileDistortion && !DisableOnMobiles && isMobile)
        {

#if !KRIPTO_FX_LWRP_RENDERING && !KRIPTO_FX_HDRP_RENDERING
            var mobileDistortion = cam.GetComponent<RFX4_MobileDistortion>();
            if (mobileDistortion != null) DestroyImmediate(mobileDistortion);
#endif
        }

#if KRIPTO_FX_LWRP_RENDERING
        var mobileLwrpDistortion = cam.GetComponent<RFX4_RenderTransparentDistortion>();
        if (mobileLwrpDistortion != null) mobileLwrpDistortion.IsActive = false;
#endif
    }

    bool IsMobilePlatform()
    {
        bool isMobile = false;
#if UNITY_EDITOR
        if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android
            || EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS
            || EditorUserBuildSettings.activeBuildTarget == BuildTarget.WSAPlayer)
            isMobile = true;
#endif
        if (Application.isMobilePlatform) isMobile = true;
        return isMobile;
    }

    void ChangeParticlesBudget(float particlesMul)
    {
        var particles = GetComponent<ParticleSystem>();
        if (particles == null) return;

        var main = particles.main;
        main.maxParticles = Mathf.Max(1, (int)(main.maxParticles * particlesMul));

        var emission = particles.emission;
        if (!emission.enabled) return;

        var rateOverTime = emission.rateOverTime;
        {
            if (rateOverTime.constantMin > 1) rateOverTime.constantMin *= particlesMul;
            if (rateOverTime.constantMax > 1) rateOverTime.constantMax *= particlesMul;
            emission.rateOverTime = rateOverTime;
        }

        var rateOverDistance = emission.rateOverDistance;
        if (rateOverDistance.constantMin > 1)
        {
            if (rateOverDistance.constantMin > 1) rateOverDistance.constantMin *= particlesMul;
            if (rateOverDistance.constantMax > 1) rateOverDistance.constantMax *= particlesMul;
            emission.rateOverDistance = rateOverDistance;
        }

        ParticleSystem.Burst[] burst = new ParticleSystem.Burst[emission.burstCount];
        emission.GetBursts(burst);
        for (var i = 0; i < burst.Length; i++)
        {

            if (burst[i].minCount > 1) burst[i].minCount = (short)(burst[i].minCount * particlesMul);
            if (burst[i].maxCount > 1) burst[i].maxCount = (short)(burst[i].maxCount * particlesMul);
        }
        emission.SetBursts(burst);
    }
}
