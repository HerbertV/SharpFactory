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
using System.Text.RegularExpressions;

using UnityEngine;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Class SnippetWildcard
	/// 
	/// Replaces the found string with a snippet file
	/// </summary>
	[CreateAssetMenu(fileName = "NewSnippetWildcard", menuName = "SharpFactory/Wildcards/Create SnippetWildcard")]
	public class SnippetWildcard : AbstractSharpWildcard
	{
		/// <summary>
		/// filename of the snippet.
		/// </summary>
		[SerializeField]
		private TextAsset file;

		public override string replace(string template, params object[] options)
		{
			return Regex.Replace(template,replacer,file.text);
		}
	}
}
