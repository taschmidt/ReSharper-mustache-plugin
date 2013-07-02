using System.Collections.Generic;
using JetBrains.Metadata.Utils;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Asp.CustomReferences;
using JetBrains.ReSharper.Psi.Web.Util;
using JetBrains.Util;

namespace ReSharper.Mustache.Plugin
{
    [MvcViewResolver]
    public class MvcViewMustacheResolver : IMvcViewResolver
    {
        private static readonly AssemblyNameInfo NustacheAssembly = new AssemblyNameInfo("Nustache.Core");

        private static readonly Dictionary<MvcViewLocationType, ICollection<string>> DefaultRoutes =
            new Dictionary<MvcViewLocationType, ICollection<string>>
                {
                    {MvcViewLocationType.Unknown, EmptyList<string>.InstanceList},
                    {MvcViewLocationType.AreaMaster, new[] {@"~\Areas\{2}\Views\{1}\{0}.mustache", @"~\Areas\{2}\Views\Shared\{0}.mustache"}},
                    {MvcViewLocationType.AreaPartialView, new[] {@"~\Areas\{2}\Views\{1}\{0}.mustache", @"~\Areas\{2}\Views\Shared\{0}.mustache"}},
                    {MvcViewLocationType.AreaView, new[] {@"~\Areas\{2}\Views\{1}\{0}.mustache", @"~\Areas\{2}\Views\Shared\{0}.mustache"}},
                    {MvcViewLocationType.Master, new[] {@"~\Views\{1}\{0}.mustache", @"~\Views\Shared\{0}.mustache"}},
                    {MvcViewLocationType.PartialView, new[] {@"~\Views\{1}\{0}.mustache", @"~\Views\Shared\{0}.mustache"}},
                    {MvcViewLocationType.View, new[] {@"~\Views\{1}\{0}.mustache", @"~\Views\Shared\{0}.mustache"}}
                };

        public bool IsApplicable(IProject project)
        {
            AssemblyNameInfo assemblyNameInfo;
            return ReferencedAssembliesService.IsProjectReferencingAssemblyByName(project, NustacheAssembly, out assemblyNameInfo);
        }

        public IDictionary<MvcViewLocationType, ICollection<string>> Values
        {
            get { return DefaultRoutes; }
        }
    }
}
