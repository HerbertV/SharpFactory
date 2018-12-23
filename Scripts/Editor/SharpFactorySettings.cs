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
using UnityEditor;
using System;
using System.IO;

namespace HVUnity.SharpFactory
{
	/// <summary>
	/// Class SharpFactorySettings
	/// </summary>
	//[CreateAssetMenu(fileName ="SharpFactorySettings", menuName ="SharpFactory/Create Settings")]
	public class SharpFactorySettings : SingletonScriptableObject<SharpFactorySettings>
	{
		/*
		 * =========================================================================
		 *  Variables
		 * =========================================================================
		 */

		[Header("Namespace Settings:")]
		/// <summary>
		/// If true namespace for new classes will be used
		/// Is also a  <see cref="ConditionalFlag"/>
		/// </summary>
		[SerializeField]
		private bool enableNamespace = true;

		/// <summary>
		/// If true the namespace is generated from the folder structure
		/// Is also a  <see cref="ConditionalFlag"/>
		/// </summary>
		[SerializeField]
		private bool useFolderStructureAsNamespace = false;

		/// <summary>
		///The default namespace
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
		/// If empty the PlayerSettings company name is used
		/// </summary>
		[Tooltip("If empty, the company name from your Player Settings is used.")]
		[SerializeField]
		private string author;
		
		[Header("References:")]
		/// <summary>
		/// list of all used wildcards for the templates
		/// </summary>
		[SerializeField]
		public List<AbstractSharpWildcard> wildcards;

		/// <summary>
		/// list of used templates
		/// </summary>
		[SerializeField]
		public List<TemplateFile> templates;

		/*
		 * =========================================================================
		 *  Accessors
		 * =========================================================================
		 */

		/// <summary>
		/// If true namespace for new classes will be used
		/// Is also a  <see cref="ConditionalFlag"/>
		/// </summary>
		public bool EnableNamespace
		{
			get{ return enableNamespace; }
		}

		/// <summary>
		/// If true the namespace is generated from the folder structure
		/// Is also a  <see cref="ConditionalFlag"/>
		/// </summary>
		public bool UseFolderStructureAsNamespace
		{
			get{ return useFolderStructureAsNamespace; }
		}

		/// <summary>
		/// The default namespace 
		/// </summary>
		public string NamespacePrefix
		{
			get{ return namespacePrefix; }
		}

		/// <summary>
		/// Name of the License for copyright info
		/// </summary>
		public string LicenseName
		{
			get	{ return licenseName; }
		}

		/// <summary>
		/// Name of the Author for copyright info
		/// </summary>
		public string Author
		{
			get { return author; }
		}

	}
}
