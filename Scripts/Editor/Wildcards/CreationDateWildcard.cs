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

using UnityEngine;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Class CreationDateWildcard
	/// 
	/// Unique Wildcard.
	/// 
	/// Replaces the "#CREATION_YEAR" marker with the current year.
	/// </summary>
	public class CreationDateWildcard : AbstractSharpReplaceable
	{
		private void Awake()
		{
			// set fixed value
			isUnique = true;
			replacer = "#CREATION_YEAR#";
		}

		public override string process(string scriptPath, string templateContent)
		{
			return templateContent.Replace(replacer, DateTime.Now.ToString("yyyy") );
		}
	}
}
