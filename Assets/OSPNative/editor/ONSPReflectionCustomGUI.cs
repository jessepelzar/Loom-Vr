using UnityEditor;
using UnityEngine;
using System.Runtime.InteropServices;

public class OculusSpatializerReflectionCustomGUI : IAudioEffectPluginGUI
{
    public override string Name
    {
        get { return "OculusSpatializerReflection"; }
    }

    public override string Description
    {
        get { return "Reflection parameters for Oculus Spatializer"; }
    }

    public override string Vendor
    {
        get { return "Oculus"; }
    }
	
    public override bool OnGUI(IAudioEffectPlugin plugin)
    {
		float fval = 0.0f;
		bool  bval = false;

		// Treat these floats as bools in the inspector
		plugin.GetFloatParameter("E.Rflt On", out fval);
		bval = (fval == 0.0f) ? false : true;
		bval = EditorGUILayout.Toggle("Early Refl. On", bval);
		plugin.SetFloatParameter("E.Rflt On", (bval == false) ? 0.0f : 1.0f);

		plugin.GetFloatParameter("E.Rflt Rev On", out fval);
		bval = (fval == 0.0f) ? false : true;
		bval = EditorGUILayout.Toggle("Reverb On", bval);
		plugin.SetFloatParameter("E.Rflt Rev On", (bval == false) ? 0.0f : 1.0f);

		Separator();
		Label("ROOM DIMENSIONS (meters)");
		Label("");
		plugin.GetFloatParameter("Room X", out fval);
		plugin.SetFloatParameter("Room X", EditorGUILayout.Slider("Room Size X", fval, 1.0f, 200.0f));
		plugin.GetFloatParameter("Room Y", out fval);
		plugin.SetFloatParameter("Room Y", EditorGUILayout.Slider("Room Size Y", fval, 1.0f, 200.0f));
		plugin.GetFloatParameter("Room Z", out fval);
		plugin.SetFloatParameter("Room Z", EditorGUILayout.Slider("Room Size Z", fval, 1.0f, 200.0f));

		Separator();
		Label("WALL REFLECTION VALUES (0-0.97)");
		Label("");

		plugin.GetFloatParameter("Left", out fval);
		plugin.SetFloatParameter("Left", EditorGUILayout.Slider("Left", fval, 0.0f, 0.97f));
		plugin.GetFloatParameter("Right", out fval);
		plugin.SetFloatParameter("Right", EditorGUILayout.Slider("Right", fval, 0.0f, 0.97f));
		plugin.GetFloatParameter("Up", out fval);
		plugin.SetFloatParameter("Up", EditorGUILayout.Slider("Up", fval, 0.0f, 0.97f));
		plugin.GetFloatParameter("Down", out fval);
		plugin.SetFloatParameter("Down", EditorGUILayout.Slider("Down", fval, 0.0f, 0.97f));
		plugin.GetFloatParameter("Behind", out fval);
		plugin.SetFloatParameter("Behind", EditorGUILayout.Slider("Behind", fval, 0.0f, 0.97f));
		plugin.GetFloatParameter("Front", out fval);
		plugin.SetFloatParameter("Front", EditorGUILayout.Slider("Front", fval, 0.0f, 0.97f));

		// We will override the controls with our own, so return false
		return false;
    }

	// Separator
	void Separator()
	{
		GUI.color = new Color(1, 1, 1, 0.25f);
		GUILayout.Box("", "HorizontalSlider", GUILayout.Height(16));
		GUI.color = Color.white;
	}
	
	// Label
	void Label(string label)
	{
		EditorGUILayout.LabelField (label);
	}


}
