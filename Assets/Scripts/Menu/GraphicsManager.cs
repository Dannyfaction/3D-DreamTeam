using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GraphicsManager : MonoBehaviour {

	public Dropdown GraphicsSettings;
	public Dropdown AntiAliasingSettings;
	public Dropdown ShadowSettings;
	public Dropdown VSyncSettings;
	public Dropdown TextureSettings;

	void Start () {

		AntiAliasingSettings.value = 2;
		ShadowSettings.value = 3;
		VSyncSettings.value = 1;
		TextureSettings.value = 1;

		GraphicsSettings.onValueChanged.AddListener (delegate {
			ChangeGraphics(GraphicsSettings);
		});
		AntiAliasingSettings.onValueChanged.AddListener (delegate {
			ChangeAntiAliasing(AntiAliasingSettings);
		});
		ShadowSettings.onValueChanged.AddListener (delegate {
			ChangeShadows(ShadowSettings);
		});
		VSyncSettings.onValueChanged.AddListener (delegate {
			ChangeVSync(VSyncSettings);
		});
		TextureSettings.onValueChanged.AddListener (delegate {
			ChangeTextures(TextureSettings);
		});
	}

	public void ChangeGraphics (Dropdown _dropdown){
		if (_dropdown.value == 0) {
			QualitySettings.SetQualityLevel (6);
			AntiAliasingSettings.value = 2;
			ShadowSettings.value = 3;
			VSyncSettings.value = 1;
			TextureSettings.value = 1;
		} else if (_dropdown.value == 1) {
			QualitySettings.SetQualityLevel (3);
			AntiAliasingSettings.value = 1;
			ShadowSettings.value = 2;
			VSyncSettings.value = 1;
			TextureSettings.value = 2;
		} else if (_dropdown.value == 2) {
			QualitySettings.SetQualityLevel (0);
			AntiAliasingSettings.value = 0;
			ShadowSettings.value = 1;
			VSyncSettings.value = 0;
			TextureSettings.value = 3;
		}
	}

	public void ChangeAntiAliasing (Dropdown _dropdown){
		if (_dropdown.value == 0) {
			QualitySettings.antiAliasing = 0;
		} else if (_dropdown.value == 1) {
			QualitySettings.antiAliasing = 2;
		} else if (_dropdown.value == 2) {
			QualitySettings.antiAliasing = 4;
		} else if (_dropdown.value == 3) {
			QualitySettings.antiAliasing = 8;
		}
	}

	public void ChangeShadows (Dropdown _dropdown) {
		if (_dropdown.value == 0) {
			QualitySettings.shadowDistance = 0;
			QualitySettings.shadowCascades = 0;
			QualitySettings.shadowProjection = ShadowProjection.CloseFit;
		} else if (_dropdown.value == 1) {
			QualitySettings.shadowDistance = 15;
			QualitySettings.shadowCascades = 0;
			QualitySettings.shadowProjection = ShadowProjection.CloseFit;
		} else if (_dropdown.value == 2) {
			QualitySettings.shadowDistance = 40;
			QualitySettings.shadowCascades = 2;
			QualitySettings.shadowProjection = ShadowProjection.CloseFit;
		} else if (_dropdown.value == 3) {
			QualitySettings.shadowDistance = 100;
			QualitySettings.shadowCascades = 4;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
		} else if (_dropdown.value == 4) {
			QualitySettings.shadowDistance = 200;
			QualitySettings.shadowCascades = 4;
			QualitySettings.shadowProjection = ShadowProjection.StableFit;
		}
	}

	public void ChangeVSync (Dropdown _dropdown){
		if (_dropdown.value == 0) {
			QualitySettings.vSyncCount = 0;
		} else if (_dropdown.value == 1) {
			QualitySettings.vSyncCount = 1;
		} else if (_dropdown.value == 2) {
			QualitySettings.vSyncCount = 2;
		}
	}

	public void ChangeTextures (Dropdown _dropdown){
		if (_dropdown.value == 0) {
			QualitySettings.masterTextureLimit = 0;
		} else if (_dropdown.value == 1) {
			QualitySettings.masterTextureLimit = 1;
		} else if (_dropdown.value == 2) {
			QualitySettings.masterTextureLimit = 2;
		} else if (_dropdown.value == 3) {
			QualitySettings.masterTextureLimit = 3;
		}
	}
		
}
