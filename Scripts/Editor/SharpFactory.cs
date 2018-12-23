
using Microsoft.CSharp;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using UnityEditor;
using UnityEngine;

using HVUnity.Core.Editor;
using HVUnity.SharpFactory.Wildcards;

namespace HVUnity.SharpFactory
{
	/// <summary>
	/// Used for processing <see cref="AbstractSharpWildcard"/> with <see cref="ISharpCondition"/>
	/// </summary>
	public enum ConditionalFlag
	{
		None,
		EnableNamespace,
		UseFolderStructureAsNamespace
	}

	/// <summary>
	/// Class SharpFactory
	/// 
	/// 
	/// </summary>
	public static class SharpFactory
	{
		
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
		/// returns the template for the corresponding type
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		internal static TemplateFile findTemplate(TemplateType type)
		{
			if( SharpFactorySettings.Instance.templates == null 
					|| SharpFactorySettings.Instance.templates.Count == 0 )
				return null;

			foreach( TemplateFile tf in SharpFactorySettings.Instance.templates )
			{
				if( tf.type == type )
					return tf;
			}

			Debug.LogError("No template file defined for " + type.ToString());

			return null;
		}

		/// <summary>
		/// Creates the new script asset
		/// </summary>
		/// <param name="scriptPath"></param>
		/// <param name="templatePath"></param>
		/// <returns></returns>
		internal static Object createScriptFromTemplate(string scriptPath, string templatePath)
		{
			// first create a unique path
			string uniquePath = AssetDatabase.GenerateUniqueAssetPath(scriptPath);

			string baseFile = Path.GetFileNameWithoutExtension(uniquePath);
			string className = normalizeClassName(baseFile);
			
			//read template
			string templateText  = File.ReadAllText(templatePath);
			
			// replace unity default wildcards
			templateText = templateText.Replace("#NOTRIM#", string.Empty);
			templateText = templateText.Replace("#SCRIPTNAME#", className);
			templateText = templateText.Replace("#NAME#", baseFile);

			// replace custom wildcards
			templateText = processWildcards(scriptPath,templateText);

			templateText = setLineEndings(templateText, EditorSettings.lineEndingsForNewScripts);
			
			// write new script
			File.WriteAllText(
					Path.GetFullPath(scriptPath), 
					templateText, 
					new UTF8Encoding(true)
				);

			AssetDatabase.ImportAsset(scriptPath);
			
			return AssetDatabase.LoadAssetAtPath(scriptPath, typeof(Object));
		}

		/// <summary>
		/// Calls all wildcards found in <see cref="SharpFactorySettings"/>
		/// </summary>
		/// <param name="scriptPath"></param>
		/// <param name="templateText"></param>
		/// <returns></returns>
		internal static string processWildcards(string scriptPath, string templateText)
		{
			foreach( AbstractSharpWildcard w in SharpFactorySettings.Instance.wildcards )
			{
				// failsave
				if( w == null )
					continue;

				templateText = w.process(scriptPath, templateText);
			}
			return templateText;
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

	}
}
