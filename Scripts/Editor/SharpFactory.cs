using HVUnity.Core.Editor;
using HVUnity.SharpFactory.Wildcards;
using Microsoft.CSharp;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;


namespace HVUnity.SharpFactory
{
	
	public static class SharpFactory
	{
		
		/*
		 * =========================================================================
		 *  Constants
		 * =========================================================================
		 */
		
		/// <summary>
		/// Menu item path base
		/// </summary>
		private const string MENU_ITEM_PATH = "Assets/Create/SharpFactory/";

		/*
		 * =========================================================================
		 *  Menu Items
		 * =========================================================================
		 */

		[MenuItem(MENU_ITEM_PATH + "C# MonoBehaviour")]
		private static void createCSharpMonoBehaviour()
		{
			Debug.Log("Create C# MonoBehaviour");

			TemplateFile template = findTemplate(TemplateType.MonoBehaviour);

			if( template == null )
				return;
						
			ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
					0,
					ScriptableObject.CreateInstance<CreateSharpFileAction>(),
					"NewMonoBehaviour.cs",
					EditorIcons.CSharpGenericIcon,
					template.getTemplatePath()
				);
		}

		[MenuItem(MENU_ITEM_PATH + "C# MonoBehaviour",true)]
		private static bool checkCSharpMonoBehaviour()
		{
			if( findTemplate(TemplateType.MonoBehaviour) == null )
				return false;

			return true;
		}

		/*
		 * =========================================================================
		 *  Functions
		 * =========================================================================
		 */

		/// <summary>
		/// Creates a valid class name for csharp
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static string normalizeClassName(string filename)
		{
			CSharpCodeProvider codeProvider = new CSharpCodeProvider();
			filename = codeProvider.CreateValidIdentifier(filename);

			return filename;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pathName"></param>
		/// <param name="templatePath"></param>
		/// <returns></returns>
		internal static Object createScriptFromTemplate(string pathName, string templatePath)
		{
			// first create a unique path
			string uniquePath = AssetDatabase.GenerateUniqueAssetPath(pathName);

			string baseFile = Path.GetFileNameWithoutExtension(uniquePath);
			string className = normalizeClassName(baseFile);
			
			//read template
			string templateText  = File.ReadAllText(templatePath);
			
			// replace unity default wildcards
			templateText = templateText.Replace("#NOTRIM#", string.Empty);
			templateText = templateText.Replace("#SCRIPTNAME#", className);
			templateText = templateText.Replace("#NAME#", baseFile);

			// replace custom wildcards
			templateText = replaceWildcards(templateText);

			templateText = setLineEndings(templateText, EditorSettings.lineEndingsForNewScripts);
			
			// write new script
			File.WriteAllText(
					Path.GetFullPath(pathName), 
					templateText, 
					new UTF8Encoding(true)
				);

			AssetDatabase.ImportAsset(pathName);
			return AssetDatabase.LoadAssetAtPath(pathName, typeof(Object));
		}

		/// <summary>
		/// From UnityEditor.ProjectWindowUtil
		/// </summary>
		/// <param name="content"></param>
		/// <param name="lineEndingsMode"></param>
		/// <returns></returns>
		internal static string setLineEndings(string content, LineEndingsMode lineEndingsMode)
		{
			const string windowsLineEndings = "\r\n";
			const string unixLineEndings = "\n";

			string preferredLineEndings;

			switch( lineEndingsMode )
			{
				case LineEndingsMode.OSNative:
					if( Application.platform == RuntimePlatform.WindowsEditor )
						preferredLineEndings = windowsLineEndings;
					else
						preferredLineEndings = unixLineEndings;
					break;
				case LineEndingsMode.Unix:
					preferredLineEndings = unixLineEndings;
					break;
				case LineEndingsMode.Windows:
					preferredLineEndings = windowsLineEndings;
					break;
				default:
					preferredLineEndings = unixLineEndings;
					break;
			}

			content = Regex.Replace(content, @"\r\n?|\n", preferredLineEndings);

			return content;
		}

		internal static TemplateFile findTemplate(TemplateType type)
		{
			foreach( TemplateFile tf in SharpFactorySettings.Instance.templates )
			{
				if( tf.type == type )
					return tf;
			}

			Debug.LogError("No template file defined for " + type.ToString());

			return null;
		}

		internal static string replaceWildcards(string templateText)
		{
			foreach(AbstractSharpWildcard w in SharpFactorySettings.Instance.wildcards )
			{
				if( w == null )
					continue;

				if( w is ConditionalWildcard )
				{
					if( ((ConditionalWildcard)w).conditionalFlag == ConditionalFlags.EnableNamespace ) 
						templateText = w.replace(templateText,SharpFactorySettings.Instance.enableNamespace);

				} else {
					templateText = w.replace(templateText);
				}
			}
			return templateText;
		}

	}
}
