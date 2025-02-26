﻿/************************************************************************************

Filename    :   OculusSpatializerUserParamsEditor.cs
Content     :   This script adds editor functionality to OculusSpatializerUserParams script.
Created     :   December 14, 2015
Authors     :   Peter Giokaris

Copyright   :   Copyright 2015 Oculus VR, Inc. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.1 (the "License"); 
you may not use the Oculus VR Rift SDK except in compliance with the License, 
which is provided at the time of installation or download, or which 
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

http://www.oculusvr.com/licenses/LICENSE-3.1 

Unless required by applicable law or agreed to in writing, the Oculus VR SDK 
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
************************************************************************************/
#define CUSTOM_LAYOUT

using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(ONSPAudioSource))]

public class OculusSpatializerUserParamsEditor : Editor
{
	// target component
	private ONSPAudioSource m_Component;
	
	// highlight color
	// Color HColor = Color.green;

	// Pop-up box for frequency hints
	string[] freqHints = new[] {"None", "Wide", "Narrow"};

	// OnEnable
	void OnEnable()
	{
		m_Component = (ONSPAudioSource)target;
	}
	
	// OnDestroy
	void OnDestroy()
	{
	}
	
	// OnInspectorGUI
	public override void OnInspectorGUI()
	{
		GUI.color = Color.white;
		Undo.RecordObject(m_Component, "OculusSpatializerUserParams");
		
		{
			#if CUSTOM_LAYOUT
			m_Component.EnableSpatialization = EditorGUILayout.Toggle("Enable Spatialization", m_Component.EnableSpatialization);
			m_Component.DisableRfl  = EditorGUILayout.Toggle("Disable Reflections", m_Component.DisableRfl);
			m_Component.Gain  = EditorGUILayout.FloatField("Gain", m_Component.Gain);

			Separator();

			Label ("INVERSE SQUARE ATTENUATION");
			m_Component.UseInvSqr = EditorGUILayout.Toggle("Enable", m_Component.UseInvSqr);
			Label ("");
			Label("FALLOFF RANGE (0 - 1000000 meters)");
			m_Component.Near  = EditorGUILayout.FloatField("Near", m_Component.Near);
			m_Component.Far   = EditorGUILayout.FloatField("Far", m_Component.Far);

			Separator();
/*
			// Reference GUI Layout fields
			m_Component.VerticalFOV         = EditorGUILayout.FloatField("Vertical FOV", m_Component.VerticalFOV);
			m_Component.NeckPosition 		= EditorGUILayout.Vector3Field("Neck Position", m_Component.NeckPosition);
			m_Component.UsePlayerEyeHeight  = EditorGUILayout.Toggle ("Use Player Eye Height", m_Component.UsePlayerEeHeight);
			m_Component.FollowOrientation   = EditorGUILayout.ObjectField("Follow Orientation", 
																		m_Component.FollowOrientation,
																		typeof(Transform), true) as Transform;
			m_Component.BackgroundColor 	= EditorGUILayout.ColorField("Background Color", m_Component.BackgroundColor);
			OVREditorGUIUtility.Separator();
*/
			
			#else			 
			DrawDefaultInspector ();
			#endif
		}
		
		if (GUI.changed)
		{
			EditorUtility.SetDirty(m_Component);
		}
	}	
	
	// Utilities, move out of here (or copy over to other editor script)
	
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

