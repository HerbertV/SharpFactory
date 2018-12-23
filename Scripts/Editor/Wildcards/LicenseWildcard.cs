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
using UnityEngine;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Class LicenseWildcard
	/// 
	/// Unique Wildcard.
	/// 
	/// Replaces the "#LICENSE_NAME" marker with license name from <see cref="SharpFactorySettings"/>.
	/// </summary>
	public class LicenseWildcard : AbstractSharpReplaceable
	{
		private void Awake()
		{
			// set fixed value
			isUnique = true;
			replacer = "#LICENSE_NAME#";
		}

		public override string process(string scriptPath, string templateContent)
		{
			return templateContent.Replace(replacer, SharpFactorySettings.Instance.LicenseName);
		}
	}
}
