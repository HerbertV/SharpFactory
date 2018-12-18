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
	/// Abstract class AbstractSharpWildcard
	/// </summary>
	public abstract class AbstractSharpWildcard : ScriptableObject
	{
		/// <summary>
		/// the string that is replaced
		/// </summary>
		[SerializeField]
		protected string replacer;

		/// <summary>
		/// replaces the template strings wildcards
		/// </summary>
		/// <param name="template"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public abstract string replace(string template, params object[] options);

	}
}
