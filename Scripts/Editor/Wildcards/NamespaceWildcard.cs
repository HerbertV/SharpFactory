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
using System.IO;
using UnityEngine;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Class NamespaceWildcard
	/// 
	/// Unique Wildcard.
	/// 
	/// Replaces the "#NAMESPACE" marker with the prefix or folder structure.
	/// If folder structure is used, anything defined in removeFromPath is stripped from the structure
	/// </summary>
	public class NamespaceWildcard : AbstractSharpReplaceable
	{
		/// <summary>
		/// list of removeables
		/// </summary>
		private static string[] removeFromPath = new string[]{
				"Assets/",
				"Resources/",
				"Scripts/",	
			};
			
		private void Awake()
		{
			// set fixed value
			isUnique = true;
			replacer = "#NAMESPACE#";
		}

		public override string process(string scriptPath, string templateContent)
		{
			if( !SharpFactorySettings.Instance.EnableNamespace )
				return templateContent;

			if( !SharpFactorySettings.Instance.UseFolderStructureAsNamespace )
				return templateContent.Replace(replacer,SharpFactorySettings.Instance.NamespacePrefix);

			scriptPath = Path.GetDirectoryName(scriptPath);

			foreach( string remove in removeFromPath )
				scriptPath = scriptPath.Replace(remove, string.Empty);

			scriptPath = scriptPath.Replace("/", ".");
			
			return templateContent.Replace(replacer,scriptPath);
		}
	}
}
