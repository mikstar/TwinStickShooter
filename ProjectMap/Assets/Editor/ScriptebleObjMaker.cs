using UnityEngine;
using System.Collections;
using UnityEditor;

public class ScriptebleObjMaker : MonoBehaviour {

	[MenuItem("Assets/Create/Weapon/TestGun")]
	public static void createTestGun()
	{
		WeaponTestGun asset = ScriptableObject.CreateInstance<WeaponTestGun>();
		
		AssetDatabase.CreateAsset(asset,AssetDatabase.GetAssetPath(Selection.activeObject) + "/NewTestGun.asset");
		AssetDatabase.SaveAssets();
	}

	[MenuItem("Assets/Create/Weapon/RayGun")]
	public static void createRayGun()
	{
		WeaponMachineGun asset = ScriptableObject.CreateInstance<WeaponMachineGun>();
		
		AssetDatabase.CreateAsset(asset,AssetDatabase.GetAssetPath(Selection.activeObject) + "/NewRayGun.asset");
		AssetDatabase.SaveAssets();
	}
}
