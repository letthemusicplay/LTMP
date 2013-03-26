using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Vortex")]
public class VortexEffect : ImageEffectBase {
	public Vector2  radius = new Vector2(0.4F,0.4F);
	public float    angle = 50;
	private float    randomAngle = 50;
	public Vector2  center = new Vector2(0.5F, 0.5F);
	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		ImageEffects.RenderDistortion (material, source, destination, angle, center, radius);
	}
	
	void Update() {
		if(Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			randomAngle = angle * Random.value;
		}
	}
}
