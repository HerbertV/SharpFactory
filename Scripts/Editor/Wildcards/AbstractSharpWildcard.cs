/*  __  __      
 * /\ \/\ \  __________   
 * \ \ \_\ \/_______  /\   
 *  \ \  _  \  ____/ / /   
 *   \ \_\ \_\ \ \/ / /    
 *    \/_/\/_/\ \ \/ /     Copyright (c) 2018 Herbert Veitengruber
 *             \ \  /      https://github.com/HerbertV
 *              \_\/
 * -----------------------------------------------------------------------------
 *  Licensed under the MIT License. 
 *  See LICENSE file in the project root for full license information.
 */
using System.Linq;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using HVUnity.Core.Editor;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Abstract class AbstractSharpWildcard
	/// 
	/// Base for processing any kind of replacement or template manipulation
	/// </summary>
	public abstract class AbstractSharpWildcard : ScriptableObject
	{
		/*
		 * =========================================================================
		 *  Variables
		 * =========================================================================
		 */

		/// <summary>
		/// if the wildcard is unique this becomes true.
		/// </summary>
		protected bool isUnique = false;

		
		/*
		 * =========================================================================
		 *  Functions
		 * =========================================================================
		 */

		/// <summary>
		/// Processes the template string and returns it afterwards
		/// </summary>
		/// <param name="scriptPath"></param>
		/// <param name="templateContent"></param>
		/// <returns></returns>
		public abstract string process(string scriptPath, string templateContent);

		/// <summary>
		/// Creates the instance and saves it as asset.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">Custom name, default is type as name</param>
		/// <returns></returns>
		public static T createAsset<T>(string name = null) 
				where T : AbstractSharpWildcard
		{
#if UNITY_EDITOR
			T asset = CreateInstance<T>();

			string path = EditorUtils.selectedProjectWindowPath();

			if( string.IsNullOrEmpty(name) )
				name = typeof(T).Name;

			string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + name + ".asset");

			AssetDatabase.CreateAsset(asset, assetPathAndName);
			AssetDatabase.SaveAssets();
			EditorUtility.FocusProjectWindow();
			Selection.activeObject = asset;

			return asset;
#else
			return default(T);
#endif
		}

		/// <summary>
		/// checks if the wildcard is a unique one and if it exists
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static bool isUniqueAvailable<T>() 
				where T : AbstractSharpWildcard
		{
#if UNITY_EDITOR
			string guid = AssetDatabase.FindAssets("t:" + typeof(T).Name).FirstOrDefault();

			if( string.IsNullOrEmpty(guid) )
				return false;

			T wildcard = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));

			if( wildcard != null )
				return wildcard.isUnique;
#else
			return false;
#endif

			return false;
		}		
	}
}
