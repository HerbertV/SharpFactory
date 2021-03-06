﻿/*  __  __      
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
using System.Text.RegularExpressions;

using UnityEngine;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Class SnippetWildcard
	/// 
	/// Replaces the found string with a snippet file
	/// </summary>
	public class SnippetWildcard : AbstractSharpReplaceable
	{
		/// <summary>
		/// TextAsset of the snippet, can be null
		/// </summary>
		[SerializeField]
		[Tooltip("if none, the replacer marker is only removed")]
		private TextAsset textAsset;
		
		public override string process(string scriptPath, string templateContent)
		{
			string snippetText = string.Empty;

			if( textAsset != null )
				snippetText = textAsset.text;

			return Regex.Replace(templateContent, replacer, snippetText);
		}
	}
}
