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
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace HVUnity.SharpFactory
{
	/// <summary>
	/// Class CreateSharpFileAction
	/// 
	/// Callback action for creating sharp scripts after name edit ended
	/// </summary>
	internal class CreateSharpFileAction : EndNameEditAction
	{
		public override void Action(int instanceId, string pathName, string resourceFile)
		{
			Object obj = SharpFactory.createScriptFromTemplate(pathName, resourceFile);
			ProjectWindowUtil.ShowCreatedAsset(obj);
		}
	}
}
