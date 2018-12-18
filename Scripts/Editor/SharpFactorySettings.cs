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
using System.Collections.Generic;

using UnityEngine;

using HVUnity.Core;
using HVUnity.SharpFactory.Wildcards;

namespace HVUnity.SharpFactory
{
	public enum ConditionalFlags
	{
		None,
		EnableNamespace,
		UseFolderStructureAsNamespace
	}

	/// <summary>
	/// Class SharpFactorySettings
	/// </summary>
	[CreateAssetMenu(fileName ="SharpFactorySettings", menuName ="SharpFactory/Create Settings")]
	public class SharpFactorySettings : SingletonScriptableObject<SharpFactorySettings>
	{
		/// <summary>
		/// if true namespace for new classes will be used
		/// </summary>
		[SerializeField]
		public bool enableNamespace = true;


		[SerializeField]
		private bool useFolderStructureAsNamespace = false;

		/// <summary>
		/// the default namespace
		/// </summary>
		[SerializeField]
		private string namespacePrefix;

		[Header("Copyright Settings:")]
		/// <summary>
		/// 
		/// </summary>
		[SerializeField]
		private string licenseName;

		/// <summary>
		/// if empty the PlayerSettings company name is used
		/// </summary>
		[SerializeField]
		private string author;
		
		[Header("References:")]
		/// <summary>
		/// list of all used wildcards for the templates
		/// </summary>
		public List<AbstractSharpWildcard> wildcards;

		/// <summary>
		/// list of used templates
		/// </summary>
		public List<TemplateFile> templates;


	}
}
