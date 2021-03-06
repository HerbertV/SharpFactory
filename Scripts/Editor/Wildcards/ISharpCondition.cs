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

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Interface ISharpCondition
	/// 
	/// used in combination with <see cref="ConditionalFlag"/>
	/// </summary>
	public interface ISharpCondition
	{
		/// <summary>
		/// checks the if the condition of the associated <see cref="ConditionalFlag"/> is met
		/// </summary>
		/// <returns></returns>
		bool checkCondition();

	}
}
