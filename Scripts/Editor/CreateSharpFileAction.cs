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
using HVUnity.Core.Editor;
using System.Reflection;
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
		/// <summary>
		/// Optional icon the script asset show in the project window and inspector
		/// </summary>
		public Texture2D scriptIcon;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="instanceId"></param>
		/// <param name="scriptPath"></param>
		/// <param name="resourceFile"></param>
		public override void Action(int instanceId, string scriptPath, string resourceFile)
		{
			Object obj = SharpFactory.createScriptFromTemplate(scriptPath, resourceFile);
			EditorIcons.injectIcon(obj,scriptIcon);
			ProjectWindowUtil.ShowCreatedAsset(obj);
		}

	}
}
