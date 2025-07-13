using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingSetup : MonoBehaviour
{
    public Volume globalVolume;

    private ColorAdjustments colorAdjustments;
    private Vignette vignette;
    private FilmGrain filmGrain;
    private Bloom bloom;

    void Start()
    {
        if (globalVolume == null)
        {
            Debug.LogError("Assign the Global Volume in the Inspector!");
            return;
        }

        // If no profile assigned, create one
        if (globalVolume.sharedProfile == null)
        {
            VolumeProfile profile = ScriptableObject.CreateInstance<VolumeProfile>();
            globalVolume.sharedProfile = profile;
        }

        VolumeProfile volumeProfile = globalVolume.sharedProfile;

        // Add or get Color Adjustments
        if (!volumeProfile.TryGet(out colorAdjustments))
        {
            colorAdjustments = volumeProfile.Add<ColorAdjustments>(true);
        }
        colorAdjustments.saturation.value = -100f;
        colorAdjustments.contrast.value = 100f;
        colorAdjustments.postExposure.value = -2f;
        colorAdjustments.colorFilter.value = new Color(0.1f, 0.1f, 0.1f);

        colorAdjustments.active = true;

        // Add or get Vignette
        if (!volumeProfile.TryGet(out vignette))
        {
            vignette = volumeProfile.Add<Vignette>(true);
        }
        vignette.intensity.value = 1f;
        vignette.smoothness.value = 0.9f;
        vignette.active = true;

        // Add or get Film Grain
        if (!volumeProfile.TryGet(out filmGrain))
        {
            filmGrain = volumeProfile.Add<FilmGrain>(true);
        }
        filmGrain.intensity.value = 1f;
        filmGrain.response.value = 1f;
        filmGrain.type.value = FilmGrainLookup.Thin1;
        filmGrain.active = true;

        // Add or get Bloom (optional)
        if (!volumeProfile.TryGet(out bloom))
        {
            bloom = volumeProfile.Add<Bloom>(true);
        }
        bloom.intensity.value = 0.2f;
        bloom.active = true;
    }
}
