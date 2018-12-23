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
using System;
using UnityEditor;
using UnityEngine;

namespace HVUnity.SharpFactory
{
	/// <summary>
	/// Enum with supported template types
	/// </summary>
	public enum TemplateType
	{
		Unknown,
		MonoBehaviour,
	}

	/// <summary>
	/// Class TemplateFile
	/// 
	/// Links type of the template with the asset file
	/// used for script templates
	/// </summary>
	[Serializable]
	public class TemplateFile
	{
		/// <summary>
		/// Type of the template
		/// </summary>
		public TemplateType type = TemplateType.Unknown;

		/// <summary>
		/// Linked template TextAsset
		/// </summary>
		public TextAsset textAsset;

		/// <summary>
		/// get asset path for the linked text asset
		/// </summary>
		/// <returns></returns>
		internal string getTemplatePath()
		{
			return AssetDatabase.GetAssetPath(textAsset);
		}

	}
}
