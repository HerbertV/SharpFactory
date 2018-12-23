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

using HVUnity.SharpFactory.Wildcards;
using HVUnity.Core.Editor;

namespace HVUnity.SharpFactory.GUI
{
	/// <summary>
	/// Class MenuItems
	/// 
	/// Contains all Menu items for SharpFactory
	/// </summary>
	internal static class MenuItems
	{
		/*
		 * =========================================================================
		 *  Constants
		 * =========================================================================
		 */

		/// <summary>
		/// Menu item path base for asset creation
		/// </summary>
		internal const string MENU_ITEM_PATH_CREATE = "Assets/Create/SharpFactory/";

		/// <summary>
		/// Menu item path base for windows
		/// </summary>
		internal const string MENU_ITEM_PATH_WINDOW = "Window/SharpFactory/";


		internal const string MENU_ITEM_PATH_CREATE_WILDCARDS = MENU_ITEM_PATH_CREATE + "Wildcards/";

		/*
		 * =========================================================================
		 *  Window Menu Items
		 * =========================================================================
		 */

		/// <summary>
		/// Menu Item SharpFactory Setup
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_WINDOW + "SharpFactory Setup", false)]
		private static void createSettings()
		{
			// TODO show Setup Window

			SharpFactorySettings.createSingletonInstance();
		}

		/// <summary>
		/// Menu Item Validator SharpFactory Setup
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_WINDOW + "SharpFactory Setup", true)]
		private static bool validateSettings()
		{
			return !SharpFactorySettings.IsAvailable;
		}


		/*
		 * =========================================================================
		 *  Create Asset Menu Items
		 * =========================================================================
		 */

		/// <summary>
		/// Menu Item AuthorWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "AuthorWildcard", false)]
		private static void createAuthorWildcard()
		{
			AbstractSharpWildcard.createAsset<AuthorWildcard>();
		}

		/// <summary>
		/// Menu Item Validator AuthorWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "AuthorWildcard", true)]
		private static bool validateAuthorWildcard()
		{
			if( !SharpFactorySettings.IsAvailable )
				return false;

			return !AbstractSharpWildcard.isUniqueAvailable<AuthorWildcard>();
		}

		/// <summary>
		/// Menu Item ConditionalWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "ConditionalWildcard", false)]
		private static void createConditionalWildcard()
		{
			AbstractSharpWildcard.createAsset<ConditionalWildcard>("New ConditonalWildcard");
		}

		/// <summary>
		/// Menu Item Validator ConditionalWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "ConditionalWildcard", true)]
		private static bool validateConditionalWildcard()
		{
			if( !SharpFactorySettings.IsAvailable )
				return false;

			return true;
		}

		/// <summary>
		/// Menu Item CreationDateWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "CreationDateWildcard", false)]
		private static void createCreationDateWildcard()
		{
			AbstractSharpWildcard.createAsset<CreationDateWildcard>();
		}

		/// <summary>
		/// Menu Item Validator CreationDateWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "CreationDateWildcard", true)]
		private static bool validateCreationDateWildcard()
		{
			if( !SharpFactorySettings.IsAvailable )
				return false;

			return !AbstractSharpWildcard.isUniqueAvailable<CreationDateWildcard>();
		}

		/// <summary>
		/// Menu Item LicenseWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "LicenseWildcard", false)]
		private static void createLicenseWildcard()
		{
			AbstractSharpWildcard.createAsset<LicenseWildcard>();
		}

		/// <summary>
		/// Menu Item Validator LicenseWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "LicenseWildcard", true)]
		private static bool validateLicenseWildcard()
		{
			if( !SharpFactorySettings.IsAvailable )
				return false;

			return !AbstractSharpWildcard.isUniqueAvailable<LicenseWildcard>();
		}

		/// <summary>
		/// Menu Item NamespaceWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "NamespaceWildcard", false)]
		private static void createNamespaceWildcard()
		{
			AbstractSharpWildcard.createAsset<NamespaceWildcard>();
		}

		/// <summary>
		/// Menu Item Validator NamespaceWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "NamespaceWildcard", true)]
		private static bool validateNamespaceWildcard()
		{
			if( !SharpFactorySettings.IsAvailable )
				return false;

			return !AbstractSharpWildcard.isUniqueAvailable<NamespaceWildcard>();
		}

		/// <summary>
		/// Menu Item SnippetWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "SnippetWildcard", false)]
		private static void createSnippetWildcard()
		{
			AbstractSharpWildcard.createAsset<SnippetWildcard>("New SnippetWildcard");
		}

		/// <summary>
		/// Menu Item Validator SnippetWildcard
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE_WILDCARDS + "SnippetWildcard", true)]
		private static bool validateSnippetWildcard()
		{
			if( !SharpFactorySettings.IsAvailable )
				return false;

			return true;
		}

		/// <summary>
		/// Menu Item C# MonoBehaviour
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE + "C# MonoBehaviour")]
		private static void createCSharpMonoBehaviour()
		{
			Debug.Log("Create C# MonoBehaviour");

			TemplateFile template = SharpFactory.findTemplate(TemplateType.MonoBehaviour);

			if( template == null )
				return;

			CreateSharpFileAction endNameEditAction = ScriptableObject.CreateInstance<CreateSharpFileAction>();
			endNameEditAction.scriptIcon = EditorIcons.CSharpBehaviourIcon;

			ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
					0,
					endNameEditAction,
					"NewMonoBehaviour.cs",
					EditorIcons.CSharpBehaviourIcon,
					template.getTemplatePath()
				);
		}

		/// <summary>
		/// Menu Item Validator C# MonoBehaviour 
		/// </summary>
		[MenuItem(MENU_ITEM_PATH_CREATE + "C# MonoBehaviour", true)]
		private static bool validateCSharpMonoBehaviour()
		{
			if( !SharpFactorySettings.IsAvailable )
				return false;

			if( SharpFactory.findTemplate(TemplateType.MonoBehaviour) == null )
				return false;

			return true;
		}
	}
}
