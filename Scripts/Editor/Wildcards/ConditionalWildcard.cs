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
using System.Text.RegularExpressions;

using UnityEngine;

namespace HVUnity.SharpFactory.Wildcards
{
	/// <summary>
	/// Class ConditionalWildcard
	/// 
	/// Removes a section of the template if condition is not met.
	/// Section starts with replacer and ends with replacerEnd.
	/// 
	/// If condition is met only the replacing markers are removed.
	/// </summary>
	public class ConditionalWildcard : AbstractSharpReplaceable
	{
		/*
		 * =========================================================================
		 *  Variables
		 * =========================================================================
		 */

		/// <summary>
		/// End of replacing section
		/// </summary>
		[SerializeField]
		private string replacerEnd;

		/// <summary>
		/// The conditonal flag reference that is used
		/// </summary>
		[SerializeField]
		private ConditionalFlag conditionalFlag;

		/// <summary>
		/// If true one leading "/t" per line is removed 
		/// </summary>
		[SerializeField]
		private bool removeLeadingTab = false;

		/*
		 * =========================================================================
		 *  Functions
		 * =========================================================================
		 */

		public override string process(string scriptPath, string templateContent)
		{
			if( checkCondition() )
			{
				// condition is met just remove the wildcards
				templateContent = templateContent.Replace(replacer, string.Empty);
				templateContent = templateContent.Replace(replacerEnd, string.Empty);

			} else {
				// condition not met remove the section
				templateContent = Regex.Replace(
						templateContent, 
						replacer + ".*?" + replacerEnd, 
						string.Empty,
						RegexOptions.Singleline
					);

				// remove one tab 
				if( removeLeadingTab )
					templateContent = Regex.Replace(templateContent, "(^.*?)(\t)",string.Empty,RegexOptions.Multiline);
			}

			return templateContent;
		}


		private bool checkCondition()
		{
			switch( conditionalFlag )
			{
				case ConditionalFlag.EnableNamespace:
					return SharpFactorySettings.Instance.EnableNamespace;

				case ConditionalFlag.UseFolderStructureAsNamespace:
					return SharpFactorySettings.Instance.UseFolderStructureAsNamespace;
			}

			return false;
		}
	}
}
