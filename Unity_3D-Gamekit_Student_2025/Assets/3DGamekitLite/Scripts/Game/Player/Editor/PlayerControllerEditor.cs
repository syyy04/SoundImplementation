using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Gamekit3D
{
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : Editor
    {
        SerializedProperty m_ScriptProp;

        SerializedProperty m_MaxForwardSpeedProp;
        SerializedProperty m_GravityProp;
        SerializedProperty m_JumpSpeedProp;
        SerializedProperty m_MinTurnSpeedProp;
        SerializedProperty m_MaxTurnSpeedProp;
        SerializedProperty m_IdleTimeoutProp;
        SerializedProperty m_CanAttackProp;

        SerializedProperty m_MeleeWeaponProp;
        SerializedProperty m_CameraSettingsProp;
        SerializedProperty m_FootstepPlayerProp;
        SerializedProperty m_HurtAudioPlayerProp;

        GUIContent m_ScriptContent = new GUIContent("Script");

        GUIContent m_MaxForwardSpeedContent = new GUIContent("Max Forward Speed", "How fast Ellen can run.");
        GUIContent m_GravityContent = new GUIContent("Gravity", "How fast Ellen falls when in the air.");
        GUIContent m_JumpSpeedContent = new GUIContent("Jump Speed", "How fast Ellen takes off when jumping.");
        GUIContent m_TurnSpeedContent = new GUIContent("Turn Speed", "How fast Ellen turns.  This varies depending on how fast she is moving.  When stationary the maximum will be used and when running at Max Forward Speed the minimum will be used.");
        GUIContent m_IdleTimeoutContent = new GUIContent("Idle Timeout", "How many seconds before Ellen starts considering random Idle poses.");
        GUIContent m_CanAttackContent = new GUIContent("Can Attack", "Whether or not Ellen can attack with her staff.  This can be set externally.");

        GUIContent m_MeleeWeaponContent = new GUIContent("Melee Weapon", "Used for damaging enemies when Ellen swings her staff.");
        GUIContent m_CameraSettingsContent = new GUIContent("Camera Settings", "Used to get the rotation of the current camera so that Ellen faces the correct direction.  Note: This is the only reference which is not part of the Ellen prefab.  It should automatically be set to the Camera Settings script of the CameraRig gameobject when the Prefab is instantiated.");
        GUIContent m_FootstepPlayerContent = new GUIContent("Footstep Source", "Used as a position to play the footstep sound.");
        GUIContent m_HurtAudioPlayerContent = new GUIContent("Voice Source", "Used as a position to play Ellens voice.");

        void OnEnable()
        {
            m_ScriptProp = serializedObject.FindProperty("m_Script");

            m_MaxForwardSpeedProp = serializedObject.FindProperty("maxForwardSpeed");
            m_GravityProp = serializedObject.FindProperty("gravity");
            m_JumpSpeedProp = serializedObject.FindProperty("jumpSpeed");
            m_MinTurnSpeedProp = serializedObject.FindProperty("minTurnSpeed");
            m_MaxTurnSpeedProp = serializedObject.FindProperty("maxTurnSpeed");
            m_IdleTimeoutProp = serializedObject.FindProperty("idleTimeout");
            m_CanAttackProp = serializedObject.FindProperty("canAttack");

            m_MeleeWeaponProp = serializedObject.FindProperty("meleeWeapon");
            m_CameraSettingsProp = serializedObject.FindProperty("cameraSettings");
            m_FootstepPlayerProp = serializedObject.FindProperty("footstepSource");
            m_HurtAudioPlayerProp = serializedObject.FindProperty("voiceSource");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUI.enabled = false;
            EditorGUILayout.PropertyField(m_ScriptProp, m_ScriptContent);
            GUI.enabled = true;

            m_MaxForwardSpeedProp.floatValue = EditorGUILayout.Slider(m_MaxForwardSpeedContent, m_MaxForwardSpeedProp.floatValue, 4f, 12f);
            m_GravityProp.floatValue = EditorGUILayout.Slider(m_GravityContent, m_GravityProp.floatValue, 10f, 30f);
            m_JumpSpeedProp.floatValue = EditorGUILayout.Slider(m_JumpSpeedContent, m_JumpSpeedProp.floatValue, 5f, 20f);

            MinMaxTurnSpeed();

            EditorGUILayout.PropertyField(m_IdleTimeoutProp, m_IdleTimeoutContent);
            EditorGUILayout.PropertyField(m_CanAttackProp, m_CanAttackContent);

            EditorGUILayout.Space();

            m_MeleeWeaponProp.isExpanded = EditorGUILayout.Foldout(m_MeleeWeaponProp.isExpanded, "References");

            if (m_MeleeWeaponProp.isExpanded)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_MeleeWeaponProp, m_MeleeWeaponContent);
                EditorGUILayout.PropertyField(m_CameraSettingsProp, m_CameraSettingsContent);
                EditorGUILayout.PropertyField(m_FootstepPlayerProp, m_FootstepPlayerContent);
                EditorGUILayout.PropertyField(m_HurtAudioPlayerProp, m_HurtAudioPlayerContent);
                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();
        }

        void MinMaxTurnSpeed()
        {
            Rect position = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);

            const float spacing = 4f;
            const float intFieldWidth = 50f;

            position.width -= spacing * 3f + intFieldWidth * 2f;

            Rect labelRect = position;
            labelRect.width *= 0.48f;

            Rect minRect = position;
            minRect.width = 50f;
            minRect.x += labelRect.width + spacing;

            Rect sliderRect = position;
            sliderRect.width *= 0.52f;
            sliderRect.x += labelRect.width + minRect.width + spacing * 2f;

            Rect maxRect = position;
            maxRect.width = minRect.width;
            maxRect.x += labelRect.width + minRect.width + sliderRect.width + spacing * 3f;

            EditorGUI.LabelField(labelRect, m_TurnSpeedContent);
            m_MinTurnSpeedProp.floatValue = EditorGUI.IntField(minRect, (int)m_MinTurnSpeedProp.floatValue);

            float minTurnSpeed = m_MinTurnSpeedProp.floatValue;
            float maxTurnSpeed = m_MaxTurnSpeedProp.floatValue;
            EditorGUI.MinMaxSlider(sliderRect, GUIContent.none, ref minTurnSpeed, ref maxTurnSpeed, 100f, 1500f);
            m_MinTurnSpeedProp.floatValue = minTurnSpeed;
            m_MaxTurnSpeedProp.floatValue = maxTurnSpeed;

            m_MaxTurnSpeedProp.floatValue = EditorGUI.IntField(maxRect, (int)m_MaxTurnSpeedProp.floatValue);
        }
    } 
}
