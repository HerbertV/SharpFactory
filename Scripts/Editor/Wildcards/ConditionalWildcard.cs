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
	/// Removes a section of the template if condition is not meet.
	/// Section starts with replacer and ends with replacerEnd.
	/// 
	/// If condition is meet only the wildcards are removed
	/// </summary>
	[CreateAssetMenu(fileName = "NewSnippetWildcard", menuName = "SharpFactory/Wildcards/Create ConditionalWildcard")]
	public class ConditionalWildcard : AbstractSharpWildcard
	{
		/// <summary>
		/// end of section
		/// </summary>
		[SerializeField]
		private string sectionEnd;

		[SerializeField]
		public ConditionalFlags conditionalFlag;

		
		public override string replace(string template, params object[] options)
		{

			if( options == null || options.Length == 0)
				return template;


			Debug.Log("condition: "+ options[0]);

			if( (bool)options[0] )
			{
				// condition is meet just remove the wildcards
				template = template.Replace(replacer, string.Empty);
				template = template.Replace(sectionEnd, string.Empty);

			} else {
				// condition not meet remove the section
				template = Regex.Replace(
						template, 
						replacer + ".*?" + sectionEnd, 
						string.Empty,
						RegexOptions.Singleline
					);

				//template = Regex.Replace(template, "(^.*?)(\t)")

			}
			return template;
		}
	}
}
