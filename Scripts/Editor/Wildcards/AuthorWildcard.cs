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
using UnityEditor;
using UnityEngine;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Class AuthorWildcard
	/// 
	/// Unique Wildcard.
	/// 
	/// Replaces the "#AUTHOR" marker with author from <see cref="SharpFactorySettings"/>
	/// or if empty with company name from <see cref="PlayerSettings"/>.
	/// </summary>
	public class AuthorWildcard : AbstractSharpReplaceable
	{
		private void Awake()
		{
			// set fixed value
			isUnique = true;
			replacer = "#AUTHOR#";
		}

		public override string process(string scriptPath, string templateContent)
		{
			string author = SharpFactorySettings.Instance.Author;

			if( string.IsNullOrEmpty(author) )
				author = PlayerSettings.companyName;

			if( string.IsNullOrEmpty(author) )
				return templateContent;

			return templateContent.Replace(replacer,author);
		}
	}
}
