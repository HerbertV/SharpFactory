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
	/// Abstract class AbstractSharpReplaceable
	/// 
	/// Extends the abstract wildcard with a replacer marker
	/// </summary>
	public abstract class AbstractSharpReplaceable : AbstractSharpWildcard
	{
		/// <summary>
		/// The string marker that is replaced
		/// </summary>
		[SerializeField]
		protected string replacer;

	}
}
