using Exortech.NetReflector;
using ThoughtWorks.CruiseControl.Core;

namespace CcNet.Labeller
{
	[ReflectorType("fileSvnRevisionLabeller")]
    public class FileSvnRevisionLabeller : SvnRevisionLabeller
	{
		[ReflectorProperty("file", Required = true)]
		public string File { get; set; }

		/// <summary>
		/// Runs the task, given the specified <see cref="IIntegrationResult"/>, in the specified <see cref="IProject"/>.
		/// </summary>
		/// <param name="result">The label for the current build.</param>
		public void Run(IIntegrationResult result)
		{
		    var label = System.IO.File.ReadAllText(this.File);
            var revision = GetRevision();

		    result.Label = label.Replace("${revision}", revision.ToString());
		}
	}
}
